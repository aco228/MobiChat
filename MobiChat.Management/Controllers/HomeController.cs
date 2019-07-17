using MobiChat.Management.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobiChat.Management.Controllers
{
  public class HomeController : MobiController
  {
    public string Index()
    {
      return string.Format("{0} {1}", this.MobiContext.Session.SessionData.Country.GlobalName, this.MobiContext.Session.SessionData.Language.GlobalName);
    }

    public ActionResult Notification(string data)
    {
      Guid guid = Guid.Empty;
      if (!Guid.TryParse(data, out guid))
        return this.Content("Error");

      MvcApplication.TempVariable = guid;
      return this.Content("");
    }

    public string Test()
    {
      return MvcApplication.TempVariable.ToString();
    }

  }
}