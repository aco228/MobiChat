using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MobiChat.Statistics.Core.Model
{
  public class MobiViewModelBase
  {

    private MobiContext _mobiContext = null;
    private string _htmlTitle = string.Empty;

    public MobiContext MobiContext { get { return this._mobiContext; } }
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
