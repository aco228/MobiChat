using log4net;
using MobiChat.Data;
using MobiChat.Web.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MobiChat.Web.Core.Filters
{
  public class AgeVerificationAttribute : MobiActionFilterAttributeBase
  {

    #region #logging#

    private static ILog _log = null;

    protected static ILog Log
    {
      get
      {
        if (AgeVerificationAttribute._log == null)
          AgeVerificationAttribute._log = LogManager.GetLogger(typeof(AgeVerificationAttribute));
        return AgeVerificationAttribute._log;
      }
    }

    #endregion #logging#


    public override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
    {
      if (!this.Required)
        return;

      if (this.MobiContext.Service.ServiceData.ServiceStatus == MobiChat.Data.ServiceStatus.Free)
        return;
      else if(this.MobiContext.Service.ServiceData.ServiceStatus == MobiChat.Data.ServiceStatus.Offline )
      {        
        Log.Error("Service status is offline.");
        filterContext.Result = this.ErrorView();
        return;
      }
      else if(this.MobiContext.Service.ServiceData.ServiceStatus == MobiChat.Data.ServiceStatus.Updating )
      {
        Log.Error("Service is updating.");
        filterContext.Result = this.ErrorView();
        return;
      }

      ServiceConfigurationEntry sce = this.MobiContext.GetConfiguration();
      if(sce.IsAgeVerificationRequired)
      {
        filterContext.Result = this.AvsView(filterContext);
        return;
      }

      return;
    }

    public ViewResult ErrorView()
    {
      ErrorViewModel model = new ErrorViewModel(MobiContext.Current);
      model.Title = Translations.Web.Error.ErrInternal;
      model.Text = Translations.Web.Error.ErrTitle;

      ViewResult viewResult = new ViewResult();
      viewResult.ViewName = "Error";
      viewResult.ViewData.Model = model;
      return viewResult;
    }

    public ViewResult AvsView(ActionExecutingContext context)
    {
      AgeVerificationViewModel model = new AgeVerificationViewModel(MobiContext.Current);
      model.OriginalUrl = context.HttpContext.Request.RawUrl; // TODO: check if this is correct

      ViewResult viewResult = new ViewResult();
      viewResult.ViewName = "AgeVerification";
      viewResult.ViewData.Model = model;
      return viewResult;
    }



  }
}
