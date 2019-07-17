using Cashflow.Message;
using Cashflow.Message.Mobile;
using log4net;
using MobiChat.Core;
using MobiChat.Data;
using MobiChat.Web.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MobiChat.Statistics.Controllers
{
  public class NotificationController : Controller
  {

    #region #logging#

    private static ILog _log = null;

    protected static ILog Log
    {
      get
      {
        if (NotificationController._log == null)
          NotificationController._log = LogManager.GetLogger(typeof(NotificationController));
        return NotificationController._log;
      }
    }

    #endregion #logging#

    private Customer _lastInsertedCustomer = null;
    private Service _service = null;

    public ActionResult MT_Handle()
    {
      #region # Get data from QueryString #

      string app_id = Request.QueryString["app-id"];
      string to = Request.QueryString["to"];
      string msg = Request.QueryString["msg"];
      string time = Request.QueryString["time"];
      string state = Request.QueryString["state"];
      string error = Request.QueryString["error"];
      string reason = Request.QueryString["reason"];
      string retry = Request.QueryString["retry"];
      string app_msg_id = Request.QueryString["app-msg-id"];

      if (string.IsNullOrEmpty(app_id))
      {
        Log.Error("NOTIFICATION_MT:: app-id is not set!");
        return new HttpStatusCodeResult(HttpStatusCode.Ambiguous);
      }

      Service service = GetServiceByAppID(app_id);
      if (service == null)
      {
        Log.Error(string.Format("NOTIFICATION_MT:: Service could not be loaded by app_id='{0}'", app_id));
        return new HttpStatusCodeResult(HttpStatusCode.Ambiguous);
      }

      #endregion

      int? _trackingID = this.TryPxidReportFromPreviousMessage(this.TryFindCustomer(service, to, null));

      #region # Insert/Update messages in database #

      MobiChat.Web.Data.Message message = null;
      MobiChat.Web.Data.MessageStatus messageStatus = Web.Data.MessageStatus.Delivered;
      Guid messageReference = Guid.Empty;

      switch(state)
      {
        case "DELIVRD":
          messageStatus = Web.Data.MessageStatus.Delivered;
          if (Guid.TryParse(app_msg_id, out messageReference))
            message = Message.CreateManager().Load(messageReference);
          break;
        case "UNDELIV":
        case "EXPIRED":
        case "REJECTED":
          messageStatus = Web.Data.MessageStatus.Not_delivered;
          if (Guid.TryParse(app_msg_id, out messageReference))
            message = Message.CreateManager().Load(messageReference);
          break;
      }

      if(message == null)
      {
        //messageStatus = (string.IsNullOrEmpty(error)) ? Web.Data.MessageStatus.Not_delivered : Web.Data.MessageStatus.Delivered;
        //message = new Message(-1,
        //  Guid.NewGuid(),
        //  this.TryParseInt(app_msg_id),
        //  service,
        //  this.TryFindCustomer(service, to, null),
        //  string.Empty, // operator string
        //  null, // mobileOperator
        //  MobiChat.Web.Data.MessageDirection.Outgoing,
        //  MobiChat.Web.Data.MessageType.MT,
        //  messageStatus,
        //  string.Empty, //text
        //  null, //shortcode,
        //  string.Empty, // keyword
        //  _trackingID,  // trackingID
        //  DateTime.Now, DateTime.Now);
        //message.Insert();
      }

      message.MessageStatus = messageStatus;
      message.Update();

      MTMessage mtMessage = new MTMessage(-1, message, app_id, to, msg, time, state, error, reason, retry, app_msg_id, DateTime.Now, DateTime.Now);
      mtMessage.Insert();
      #endregion

      Log.Info(string.Format("NOTIFICATION_MT:: Success messageID='{0}', mtMessageID={1}", message.ID, mtMessage.ID));
      return new HttpStatusCodeResult(HttpStatusCode.OK);
    }

    public ActionResult MO_Handle()
    {
      #region # Get data from QueryString #

      string app_id = Request.QueryString["app-id"];
      string from = Request.QueryString["from"];
      string mobileOperator = Request.QueryString["operator"];
      string to = Request.QueryString["to"];
      string keyword = Request.QueryString["keyword"];
      string tariff = Request.QueryString["tariff"];
      string messageText = Request.QueryString["message"];
      string sms_id = Request.QueryString["sms-id"];

      if (string.IsNullOrEmpty(app_id))
      {
        Log.Error("NOTIFICATION_MO:: app-id is not set!");
        return new HttpStatusCodeResult(HttpStatusCode.Ambiguous);
      }

      Service service = GetServiceByAppID(app_id);
      if (service == null)
      {
        Log.Error(string.Format("NOTIFICATION_MO:: Service could not be loaded by app_id='{0}'", app_id));
        return new HttpStatusCodeResult(HttpStatusCode.Ambiguous);
      }

      #endregion

      MobileOperator _mobileOperator = this.TryParseMobileOperator(mobileOperator);
      int? _trackingID = this.TryPxidReportFromCurrentMessage(messageText);
      if(_trackingID == null)
        _trackingID = this.TryPxidReportFromPreviousMessage(this.TryFindCustomer(service, from, _mobileOperator));
      if(_trackingID != null)
        Report.SendReport("pxid", _trackingID, string.Empty);

      #region # Insert messages in database #
      Message message = new Message(-1,
        Guid.NewGuid(),
        TryParseInt(sms_id),
        service,
        TryFindCustomer(service, from, _mobileOperator),
        mobileOperator, // mobileOperatorName
        _mobileOperator,
        MessageDirection.Incoming,
        MobiChat.Web.Data.MessageType.MO,
        MobiChat.Web.Data.MessageStatus.Received,
        messageText,
        null, // shortcode
        keyword, // keyword
        _trackingID, // trackingID
        DateTime.Now, DateTime.Now);
      message.Insert();

      MOMessage moMessage = new MOMessage(-1, message, app_id, from, mobileOperator, to, keyword, tariff, messageText, sms_id, DateTime.Now, DateTime.Now);
      moMessage.Insert();
      #endregion

      Message lastWelcomeMessage = Message.CreateManager().Load(this._lastInsertedCustomer, Web.Data.MessageType.MT_Free).FirstOrDefault();
      if (lastWelcomeMessage == null)
        this.SendWelcomeMessage(message);
      else
        Log.Info(string.Format("NOTIFICATION_MO:: Welcome message not sent becase this custome allready received welcome message (customerID:" + this._lastInsertedCustomer.ID + ")"));

      Log.Info(string.Format("NOTIFICATION_MO:: Success messageID='{0}', moMessageID={1}", message.ID, moMessage.ID));
      return new HttpStatusCodeResult(HttpStatusCode.OK);
    }




    // SUMMARY Try to find Service by appID (appID is located in ServiceConfiguration as ExternalID)
    public Service GetServiceByAppID(string appID)
    {
      // TODO: delete after Laszlo response
      if (appID.Equals("108329"))
        return Service.CreateManager().Load(2);

      ServiceConfiguration serviceConfiguration = ServiceConfiguration.CreateManager().Load(appID);
      if (serviceConfiguration == null)
      {
        Log.Error(string.Format("NOTIFICATION_MO/MT:: Could not load ServiceConfiguration by AppID={0}", appID));
        return null;
      }

      Service service = Service.CreateManager().Load(serviceConfiguration);
      if (service == null)
      {
        Log.Error(string.Format("NOTIFICATION_MO/MT:: Could not load Service for ServiceConfiguration={0}", serviceConfiguration.ID));
        return null;
      }

      this._service = service;
      return service;
    }

    // SUMMARY: Create int? from string
    public int? TryParseInt(string value)
    {
      int result = -1;
      if (!Int32.TryParse(value, out result))
        return null;
      return result;
    }

    // SUMMARY: Try to find customer by sevrice and Msisnd (if there is none, create one)
    public Customer TryFindCustomer(Service service, string msisnd, MobileOperator mobileOperator)
    {
      if (this._lastInsertedCustomer != null)
        return this._lastInsertedCustomer;

      if (mobileOperator == null)
        mobileOperator = this.TryParseMobileOperatorByMsisdn(msisnd);

      Customer customer = Customer.CreateManager().Load(service, msisnd, CustomerIdentifier.Msisdn).FirstOrDefault();
      if (customer == null)
      {
        customer = new Customer(-1,
          Guid.NewGuid(),
          null,
          service,
          service.FallbackCountry,
          service.FallbackLanguage,
          mobileOperator, // mobileOperator
          msisnd,
          string.Empty, // encryptedMsisnd
          DateTime.Now, DateTime.Now);
        customer.Insert();
      }

      this._lastInsertedCustomer = customer;
      return customer;
    }

    // SUMMARY: Try to parse MobileOperator by name (Dimoco)
    public MobileOperator TryParseMobileOperator(string name)
    {
      name = name.Trim();
      switch(name)
      {
        #region # CZ Operators #
        case "CZ_EUROTEL":
        case "CZ_O2": return MobileOperator.CreateManager().Load(49);
        case "CZ_TMOBILE":
        case "CZ_T-MOBILE": return MobileOperator.CreateManager().Load(50);
        case "CZ_OSKAR":
        case "CZ_VODAFONE": return MobileOperator.CreateManager().Load(53);
        #endregion
        #region # AT Operators #
        // 
        #endregion
        default: return null;
      }
    }

    // SUMMARY: Try to parse Msisdn by msisnd
    public MobileOperator TryParseMobileOperatorByMsisdn(string msisnd)
    {
      #region # CZ Numbers #
      if (this._service.FallbackCountry.TwoLetterIsoCode.Equals("CZ"))
      {

        // TMObile
        if (msisnd.StartsWith("42073"))
          return MobileOperator.CreateManager().Load(50);
        // O2
        else if (msisnd.StartsWith("42072") || msisnd.StartsWith("42070"))
          return MobileOperator.CreateManager().Load(49);
        // VODAFONE
        else if (msisnd.StartsWith("42077"))
          return MobileOperator.CreateManager().Load(53);
        // Ufone
        else if (msisnd.StartsWith("42079"))
          return MobileOperator.CreateManager().Load(52);

      }
      #endregion
      return null;
    }

    // SUMMARY: Send Welcome message from ISendMessage manager for specific Service
    public void SendWelcomeMessage(Message message)
    {
      ServiceSendNumberMap serviceSendNumberMap = ServiceSendNumberMap.CreateManager().Load(message.Service).FirstOrDefault();
      if(serviceSendNumberMap == null)
      {
        Log.Error("NOTIFICATION_MOMT:: ServiceSendNumberMap could not be loaded by ServiceID:" + message.Service.ID);
        return;
      }

      if(message.MobileOperator == null)
      {
        Log.Error("NOTIFICATION_MOMT:: MobileOperator is null for number:" + message.Customer.Msisdn);
        return;
      }

      try
      {
        string smsMessage = serviceSendNumberMap.SmsMessages.FirstOrDefault();

        SendSmsResponse response = null;
        Guid messageReference = Guid.NewGuid();

        #region # Get cashflow SendSmsResponse #

        SendSmsRequest smsRequest = new SendSmsRequest(RequestMode.Default,
                                                       messageReference.ToString(),
                                                       message.Service.ServiceConfiguration.PaymentConfiguration.PaymentCredentials.Username,  // username
                                                       message.Service.ServiceConfiguration.PaymentConfiguration.PaymentCredentials.Password,  // password
                                                       message.Service.ServiceConfiguration.PaymentConfiguration.BehaviorModel.Guid, //bm
                                                       message.Service.Product.ExternalProductGuid, //product
                                                       message.Service.ServiceConfiguration.PaymentConfiguration.PaymentInterface.ExternalPaymentInterfaceGuid, //interface
                                                       message.Service.FallbackCountry.TwoLetterIsoCode,
                                                       message.Service.ServiceConfiguration.PaymentConfiguration.PaymentProvider.ExternalPaymentProviderGuid.Value, //provider
                                                       message.MobileOperator.ExternalMobileOperatorID.ToString(),
                                                       message.Customer.Msisdn,
                                                       smsMessage,
                                                       messageReference.ToString(), // "send sms ref."
                                                       string.Empty,
                                                       null);
        response = (new Cashflow.Client.MobileExtensionClient("http://v10.api.cashflow-payment.com/mobile.svc/soap12")).SendSms(smsRequest);

        #endregion

        if (response.Status.Code == MessageStatusCode.Success)
        {
          Log.Info(string.Format("NOTIFICATION_MOMT::SendNumber:: Message successfuly sent. (message='{0} to number='{1}'", smsMessage, message.Customer.Msisdn));
          #region # Insert messages in database #
          MobiChat.Web.Data.Message dataMessage = new Message(-1,
            messageReference,
            null, /// externalID
            message.Service,
            message.Customer,
            message.MobileOperator.Name,
            message.Customer.MobileOperator,
            MessageDirection.Outgoing,
            Web.Data.MessageType.MT_Free,
            Web.Data.MessageStatus.Sent,
            smsMessage,
            null, // shorcode
            string.Empty, // keyword
            message.TrackingID, // pxid
            DateTime.Now, DateTime.Now);
          dataMessage.Insert();

          MTMessage mtMessage = new MTMessage(-1,
            dataMessage,
            message.Service.ServiceConfiguration.ExternalID,
            message.Customer.Msisdn,
            string.Empty, // msgID
            DateTime.Now.ToString(),
            "MOBICHAT_NOTIFICATION",
            string.Empty, //error
            string.Empty, //reasonCode
            string.Empty, //retry
            string.Empty,  //appMsgID
            DateTime.Now, DateTime.Now);
          mtMessage.Insert();
          #endregion
        }
        else
        {
          Log.Error(string.Format("NOTIFICATION_MOMT::SendWelcomeMessage - Cashlfow returned us error (SubCode='{0}', Message='{1}'",
              response.Status.SubCode.ToString(),
              response.Status.Message));
        }
      }
      catch (Exception e)
      {
        Log.Error(string.Format("NOTIFICATION_MOMT::SendWelcomeMessage - FATAL", e));
      }
    }
    
    // SUMMARY: Try to find PXID from current message
    public int? TryPxidReportFromCurrentMessage(string textMessage)
    {
      string[] split = textMessage.Split('/');
      if (split.Length == 0)
        return null;

      string numberSplit = split[split.Length - 1];
      string number = "";

      foreach (char n in numberSplit)
        if (char.IsNumber(n))
          number += n;
        else
          break;

      int pxid = -1;
      if (!Int32.TryParse(number, out pxid))
        return null;

      return pxid;
    }

    // SUMMARY: Try to find PXID from previous messages from this customer
    public int? TryPxidReportFromPreviousMessage(Customer customer)
    {
      if (customer == null)
        return null;

      MobiChat.Web.Data.Message message = Message.CreateManager().Load(customer, MobiChat.Web.Data.MessageType.MT_Free).FirstOrDefault();
      if (message != null && message.TrackingID.HasValue)
        return message.TrackingID;

      return null;
    }

  }
}