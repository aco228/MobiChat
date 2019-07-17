using log4net;
using MobiChat.Core;
using MobiChat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat
{
  public abstract class ServiceBase : IService
  {

    #region #logging#

    private static ILog _log = null;

    protected static ILog Log
    {
      get
      {
        if (ServiceBase._log == null)
          ServiceBase._log = LogManager.GetLogger(typeof(ServiceBase));
        return ServiceBase._log;
      }
    }

    #endregion #logging#

    private Data.Service _serviceData = null;
    private IRuntime _runtime = null;
    private List<Domain> _domains = null;
    private ServiceLogo _serviceLogo = null;
    protected string _homeView = string.Empty;
    protected string _partialHomeView = string.Empty;
    protected Dictionary<int, ServiceConfigurationEntry> _countryConfigurationEntryMap = null; // CountryID
    private ISendNumber _sendNumberManager = null;
    private PaymentProvider _paymentProvider = null;

    public Data.Service ServiceData { get { return this._serviceData; } }
    public IRuntime Runtime { get { return this._runtime; } }
    public List<Data.Domain> Domains { get { return this._domains; } }
    public Data.ServiceLogo ServiceLogo { get { return this._serviceLogo; } }
    public Template Template { get { return this._serviceData.Template; } }
    public ICache Cache { get { return this.Runtime.Cache[this._serviceData.ServiceType]; } }
    public PaymentProvider PaymentProvider { get { return this._paymentProvider; } }
    public string HomeView { get { return this._homeView; } }
    public string PartialHomeView { get { return this._partialHomeView; } }

    public ISendNumber SendNumberManager
    {
      get
      {
        if (this._sendNumberManager != null)
          return this._sendNumberManager;

        ServiceSendNumberMap sendNumberMap = ServiceSendNumberMap.CreateManager().Load(this._serviceData).FirstOrDefault();
        if (sendNumberMap == null)
          return null;

        this._sendNumberManager = sendNumberMap.Instantiate();
        return this._sendNumberManager;
      }
    }

    public string Shortcode
    {
      get
      {
        if (this._countryConfigurationEntryMap.ContainsKey(this._serviceData.FallbackCountry.ID))
          return this._countryConfigurationEntryMap[this._serviceData.FallbackCountry.ID].Shortcode.ToString();

        ServiceConfigurationEntry sce = this.GetConfiguration(this._serviceData.FallbackCountry);
        if (sce != null)
          return sce.Shortcode.ToString();

        return string.Empty;
      }
    }

    public ServiceBase(Service service)
    {
      this._serviceData = service;
      this._countryConfigurationEntryMap = new Dictionary<int, ServiceConfigurationEntry>();
      Log.Info(string.Format("Service '{0}' has been constructed", this._serviceData.Name));

      this.Init();
    }

    public ServiceBase(Service service, IRuntime runtime)
    {
      this._serviceData = service;
      this._countryConfigurationEntryMap = new Dictionary<int, ServiceConfigurationEntry>();
      this._runtime = runtime;
      Log.Info(string.Format("Service '{0}' has been constructed", this._serviceData.Name));

      this.Init();
    }

    public abstract void Init();
    
    public ServiceConfigurationEntry GetConfiguration(Data.Country country)
    {
      return this.GetConfiguration(country, null);
    }

    public ServiceConfigurationEntry GetConfiguration(Data.Country country, Data.MobileOperator mobileOperator)
    {
      ServiceConfigurationEntry sce = null;

      if (mobileOperator == null)
      {
        if (this._countryConfigurationEntryMap.ContainsKey(country.ID))
          return this._countryConfigurationEntryMap[country.ID];
        
        sce = ServiceConfigurationEntry.CreateManager().Load(this._serviceData, country);
        if (sce != null)
          this._countryConfigurationEntryMap.Add(country.ID, sce);

        return sce;
      }
      else
        return ServiceConfigurationEntry.CreateManager().Load(this._serviceData, country, mobileOperator);

    }


    public virtual void OnSentMessageNotification(Guid shortMessageRequestGuid)
    { }

    public virtual void OnReceivedMessageNotification(Guid shorMessageGuid)
    { }

    public virtual void OnChargedNotification(Guid transactionGuid)
    { }

  }
}
