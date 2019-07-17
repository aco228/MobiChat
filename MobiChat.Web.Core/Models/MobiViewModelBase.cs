using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MobiChat.Web.Core
{
  public class MobiViewModelBase
  {

    private MobiContext _mobiContext = null;
    private string _htmlTitle = string.Empty;

    public string HtmlTitle { get { return string.IsNullOrEmpty(this._htmlTitle) ? this._mobiContext.Service.ServiceData.Name : this._htmlTitle; } }
    public MobiContext MobiContext{get{return this._mobiContext;}}
    public HttpContext HttpContext { get { return this._mobiContext.HttpContext; } } 

    public MobiViewModelBase(MobiContext context)
    {
      this._mobiContext = context;
    }

    public string GetLogoUrl()
    {
      return "/logo";
    }


  }
}
