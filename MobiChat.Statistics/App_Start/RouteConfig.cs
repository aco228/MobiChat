using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MobiChat.Statistics
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      routes.MapRoute(name: "MO Notification", url: "_mo", defaults: new { controller = "Notification", action = "MO_Handle" });
      routes.MapRoute(name: "MT Notification", url: "_mt", defaults: new { controller = "Notification", action = "MT_Handle" });


      routes.MapRoute(
       name: "Index",
       url: "{controller}/{action}",
       defaults: new { controller = "Statistic", action = "Index" }
       );


      routes.MapRoute(
       name: "SideBar",
       url: "Statistic/Sidebar",
       defaults: new { controller = "Statistic", action = "Sidebar" }
       );

      routes.MapRoute(
       name: "Main",
       url: "{controller}/{action}",
       defaults: new { controller = "Statistic", action = "Main" }
       );

      routes.MapRoute(
        name: "Table",
        url: "{controller}/{action}",
        defaults: new { controller = "Statistic", action = "Table" }
        );


      routes.MapRoute(
        name: "Filter",
        url: "{controller}/{action}",
        defaults: new { controller = "Statistic", action = "Filter" }
        );


      routes.MapRoute(
      name: "Users",
      url: "Users",
      defaults: new { controller = "Users", action = "Index" }
      );
      
      

      routes.MapRoute(
        name: "Default",
        url: "{controller}/{action}/{id}",
        defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });

    }
  }
}
