using Senti.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 

namespace MobiChat.Data 
{
  public partial interface IApplicationRouteSetMapManager 
  {

    
    List<ApplicationRouteSetMap> Load(Application application);
    List<ApplicationRouteSetMap> Load(IConnectionInfo connection, Application application);



  }

  public partial class ApplicationRouteSetMap
  {
  }
}

