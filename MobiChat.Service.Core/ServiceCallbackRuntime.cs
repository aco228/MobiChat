using MobiChat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Service.Core
{
  public class ServiceCallbackRuntime : RuntimeBase
  {
    
    private bool _isInitialized = false;
    protected List<IService> _services = null;
    protected Dictionary<string, IService> _serviceMap = null;
    protected Dictionary<string, Domain> _domainMap = null;

    private static readonly object MobiRuntimeInitializationLockObject = new object();

    public ServiceCallbackRuntime(Application application)
      :base(application)
    {

    }

    public override bool Initialize(string siteName)
    {
      if (this._isInitialized)
        return true;

      lock (ServiceCallbackRuntime.MobiRuntimeInitializationLockObject)
      {
        if (this._isInitialized)
          return true;

        //

      }

      return true;
    }

    public override IService GetService(string domainName)
    {
      throw new NotImplementedException();
    }

    public override IService GetServiceByName(string name)
    {
      throw new NotImplementedException();
    }

    public override Domain GetDomain(string domainName)
    {
      throw new NotImplementedException();
    }

    public override Country GetCountryByID(int id)
    {
      throw new NotImplementedException();
    }

  }
}
