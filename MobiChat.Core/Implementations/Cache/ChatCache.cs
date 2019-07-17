using log4net;
using MobiChat.Data;
using MobiChat.Web.Data;
using Senti.Diagnostics.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Core.Implementations
{
  public class ChatCache : CacheBase
  {

    #region #logging#

    private static ILog _log = null;

    protected static ILog Log
    {
      get
      {
        if (ChatCache._log == null)
          ChatCache._log = LogManager.GetLogger(typeof(ChatCache));
        return ChatCache._log;
      }
    }

    #endregion #logging#

    private List<ProfileGroup> _profileGroups = null;
    private Dictionary<int, ProfileThumbnailData> _thumbnails; // dictonary<ProfileThumbanilID, ProfileThumbanilData>


    public ChatCache(Application application)
      : base(application)
    {
      this._content = new List<ICacheContent>();
      this._profileGroups = new List<ProfileGroup>();
    }

    public override void CacheService(IService service)
    {
      // SUMMARY: Adding profile groups for service
      List<ServiceProfileGroupMap> spgMap = ServiceProfileGroupMap.CreateManager().Load(service.ServiceData);
      List<ProfileGroup> tempGroups = new List<ProfileGroup>();

      foreach (ServiceProfileGroupMap spgm in spgMap)
        if (spgm.ProfileGroup.Instance.ID == this._application.Instance.ID && !this._profileGroups.Contains(spgm.ProfileGroup))
        {
          this._profileGroups.Add(spgm.ProfileGroup);
          tempGroups.Add(spgm.ProfileGroup);
        }

      // SUMMARY: Adding profiles from profile groups
      IProfileManager pManager = Profile.CreateManager();
      foreach(ProfileGroup pg in tempGroups)
      {
        List<Profile> profiles = pManager.Load(pg);
        foreach (Profile p in profiles)
        {
          ProfileCache tempCache = new ProfileCache(p);
          if (!tempCache.HasError)
            this._content.Add(tempCache);
          else
            Log.Error(string.Format("ProfileCache:CacheService Proflie with id '{0}' could not be cached", p.ID));
        }
      }

      Log.Debug(string.Format("Cache is created for '{0}' service", service.ServiceData.Name));
    }

    
    public ProfileCache GetProfileByID(string id)
    {
      int profileID = -1;
      if (!Int32.TryParse(id, out profileID))
      {
        Log.Error("Could not parse id.");
        return null;
      }

      ICacheContent profileCache = this.Get(profileID);
      if (profileCache == null)
      {
        Log.Error("Cache did not retrieve any cacheContent.");
        return null;
      }

      ProfileCache profileCacheObj = profileCache as ProfileCache;
      if (profileCacheObj == null)
      {
        Log.Error("CacheObject could not be passed into ProfileCache");
        return null;
      }

      return profileCacheObj;
    }

  }
}