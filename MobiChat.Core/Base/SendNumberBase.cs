using Cashflow.Message;
using Cashflow.Message.Mobile;
using log4net;
using MobiChat.Data;
using MobiChat.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MobiChat.Core
{
  public abstract class SendNumberBase : ISendNumber
  {

    #region #logging#

    private static ILog _log = null;

    protected static ILog Log
    {
      get
      {
        if (SendNumberBase._log == null)
          SendNumberBase._log = LogManager.GetLogger(typeof(SendNumberBase));
        return SendNumberBase._log;
      }
    }

    #endregion #logging#

    private ServiceSendNumberMap _map = null;
    private IService _service = null;
    private HttpContext _context = null;
    private string _msisdn = string.Empty;
    private MobileOperator _mobileOperator = null;
    private bool _status = false;
    protected bool _hasError = false;
    private string _message = string.Empty;
    private string _errorMessage = string.Empty;
    private string _successMessage = string.Empty;
    Cashflow.Client.MobileExtensionClient _cashflowClient = null;

    public MobileOperator MobileOperator { get { return this._mobileOperator; } protected set { this._mobileOperator = value; } }
    public bool Status { get { return this._status; } protected set { this._status = value; } }
    public string Msisnd { get { return this._msisdn; } protected set { this._msisdn = value; } }
    public string Message { get { return this._message; } protected set { this._message = value; } }
    public bool HasError { get { return this._hasError; } }
    protected ServiceSendNumberMap Map { get { return this._map; } }
    protected IService Service { get { return this._service; } }
    protected Cashflow.Client.MobileExtensionClient CashflowClient { get { return this._cashflowClient; } }
    protected string ErrorMessage { get { return this._errorMessage; } }
    protected string SuccessMessage { get { return this._successMessage; } }

    public SendNumberBase(ServiceSendNumberMap map)
    {
      this._map = map;
    }

    public void Initialize(IService service, HttpContext context, string msisnd)
    {
      this._context = context;
      this._service = service;
      this._msisdn = msisnd;
      this._cashflowClient = new Cashflow.Client.MobileExtensionClient("http://v10.api.cashflow-payment.com/mobile.svc/soap12");

      this._hasError = this.CheckNumber();
      if (!this._hasError)
        this._hasError = this.TryParseMobileOperator();
      if (!this._hasError)
        this._hasError = this.Send();
    }

    public abstract bool CheckNumber();
    public abstract bool TryParseMobileOperator();

    public void SetErrorMessage(string message)
    {
      this._errorMessage = message;
    }

    public void SetSuccessMessage(string message)
    {
      this._successMessage = message;
    }

    public SendSmsResponse GetRespone(string message)
    {
      SendSmsRequest smsRequest = new SendSmsRequest(RequestMode.Default,
                                                       string.Empty,
                                                       this._service.ServiceData.ServiceConfiguration.PaymentConfiguration.PaymentCredentials.Username,  // username
                                                       this._service.ServiceData.ServiceConfiguration.PaymentConfiguration.PaymentCredentials.Password,  // password
                                                       this._service.ServiceData.ServiceConfiguration.PaymentConfiguration.BehaviorModel.Guid, //bm
                                                       this._service.ServiceData.Product.ExternalProductGuid, //product
                                                       this._service.ServiceData.ServiceConfiguration.PaymentConfiguration.PaymentInterface.ExternalPaymentInterfaceGuid, //interface
                                                       this._service.ServiceData.FallbackCountry.TwoLetterIsoCode,
                                                       this._service.ServiceData.ServiceConfiguration.PaymentConfiguration.PaymentProvider.ExternalPaymentProviderGuid.Value, //provider
                                                       this.MobileOperator.ExternalMobileOperatorID.ToString(),
                                                       this.Msisnd,
                                                       message,
                                                       Guid.NewGuid().ToString(), // "send sms ref."
                                                       string.Empty,
                                                       null);
      return this._cashflowClient.SendSms(smsRequest);
    }

    protected Customer GetCustomer()
    {
      Customer customer = Customer.CreateManager().Load(this._service.ServiceData, this.Msisnd, CustomerIdentifier.Msisdn).FirstOrDefault();
      if (customer != null)
        return customer;

      customer = new Customer(-1,
        Guid.NewGuid(),
        null,
        this._service.ServiceData,
        this._service.ServiceData.FallbackCountry,
        this._service.ServiceData.FallbackLanguage,
        this.MobileOperator,
        this.Msisnd,
        string.Empty,
        DateTime.Now, DateTime.Now);
      customer.Insert();

      return customer;
    }

    protected int? TryGetPxid()
    {
      string pxidString = this._context.Request["pxid"];
      int pxid = -1;
      if (Int32.TryParse(pxidString, out pxid))
        return pxid;
      return null;
    }

    public virtual bool Send()
    {
      try
      {
        foreach (string message in this.Map.SmsMessages)
        {
          SendSmsResponse response = this.GetRespone(message);
          if (response.Status.Code == MessageStatusCode.Success)
            Log.Info(string.Format("SendNumber:: Message successfuly sent. (message='{0} to number='{1}'", message, this.Msisnd));
          else
          {
            Log.Error(string.Format("ISendNumber:: Cashflow returned us error on first message (SubCode='{0}', Message='{1}'",
              response.Status.SubCode.ToString(),
              response.Status.Message));

            this.Status = false;
            this.Message = this._errorMessage;
            return true;
          }
        }

        MobiChat.Web.Data.Message dataMessage = new Message(-1,
          null, /// externalID
          this._service.ServiceData,
          this.GetCustomer(),
          this.MobileOperator.Name,
          this.MobileOperator,
          MessageDirection.Outcoming,
          Web.Data.MessageType.MT_Free,
          Web.Data.MessageStatus.Sent,
          this.Map.SmsMessages.FirstOrDefault(),
          null, // shorcode
          string.Empty, // keyword
          this.TryGetPxid(),
          DateTime.Now, DateTime.Now);
        dataMessage.Insert();

        this.Status = true;
        this.Message = this._successMessage;
        return false;
      }
      catch(Exception e)
      {
        Log.Fatal(string.Format("ISendNumber:: Fatal error on send"), e);
        this.Status = false;
        this.Message = this._errorMessage;
        return true;
      }

    }
  }
}
