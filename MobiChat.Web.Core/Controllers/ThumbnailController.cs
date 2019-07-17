using MobiChat.Core;
using MobiChat.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.IO;
using MobiChat.Web.Data;
using MobiChat.Web.Core.Models;
using log4net;
using Senti.Diagnostics.Log;

namespace MobiChat.Web.Controllers
{     
  [SessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
  public class ThumbnailController : MobiController
  {
    #region #logging#

    private static ILog _log = null;

    protected static ILog Log
    {
      get
      {
        if (ThumbnailController._log == null)
          ThumbnailController._log = LogManager.GetLogger(typeof(ThumbnailController));
        return ThumbnailController._log;
      }
    }

    #endregion #logging#

    public string test() { return "radi"; }

    public FileResult Default(int contentID)
    {
      ICacheContent content = this.MobiContext.Service.Cache.Get(contentID);

      if(content == null)
      {
        return null;
      }

      return File(content.DefaultThumbnail as byte[], "image/jpg", string.Format("{0}{1}", contentID, ".jpg"));
    }

    public ActionResult Get(int profileThumbnailID)
    {
      ProfileThumbnail pt = ProfileThumbnail.CreateManager().Load(profileThumbnailID);
      if (pt == null)
      {
        Log.Error("Profile thumbnail does not exist.");
        return this.InternalError();
      }

      ProfileThumbnailData ptd = ProfileThumbnailData.LoadByProfileThumbnail(pt).FirstOrDefault();
      if (ptd == null)
      {
        Log.Error("COULD NOT LOAD THUMBNAIL. ProfileThumbnailData is null for ProfileThumbnailID=" + profileThumbnailID);
        return this.InternalError();
      }

      return File(ptd.Data, "image/jpg", string.Format("{0}{1}", profileThumbnailID, ".jpg"));
    }




  }
}
