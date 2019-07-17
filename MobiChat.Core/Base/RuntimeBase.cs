using MobiChat.Core;
using MobiChat.Data;
using Senti.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat
{
  public abstract class RuntimeBase : IRuntime
  {
    private Data.RuntimeType _runtimeType = null;
    private Data.Application _application = null;
    protected Dictionary<ServiceType, ICache> _cache = null;
    protected Dictionary<Data.Localization, ILocalizationProvider> _localizationProviders = new Dictionary<Data.Localization, ILocalizationProvider>();

    public Data.RuntimeType RuntimeType { get { return this._runtimeType; } }
    public Data.Application ApplicationData { get { return this._application; } }
    public Dictionary<ServiceType, ICache> Cache { get { return this._cache; } }
    public Dictionary<Localization, ILocalizationProvider> LocalizationProviders { get { return this._localizationProviders; } }

    // TODO: implement

    public RuntimeBase(Application application)
    {
      this._application = application;
      this._cache = new Dictionary<ServiceType, ICache>();
    }


    public virtual bool Initialize(string siteName)
    {
      throw new NotImplementedException();
    }

    public virtual Data.Domain GetDomain(string domainName)
    {
      throw new NotImplementedException();
    }

    public virtual IService GetService(string domainName)
    {
      throw new NotImplementedException();
    }

    public virtual IService GetServiceByName(string name)
    {
      throw new NotImplementedException();
    }

    public virtual Data.Merchant GetMerchantByID(int id)
    {
      throw new NotImplementedException();
    }

    public virtual Data.Country GetCountryByID(int id)
    {
      throw new NotImplementedException();
    }

  }
}
