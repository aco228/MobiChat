using MobiChat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MobiChat.Statistics.Core
{
  public class MobiContext : MobiChatContextBase
  {
    protected static readonly string MobiHttpContextItemKey = "MobiHttpContextItemKey";
    protected static readonly string MobiLocalizationItemKey = "MobiLocalizationItemKey";
    private IUserSession _session = null;

    public static MobiContext Current
    {
      get
      {
        HttpContext httpContext = HttpContext.Current;
        return MobiContext.GetCurrent(httpContext);
      }
    }
    public IUserSession Session { get { return this._session; } }
    public StatisticsUserSession StatisticsUserSession { get { return this._session as StatisticsUserSession; } }

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

        mobiContext = new MobiContext(httpContext, StatisticsApplication.GetRuntime(httpContext));
        httpContext.Items[MobiHttpContextItemKey] = mobiContext;
        return mobiContext;
      }
    }


    public MobiContext(HttpContext context, IRuntime runtime)
      : base(context, runtime)
    {
      string hostName = context.Request.Url.Host; //httpContext.Request.ServerVariables["HTTP_HOST"]; 

      /// IGNORE SESSION INITIALIZATION WITH THIS ROUTE NAMES
      this.InitializeSession(context);
    }


    protected virtual void InitializeSession(HttpContext httpContext)
    {
      string sessionID = httpContext.Session.SessionID;
      Guid sessionGuid = Guid.Empty;
      if (!Guid.TryParseExact(sessionID, "N", out sessionGuid))
      {
        // TODO: log4net
        //if (Log.IsWarnEnabled)
        //  Log.Warn(new LogMessageBuilder(
        //    new LogErrorCode("paywall.web.core", "paywallhttpcontext", "initializesession"),
        //      "Invalid session ID", sessionGuid));

        throw new ArgumentException("MobiContext: Could not parse Session guid");
      }

      IUserSessionManager usManager = UserSession.CreateManager();
      UserSession session = usManager.Load(sessionGuid);

      if (session != null && session.IPAddress != httpContext.Request.UserHostAddress)
      {
        // TODO: Session hijack.. log
      }

      if (session == null)
      {
        IIPCountryMapManager ipcmManager = IPCountryMap.CreateManager();

        // TODO: Remove this in production
        string ipAddress = !httpContext.Request.UserHostAddress.Equals("::1") && !httpContext.Request.UserHostAddress.StartsWith("192.") ?
          httpContext.Request.UserHostAddress :
          "78.155.61.246";

        IPCountryMap countryMap = ipcmManager.Load(ipAddress);
        Language language = countryMap.Country.Language != null ? countryMap.Country.Language : Language.CreateManager().Load("EN", LanguageIdentifier.TwoLetterIsoCode);

        session = new UserSession(-1,
          sessionGuid,
          StatisticsApplication.GetDefaultUserSessionType(),
          null, // service
          this.Runtime.ApplicationData,
          null, // domain,
          null, // user,
          countryMap.Country,
          language, // language
          null, // mobileOperator
          null, // trackingID,
          httpContext.Request.UserHostAddress,
          httpContext.Request.UserAgent,
          httpContext.Request.Url.ToString().Replace(" ", string.Empty),
          httpContext.Request.UrlReferrer != null ? httpContext.Request.UrlReferrer.ToString() : null,
          false,
          DateTime.Now.AddMinutes(20),
          DateTime.Now, DateTime.Now);

        session.Insert();

        //INFO: DO NOT DO ANYTHING WITH THIS LINE BELOW!!!
        httpContext.Session["someValue"] = "bla";
      }

      this._session = new StatisticsUserSession(session);
    }

    public ServiceConfigurationEntry GetConfiguration()
    {
      // TODO: Implement this
      throw new NotImplementedException();
    }

    // TODO: Localization

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
          return url;
        }
        else
        {
          //INFO: Session in URL does NOT match session in context.
          //Log.Debug(new LogMessageBuilder(new PaywallLogErrorCode("web.core", "urlhelper", "match"),
          //  string.Format("SessionID in URL ({0}) does NOT match SessionID ({1}) from context.", url, sessionID)));
          return "/";
        }
      }
      else
      {
        //INFO: Session is not provided in URL. So append it.
        //Log.Debug(new LogMessageBuilder(new PaywallLogErrorCode("web.core", "urlhelper", "notprovided"),
        //    string.Format("SessionID is not provided in URL ({0}). SessionID ({1}) from context will be appended to URL.", url, sessionID)));
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
