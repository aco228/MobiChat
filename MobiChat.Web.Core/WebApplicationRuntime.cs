using MobiChat.Data;
using MobiChat.Web.Core.Localization;
using Senti.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace MobiChat.Web.Core
{
  public class WebApplicationRuntime : RuntimeBase
  {
    #region #logging#

    private static ILog _log = null;

    protected static ILog Log
    {
      get
      {
        if (WebApplicationRuntime._log == null)
          WebApplicationRuntime._log = LogManager.GetLogger(typeof(WebApplicationRuntime));
        return WebApplicationRuntime._log;
      }
    }

    #endregion #logging#


    private bool _isInitialized = false;
    protected List<IService> _services = null;
    protected Dictionary<string, IService> _serviceMap = null;
    protected Dictionary<string, Domain> _domainMap = null;

    private static readonly object MobiRuntimeInitializationLockObject = new object();

    public WebApplicationRuntime(Application application)
      :base(application)
    {

    }

    public override bool Initialize(string siteName)
    {
      if (this._isInitialized)
        return true;

      lock (WebApplicationRuntime.MobiRuntimeInitializationLockObject)
      {
        if (this._isInitialized)
          return true;

        this._serviceMap = new Dictionary<string, IService>();
        this._domainMap = new Dictionary<string, Domain>();
        this._services = new List<IService>();

        IServiceManager sManager = Service.CreateManager();
        List<Service> services = sManager.Load(this.ApplicationData);

        if(services == null || services.Count == 0)
        {          
          Log.Fatal("WebApplicationRuntime: There is no services for this application");
          //throw new ArgumentException("WebApplicationRuntime: There is no services for this application");
        }

        IDomainManager dManager = Domain.CreateManager();

        foreach(Service service in services)
        {

          // adding domain
          List<Domain> serviceDomains = dManager.Load(service);
          if(serviceDomains == null || serviceDomains.Count == 0)
          {            
            Log.Error("Domain doesn't exist");
          }

          foreach (Domain sDomain in serviceDomains)
            this._domainMap.Add(sDomain.DomainName, sDomain);

          // adding service
          IService iservice = service.Instantiate(this);
          this._services.Add(iservice);
          this._serviceMap.Add(service.Name, iservice);

          // ading localizations
          MobiChat.Data.ILocalizationManager lManager = MobiChat.Data.Localization.CreateManager();
          List<MobiChat.Data.Localization> localizations = lManager.Load(this.ApplicationData);

          foreach (MobiChat.Data.Localization localization in localizations)
            if(!this._localizationProviders.ContainsKey(localization))
              this._localizationProviders.Add(localization, localization.InstantiateProvider());

        }
      }

      return true;
    }

    public override IService GetService(string domainName)
    {
      if (this._serviceMap.ContainsKey(domainName))
        return this._serviceMap[domainName];
      return null;
    }

    public override IService GetServiceByName(string name)
    {
      if (this._serviceMap.ContainsKey(name))
        return this._serviceMap[name];
      return null;
    }

    public override Domain GetDomain(string domainName)
    {
      if (this._domainMap.ContainsKey(domainName))
        return this._domainMap[domainName];
      return null;
    }

    public override Country GetCountryByID(int id)
    {
      
      return base.GetCountryByID(id);
    }



  }
}
