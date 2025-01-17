﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace MobiChat.Web.Core
{
  public class SessionRoute : System.Web.Routing.Route
  {

    public SessionRoute(string url, IRouteHandler routeHandler) : base(url, routeHandler) { }
    public SessionRoute(string url, RouteValueDictionary defaults, IRouteHandler routeHandler) : base(url, defaults, routeHandler) { }
    public SessionRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, IRouteHandler routeHandler) : base(url, defaults, constraints, routeHandler) { }
    public SessionRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, RouteValueDictionary dataTokens, IRouteHandler routeHandler) : base(url, defaults, constraints, dataTokens, routeHandler) { }


    public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
    {
      VirtualPathData basePathData = base.GetVirtualPath(requestContext, values);
      if (basePathData != null)
        basePathData.VirtualPath = MobiChat.Web.Core.UrlHelper.AppendSessionID(requestContext, basePathData.VirtualPath);

      return basePathData;
    }
  }
}
