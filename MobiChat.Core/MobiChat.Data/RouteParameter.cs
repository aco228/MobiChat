using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Senti.Data;
 

namespace MobiChat.Data 
{
  public partial interface IRouteParameterManager 
  {
    List<RouteParameter> Load(Route route);
    List<RouteParameter> Load(IConnectionInfo connection, Route route);
  }

  public partial class RouteParameter
  {
  }
}

