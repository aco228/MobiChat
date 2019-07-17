using MobiChat.Web.Core;
using MobiChat.Web.Core.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MobiChat.Web.Controllers
{
  public class ImprintController : MobiController
  {
    // GET: Imprint
    [AgeVerification(Required = false)]
    public ActionResult Index()
    {
      MobiViewModelBase model = new MobiViewModelBase(this.MobiContext);
      return View("Imprint", model);
    }
  }
}