using MobiChat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat
{
  public abstract class UserSessionBase : IUserSession
  {
    private UserSession _userSessionData = null;
    private IService _service = null;
    private Country _country = null;
    private Language _language = null;
    private IUser _user = null;

    public Data.UserSession SessionData { get { return this._userSessionData; } }
    public IService Service { get { return this._service; } }
    public Data.Country Country { get { return this._country; } }
    public Data.Language Language { get { return this._language; } }
    public IUser User { get { return this._user; } }
    public string UserType { get { return this._userSessionData.User != null ? this._userSessionData.User.UserType.Name : string.Empty; } }
    
    public UserSessionBase(UserSession userSession)
    {
      this._userSessionData = userSession;
      this.UpdateUser();
    }

    public Data.Country GetUserSessionCountry()
    {
      this._country = this._userSessionData.Country ?? this._service.ServiceData.FallbackCountry;
      if (this._country == null)
        throw new ArgumentException("UserSessionBase:GetUserSessionCountry - Country is null");

      return this._country;
    }

    public Data.Language GetUserSessionLanguage()
    {
      //return Language.CreateManager().Load("EN", LanguageIdentifier.TwoLetterIsoCode);
      return this._userSessionData.Language == null ? this._service.ServiceData.FallbackLanguage : this._userSessionData.Language;
    }

    public void ReloadSession()
    {
      this._userSessionData = UserSession.CreateManager().Load(this._userSessionData.ID);
    }

    public void UpdateUser()
    {
      if (this._userSessionData.User == null)
        this._user = null;
      else
        this._user = this._userSessionData.User.Instantiate();

    }

  }
}
