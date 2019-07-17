using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Senti.Data;
 

namespace MobiChat.Data 
{
  public partial interface IRouteManager 
  {
    List<Route> Load(RouteSet routeSet);
    List<Route> Load(IConnectionInfo connection, RouteSet routeSet);
  }

  public partial class Route
  {
  }
}

