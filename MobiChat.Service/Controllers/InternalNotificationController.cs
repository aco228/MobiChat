using Cashflow.Message;
using Cashflow.Message.Mobile;
using log4net;
using MobiChat.Data;
using MobiChat.Service.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobiChat.Service.Controllers
{
  public class InternalNotificationController : Controller
  {

    #region #logging#

    private static ILog _log = null;

    protected static ILog Log
    {
      get
      {
        if (InternalNotificationController._log == null)
          InternalNotificationController._log = LogManager.GetLogger(typeof(InternalNotificationController));
        return InternalNotificationController._log;
      }
    }

    #endregion #logging#


    public ActionResult ShortMessageRequest(string requestGuid)
    {

      // TODO: do some security check (domain, ip) of the sender

      Guid guid = Guid.Empty;
      if(!Guid.TryParse(requestGuid, out guid))
      {
        Log.Error(String.Format("Couldn't parse short message guid with request guid : " + requestGuid));
        this.Response.StatusCode = 503;
        this.Response.StatusDescription = "RequestGuid could not be parsed";
        return null;
      }

      MobiChat.Data.ShortMessageRequest shortMessageRequest = MobiChat.Data.ShortMessageRequest.CreateManager().Load(guid);
      if(shortMessageRequest == null)
      {       
        Log.Error(string.Format("Short message request couldn't be loaded where guid: {0}", guid));
        this.Response.StatusCode = 503;
        this.Response.StatusDescription = "RequestGuid does not exist";
        return null;
      }

      if(shortMessageRequest.ShortMessage.ShortMessageStatus == Data.ShortMessageStatus.Sent)
      {
        Log.Error("Short message has been already sent");
        this.Response.StatusCode = 503;
        this.Response.StatusDescription = "ShortMessage is already sent";
        return null;
      }

      MessageArgument[] arguments = new MessageArgument[] 
      {
        new MessageArgument("smschatargs_content", shortMessageRequest.ShortMessage.Text),
        new MessageArgument("smschatargs_keyword", shortMessageRequest.ShortMessage.Keyword),
        new MessageArgument("smschatargs_shortcode", shortMessageRequest.ShortMessage.Shortcode.ToString()),
        new MessageArgument("smschatargs_customer", shortMessageRequest.ShortMessage.Customer.Guid.ToString())
      };

      ServiceConfiguration serviceConfiguration = ServiceConfiguration.CreateManager().Load(shortMessageRequest.ShortMessage.Service.ServiceConfiguration.ID);

      // TODO: remove url to config
      Cashflow.Client.MobileExtensionClient client = new Cashflow.Client.MobileExtensionClient("http://v1.0.api.cashflow.dev.sentiware.local/mobile.svc/soap12");

      SendShortMessageRequest sendShortMessageRequest = new SendShortMessageRequest(
        RequestMode.Synchronous,
        shortMessageRequest.Guid.ToString(),
        serviceConfiguration.PaymentConfiguration.PaymentCredentials.Username,  // username
        serviceConfiguration.PaymentConfiguration.PaymentCredentials.Password,  // password
        shortMessageRequest.ShortMessage.Customer.Guid,
        shortMessageRequest.ShortMessage.Text,
        shortMessageRequest.Guid.ToString(),
        "",
        arguments);

      Log.Info("SendShortMessageRequest sent with referenceID: " + shortMessageRequest.Guid.ToString());

      SendShortMessageResponse response = client.SendShortMessage(sendShortMessageRequest);

      if(response.Status.Code != MessageStatusCode.Success)
      {
        
        Log.Error("Message Status Code is not Success");
        this.Response.StatusCode = 503;
        this.Response.StatusDescription = "SendShortMessageResponse is not success";
        return null;
      }
      else if(response.Status.Code == MessageStatusCode.Success)
        Code.Report.Call(string.Format("http://{0}/notification/sent/{1}", shortMessageRequest.ShortMessage.Service.Name, shortMessageRequest.Guid.ToString()));
      
      shortMessageRequest.ShortMessage.ShortMessageStatus = ShortMessageStatus.Sent;
    
      Log.Info("Short Message Status is Success");
      this.Response.StatusCode = 200;
      this.Response.StatusDescription = "Success";
      return null;
    }

  }
}