using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Senti.Localization;

namespace MobiChat.Web.Core.Localization
{
  public class AVSLocalizationGroup : ILocalizationGroup 
  {
    public static readonly AVSLocalizationGroup Empty = new AVSLocalizationGroup();

    private MobiChatWebLocalization _localization = null;

    protected bool IsEmpty { get { return this._localization == null; } }
    protected MobiChatWebLocalization Localization { get { return this._localization; } }

    private string _title = null;
		private string _confirm = null;
		private string _deny = null;
		private string _question = null;
		private string _denyUrl = null;
		

    public string Title { get { return this._title ?? ((this.Localization.HasFallback && this.Localization.Fallback.AVS != null) ? this.Localization.Fallback.AVS.Title : string.Empty); } }
		public string Confirm { get { return this._confirm ?? ((this.Localization.HasFallback && this.Localization.Fallback.AVS != null) ? this.Localization.Fallback.AVS.Confirm : string.Empty); } }
		public string Deny { get { return this._deny ?? ((this.Localization.HasFallback && this.Localization.Fallback.AVS != null) ? this.Localization.Fallback.AVS.Deny : string.Empty); } }
		public string Question { get { return this._question ?? ((this.Localization.HasFallback && this.Localization.Fallback.AVS != null) ? this.Localization.Fallback.AVS.Question : string.Empty); } }
		public string DenyUrl { get { return this._denyUrl ?? ((this.Localization.HasFallback && this.Localization.Fallback.AVS != null) ? this.Localization.Fallback.AVS.DenyUrl : string.Empty); } }
		

    private AVSLocalizationGroup()
    {
      this._title = string.Empty;
				this._confirm = string.Empty;
				this._deny = string.Empty;
				this._question = string.Empty;
				this._denyUrl = string.Empty;
				
    }

    public AVSLocalizationGroup(MobiChatWebLocalization localization)
    {
      this._localization = localization;
    }

    public string GetValue(string key)
    {
      switch (key)
      {
        case "Title":
					return this.Title;
				case "Confirm":
					return this.Confirm;
				case "Deny":
					return this.Deny;
				case "Question":
					return this.Question;
				case "DenyUrl":
					return this.DenyUrl;
				
        default:
          return null;
      }
    }

    public bool AssignValue(string key, string value)
    {
      switch (key)
      {
        case "Title":
					this._title = value;
					return true;
				case "Confirm":
					this._confirm = value;
					return true;
				case "Deny":
					this._deny = value;
					return true;
				case "Question":
					this._question = value;
					return true;
				case "DenyUrl":
					this._denyUrl = value;
					return true;
				
        default:
          return false;
      }
    }
  }
}
