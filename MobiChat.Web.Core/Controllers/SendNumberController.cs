using log4net;
using MobiChat.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MobiChat.Web.Core.Controllers
{
  public class SendNumberController : MobiController
  {

    #region #logging#

    private static ILog _log = null;

    protected static ILog Log
    {
      get
      {
        if (SendNumberController._log == null)
          SendNumberController._log = LogManager.GetLogger(typeof(SendNumberController));
        return SendNumberController._log;
      }
    }

    #endregion #logging#

    public ActionResult Send(string number)
    {
      Log.Info(string.Format("SendNumber:: init for number=" + number));
      string customMessage = Request["sm"];

      ISendNumber sendNumberManager = this.MobiContext.Service.SendNumberManager;
      if(sendNumberManager == null)
      {
        Log.Error(string.Format("SendNumber:: ISendNumber could not be loaded for service '{0}' with id {1}", this.MobiContext.Service.ServiceData.Name, this.MobiContext.Service.ServiceData.ID));
        return this.Json(new { status = false, message = Translations.Web.Error.ErrInternal }, JsonRequestBehavior.AllowGet);
      }
      //TODO: if language germany(message on german language)
      // TODO: Add translation for success message
      sendNumberManager.SetErrorMessage(Translations.Web.Error.ErrInternal);
      sendNumberManager.SetSuccessMessage("Vaše žádost byla úspěšně odeslána");
      sendNumberManager.SetMessageAllreadySent("Uvítací zpráva již byla odeslána do tohoto čísla"); // Welcome message has allready been sent to this number
      if (!string.IsNullOrEmpty(customMessage))
        sendNumberManager.SetCustomMessage(customMessage);
      sendNumberManager.Initialize(this.MobiContext.Service, this.MobiContext.HttpContext, number);

      return this.Json(new { status = sendNumberManager.Status, message = sendNumberManager.Message }, JsonRequestBehavior.AllowGet);
    }

  }
}
