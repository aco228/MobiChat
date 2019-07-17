using MobiChat.Web.Core;
using MobiChat.Web.Core.Filters;
using MobiChat.Web.Core.Models;
using MobiChat.Web.Core.Models.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobiChat.Web.Controllers
{
  [TemplateAttribute(Order = 50, Required = true)]
  public partial class TemplateController : MobiController
  {

    // SUMMARY: Template -> Index page
    public ActionResult Index()
    {
      bool extendedAccess = true;// TODO: make this dynamic
      TemplateIndexModel model = new TemplateIndexModel(this.MobiContext, extendedAccess);
      return View("~/Views/Template/Index.cshtml", model);
    }
    
    // SUMMARY: Template -> On logout
    public ActionResult Logout()
    {
      if(this.MobiContext.Session.User != null)
      {
        this.MobiContext.Session.SessionData.User = null;
        this.MobiContext.Session.SessionData.Update();
        this.MobiContext.Session.UpdateUser();
      }

      ViewBag.OriginalRequest = "/template";
      return View("~/Views/Template/Login.cshtml");
    }

    // SUMMARY: Template -> Translation page
    [TemplateAttribute(AdministratorAccess = true)]
    public ActionResult Translation(string t, string name)
    {
      int translationID = -1;
      if(!Int32.TryParse(t, out translationID))
      {
        ErrorViewModel errorModel = new ErrorViewModel(this.MobiContext, "Translation Error", "Could not load translation with ID:" + t);
        return View("Error", errorModel);
      }

      MobiChat.Data.Translation translation = MobiChat.Data.Translation.CreateManager().Load(translationID);
      if (translation == null)
      {
        ErrorViewModel errorModel = new ErrorViewModel(this.MobiContext, "Translation Error", "Could not load translation with ID:" + translationID);
        return View("Error", errorModel);
      }

      TranslationTemplateModel model = new TranslationTemplateModel(this.MobiContext, translation, true, name);
      if (model.HasTranslation)
        return View("~/Views/Template/Translation.cshtml", model);
      else
      {
        ErrorViewModel errorModel = new ErrorViewModel(this.MobiContext, "Translation Error", "This service has no translation. Please contact administrator!");
        return View("Error", errorModel);
      }
    }

    // SUMMARY: Template -> Update service logo
    public ActionResult UpdateLogo()
    {
      TemplateServiceUpdateLogoModel model = new TemplateServiceUpdateLogoModel(this.MobiContext, string.Empty);
      return View("~/Views/Template/UpdateLogo.cshtml", model);
    }

  }
}