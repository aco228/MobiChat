using log4net;
using MobiChat.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobiChat.Web.Controllers
{
  public class NotificationController : MobiController
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

    public ActionResult Sent(string guid)
    {
      Guid notificationGuid = Guid.Empty;
      if (!Guid.TryParse(guid, out notificationGuid))
      {
        Log.Error(string.Format("NotificationController:Sent, guid could not be parsed (guid = {0})", guid));
        return this.Content("e");
      }

      this.MobiContext.Service.OnSentMessageNotification(notificationGuid);
      return this.Content("s");
    }

    public ActionResult Received(string guid)
    {
      Guid notificationGuid = Guid.Empty;
      if (!Guid.TryParse(guid, out notificationGuid))
      {
        Log.Error(string.Format("NotificationController:Receive, guid could not be parsed (guid = {0})", guid));
        return this.Content("e");
      }

      this.MobiContext.Service.OnReceivedMessageNotification(notificationGuid);
      return this.Content("s");
    }

    public ActionResult Charged(string guid)
    {
      Guid notificationGuid = Guid.Empty;
      if (!Guid.TryParse(guid, out notificationGuid))
      {
        Log.Error(string.Format("NotificationController:Charged, guid could not be parsed (guid = {0})", guid));
        return this.Content("e");
      }

      this.MobiContext.Service.OnChargedNotification(notificationGuid);
      return this.Content("s");
    }

  }
}