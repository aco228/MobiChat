using Cashflow.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cashflow.Message;
using MobiChat.Data;
using log4net;
using MobiChat.Service.Code;
using MobiChat.Service.Core;

namespace MobiChat.Service.Handlers
{
  public class ChargePurchaseNotificationHandler : NotificationHandlerBase
  {

    #region #logging#

    private static ILog _log = null;

    protected static ILog Log
    {
      get
      {
        if (ChargePurchaseNotificationHandler._log == null)
          ChargePurchaseNotificationHandler._log = LogManager.GetLogger(typeof(ChargePurchaseNotificationHandler));
        return ChargePurchaseNotificationHandler._log;
      }
    }

    #endregion #logging#

    // SUMMARY: 
    /*
        - Check if there is shortMessage
        - Check if we have Customer
        - We create Transaction
          -ShortMessage.Guid '{0}' proccessed!
    */

    protected override void ProcessChargePurchase(ChargePurchaseNotification notification)
    {
      base.ProcessChargePurchase(notification);

      try
      {
        ShortMessage shortMessage = null;
        Log.Info(string.Format("ChargePurchaseNotification '{0}' arrived!", notification.ReferenceID));
        
        Guid externalShortMessageGuid = Guid.Empty;
        MessageArgument shortMessageGuidArgument = (from ms in notification.Arguments where ms.Key.Equals("shortMessageGuid") select ms).FirstOrDefault();

        if(shortMessageGuidArgument == null)
        {
          Log.Error(string.Format("There is no 'shortMessageGuid' argument in notification"));
          return;
        }

        string shortMessageGuidString = shortMessageGuidArgument.Value.ToString();
        if (!Guid.TryParse(shortMessageGuidString, out externalShortMessageGuid))
        {
          Log.Error(string.Format("Could not parse 'shorMessageGuid' from notificaiton ('{0}')", shortMessageGuidString));
          return;
        }

        shortMessage = ShortMessage.CreateManager().Load(externalShortMessageGuid);

        if (shortMessage == null)
        {
          Log.Error(String.Format("Couldn't find short message where externalShortMessageGuid is {0}", externalShortMessageGuid.ToString()));
          return;
        }

        if (shortMessage.ShortMessageStatus == ShortMessageStatus.Sent)
        {
          shortMessage.ShortMessageStatus = ShortMessageStatus.Delivered;
          shortMessage.Update();
        }

        MobiChat.Data.Customer customer = MobiChat.Data.Customer.CreateManager().Load(notification.Transaction.CustomerID);
        if (customer == null)
        {
          Log.Error(String.Format("Couldn't find Customer with ID: {0}", notification.Transaction.CustomerID));
          return;
        }

        Transaction transaction = Transaction.CreateManager().Load(notification.Transaction.TransactionID, GuidType.External);
        if(transaction != null)
        {
          Log.Error(String.Format("Transaction allready exist with externalGuid:{0}", notification.Transaction.TransactionID));
          return;
        }

        transaction = new Transaction(-1,
          Guid.NewGuid(), notification.Transaction.TransactionID,
          notification.Purchase.PurchaseID,
          notification.Transaction.TransactionGroupID,
          TransactionStatus.Executed,
          TransactionType.Debit,
          DateTime.Now, DateTime.Now);
        transaction.Insert();

        Log.Info(string.Format("Transaction '{0}' created!", transaction.Guid));

        List<CallbackReport> reports = CallbackReport.CreateManager().Load(CallbackNotificationType.ChargePurchaseNotification);
        foreach (CallbackReport report in reports)
          Code.Report.Call(report.Url.Replace("{data}", shortMessage.Guid.ToString()));
        Code.Report.Call(string.Format("http://{0}/notification/charged/{1}", shortMessage.Service.Name, shortMessage.Guid.ToString()));
      }
      catch (Exception e)
      {
        Log.Fatal(string.Format("ProcessChargePurchase fatal"), e);
      }
    }

  }
}