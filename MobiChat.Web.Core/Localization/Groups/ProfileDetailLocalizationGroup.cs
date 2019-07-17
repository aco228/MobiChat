using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Senti.Localization;

namespace MobiChat.Web.Core.Localization
{
  public class ProfileDetailLocalizationGroup : ILocalizationGroup 
  {
    public static readonly ProfileDetailLocalizationGroup Empty = new ProfileDetailLocalizationGroup();

    private MobiChatWebLocalization _localization = null;

    protected bool IsEmpty { get { return this._localization == null; } }
    protected MobiChatWebLocalization Localization { get { return this._localization; } }

    private string _myPictures  = null;
    private string _aboutMe = null;
    private string _sendMessage = null;
    private string _enterYourNumber = null;
    private string _insertNumberTextAbove = null;

    public string MyPictures  { get { return this._myPictures  ?? ((this.Localization.HasFallback && this.Localization.Fallback.ProfileDetail != null) ? this.Localization.Fallback.ProfileDetail.MyPictures  : string.Empty); } }
    public string AboutMe { get { return this._aboutMe ?? ((this.Localization.HasFallback && this.Localization.Fallback.ProfileDetail != null) ? this.Localization.Fallback.ProfileDetail.AboutMe : string.Empty); } }
    public string SendMessage { get { return this._sendMessage ?? ((this.Localization.HasFallback && this.Localization.Fallback.ProfileDetail != null) ? this.Localization.Fallback.ProfileDetail.SendMessage : string.Empty); } }
    public string EnterYourNumber { get { return this._enterYourNumber ?? ((this.Localization.HasFallback && this.Localization.Fallback.ProfileDetail != null) ? this.Localization.Fallback.ProfileDetail.EnterYourNumber : string.Empty); } }
    public string InsertNumberAboveText { get { return this._insertNumberTextAbove ?? ((this.Localization.HasFallback && this.Localization.Fallback.ProfileDetail != null) ? this.Localization.Fallback.ProfileDetail.InsertNumberAboveText : string.Empty); } }
		

    private ProfileDetailLocalizationGroup()
    {
      this._myPictures  = string.Empty;
      this._aboutMe = string.Empty;
      this._sendMessage = string.Empty;
      this._enterYourNumber = string.Empty;
      this._insertNumberTextAbove = string.Empty;
    }

    public ProfileDetailLocalizationGroup(MobiChatWebLocalization localization)
    {
      this._localization = localization;
    }

    public string GetValue(string key)
    {
      switch (key)
      {
        case "MyPictures":
          return this.MyPictures;
        case "AboutMe":
          return this.AboutMe;
        case "SendMessage":
          return this.SendMessage;
        case "EnterYourNumber":
          return this.EnterYourNumber;
        case "InsertNumberAboveText":
          return this.InsertNumberAboveText;
				
        default:
          return null;
      }
    }

    public bool AssignValue(string key, string value)
    {
      switch (key)
      {
        case "MyPictures":
					this._myPictures  = value;
          return true;
        case "AboutMe":
          this._aboutMe = value;
          return true;
        case "SendMessage":
          this._sendMessage = value;
          return true;
        case "EnterYourNumber":
          this._enterYourNumber = value;
          return true;
        case "InsertNumberAboveText":
          this._insertNumberTextAbove = value;
          return true;
				
        default:
          return false;
      }
    }
  }
}
