using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Senti.Localization;

namespace MobiChat.Web.Core.Localization
{
  public class ErrorLocalizationGroup : ILocalizationGroup 
  {
    public static readonly ErrorLocalizationGroup Empty = new ErrorLocalizationGroup();

    private MobiChatWebLocalization _localization = null;

    protected bool IsEmpty { get { return this._localization == null; } }
    protected MobiChatWebLocalization Localization { get { return this._localization; } }

    private string _errInternal  = null;
		private string _errApplication  = null;
		private string _errService  = null;
		private string _errCounty  = null;
		private string _errTitle  = null;
		

    public string ErrInternal  { get { return this._errInternal  ?? ((this.Localization.HasFallback && this.Localization.Fallback.Error != null) ? this.Localization.Fallback.Error.ErrInternal  : string.Empty); } }
		public string ErrApplication  { get { return this._errApplication  ?? ((this.Localization.HasFallback && this.Localization.Fallback.Error != null) ? this.Localization.Fallback.Error.ErrApplication  : string.Empty); } }
		public string ErrService  { get { return this._errService  ?? ((this.Localization.HasFallback && this.Localization.Fallback.Error != null) ? this.Localization.Fallback.Error.ErrService  : string.Empty); } }
		public string ErrCounty  { get { return this._errCounty  ?? ((this.Localization.HasFallback && this.Localization.Fallback.Error != null) ? this.Localization.Fallback.Error.ErrCounty  : string.Empty); } }
		public string ErrTitle  { get { return this._errTitle  ?? ((this.Localization.HasFallback && this.Localization.Fallback.Error != null) ? this.Localization.Fallback.Error.ErrTitle  : string.Empty); } }
		

    private ErrorLocalizationGroup()
    {
      this._errInternal  = string.Empty;
				this._errApplication  = string.Empty;
				this._errService  = string.Empty;
				this._errCounty  = string.Empty;
				this._errTitle  = string.Empty;
				
    }

    public ErrorLocalizationGroup(MobiChatWebLocalization localization)
    {
      this._localization = localization;
    }

    public string GetValue(string key)
    {
      switch (key)
      {
        case "ErrInternal ":
					return this.ErrInternal ;
				case "ErrApplication ":
					return this.ErrApplication ;
				case "ErrService ":
					return this.ErrService ;
				case "ErrCounty ":
					return this.ErrCounty ;
				case "ErrTitle ":
					return this.ErrTitle ;
				
        default:
          return null;
      }
    }

    public bool AssignValue(string key, string value)
    {
      switch (key)
      {
        case "ErrInternal ":
					this._errInternal  = value;
					return true;
				case "ErrApplication ":
					this._errApplication  = value;
					return true;
				case "ErrService ":
					this._errService  = value;
					return true;
				case "ErrCounty ":
					this._errCounty  = value;
					return true;
				case "ErrTitle ":
					this._errTitle  = value;
					return true;
				
        default:
          return false;
      }
    }
  }
}
