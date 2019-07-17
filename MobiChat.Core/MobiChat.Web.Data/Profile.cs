using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MobiChat.Web.Data;
using Senti.Data; 

namespace MobiChat.Web.Data 
{
  public partial interface IProfileManager 
  {


    List<Profile> Load();
    List<Profile> Load(IConnectionInfo connection);
    

    List<Profile> Load(ProfileGroup profileGroup);
    List<Profile> Load(IConnectionInfo connection, ProfileGroup profileGroup);
    
  }

  public partial class Profile
  {
  }
}

