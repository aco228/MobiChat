using MobiChat.Data;
using MobiChat.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MobiChat.Web
{
  public class RouteConfig
  {

    public static void RegisterRoutes(HttpApplication httpApplication)
    {
      RouteTable.Routes.Clear();
      RouteTable.Routes.IgnoreRoute("{*pathInfo}", new { pathInfo = @".*\.(css|js|gif|jpg|woff|woff2|svg|png|ttf)" });

      Application application = WebApplication.GetRuntime(httpApplication).ApplicationData;

      List<ApplicationRouteSetMap> applicationRouteSetMap = ApplicationRouteSetMap.CreateManager().Load(application);
      List<RouteSet> routeSets = new List<RouteSet>();

      foreach (ApplicationRouteSetMap ars in applicationRouteSetMap)
        routeSets.Add(ars.RouteSet);

      IRouteManager rManager = MobiChat.Data.Route.CreateManager();
      foreach(RouteSet rs in routeSets)
      {
        List<MobiChat.Data.Route> routes = rManager.Load(rs);

        foreach (MobiChat.Data.Route route in routes)
        {
          if (route.Pattern.StartsWith("/"))
            route.Pattern = route.Pattern.Substring(1);

          if (!route.IsEnabled.Value)
            continue;

          if (route.IsIgnore.Value)
            RouteTable.Routes.IgnoreRoute(route.Pattern);
          else
          {
            if (!route.Pattern.Contains("{") && !route.Pattern.Contains("}"))
            {
              MapRoute(route, null);
              continue;
            }

            IRouteParameterManager rpManager = MobiChat.Data.RouteParameter.CreateManager();
            List<MobiChat.Data.RouteParameter> routeParameters = rpManager.Load(route);
            MapRoute(route, routeParameters);
          }
        }
      }


      RouteTable.Routes.Add("SessionRootRoute",
      new SessionRoute("{*dynamicParameters}",
        new RouteValueDictionary(new { controller = "Home", action = "Index" }),
        new RouteValueDictionary(new { dynamicParameters = string.Format(@"((/?{0}/{3})|(/?{1}/{3})|(/?{2}/{3}))*", MobiChat.Constants.SessionID, MobiChat.Constants.LookupID, MobiChat.Constants.PaymentID, MobiChat.Constants.RegexGuid) }),
        new MvcRouteHandler()));

      RouteTable.Routes.Add("Default",
        new SessionRoute("{controller}/{action}/{id}/{*dynamicParameters}",
          new RouteValueDictionary(new { controller = "Home", action = "Index", id = UrlParameter.Optional }),
          new RouteValueDictionary(new { dynamicParameters = string.Format(@"((/?{0}/{3})|(/?{1}/{3})|(/?{2}/{3}))*", MobiChat.Constants.SessionID, MobiChat.Constants.LookupID, MobiChat.Constants.PaymentID, MobiChat.Constants.RegexGuid) }),
          new MvcRouteHandler()));
      
    }


    private static void MapRoute(MobiChat.Data.Route route, List<RouteParameter> parameters)
    {
      RouteValueDictionary defaults = new RouteValueDictionary();
      RouteValueDictionary constraints = new RouteValueDictionary();

      if (!defaults.ContainsKey("controller"))
        defaults.Add("controller", route.Controller);
      if (!defaults.ContainsKey("action"))
        defaults.Add("action", route.Action);

      if (parameters != null)
      {
        foreach (RouteParameter parameter in parameters)
        {
          if (!defaults.ContainsKey(parameter.Key))
          {
            if (parameter.IsOptional)
              defaults.Add(parameter.Key, UrlParameter.Optional);
            else
              defaults.Add(parameter.Key, !string.IsNullOrEmpty(parameter.Value) ? parameter.Value : (object)UrlParameter.Optional);
          }
          if (parameter.Constraint != null)
            constraints.Add(parameter.Key, parameter.Constraint);
        }
      }

      string pattern = route.Pattern;
      System.Web.Routing.Route routeTemp = null;
      if (route.IsSessionRoute)
      {
        constraints.Add("dynamicParameters", string.Format(@"((/?{0}/{3})|(/?{1}/{3})|(/?{2}/{3}))*", MobiChat.Constants.SessionID, MobiChat.Constants.LookupID, MobiChat.Constants.PaymentID, MobiChat.Constants.RegexGuid));
        pattern += "/{*dynamicParameters}";
        RouteTable.Routes.Add(route.Name, new SessionRoute(pattern, defaults, constraints, new MvcRouteHandler()));
      }
      else
        RouteTable.Routes.Add(route.Name, new System.Web.Routing.Route(pattern, defaults, constraints, new MvcRouteHandler()));
      
    }


  }
}
