using Cashflow.Message;
using Cashflow.Message.Mobile;
using log4net;
using MobiChat.Core;
using MobiChat.Data;
using MobiChat.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MobiChat.Web.Core
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

    private int _smsSent = 0;
    private ServiceSendNumberMap _map = null;
    private Service _service = null;
    private HttpContext _context = null;
    private Customer _customer = null;
    private string _msisdn = string.Empty;
    private MobileOperator _mobileOperator = null;
    private bool _status = false;
    protected bool _hasError = false;
    private string _message = string.Empty;
    private string _errorMessage = string.Empty;
    private string _successMessage = string.Empty;
    private string _messageAllreadySent = string.Empty;
    private Guid _refenceGuid = Guid.NewGuid();
    Cashflow.Client.MobileExtensionClient _cashflowClient = null;
    private ServiceConfigurationEntry _serviceConfigurationEntry = null;

    public MobileOperator MobileOperator { get { return this._mobileOperator; } protected set { this._mobileOperator = value; } }
    public bool Status { get { return this._status; } protected set { this._status = value; } }
    public string Msisnd { get { return this._msisdn; } protected set { this._msisdn = value; } }
    public string Message { get { return this._message; } protected set { this._message = value; } }
    public bool HasError { get { return this._hasError; } }
    protected ServiceSendNumberMap Map { get { return this._map; } }
    protected Service Service { get { return this._service; } }
    protected Cashflow.Client.MobileExtensionClient CashflowClient { get { return this._cashflowClient; } }
    protected string ErrorMessage { get { return this._errorMessage; } }
    protected string SuccessMessage { get { return this._successMessage; } }

    public SendNumberBase(ServiceSendNumberMap map)
    {
      this._map = map;
    }

    public void Initialize(IService service, HttpContext context, string msisnd)
    {
      this._refenceGuid = Guid.NewGuid();
      this._customer = null;
      this._context = context;
      this._service = service.ServiceData;
      this._msisdn = msisnd.Trim();
      this._cashflowClient = new Cashflow.Client.MobileExtensionClient("http://v10.api.cashflow-payment.com/mobile.svc/soap12");
      this._cashflowClient.AttachLogWriter(new CashflowLog());

      if (!this._hasError) this._hasError = this.CheckNumber();
      if (!this._hasError) this._hasError = this.TryParseMobileOperator();
      if (!this._hasError) this._hasError = this.TryGetServiceConfiguration();
      if (!this._hasError) this._hasError = this.Send();
    }
    
    public bool TryGetServiceConfiguration()
    {
      this._serviceConfigurationEntry = MobiContext.Current.Service.GetConfiguration(MobiContext.Current.Service.ServiceData.FallbackCountry, this._mobileOperator);
      if (this._serviceConfigurationEntry == null)
        this._serviceConfigurationEntry = MobiContext.Current.Service.GetConfiguration(MobiContext.Current.Service.ServiceData.FallbackCountry);
      if (this._serviceConfigurationEntry == null)
      {
        Log.Error("SendMessageBase:: ServiceConfiguratioEtnry could not be loaded for " + this._service.Name);
        this.Status = false;
        this.Message = this.ErrorMessage;
        return true;
      }
      
      return false;
    }
    
    //
    public abstract bool TryParseMobileOperator();

    public void SetErrorMessage(string message)
    {
      this._errorMessage = message;
    }

    public void SetSuccessMessage(string message)
    {
      this._successMessage = message;
    }

    public void SetMessageAllreadySent(string message)
    {
      this._messageAllreadySent = message;
    }

    public void SetCustomMessage(string message)
    {
      this.Map.AddCustomMessage(message);
    }

    public virtual bool CheckNumber()
    {
      if (string.IsNullOrEmpty(this.Msisnd))
      {
        this.Status = false;
        this.Message = this.ErrorMessage;
        return true;
      }

      // Test number
      if (this.Msisnd.Equals("33228"))
      {
        this.Status = true;
        this.Message = this.SuccessMessage;
        return true;
      }

      this.Msisnd = this.Msisnd.Replace(" ", string.Empty).Replace("+", string.Empty);

      // check if number is correct
      for (int i = 0; i < this.Msisnd.Length; i++)
        if (!Char.IsNumber(this.Msisnd[i]))
        {
          this.Status = false;
          this.Message = this.ErrorMessage;
          return true;
        }

      return false;
    }

    public object GetRespone(string message)
    {
      ArgumentGroupBase arguments = null; 
      string shortcode = this._serviceConfigurationEntry.ID == 5 ?
        "0" + this._serviceConfigurationEntry.Shortcode : this._serviceConfigurationEntry.Shortcode.ToString();

      if (this._smsSent == 0)
        arguments = new SmsGeneratorArguments() { Keyword = this._serviceConfigurationEntry.Keyword, Shortcode = shortcode };
      else
        arguments = new SmsChatArguments() { Keyword = this._serviceConfigurationEntry.Keyword, Shortcode = shortcode };


      SendSmsRequest smsRequest = new SendSmsRequest(RequestMode.Default,
                                                       this._refenceGuid.ToString(),
                                                       this._service.ServiceConfiguration.PaymentConfiguration.PaymentCredentials.Username,  // username
                                                       this._service.ServiceConfiguration.PaymentConfiguration.PaymentCredentials.Password,  // password
                                                       this._service.ServiceConfiguration.PaymentConfiguration.BehaviorModel.Guid, //bm
                                                       this._service.Product.ExternalProductGuid, //product
                                                       this._service.ServiceConfiguration.PaymentConfiguration.PaymentInterface.ExternalPaymentInterfaceGuid, //interface
                                                       this._service.FallbackCountry.TwoLetterIsoCode,
                                                       this._service.ServiceConfiguration.PaymentConfiguration.PaymentProvider.ExternalPaymentProviderGuid.Value, //provider
                                                       this.MobileOperator.ExternalMobileOperatorID.ToString(),
                                                       this.Msisnd,
                                                       message,
                                                       this._refenceGuid.ToString(), // "send sms ref."
                                                       string.Empty,
                                                       arguments.ToMessageArguments());
      
      Log.Debug("Operator Code: " + smsRequest.OperatorCode);
      return this._cashflowClient.SendSms(smsRequest);
    }

    protected Customer GetCustomer()
    {
      this._customer  = Customer.GetCustomerByMsisdn(this._service, this.Msisnd);
      if (this._customer != null)
        return this._customer;

      this._customer = new Customer(-1,
        Guid.NewGuid(),
        null,
        this._service,
        this._service.FallbackCountry,
        this._service.FallbackLanguage,
        this.MobileOperator,
        this.Msisnd,
        string.Empty,
        DateTime.Now, DateTime.Now);
      this._customer.Insert();

      return this._customer;
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
      List<Data.Message> oldMessages = Data.Message.CreateManager().Load(this.GetCustomer(), Data.MessageType.MT_Free);
      if ( oldMessages.Count > 0 )
      {
        Log.Error(string.Format("SendNumber:: Message is not sent due customer allready received it. (to number='{0}') ({1})", this.Msisnd, oldMessages.ElementAt(0).ID));
        this.Status = false;
        this.Message = this._messageAllreadySent;
        return false;
      }

      try
      {
        foreach (string message in this.Map.SmsMessages)
        {
          SendSmsResponse response = this.GetRespone(message) as SendSmsResponse;
          if (response.Status.Code == MessageStatusCode.Success)
          {
            Log.Info(string.Format("SendNumber:: Message successfuly sent. (message='{0} to number='{1}'", message, this.Msisnd));
            this._smsSent++;
          }
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

        #region # Insert messages in database #

        MobiChat.Web.Data.Message dataMessage = new Message(-1,
          this._refenceGuid,
          null, /// externalID
          this._service,
          this.GetCustomer(),
          this.MobileOperator.Name,
          this.MobileOperator,
          MessageDirection.Outgoing,
          Web.Data.MessageType.MT_Free,
          Web.Data.MessageStatus.Sent,
          this.Map.SmsMessages.FirstOrDefault(),
          this._serviceConfigurationEntry.Shortcode, // shorcode
          this._serviceConfigurationEntry.Keyword, // keyword
          this.TryGetPxid(),
          DateTime.Now, DateTime.Now);
        dataMessage.Insert();

        MTMessage mtMessage = new MTMessage(-1,
          dataMessage,
          this._service.ServiceConfiguration.ExternalID,
          this.Msisnd,
          string.Empty,
          DateTime.Now.ToString(),
          "MOBICHAT_WEB",
          string.Empty, //error
          string.Empty, //reasonCode
          string.Empty, //retry
          this._refenceGuid.ToString(),  //appMsgID
          DateTime.Now, DateTime.Now);
        mtMessage.Insert();
        #endregion

        this.Status = true;
        this.Message = this._successMessage;
        return false;
      }
      catch (Exception e)
      {
        Log.Fatal(string.Format("ISendNumber:: Fatal error on send"), e);
        this.Status = false;
        this.Message = this._errorMessage;
        return true;
      }

    }

  }
}
