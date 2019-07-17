using MobiChat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat
{
  public class UserBase : IUser
  {
    private User _userData = null;

    public Data.User UserData { get { return this._userData; } }

    public UserBase(User user)
    {
      this._userData = user;
    }
  }
}
