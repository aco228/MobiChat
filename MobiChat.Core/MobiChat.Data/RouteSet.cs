using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Senti.Data;
 

namespace MobiChat.Data 
{
  public partial interface IRouteSetManager 
  {
    List<RouteSet> Load(Instance instance);
    List<RouteSet> Load(IConnectionInfo connection, Instance instance);
  }

  public partial class RouteSet
  {
  }
}

