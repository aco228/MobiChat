using Senti.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 

namespace MobiChat.Data 
{
  public partial interface IServiceManager 
  {

    // 

    
    Service Load(string serviceName);
    Service Load(IConnectionInfo connection, string serviceName);
    List<Service> Load(Application application);
    List<Service> Load(IConnectionInfo connection, Application application);

    Service Load(ServiceConfiguration serviceConfiguration);
    Service Load(IConnectionInfo connection, ServiceConfiguration serviceConfiguration);


  }

  public partial class Service
  {

    public IService Instantiate(IRuntime runtime)
    {
      return this.ServiceType.Instantiate(this, runtime);
    }
  }
}

