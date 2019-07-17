using log4net;
using MobiChat.Web.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MobiChat.Web.Core.Filters
{
  public class TemplateAttribute : MobiActionFilterAttributeBase
  {

    #region #logging#
    private static ILog _log = null;

    protected static ILog Log
    {
      get
      {
        if (TemplateAttribute._log == null)
          TemplateAttribute._log = LogManager.GetLogger(typeof(TemplateAttribute));
        return TemplateAttribute._log;
      }
    }

    #endregion #logging#

    private bool _loginRequired = true;
    private bool _administratorAccess = false;
    private bool _marketingAccess = false;
    private bool _merchantAccess = false;
    private bool _customerCareAccess = false;

    public bool AdministratorAccess { get { return this._administratorAccess; } set { this._administratorAccess = value; } }
    public bool MarketingAccess { get { return this._marketingAccess; } set { this._marketingAccess = value; } }
    public bool MerchantAccess { get { return this._merchantAccess; } set { this._merchantAccess = value; } }
    public bool CustomerCareAccess { get { return this._customerCareAccess; } set { this._customerCareAccess = value; } }
    public bool LoginRequired { get { return this._loginRequired; } set { this._loginRequired = value; } }


    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
      base.OnActionExecuting(filterContext);

      #region # Skip attribute #

      if (filterContext.HttpContext.Request.RawUrl.Contains("skip=") ||
        !this._loginRequired ||
        filterContext.HttpContext.Request.RawUrl.ToLower().Contains("api"))
        return;

      #endregion

      #region # Check ClientSession #

      if(this.MobiContext.Session.User == null || 
        DateTime.Now > this.MobiContext.Session.SessionData.ValidUntil)
      {
        //string username = (this.MobiContext.Session != null && this.MobiContext.Session.ClientSession != null) ? this.MobiContext.Session.ClientSession.Client.Username : "";
        string username = string.Empty;
        this.Login(filterContext, username, filterContext.HttpContext.Request.RawUrl);
        return;
      }
      
      #endregion

      #region # Access Restriction #

      if ((this._administratorAccess && this.MobiContext.Session.UserType.Equals("Administrator")) ||
        (this._marketingAccess && this.MobiContext.Session.UserType.Equals("Marketing")) ||
        (this._merchantAccess && this.MobiContext.Session.UserType.Equals("Merchant")) ||
        (this._customerCareAccess && this.MobiContext.Session.UserType.Equals("CustomerCare")) ||
        (!this._administratorAccess && !this._marketingAccess && !this._merchantAccess && !this._customerCareAccess))
      { }
      else
      {
        this.Error(filterContext, "You dont have rights to see this page! ");
        return;
      }

      #endregion

    }

    private void Login(ActionExecutingContext filterContext, string username, string originalRequest)
    {
      if (filterContext.HttpContext.Request.IsAjaxRequest())
      {
        JsonResult jsonResutl = new JsonResult();
        jsonResutl.Data = new { status = false, message = "Your session is over. Please refresh page!", redirect = "/" };
        filterContext.Result = jsonResutl;
        return;
      }

      ViewResult result = new ViewResult();
      result.ViewName = "~/Views/Template/Login.cshtml";
      result.ViewBag.Username = username;
      result.ViewBag.OriginalRequest = originalRequest;
      filterContext.Result = result;
      return;
    }

    private void Error(ActionExecutingContext filterContext, string errorMessage)
    {
      if (filterContext.HttpContext.Request.IsAjaxRequest())
      {
        JsonResult jsonResutl = new JsonResult();
        jsonResutl.Data = new { status = false, message = "You dont have permission for this action", redirect = "/" };
        filterContext.Result = jsonResutl;
        return;
      }

      ErrorViewModel model = new ErrorViewModel(this.MobiContext, "Error", errorMessage);
      ViewResult viewResult = new ViewResult();
      viewResult.ViewName = "Error";
      viewResult.ViewData.Model = model;
      filterContext.Result = viewResult;
      return;
    }

  }
}
