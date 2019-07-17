using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobiChat.Web.Controllers
{
  public class HelpdeskController : Controller
  {
    // GET: Helpdesk
    public ActionResult Index()
    {
      return this.Content("<b>Helpdesk</b>");
    }
  }
}