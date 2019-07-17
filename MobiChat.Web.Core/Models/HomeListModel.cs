using MobiChat.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Web.Core.Models
{
  public class HomeListModel : MobiViewModelBase
  {

    private int _profileCount = -1;
    private int _defaultDisplay = 0;
    private List<ICacheContent> _content = null;

    public List<ICacheContent> Content { get { return this._content; } set { this._content = value; } }
    public int ProfileCount { get { return this._profileCount; } set { this._profileCount = value; } }
    public int DefaultDisplay { get { return this._defaultDisplay; } set { this._defaultDisplay = value; } }

    public HomeListModel(MobiContext context)
      : base(context)
    {

    }

  }
}
