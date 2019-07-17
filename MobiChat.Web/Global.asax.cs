using MobiChat.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MobiChat.Web
{
  public class MvcApplication : WebApplication
  {

    protected override void InitializeApplication()
    {
      base.InitializeApplication();

      AreaRegistration.RegisterAllAreas();
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

      BundleConfig.RegisterBundles(BundleTable.Bundles);

      //GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Include;
    }

    protected void Session_Start(Object sender, EventArgs e)
    {
      Session["Init"] = 0;
    }
  }
}
