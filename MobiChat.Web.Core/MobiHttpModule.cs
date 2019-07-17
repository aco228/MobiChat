using MobiChat.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MobiChat.Web
{
  public class MobiHttpModule : IHttpModule
  {
    private HttpApplication _application = null;

    public void Init(HttpApplication context)
    {
      WebApplication paywallApplication = context as WebApplication;
      if (paywallApplication == null)
        throw new InvalidOperationException("PaywallHttpModule only works in conjunction with a PaywallHttpApplication.");
      this._application = context;
      MobiChat.Data.Application application = WebApplication.GetRuntime(_application).ApplicationData;
      context.PreRequestHandlerExecute += new EventHandler(this.ApplicationPreRequestHandlerExecute);
    }

    private void ApplicationPreRequestHandlerExecute(object sender, EventArgs e)
    {
      // TODO question: should we remove this now?
      HttpContext context = HttpContext.Current;
      string a = string.Empty;
    }


    public void Dispose()
    {
      return;
    }
  }
}
