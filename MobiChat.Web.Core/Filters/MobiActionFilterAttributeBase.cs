using MobiChat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MobiChat.Web.Core
{
  public class MobiActionFilterAttributeBase : ActionFilterAttribute
  {
    private bool _required = false;

    public bool Required { get { return this._required; } set { this._required = value; } }
    public MobiChat.Data.ServiceConfigurationEntry Configuration { get { return MobiContext.Current.GetConfiguration(); } }
    public MobiContext MobiContext { get { return MobiContext.Current; } }

    public MobiActionFilterAttributeBase() { }




  }
}
