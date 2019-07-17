using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Senti.Localization;

namespace MobiChat.Web.Core.Localization
{
  public class HomeLocalizationGroup : ILocalizationGroup 
  {
    public static readonly HomeLocalizationGroup Empty = new HomeLocalizationGroup();

    private MobiChatWebLocalization _localization = null;

    protected bool IsEmpty { get { return this._localization == null; } }
    protected MobiChatWebLocalization Localization { get { return this._localization; } }

    private string _header1  = null;
		private string _header2  = null;
		private string _header3  = null;
		private string _notification1 = null;
		private string _notification2 = null;
		private string _notification3 = null;
		private string _title = null;
		private string _text1 = null;
		private string _text2 = null;
		private string _text3 = null;
		private string _text4 = null;
		private string _text5 = null;
		private string _text6 = null;
		private string _text7 = null;
		private string _text8 = null;
		private string _text9 = null;
		private string _text10 = null;
		

    public string Header1  { get { return this._header1  ?? ((this.Localization.HasFallback && this.Localization.Fallback.Home != null) ? this.Localization.Fallback.Home.Header1  : string.Empty); } }
		public string Header2  { get { return this._header2  ?? ((this.Localization.HasFallback && this.Localization.Fallback.Home != null) ? this.Localization.Fallback.Home.Header2  : string.Empty); } }
		public string Header3  { get { return this._header3  ?? ((this.Localization.HasFallback && this.Localization.Fallback.Home != null) ? this.Localization.Fallback.Home.Header3  : string.Empty); } }
		public string Notification1 { get { return this._notification1 ?? ((this.Localization.HasFallback && this.Localization.Fallback.Home != null) ? this.Localization.Fallback.Home.Notification1 : string.Empty); } }
		public string Notification2 { get { return this._notification2 ?? ((this.Localization.HasFallback && this.Localization.Fallback.Home != null) ? this.Localization.Fallback.Home.Notification2 : string.Empty); } }
		public string Notification3 { get { return this._notification3 ?? ((this.Localization.HasFallback && this.Localization.Fallback.Home != null) ? this.Localization.Fallback.Home.Notification3 : string.Empty); } }
		public string Title { get { return this._title ?? ((this.Localization.HasFallback && this.Localization.Fallback.Home != null) ? this.Localization.Fallback.Home.Title : string.Empty); } }
		public string Text1 { get { return this._text1 ?? ((this.Localization.HasFallback && this.Localization.Fallback.Home != null) ? this.Localization.Fallback.Home.Text1 : string.Empty); } }
		public string Text2 { get { return this._text2 ?? ((this.Localization.HasFallback && this.Localization.Fallback.Home != null) ? this.Localization.Fallback.Home.Text2 : string.Empty); } }
		public string Text3 { get { return this._text3 ?? ((this.Localization.HasFallback && this.Localization.Fallback.Home != null) ? this.Localization.Fallback.Home.Text3 : string.Empty); } }
		public string Text4 { get { return this._text4 ?? ((this.Localization.HasFallback && this.Localization.Fallback.Home != null) ? this.Localization.Fallback.Home.Text4 : string.Empty); } }
		public string Text5 { get { return this._text5 ?? ((this.Localization.HasFallback && this.Localization.Fallback.Home != null) ? this.Localization.Fallback.Home.Text5 : string.Empty); } }
		public string Text6 { get { return this._text6 ?? ((this.Localization.HasFallback && this.Localization.Fallback.Home != null) ? this.Localization.Fallback.Home.Text6 : string.Empty); } }
		public string Text7 { get { return this._text7 ?? ((this.Localization.HasFallback && this.Localization.Fallback.Home != null) ? this.Localization.Fallback.Home.Text7 : string.Empty); } }
		public string Text8 { get { return this._text8 ?? ((this.Localization.HasFallback && this.Localization.Fallback.Home != null) ? this.Localization.Fallback.Home.Text8 : string.Empty); } }
		public string Text9 { get { return this._text9 ?? ((this.Localization.HasFallback && this.Localization.Fallback.Home != null) ? this.Localization.Fallback.Home.Text9 : string.Empty); } }
		public string Text10 { get { return this._text10 ?? ((this.Localization.HasFallback && this.Localization.Fallback.Home != null) ? this.Localization.Fallback.Home.Text10 : string.Empty); } }
		

    private HomeLocalizationGroup()
    {
      this._header1  = string.Empty;
				this._header2  = string.Empty;
				this._header3  = string.Empty;
				this._notification1 = string.Empty;
				this._notification2 = string.Empty;
				this._notification3 = string.Empty;
				this._title = string.Empty;
				this._text1 = string.Empty;
				this._text2 = string.Empty;
				this._text3 = string.Empty;
				this._text4 = string.Empty;
				this._text5 = string.Empty;
				this._text6 = string.Empty;
				this._text7 = string.Empty;
				this._text8 = string.Empty;
				this._text9 = string.Empty;
				this._text10 = string.Empty;
				
    }

    public HomeLocalizationGroup(MobiChatWebLocalization localization)
    {
      this._localization = localization;
    }

    public string GetValue(string key)
    {
      switch (key)
      {
        case "Header1 ":
					return this.Header1 ;
				case "Header2 ":
					return this.Header2 ;
				case "Header3 ":
					return this.Header3 ;
				case "Notification1":
					return this.Notification1;
				case "Notification2":
					return this.Notification2;
				case "Notification3":
					return this.Notification3;
				case "Title":
					return this.Title;
				case "Text1":
					return this.Text1;
				case "Text2":
					return this.Text2;
				case "Text3":
					return this.Text3;
				case "Text4":
					return this.Text4;
				case "Text5":
					return this.Text5;
				case "Text6":
					return this.Text6;
				case "Text7":
					return this.Text7;
				case "Text8":
					return this.Text8;
				case "Text9":
					return this.Text9;
				case "Text10":
					return this.Text10;
				
        default:
          return null;
      }
    }

    public bool AssignValue(string key, string value)
    {
      switch (key)
      {
        case "Header1 ":
					this._header1  = value;
					return true;
				case "Header2 ":
					this._header2  = value;
					return true;
				case "Header3 ":
					this._header3  = value;
					return true;
				case "Notification1":
					this._notification1 = value;
					return true;
				case "Notification2":
					this._notification2 = value;
					return true;
				case "Notification3":
					this._notification3 = value;
					return true;
				case "Title":
					this._title = value;
					return true;
				case "Text1":
					this._text1 = value;
					return true;
				case "Text2":
					this._text2 = value;
					return true;
				case "Text3":
					this._text3 = value;
					return true;
				case "Text4":
					this._text4 = value;
					return true;
				case "Text5":
					this._text5 = value;
					return true;
				case "Text6":
					this._text6 = value;
					return true;
				case "Text7":
					this._text7 = value;
					return true;
				case "Text8":
					this._text8 = value;
					return true;
				case "Text9":
					this._text9 = value;
					return true;
				case "Text10":
					this._text10 = value;
					return true;
				
        default:
          return false;
      }
    }
  }
}
