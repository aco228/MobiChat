using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.ComponentModel;
using Senti.Data; 

namespace MobiChat.Data 
{
  public partial interface IUserSessionTypeManager 
  {
    List<UserSessionType> Load();
    List<UserSessionType> Load(IConnectionInfo connection);
  }

  public partial class UserSessionType
  {
  }
}

