using MobiChat.Core;
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
    User Load(string username);
    User Load(IConnectionInfo connection, string username);
    List<User> Load(UserStatus userStatus);
    List<User> Load(IConnectionInfo connection, UserStatus userStatus);

    List<User> Load();
    List<User> Load(IConnectionInfo connection);


    User Load(User user);
    User Load(IConnectionInfo connection, User user);
    

    User Load(string username, string password);
    User Load(IConnectionInfo connection, string username, string password);
  }

  public partial class User
  {

    public IUser Instantiate()
    {
      return this.UserType.Instantiate(this);
    }

  }
}

