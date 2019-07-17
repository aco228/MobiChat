using MobiChat.Management.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MobiChat.Management
{
  public class MvcApplication : ManagementApplication
  {

    public static Guid TempVariable = Guid.Empty;

    protected override void InitializeApplication()
    {
      AreaRegistration.RegisterAllAreas();
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);
    }

    protected void Session_Start(Object sender, EventArgs e)
    {
      Session["Init"] = 0;
    }

  }
}
