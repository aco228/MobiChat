using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Senti.Localization;

namespace MobiChat.Web.Core.Localization
{
  public class SEOLocalizationGroup : ILocalizationGroup 
  {
    public static readonly SEOLocalizationGroup Empty = new SEOLocalizationGroup();

    private MobiChatWebLocalization _localization = null;

    protected bool IsEmpty { get { return this._localization == null; } }
    protected MobiChatWebLocalization Localization { get { return this._localization; } }

    private string _title  = null;
		private string _keywords  = null;
		private string _description  = null;
		private string _gaid  = null;
		

    public string Title  { get { return this._title  ?? ((this.Localization.HasFallback && this.Localization.Fallback.SEO != null) ? this.Localization.Fallback.SEO.Title  : string.Empty); } }
		public string Keywords  { get { return this._keywords  ?? ((this.Localization.HasFallback && this.Localization.Fallback.SEO != null) ? this.Localization.Fallback.SEO.Keywords  : string.Empty); } }
		public string Description  { get { return this._description  ?? ((this.Localization.HasFallback && this.Localization.Fallback.SEO != null) ? this.Localization.Fallback.SEO.Description  : string.Empty); } }
		public string Gaid  { get { return this._gaid  ?? ((this.Localization.HasFallback && this.Localization.Fallback.SEO != null) ? this.Localization.Fallback.SEO.Gaid  : string.Empty); } }
		

    private SEOLocalizationGroup()
    {
      this._title  = string.Empty;
				this._keywords  = string.Empty;
				this._description  = string.Empty;
				this._gaid  = string.Empty;
				
    }

    public SEOLocalizationGroup(MobiChatWebLocalization localization)
    {
      this._localization = localization;
    }

    public string GetValue(string key)
    {
      switch (key)
      {
        case "Title ":
					return this.Title ;
				case "Keywords ":
					return this.Keywords ;
				case "Description ":
					return this.Description ;
				case "Gaid ":
					return this.Gaid ;
				
        default:
          return null;
      }
    }

    public bool AssignValue(string key, string value)
    {
      switch (key)
      {
        case "Title ":
					this._title  = value;
					return true;
				case "Keywords ":
					this._keywords  = value;
					return true;
				case "Description ":
					this._description  = value;
					return true;
				case "Gaid ":
					this._gaid  = value;
					return true;
				
        default:
          return false;
      }
    }
  }
}
