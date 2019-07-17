using Senti.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 

namespace MobiChat.Data 
{
  public partial interface IServiceConfigurationManager 
  {
    
    ServiceConfiguration Load(string appID);
    ServiceConfiguration Load(IConnectionInfo connection, string appID);




    
  }

  public partial class ServiceConfiguration
  {
  }
}

