using Senti.ComponentModel;
using Senti.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 

namespace MobiChat.Data 
{
  public partial interface IUserTypeManager 
  {

    List<UserType> Load();
    List<UserType> Load(IConnectionInfo connection);
    
    


  }

  public partial class UserType
  {

    public IUser Instantiate(User user)
    {
      return TypeFactory.Instantiate<IUser, User>(this.TypeName, user);
    }
  }
}

