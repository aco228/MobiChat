using MobiChat.Data;
using MobiChat.Web.Core;
using MobiChat.Web.Core.Filters;
using MobiChat.Web.Core.Models.Template;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobiChat.Web.Controllers
{
  public partial class TemplateController : MobiController
  {

    // SUMMARY: Login
    public ActionResult ApiLogin(string username, string password)
    {
      username = username.ToLower();

      if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        return this.Json(new { status = false, message = "Arguments missing", redirect = string.Empty });

      if (this.MobiContext.Session.User != null)
        return this.Json(new { status = false, message = "Session exsists", redirect = string.Empty });

      MobiChat.Data.User client = MobiChat.Data.User.CreateManager().Load(username, password);

      if (client == null)
        return this.Json(new { status = false, message = "Wrong credentials", redirect = string.Empty });
      else if (client.UserStatus != MobiChat.Data.UserStatus.Active)
        return this.Json(new { status = false, message = "Account is inactive", redirect = string.Empty });
      else
      {
        if (this.MobiContext.Session.User != null)
        { }
        else
        {
          this.MobiContext.Session.SessionData.User = client;
          this.MobiContext.Session.SessionData.Update();
          this.MobiContext.Session.UpdateUser();
        }
        return this.Json(new { status = true, message = "OK", redirect = "/template" });
      }
    }

    // SUMMARY: Template -> Translation -> Update or create new translation value for service
    [TemplateAttribute(AdministratorAccess = true, MarketingAccess = true)]
    public ActionResult ApiUpdateTranslationValue(string translationValueKeyID, string translationKeyID, string translationGroupKeyID, string groupName, string groupKey, string value)
    {
      int tvalueID, tKeyID, tGroupKeyID;
      if (!Int32.TryParse(translationValueKeyID, out tvalueID))
        return this.Json(new { status = false, message = "Argument error 'translationValueKeyID" });
      if (!Int32.TryParse(translationKeyID, out tKeyID))
        return this.Json(new { status = false, message = "Argument error 'translationKeyID" });
      if (!Int32.TryParse(translationGroupKeyID, out tGroupKeyID))
        return this.Json(new { status = false, message = "Argument error 'translationGroupKeyID" });

      string message = "";
      value = HttpUtility.UrlDecode(value);

      TranslationValue translationValue;
      if (tvalueID == -1)
      {
        translationValue = new TranslationValue(-1,
          TranslationKey.CreateManager().Load(tKeyID),
          TranslationGroupKey.CreateManager().Load(tGroupKeyID),
          value,
          DateTime.Now, DateTime.Now);
        translationValue.Insert();
        message = "Translation has been added";
      }
      else
      {
        translationValue = TranslationValue.CreateManager().Load(tvalueID);
        if (translationValue == null)
          return this.Json(new { status = false, message = "Translation value does not exists!" });

        translationValue.Value = value;
        translationValue.Update();
        message = "Translation has been updated";
      }

      Translations.Web.GetGroup(groupName).AssignValue(groupKey, value);
      //MobiContext.Current.UpdateTranslationsWildcars();

      return this.Json(new { status = true, message = message, id = translationValue.ID, Updated = translationValue.Updated.ToString() });
    }

    // SUMMARY: Translations -> Delete translation values
    [TemplateAttribute(AdministratorAccess = true)]
    public ActionResult ApiDeleteTranslationValue(string translationValue)
    {
      int translationValueID = -1;
      if (!Int32.TryParse(translationValue, out translationValueID))
        return this.Json(new { status = false, message = "Invalid value was sent to the API" });

      TranslationValue value = TranslationValue.CreateManager().Load(translationValueID);

      if (value == null)
        return this.Json(new { status = false, message = "TranslationValue with ID:" + translationValueID + " does not exists in database" });

      if (!value.IsDeletable)
        return this.Json(new { status = false, message = "Value could not be deleted. Please contact system administrator" });

      value.Delete();
      return this.Json(new { status = true, message = "Value is deleted. Please restart application pool." });
    }

    // SUMMARY: Add or update service logo from dataabse
    [TemplateAttribute(AdministratorAccess = true, MarketingAccess = true)]
    public ActionResult ApiUpdateLogo(HttpPostedFileBase file)
    {
      if (file == null && file.ContentLength == 0)
        return View("~/Views/Template/UpdateLogo.cshtml", new TemplateServiceUpdateLogoModel(this.MobiContext, "You did not provided file for upload"));

      if (!file.FileName.Contains(".png"))
        return View("~/Views/Template/UpdateLogo.cshtml", new TemplateServiceUpdateLogoModel(this.MobiContext, "Error. You must provide file with .png extension"));

      byte[] data = null;
      using (MemoryStream ms = new MemoryStream())
      {
        file.InputStream.CopyTo(ms);
        data = ms.GetBuffer();
      }

      if (data == null)
        return View("~/Views/Template/UpdateLogo.cshtml", new TemplateServiceUpdateLogoModel(this.MobiContext, "Error with converting file"));

      ServiceLogo serviceLogo = ServiceLogo.LoadByService(this.MobiContext.Service.ServiceData);

      if (serviceLogo == null)
      {
        serviceLogo = new ServiceLogo(-1, this.MobiContext.Service.ServiceData, data, DateTime.Now, DateTime.Now);
        serviceLogo.Insert();
        this.MobiContext.Service.Init();
        return View("~/Views/Template/UpdateLogo.cshtml", new TemplateServiceUpdateLogoModel(this.MobiContext, "Success! Logo is inserted. "));
      }
      else
      {
        serviceLogo.Data = data;
        serviceLogo.Update();
        this.MobiContext.Service.Init();
        return View("~/Views/Template/UpdateLogo.cshtml", new TemplateServiceUpdateLogoModel(this.MobiContext, "Success! Logo is updated. "));
      }
    }

  }
}