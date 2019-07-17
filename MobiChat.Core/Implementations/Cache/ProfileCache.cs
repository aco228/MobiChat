using log4net;
using MobiChat.Data;
using MobiChat.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Core.Implementations
{
  public class ProfileCache : CacheContentBase
  {

    #region #logging#

    private static ILog _log = null;

    protected static ILog Log
    {
      get
      {
        if (ProfileCache._log == null)
          ProfileCache._log = LogManager.GetLogger(typeof(ProfileCache));
        return ProfileCache._log;
      }
    }

    #endregion #logging#

    private bool _hasError = false;
    private Dictionary<string, ProfileDetail> _details = null; // Language.TwoLetterIsoCode 

    private static readonly object CacheLockObject = new object();
    public bool HasError { get { return this._hasError; } }
    public Profile ProfileData { get { return this._data as Profile; } }
    
    public ProfileCache(Profile profile)
      :base(profile)
    {
      lock (CacheLockObject)
      {
        // SUMMARY: Adding ProfileThumbnail
        ProfileThumbnail profileThumbnail = ProfileThumbnail.CreateManager().Load(profile, ThumbnailIdentifier.Default).FirstOrDefault();
        if (profileThumbnail != null)
        {
          ProfileThumbnailData thumbnailData = ProfileThumbnailData.LoadByProfileThumbnail(profileThumbnail, null).FirstOrDefault();
          this._defaultThumbnail = thumbnailData.Data;
          this._thumbnailUrl = string.Format("/thumbnails/default/{0}", profile.ID);
        }

        this._id = profile.ID;
        this._url = string.Format("/profile/{0}", profile.ID);
        this._details = new Dictionary<string, ProfileDetail>();

        List<ProfileDetail> profileDetails = ProfileDetail.CreateManager().Load(profile);
        if (profileDetails == null || profileDetails.Count == 0)
        {
          this._hasError = true;
          Log.Error("web.Profile:" + this._id + " does not have any ProfileDetail");
          return;
        }

        foreach (ProfileDetail pd in profileDetails)
        {
          if (this._details.ContainsKey(pd.Language.TwoLetterIsoCode))
            continue;
          this._details.Add(pd.Language.TwoLetterIsoCode, pd);
        }

      }
    }

    public ProfileDetail GetDetails(Language language)
    {
      ProfileDetail result = null;

      this._details.TryGetValue(language.TwoLetterIsoCode, out result);
      if (result != null)
        return result;

      result = ProfileDetail.CreateManager().Load(this.ProfileData, language);
      if (result != null)
      {
        this._details.Add(language.TwoLetterIsoCode, result);
        return result;
      }
      else
        return this._details["EN"];

    }


  }
}
