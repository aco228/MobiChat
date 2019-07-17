using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MobiChat.Service
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      routes.MapRoute(
        name: "InternalShortMessageRequestRoute",
        url: "request/{requestGuid}",
        defaults: new { controller = "InternalNotification", action = "ShortMessageRequest", requestGuid = UrlParameter.Optional }
      );

      routes.MapRoute(
          name: "Default2",
          url: "{controller}/{action}",
          defaults: new { controller = "Home", action = "Index" }
      );
      
    }
  }
}
