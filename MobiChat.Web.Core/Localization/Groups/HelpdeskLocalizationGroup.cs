using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Senti.Localization;

namespace MobiChat.Web.Core.Localization
{
  public class HelpdeskLocalizationGroup : ILocalizationGroup 
  {
    public static readonly HelpdeskLocalizationGroup Empty = new HelpdeskLocalizationGroup();

    private MobiChatWebLocalization _localization = null;

    protected bool IsEmpty { get { return this._localization == null; } }
    protected MobiChatWebLocalization Localization { get { return this._localization; } }

    private string _header  = null;
		private string _title  = null;
		private string _text  = null;
		

    public string Header  { get { return this._header  ?? ((this.Localization.HasFallback && this.Localization.Fallback.Helpdesk != null) ? this.Localization.Fallback.Helpdesk.Header  : string.Empty); } }
		public string Title  { get { return this._title  ?? ((this.Localization.HasFallback && this.Localization.Fallback.Helpdesk != null) ? this.Localization.Fallback.Helpdesk.Title  : string.Empty); } }
		public string Text  { get { return this._text  ?? ((this.Localization.HasFallback && this.Localization.Fallback.Helpdesk != null) ? this.Localization.Fallback.Helpdesk.Text  : string.Empty); } }
		

    private HelpdeskLocalizationGroup()
    {
      this._header  = string.Empty;
				this._title  = string.Empty;
				this._text  = string.Empty;
				
    }

    public HelpdeskLocalizationGroup(MobiChatWebLocalization localization)
    {
      this._localization = localization;
    }

    public string GetValue(string key)
    {
      switch (key)
      {
        case "Header ":
					return this.Header ;
				case "Title ":
					return this.Title ;
				case "Text ":
					return this.Text ;
				
        default:
          return null;
      }
    }

    public bool AssignValue(string key, string value)
    {
      switch (key)
      {
        case "Header ":
					this._header  = value;
					return true;
				case "Title ":
					this._title  = value;
					return true;
				case "Text ":
					this._text  = value;
					return true;
				
        default:
          return false;
      }
    }
  }
}
