using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Senti.Localization;

namespace MobiChat.Web.Core.Localization
{
  public class ControlsLocalizationGroup : ILocalizationGroup 
  {
    public static readonly ControlsLocalizationGroup Empty = new ControlsLocalizationGroup();

    private MobiChatWebLocalization _localization = null;

    protected bool IsEmpty { get { return this._localization == null; } }
    protected MobiChatWebLocalization Localization { get { return this._localization; } }

    private string _loadMore  = null;
		private string _menu  = null;
		

    public string LoadMore  { get { return this._loadMore  ?? ((this.Localization.HasFallback && this.Localization.Fallback.Controls != null) ? this.Localization.Fallback.Controls.LoadMore  : string.Empty); } }
		public string Menu  { get { return this._menu  ?? ((this.Localization.HasFallback && this.Localization.Fallback.Controls != null) ? this.Localization.Fallback.Controls.Menu  : string.Empty); } }
		

    private ControlsLocalizationGroup()
    {
      this._loadMore  = string.Empty;
				this._menu  = string.Empty;
				
    }

    public ControlsLocalizationGroup(MobiChatWebLocalization localization)
    {
      this._localization = localization;
    }

    public string GetValue(string key)
    {
      switch (key)
      {
        case "LoadMore ":
					return this.LoadMore ;
				case "Menu ":
					return this.Menu ;
				
        default:
          return null;
      }
    }

    public bool AssignValue(string key, string value)
    {
      switch (key)
      {
        case "LoadMore ":
					this._loadMore  = value;
					return true;
				case "Menu ":
					this._menu  = value;
					return true;
				
        default:
          return false;
      }
    }
  }
}
