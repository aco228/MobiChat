using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MobiChat.Management.Core
{

  public class MobiController : Controller, IMobiController
  {
    private MobiContext _mobiContext = null;
    private ManagementApplication _application = null;

    public MobiContext MobiContext { get { return MobiContext.Current; } }

    public ManagementApplication MobiApplication
    {
      get
      {
        if (this._application != null)
          this._application = this.HttpContext.ApplicationInstance as ManagementApplication;
        return this._application;
      }
    }

  }
}
