using Cashflow.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cashflow.Message.Mobile;
using Cashflow.Message.Data;
using MobiChat.Data;
using Cashflow.Message;
using log4net;
using MobiChat.Service.Code;

namespace MobiChat.Service.Handlers
{
  public class ReceiveShortMessageNotificationHandler : NotificationHandlerBase
  {

    #region #logging#

    private static ILog _log = null;

    protected static ILog Log
    {
      get
      {
        if (ReceiveShortMessageNotificationHandler._log == null)
          ReceiveShortMessageNotificationHandler._log = LogManager.GetLogger(typeof(ReceiveShortMessageNotificationHandler));
        return ReceiveShortMessageNotificationHandler._log;
      }
    }

    #endregion #logging#

    // SUMMARY: Here we are receiving message that customer sent to us
    /*
        - Check if we can parse shortcode
        - Check if we can find ServiceConfigurationEntry
        - Check if we have Customer, if not, create one
        - We create ShorMessage
          -ShortMessage.Guid '{0}' proccessed!
    */

    protected override void ProcessReceiveShortMessageNotification(ReceiveShortMessageNotification notification)
    {
      base.ProcessReceiveShortMessageNotification(notification);

      try
      {
        ActionContext actionContext = null;
        MobiChat.Data.MobileOperator mobileOperator = null;
        MobiChat.Data.Service service = null;
        MobiChat.Data.Customer customer = null;
        Country country = null;

        Log.Info(string.Format("ShortMessage.ExternalGuid '{0}' arrived!", notification.ShortMessage.ShortMessageID.Value));

        if (notification.ShortMessage.Operator.HasValue)
          mobileOperator = MobiChat.Data.MobileOperator.CreateManager().Load(notification.ShortMessage.Operator.Value, IDType.External);
        country = mobileOperator != null ? mobileOperator.Country : null;

        int shortcode = -1;
        if (!Int32.TryParse(notification.ShortMessage.Shortcode, out shortcode))
        {
          Log.Error(string.Format("Shortcode could not be parsed (Shortcode={0})", notification.ShortMessage.Shortcode));
          return;
        }

        ServiceConfigurationEntry sce = ServiceConfigurationEntry.CreateManager().Load(notification.ShortMessage.Keyword, shortcode, country);
        if (sce == null)
        {
          Log.Error(string.Format("ServiceConfigurationEntry could not be loaded. ( keyword={0}, shortcode={1}, country={2} )",
            notification.ShortMessage.Keyword,
            shortcode,
            country != null ? country.TwoLetterIsoCode : "NULL"));

          return;
        }

        service = MobiChat.Data.Service.CreateManager().Load(sce.ServiceConfiguration);
        if (service == null)
        {
          Log.Error(string.Format("Service could not be loaded by ServiceConfiguration={0}", sce.ServiceConfiguration.ID));
          return;
        }

        Guid externalCustomerGuid = Guid.Empty;
        string notificationCustomerGuid = (from ms in notification.Arguments where ms.Key.Equals("customer") select ms.Value).FirstOrDefault().ToString();
        if (!Guid.TryParse(notificationCustomerGuid, out externalCustomerGuid))
        {
          Log.Error(string.Format("ExternalCustomerGuid could not be parsed. ExternalCustomerGuid={0}",
            (from ms in notification.Arguments where ms.Key.Equals("customer") select ms.Key).ToString()));
          return;
        }

        country = service.FallbackCountry;
        customer = this.GetCustomer(externalCustomerGuid, service, country, mobileOperator, notification.ShortMessage.Msisdn);

        if(!notification.ShortMessage.ShortMessageID.HasValue)
        {
          Log.Error(string.Format("Notification does not contain ShortMessageID"));
          return;
        }

        MobiChat.Data.ShortMessage shortMessage = MobiChat.Data.ShortMessage.CreateManager().Load(notification.ShortMessage.ShortMessageID.Value);
        if(shortMessage != null)
        {
          Log.Error(string.Format("ShortMessage with guid:'{0}' allready exists", notification.ShortMessage.ShortMessageID.Value));
          return;
        }

        shortMessage = new MobiChat.Data.ShortMessage(-1,
          notification.ShortMessage.ShortMessageID.Value,
          actionContext,
          service,
          mobileOperator,
          customer,
          ShortMessageDirection.Incoming,
          ShortMessageStatus.Received,
          notification.ShortMessage.Text,
          shortcode,
          notification.ShortMessage.Keyword,
          DateTime.Now, DateTime.Now);
        shortMessage.Insert();

        Log.Info(string.Format("ShortMessage.Guid '{0}' proccessed!", shortMessage.Guid));

        List<CallbackReport> reports = CallbackReport.CreateManager().Load(CallbackNotificationType.ReceiveShortMessageNotification);
        foreach (CallbackReport report in reports)
          Code.Report.Call(report.Url.Replace("{data}", shortMessage.Guid.ToString()));
        Code.Report.Call(string.Format("http://{0}/notification/received/{1}", service.Name, shortMessage.Guid.ToString()));
      }
      catch (Exception e)
      {
        Log.Fatal(string.Format("ProcessReceiveShortMessageNotification FATAL!"), e);
      }
    }

    private MobiChat.Data.Customer GetCustomer(Guid externalCustomerGuid, MobiChat.Data.Service service, Country country, MobiChat.Data.MobileOperator mobileOperator, string msisdn)
    {
      MobiChat.Data.Customer customer = MobiChat.Data.Customer.CreateManager().Load(externalCustomerGuid);
      if (customer == null)
      {
        User user = new User(-1,
          Guid.NewGuid(),
          UserType.CreateManager().Load(1),
          UserStatus.Active,
          string.Empty,
          new byte[] { 0 },
          DateTime.Now, DateTime.Now);
        user.Insert();

        customer = new MobiChat.Data.Customer(-1,
          externalCustomerGuid,
          user,
          service,
          country,
          country.Language,
          mobileOperator,
          msisdn,
          string.Empty,
          DateTime.Now, DateTime.Now);
        customer.Insert();
      }

      return customer;
    }

  }
}