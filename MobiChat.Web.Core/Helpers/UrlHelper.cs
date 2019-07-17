using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;
using log4net;

namespace MobiChat.Web.Core
{
  public static class UrlHelper
  {


    #region #logging#

    private static ILog _log = null;

    public static ILog Log
    {
      get
      {
        if (UrlHelper._log == null)
          UrlHelper._log = LogManager.GetLogger(typeof(UrlHelper));
        return UrlHelper._log;
      }
    }

    #endregion #logging#

    public static string Internal(this System.Web.Mvc.UrlHelper helper, object url)
    {
      string urlString = url as string;
      if (urlString == null) return string.Empty;
      return UrlHelper.AppendSessionID(helper.RequestContext, urlString);
    }

    public static string AppendSessionID(RequestContext requestContext, string url)
    {
      try
      {
        MobiContext paywallContext = MobiContext.GetCurrent(requestContext.HttpContext.ApplicationInstance.Context);
        string sessionID = paywallContext.Session.SessionData.Guid.ToString().Replace("-", "");
        string sessionPath = MobiChat.Constants.SessionID + "/" + sessionID;

        if (url.Contains(MobiChat.Constants.SessionID + "/"))
        {
          if (url.Contains(sessionPath))
          {
            //INFO: Session in URL matches session in context.
            //Log.Debug(new LogMessageBuilder(new PaywallLogErrorCode("web.core", "urlhelper", "match"),
            //  string.Format("SessionID in URL ({0}) matches SessionID ({1}) from context.", url, sessionID)));
            return url;
          }
          else
          {
            //INFO: Session in URL does NOT match session in context.
            //Log.Debug(new LogMessageBuilder(new PaywallLogErrorCode("web.core", "urlhelper", "match"),
            //  string.Format("SessionID in URL ({0}) does NOT match SessionID ({1}) from context.", url, sessionID)));
            return "/";
          }
        }
        else
        {
          //INFO: Session is not provided in URL. So append it.
          //Log.Debug(new LogMessageBuilder(new PaywallLogErrorCode("web.core", "urlhelper", "notprovided"),
          //    string.Format("SessionID is not provided in URL ({0}). SessionID ({1}) from context will be appended to URL.", url, sessionID)));
          url = PrepareUrl(url, sessionPath);
        }

        if (!url.StartsWith("/"))
          url = "/" + url;

        //Log.Debug(new LogMessageBuilder(new PaywallLogErrorCode("web.core", "urlhelper", "end"),
        //    string.Format("Final URL ({0})", url)));
      }
      catch (Exception e)
      {
        // TODO log this error
        Log.Error("URL in UrlHelper is not correct.", e);
      }

      return url;
    }

    private static string PrepareUrl(string url, string sessionPath)
    {
      if (url.Contains("?"))
      {
        string[] parts = url.Split('?');
        if (parts[0].EndsWith("/"))
          url = url.Replace("?", sessionPath + "?");
        else
          url = url.Replace("?", "/" + sessionPath + "?");
      }
      else
        if (!url.EndsWith("/"))
          url += "/" + sessionPath;
        else
          url += sessionPath;

      return url;
    }

    private static bool IsSessionProvidedButDifferent(string url, string paywallSessionGuid)
    {
      // Check if the session id is already provided but different from the one which is in the paywall context session.
      //string sessionGuid = url.Split('/').LastOrDefault().Split('?').First();

      string[] urlData = url.Split('/');
      for (int i = 0; i < urlData.Length; i++)
        if (urlData[i].ToLower().Equals(MobiChat.Constants.SessionID))
        {
          //if (!urlData[i++].Equals(sessionGuid))
          if (!urlData[i++].Equals(paywallSessionGuid))
          {
            return true;
          }
          break;
        }
      return false;
    }
  }
}
