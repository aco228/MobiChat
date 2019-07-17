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
  public class ContextAttribute : MobiActionFilterAttributeBase
  {
    #region #logging#

    private static ILog _log = null;

    protected static ILog Log
    {
      get
      {
        if (ContextAttribute._log == null)
          ContextAttribute._log = LogManager.GetLogger(typeof(ContextAttribute));
        return ContextAttribute._log;
      }
    }

    #endregion #logging#

    public override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
    {
      if (!this.Required)
        return;

      if (this.MobiContext.Service.ServiceData.ServiceStatus == MobiChat.Data.ServiceStatus.Offline)
      {
        Log.Error("Service status is offline.");
        filterContext.Result = this.ErrorView();
        return;
      }
      else if (this.MobiContext.Service.ServiceData.ServiceStatus == MobiChat.Data.ServiceStatus.Updating)
      {
        Log.Error("Service is updating.");
        filterContext.Result = this.ErrorView();
        return;
      }
      else if (this.MobiContext.Service.ServiceData.ServiceStatus == MobiChat.Data.ServiceStatus.Free)
        return;

      ServiceConfigurationEntry sce = this.MobiContext.GetConfiguration();
      if(this.MobiContext.GetConfiguration() == null)
      {
        Log.Error("Service cnofiguration entry is empty.");
        filterContext.Result = this.ErrorView();
        return;
      }
      
      base.OnActionExecuting(filterContext);
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

  }
}
