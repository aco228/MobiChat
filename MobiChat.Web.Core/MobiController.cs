using MobiChat.Web.Core.Filters;
using MobiChat.Web.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MobiChat.Web.Core
{
  [ContextAttribute(Order = 100, Required = true)]
  [AgeVerificationAttribute(Order = 100, Required = true)]
  public class MobiController : Controller, IMobiController
  {
    private MobiContext _mobiContext = null;
    private WebApplication _application = null;

    public MobiContext MobiContext { get {  return MobiContext.Current; } }

    public ActionResult InternalError()
    {
      ErrorViewModel model = new ErrorViewModel(this.MobiContext)
      {
        Title = Translations.Web.Error.ErrTitle,
        Text = Translations.Web.Error.ErrInternal
      };

      return View("Error", model);
    }

    public WebApplication MobiApplication
    {
      get
      {
        if (this._application != null)
          this._application = this.HttpContext.ApplicationInstance as WebApplication;
        return this._application;
      }
    }

  }
}
