using log4net;
using MobiChat.Data;
using Senti.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MobiChat.Service.Core
{
  public class MobiContext : MobiChatContextBase
  {

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

    protected static readonly string MobiHttpContextItemKey = "MobiHttpContextItemKey";
    protected static readonly string MobiLocalizationItemKey = "MobiLocalizationItemKey";

    private Guid _sessionGuid = Guid.Empty;

    public Guid SessionGuid { get { return this._sessionGuid; } }

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
      try
      {
        lock (httpContext.Request)
        {
          MobiContext mobiContext = httpContext.Items[MobiHttpContextItemKey] as MobiContext;
          if (mobiContext != null)
            return mobiContext as MobiContext;

          mobiContext = new MobiContext(httpContext, ServiceCallbackApplication.GetRuntime(httpContext));
          httpContext.Items[MobiHttpContextItemKey] = mobiContext;
          return mobiContext;
        }
      }
      catch(Exception e)
      {
        MobiContext mobiContext = httpContext.Items[MobiHttpContextItemKey] as MobiContext;
        if (mobiContext != null)
          return mobiContext as MobiContext;

        mobiContext = new MobiContext(httpContext, ServiceCallbackApplication.GetRuntime(httpContext));
        httpContext.Items[MobiHttpContextItemKey] = mobiContext;
        return mobiContext;
      }
    }


    public MobiContext(HttpContext context, IRuntime runtime)
      : base(context, runtime)
    {
      /// IGNORE SESSION INITIALIZATION WITH THIS ROUTE NAMES
      this.InitializeSession(context);
    }
    
    protected virtual void InitializeSession(HttpContext httpContext)
    {
      if (this._sessionGuid == Guid.Empty)
        this._sessionGuid = Guid.NewGuid();
      
      //INFO: DO NOT DO ANYTHING WITH THIS LINE BELOW!!!
      //httpContext.Session["someValue"] = "bla";
    }

    public ServiceConfigurationEntry GetConfiguration()
    {
      throw new NotImplementedException();
    }

    public ILocalization GetLocalization()
    {
      throw new NotImplementedException();
    }

    public void SetTemplateSession(IUserSession session)
    {
      throw new NotImplementedException();
    }

    public static string AppendSessionID(string url)
    {
      return string.Empty;     
    }

    private static string PrepareUrl(string url, string sessionPath)
    {
      return string.Empty;
    }
  }
}
