using MobiChat.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat
{
  public interface IUserSession
  {
    Data.UserSession SessionData { get; }
    IService Service { get; }
    Data.Country Country { get; }
    Data.Language Language { get; }
    IUser User { get; }
    string UserType { get; }

    Data.Country GetUserSessionCountry();
    Data.Language GetUserSessionLanguage();

    void ReloadSession();
    void UpdateUser();

  }
}
