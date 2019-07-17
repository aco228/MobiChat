using Senti.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 

namespace MobiChat.Data 
{
  public partial interface IUserDetailManager 
  {    
    UserDetail Load(User user);
    UserDetail Load(IConnectionInfo connection, User user);
  }

  public partial class UserDetail
  {
  }
}

