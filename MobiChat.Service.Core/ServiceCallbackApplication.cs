using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;

namespace MobiChat.Service.Core
{
  public class ServiceCallbackApplication : HttpApplication
  {

    #region #logging#

    private static ILog _log = null;

    protected static ILog Log
    {
      get
      {
        if (ServiceCallbackApplication._log == null)
          ServiceCallbackApplication._log = LogManager.GetLogger(typeof(ServiceCallbackApplication));
        return ServiceCallbackApplication._log;
      }
    }

    #endregion #logging#

    private ApplicationBase _baseApplication = null;

    public ApplicationBase BaseApplication { get { return this._baseApplication; } }

    private static readonly object HasPreExecuteRequestHandlerListenerLockObject = new object();
    private static readonly object MobiHttpApplicationInitializeRuntimeLockObject = new object();
    private static readonly string MobiRuntimeApplicationKey = "MobiRuntimeApplicationKey";

    public static bool HasRuntime(HttpContext context)
    {
      return ServiceCallbackApplication.HasRuntime(context.Application);
    }

    public static bool HasRuntime(HttpApplication application)
    {
      return ServiceCallbackApplication.HasRuntime(application.Application);
    }

    public static bool HasRuntime(HttpApplicationState state)
    {
      return state[ServiceCallbackApplication.MobiRuntimeApplicationKey] != null;
    }

    public static IRuntime GetRuntime(HttpContext context)
    {
      return ServiceCallbackApplication.GetRuntime(context.Application);
    }

    public static IRuntime GetRuntime(HttpApplication application)
    {
      return ServiceCallbackApplication.GetRuntime(application.Application);
    }

    public static IRuntime GetRuntime(HttpApplicationState state)
    {
      return state[ServiceCallbackApplication.MobiRuntimeApplicationKey] as IRuntime;
    }

    protected static void SetRuntime(HttpContext context, IRuntime runtime)
    {
      ServiceCallbackApplication.SetRuntime(context.Application, runtime);
    }

    protected static void SetRuntime(HttpApplication application, IRuntime runtime)
    {
      ServiceCallbackApplication.SetRuntime(application.Application, runtime);
    }

    protected static void SetRuntime(HttpApplicationState state, IRuntime runtime)
    {
      state[ServiceCallbackApplication.MobiRuntimeApplicationKey] = runtime;
    }

    public override void Init()
    {
      base.Init();

      //LogMessageBuilder builder = null;
      MobiChat.Data.Sql.Database dummy = null;
      Senti.Data.DataLayerRuntime r = new Senti.Data.DataLayerRuntime();
      log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(Server.MapPath("~/log4net.config")));

      try
      {
        this.InitializeRuntime();
      }
      catch (Exception ex)
      {
        //builder = new LogMessageBuilder(new LogErrorCode("paywall.web.core", "paywallhttpapplication", "init"), "");
        //if (Log.IsFatalEnabled)
        //  Log.Fatal(builder, ex);
        throw new ArgumentException(ex.Message);
      }
    }

    protected virtual void InitializeRuntime()
    {
      if (ServiceCallbackApplication.HasRuntime(this))
        return;

      lock (MobiHttpApplicationInitializeRuntimeLockObject)
      {
        //string name = HostingEnvironment.SiteName;
        if (ServiceCallbackApplication.HasRuntime(this))
          return;

        // TODO: Load application differently
        this._baseApplication = new ApplicationBase(MobiChat.Data.Application.CreateManager().Load(3));
        //MobilePaywall.Data.Application application = appManager.Load(HostingEnvironment.SiteName);

        if (this._baseApplication == null)
        {
          //Log.Fatal(new LogMessageBuilder(new LogErrorCode("paywall.web.core", "paywallhttpapplication", "initializeruntime"),
          //  string.Format("Application {0} is not loaded.", HostingEnvironment.SiteName), application));

          throw new InvalidOperationException(string.Format("No application with name '{0}' registered in database.", HostingEnvironment.SiteName));
        }

        IRuntime runtime = this._baseApplication.ApplicationData.InstantiateRuntime();
        if (!runtime.Initialize(HostingEnvironment.SiteName))
        {
          return;
        }

        ServiceCallbackApplication.SetRuntime(this, runtime);
        Log.Info("ServiceCallbackApplication initialized!");
        this.InitializeApplication();
      }

      //Log.Info(new LogMessageBuilder(new LogErrorCode("paywall.web.core", "paywallhttpapplication", "initializeruntime"),
      //  "Initialization of PaywallHttpApplication(" + HostingEnvironment.SiteName + ") is complete"));

      return;
    }

    protected virtual void InitializeApplication()
    {
    }

    protected virtual void Application_Error(object sender, EventArgs e)
    {
      HttpContext context = HttpContext.Current;
      Exception lastExceptionWhichWasNotHandled = context.Server.GetLastError();

      // Print error message if neccesssery
      string errorMessage = "";
      if (context.Request.RawUrl.Contains("dbg=true"))
        errorMessage = lastExceptionWhichWasNotHandled.Message.ToString() + "<br/><br/>" + lastExceptionWhichWasNotHandled.InnerException.Message.ToString();

      this.Response.Write("<strong style=\"color:red\">Application error!</strong> Please contact system administrator! <br/><br/><br/> "); // + 
      //(context.Request.RawUrl.Contains("dbg=") ? errorMessage : "(dbg not included)"));

      //Log.Debug(new LogMessageBuilder(new LogErrorCode(), "ApplicationFatal"), lastExceptionWhichWasNotHandled);
      Log.Fatal("FATAL!!! ", lastExceptionWhichWasNotHandled);

      this.Response.Flush();
      this.Response.Close();
    }

    protected virtual void Application_PreRequestHandlerExecute(object sender, EventArgs e)
    {
      //IPaywallRuntime runtime = PaywallHttpApplication.GetRuntime(this);
      HttpContext httpContext = HttpContext.Current;

      if (HttpContext.Current.Session == null)
        return;

      //if (HttpContext.Current.Handler == null || HttpContext.Current.Session == null ||
      //		HttpContext.Current.Handler.GetType().IsAssignableFrom(typeof(IRequiresSessionState)))
      //	return;

      MobiContext mobiContext = MobiContext.Current;
      return;
    }
  }
}
