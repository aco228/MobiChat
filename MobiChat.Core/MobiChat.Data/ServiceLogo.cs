using Senti.Data;
using System;
using System.Collections.Generic;
using System.Data;
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

    public static ServiceLogo LoadByService(Service service)
    {
      ServiceLogo serviceLogo = null;
      using (ConnectionInfo connection = new ConnectionInfo(IsolationLevel.ReadUncommitted))
      {
        connection.Transaction.Begin();
        serviceLogo = ServiceLogo.CreateManager().Load(service);
        connection.Transaction.Commit();
      }
      return serviceLogo;
    }

  }
}

