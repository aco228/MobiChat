using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MobiChat.Management.Core
{
  public class MobiActionFilterAttributeBase : ActionFilterAttribute, IMobiActionFilterAttributeBase
  {
    private bool _required = false;

    public bool Required { get { return this._required; } set { this._required = value; } }
    public MobiChat.Data.ServiceConfigurationEntry Configuration { get { return this.MobiContext.GetConfiguration(); } }
    public MobiContext MobiContext { get { return MobiContext.Current; } }

  }
}
