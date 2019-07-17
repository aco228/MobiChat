using Senti.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Senti.ComponentModel;


namespace MobiChat.Data
{
  public partial interface IServiceTypeManager
  {

    List<ServiceType> Load();
    List<ServiceType> Load(IConnectionInfo connection);

    ServiceType Load(string name);
    ServiceType Load(IConnectionInfo connection, string name);

  }

  public partial class ServiceType
  {

    public IService Instantiate(Service service, IRuntime runtime)
    {
      return TypeFactory.Instantiate<IService, Service, IRuntime>(this.TypeName, service, runtime);
    }

  }
}

