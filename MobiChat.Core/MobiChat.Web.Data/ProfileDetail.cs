using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MobiChat.Web.Data;
using Senti.Data;
using MobiChat.Data;

namespace MobiChat.Web.Data 
{
  public partial interface IProfileDetailManager 
  {

    List<ProfileDetail> Load();
    List<ProfileDetail> Load(IConnectionInfo connection);

    List<ProfileDetail> Load(Language language);
    List<ProfileDetail> Load(IConnectionInfo connection, Language language);

    ProfileDetail Load(Profile profile, MobiChat.Data.Language language);
    ProfileDetail Load(IConnectionInfo connection, Profile profile, MobiChat.Data.Language language);

    List<ProfileDetail> Load(Profile profile);
    List<ProfileDetail> Load(IConnectionInfo connection, Profile profile);
    
  }

  public partial class ProfileDetail
  {
  }
}

