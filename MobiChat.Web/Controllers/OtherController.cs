using log4net;
using MobiChat.Data;
using MobiChat.Web.Core;
using Senti.Diagnostics.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobiChat.Web.Controllers
{
  public class OtherController : MobiController
  {

    #region #logging#

    private static ILog _log = null;

    protected static ILog Log
    {
      get
      {
        if (OtherController._log == null)
          OtherController._log = LogManager.GetLogger(typeof(OtherController));
        return OtherController._log;
      }
    }

    #endregion #logging#

    public string Test()
    {
      Report.TryReportPxid(this.MobiContext.HttpContext.Request);
      return "ok";
    }

    public ActionResult Logo()
    {
      if (this.MobiContext.Service.ServiceLogo == null)
      {
        string logoUrl = string.Format("~/Images/_Logo/{0}.png", this.MobiContext.Service.ServiceData.ID);
        return (System.IO.File.Exists(Server.MapPath(logoUrl))) ? Redirect(logoUrl) : null;
      }

      return File(this.MobiContext.Service.ServiceLogo.Data, "image/png", string.Format("logo.{0}.png", this.MobiContext.Service.ServiceData.ID));
    }

  }
}