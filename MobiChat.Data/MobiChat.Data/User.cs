using Senti.Data;
using Senti.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 

namespace MobiChat.Data 
{
  public partial interface IUserManager 
  {
    
    User Load(Guid UserGuid);
    User Load(IConnectionInfo connection, Guid UserGuid);
    
    User Load(string Username);
    User Load(IConnectionInfo connection, string Username);
    List<User> Load(UserStatus userStatus);
    List<User> Load(IConnectionInfo connection, UserStatus userStatus);

  }

  public partial class User
  {
  }
}

