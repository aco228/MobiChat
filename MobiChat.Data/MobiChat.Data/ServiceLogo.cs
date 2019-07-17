using Senti.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 

namespace MobiChat.Data 
{
  public partial interface IServiceLogoManager 
  {
    
    ServiceLogo Load(Service service);
    ServiceLogo Load(IConnectionInfo connection, Service service);

  }

  public partial class ServiceLogo
  {
  }
}

