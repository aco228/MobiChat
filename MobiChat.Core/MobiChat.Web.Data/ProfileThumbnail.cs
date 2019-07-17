using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MobiChat.Web.Data;
using Senti.Data; 

namespace MobiChat.Web.Data 
{
  public partial interface IProfileThumbnailManager 
  {
    
    List<ProfileThumbnail> Load(Profile profile, MobiChat.Data.ThumbnailIdentifier identifier);
    List<ProfileThumbnail> Load(IConnectionInfo connection, Profile profile, MobiChat.Data.ThumbnailIdentifier identifier);


    List<ProfileThumbnail> Load(Profile profile);
    List<ProfileThumbnail> Load(IConnectionInfo connection, Profile profile);


    


  }

  public partial class ProfileThumbnail
  {

    public string GetDefaultUrl()
    {
      return string.Format("/thumbnails/get/{0}", this.ID);
    }

  }
}

