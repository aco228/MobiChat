using log4net;
using MobiChat.Data;
using MobiChat.Web.Core.Localization;
using Senti.Diagnostics.Log;
using Senti.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MobiChat.Web.Core
{
  public class MobiContext : MobiChatContextBase
  {
    
    protected static readonly string MobiHttpContextItemKey = "MobiHttpContextItemKey";
    protected static readonly string MobiLocalizationItemKey = "MobiLocalizationItemKey";

    #region #logging#

    private static ILog _log = null;

    protected static ILog Log
    {
      get
      {
        if (MobiContext._log == null)
          MobiContext._log = LogManager.GetLogger(typeof(MobiContext));
        return MobiContext._log;
      }
    }

    #endregion #logging#

    private IService _service = null;
    private IUserSession _session = null;
    private Domain _domain = null;

    public IService Service { get { return this._service; } }
    public IUserSession Session { get { return this._session; } }
    public WebUserSession WebUserSession { get { return this._session as WebUserSession; } }
    public Domain Domain { get { return this._domain; } }

    public int MobileOperatorID { get { return this._session.SessionData.MobileOperator != null ? this._session.SessionData.MobileOperator.ID : -1; } }

    public static MobiContext Current
    {
      get
      {
        HttpContext httpContext = HttpContext.Current;
        return MobiContext.GetCurrent(httpContext);
      }
    }

    public static MobiContext GetExisting()
    {
      HttpContext httpContext = HttpContext.Current;
      return httpContext.Items[MobiHttpContextItemKey] as MobiContext;
    }
    
    public static MobiContext GetCurrent(HttpContext httpContext)
    {
      lock (httpContext.Request)
      {
        MobiContext mobiContext = httpContext.Items[MobiHttpContextItemKey] as MobiContext;
        if (mobiContext != null)
          return mobiContext as MobiContext;

        mobiContext = new MobiContext(httpContext, WebApplication.GetRuntime(httpContext));
        httpContext.Items[MobiHttpContextItemKey] = mobiContext;
        return mobiContext;
      }
    }


    public MobiContext(HttpContext context, IRuntime runtime)
      : base(context, runtime)
    {
      string hostName = context.Request.Url.Host; //httpContext.Request.ServerVariables["HTTP_HOST"]; 
      this._domain = this.Runtime.GetDomain(hostName);

      if (this._domain == null)
        throw new InvalidOperationException(string.Format("Domain name '{0}' is not registered in database.", hostName));

      // SERVICE
      this._service = this.Runtime.GetService(hostName);

      /// IGNORE SESSION INITIALIZATION WITH THIS ROUTE NAMES
      if (!this.HttpContext.Request.Url.ToString().Contains("/thumbnail/") ||
        (!this.HttpContext.Request.Url.ToString().Contains("/logo/") && !this.HttpContext.Request.Url.ToString().EndsWith("/logo")) ||
        (!this.HttpContext.Request.Url.ToString().Contains("/ping")))
        this.InitializeSession(context);

    }

    protected virtual void InitializeSession(HttpContext httpContext)
    {
      string sessionID = httpContext.Session.SessionID;
      Guid sessionGuid = Guid.Empty;
      if (!Guid.TryParseExact(sessionID, "N", out sessionGuid))
      {
        Log.Error("Invalid session ID" + sessionGuid);    
      }
       
      IUserSessionManager usManager = UserSession.CreateManager();
      UserSession session = usManager.Load(this.Service.ServiceData, sessionGuid);
       
      if (session != null && session.IPAddress != httpContext.Request.UserHostAddress)
      {
        Log.Error("Session hijack!");
      }
      
      if (session == null)
      {

        // TODO: Remove this in production
        string ipAddress = !httpContext.Request.UserHostAddress.Equals("::1") && !httpContext.Request.UserHostAddress.StartsWith("192.") ?
          httpContext.Request.UserHostAddress :
          "78.155.61.246";
        
        IIPCountryMapManager ipcmManager = IPCountryMap.CreateManager();
        IPCountryMap countryMap = ipcmManager.Load(ipAddress);

        Language language = countryMap.Country.Language != null ? countryMap.Country.Language : Language.CreateManager().Load("EN", LanguageIdentifier.TwoLetterIsoCode);
        
        session = new UserSession(-1,
          sessionGuid,
          this.Service.ServiceData.UserSessionType,
          this.Service.ServiceData,
          null,
          this.Domain,
          null,
          countryMap.Country,
          language,
          null,
          null,
          httpContext.Request.UserHostAddress,
          httpContext.Request.UserAgent,
          httpContext.Request.Url.ToString(),
          httpContext.Request.UrlReferrer != null ? httpContext.Request.UrlReferrer.ToString() : null,
          false,
          DateTime.Now.AddMinutes(20),
          DateTime.Now, DateTime.Now);
        
        // TODO: Make this dynamic
        if (!session.EntranceUrl.Contains("/thumbnail") &&
          !session.EntranceUrl.EndsWith("/logo"))
          session.Insert();

        //INFO: DO NOT DO ANYTHING WITH THIS LINE BELOW!!!
        httpContext.Session["someValue"] = "bla";
      }

      this._session = new WebUserSession(session);
    }

    public ServiceConfigurationEntry GetConfiguration()
    {
      return this.Service.GetConfiguration(this.Session.SessionData.Country);
    }

    public ILocalization GetLocalization()
    {
      try
      {
        ILocalization localization = this.HttpContext.Items[MobiLocalizationItemKey] as ILocalization;
        if (localization != null)
          return localization;

        //Language language = this.Session.GetUserSessionLanguage();
        Language language = this.Service.ServiceData.FallbackLanguage;
        KeyValuePair<MobiChat.Data.Localization, ILocalizationProvider> translationMapKeyEntry = (from tmk in this.Runtime.LocalizationProviders
                                                                                                       where tmk.Key.Application.ID == this.Runtime.ApplicationData.ID && 
                                                                                                        (tmk.Key.Product == null || tmk.Key.Product.ID == this.Service.ServiceData.Product.ID )
                                                                                                       select tmk).FirstOrDefault();

        TranslationKey translationKey = new TranslationKey(translationMapKeyEntry.Key, language, this.Service.ServiceData);
        localization = translationMapKeyEntry.Value.GetLocalization(translationKey);
        localization = this.ConfigureTranslationWildcards(localization);
        this.HttpContext.Items[MobiLocalizationItemKey] = localization;

        return localization;
      }
      catch (Exception ex)
      {
        Log.Error("Exception while creating localization...", ex);
        return null;
      }
    }

    // SUMMARY: Replace wildcards from translations with values refering service
    public ILocalization ConfigureTranslationWildcards(ILocalization localization)
    {
      MobiChatWebLocalization mobiChatLocalization = localization as MobiChatWebLocalization;
      List<TranslationGroup> translationGroups = TranslationGroup.CreateManager().Load(Translation.CreateManager().Load(1));
      foreach (TranslationGroup tg in translationGroups)
      {
        ILocalizationGroup groupItem = mobiChatLocalization.GetGroup(tg.Name);
        if (groupItem == null)
          continue;

        foreach (TranslationGroupKey tgk in tg.Keys)
        {
          string groupKeyText = groupItem.GetValue(tgk.Name);
          if (string.IsNullOrEmpty(groupKeyText))
            continue;

          //groupKeyText = TranslationValue.Conditions(groupKeyText, MobiContext.Current.Service);
          groupKeyText = groupKeyText.Replace("[Service.ID]", MobiContext.Current.Service.ServiceData.ID.ToString());
          groupKeyText = groupKeyText.Replace("[Service.Name]", MobiContext.Current.Service.ServiceData.Name);
          groupKeyText = groupKeyText.Replace("[Service.Url]", string.Format("http://{0}", MobiContext.Current.Service.ServiceData.Name));
          //groupKeyText = groupKeyText.Replace("[Service.Price]", MobiContext.Current.Service.ServiceInfo != null ? MobiContext.Current.Service.ServiceInfo.DynamicPrice() : string.Empty);
          //groupKeyText = groupKeyText.Replace("[Service.Type]", MobiContext.Current.Service.ServiceInfo != null ? MobiContext.Current.Service.ServiceInfo.TemplateServiceType.ToString() : string.Empty);
          groupKeyText = groupKeyText.Replace("[Service.Country]", MobiContext.Current.Service.ServiceData.FallbackLanguage.GlobalName);
          groupKeyText = groupKeyText.Replace("[Merchant.Name]", MobiContext.Current.Service.ServiceData.Merchant.Name);
          groupKeyText = groupKeyText.Replace("[Merchant.Address]", MobiContext.Current.Service.ServiceData.Merchant.Address);
          //groupKeyText = groupKeyText.Replace("[PaymentProvider.Name]", MobiContext.Current.Service.PaymentProvider.Name);

          //Log.Debug(new LogMessageBuilder(new PaywallLogErrorCode("paywallcontext", "getlocalization", "exception"), string.Format(" - WILDCARD TRANSLATION - Change has been made in Group: {0}, Key: {1}, Value: {2}", group, groupKey, groupKeyText)));
          mobiChatLocalization.GetGroup(tg.Name).AssignValue(tgk.Name, groupKeyText);
        }
      }

      return mobiChatLocalization;
    }
    
    public void SetTemplateSession(IUserSession session)
    {
      this._session = session;
    }

    public static string AppendSessionID(string url)
    {
      MobiContext mobiContext = Current;
      string sessionID = mobiContext.Session.SessionData.Guid.ToString().Replace("-", "");
      string sessionPath = MobiChat.Constants.SessionID + "/" + sessionID;

      if (url.Contains(MobiChat.Constants.SessionID + "/"))
      {
        if (url.Contains(sessionPath))
        {
          //INFO: Session in URL matches session in context.
          //Log.Debug(new LogMessageBuilder(new PaywallLogErrorCode("web.core", "urlhelper", "match"),
          //  string.Format("SessionID in URL ({0}) matches SessionID ({1}) from context.", url, sessionID)));
          Log.Info("Session in URL matches session in context.");
          return url;
        }
        else
        {
          //INFO: Session in URL does NOT match session in context.
          //Log.Debug(new LogMessageBuilder(new PaywallLogErrorCode("web.core", "urlhelper", "match"),
          //  string.Format("SessionID in URL ({0}) does NOT match SessionID ({1}) from context.", url, sessionID)));
          Log.Info("Session in URL does NOT match session in context");
          return "/";
        }
      }
      else
      {
        //INFO: Session is not provided in URL. So append it.
        //Log.Debug(new LogMessageBuilder(new PaywallLogErrorCode("web.core", "urlhelper", "notprovided"),
        //    string.Format("SessionID is not provided in URL ({0}). SessionID ({1}) from context will be appended to URL.", url, sessionID)));
        Log.Info("Session is not provided in URL. So append it.");
        url = PrepareUrl(url, sessionPath);
      }

      if (!url.StartsWith("/"))
        url = "/" + url;

      //Log.Debug(new LogMessageBuilder(new PaywallLogErrorCode("web.core", "urlhelper", "end"),
      //    string.Format("Final URL ({0})", url)));
      return url;
    }

    private static string PrepareUrl(string url, string sessionPath)
    {
      if (url.Contains("?"))
      {
        string[] parts = url.Split('?');
        if (parts[0].EndsWith("/"))
          url = url.Replace("?", sessionPath + "?");
        else
          url = url.Replace("?", "/" + sessionPath + "?");
      }
      else
        if (!url.EndsWith("/"))
          url += "/" + sessionPath;
        else
          url += sessionPath;

      return url;
    }

  }
}
