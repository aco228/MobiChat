using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MobiChat
{
  public abstract class MobiChatContextBase : IMobiChatContext
  {
    private HttpContext _httpContext = null;
    private IRuntime _runtime = null;

    public System.Web.HttpContext HttpContext { get { return this._httpContext; } }
    public IRuntime Runtime { get { return this._runtime; } }

    public MobiChatContextBase(HttpContext context, IRuntime runtime)
    {
      this._runtime = runtime;
      this._httpContext = context;
    }

  }
}
