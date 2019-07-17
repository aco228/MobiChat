using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.SessionState;

namespace MobiChat.Service.Core
{
  public class MobiSessionIDManager : ISessionIDManager
  {
    private MobiSessionGuidManager _manager = new MobiSessionGuidManager();

    public MobiSessionIDManager() { }

    public string CreateSessionID(System.Web.HttpContext context)
    {
      this._manager.SessionID = this.GetSessionID(context);
      return this._manager.CreateSessionID(context);
    }

    public string GetSessionID(System.Web.HttpContext context)
    {
      Regex sessionRegex = new Regex(MobiChat.Constants.SessionID + "/" + MobiChat.Constants.RegexGuid, RegexOptions.None);
      Match sessionMatch = sessionRegex.Match(context.Request.RawUrl);
      if (sessionMatch.Success)
        return sessionMatch.Groups[1].Value;

      string sessionID = this._manager.GetSessionID(context);
      if (sessionID != null)
        return sessionID;

      return null;
    }

    public void Initialize()
    {
      this._manager.Initialize();
    }

    public bool InitializeRequest(System.Web.HttpContext context, bool suppressAutoDetectRedirect, out bool supportSessionIDReissue)
    {
      return this._manager.InitializeRequest(context, suppressAutoDetectRedirect, out supportSessionIDReissue);
    }

    public void RemoveSessionID(System.Web.HttpContext context)
    {
      this._manager.RemoveSessionID(context);
    }

    public void SaveSessionID(System.Web.HttpContext context, string id, out bool redirected, out bool cookieAdded)
    {
      this._manager.SaveSessionID(context, id, out redirected, out cookieAdded);
    }

    public bool Validate(string id)
    {
      return this._manager.Validate(id);
    }
  }

  public class MobiSessionGuidManager : SessionIDManager
  {
    public string SessionID { get; set; }

    public override string CreateSessionID(System.Web.HttpContext context)
    {
      if (!string.IsNullOrEmpty(this.SessionID))
        return this.SessionID;
      return Guid.NewGuid().ToString().Replace("-", string.Empty);
    }

    public override bool Validate(string id)
    {
      Guid tmp = Guid.Empty;
      return Guid.TryParseExact(id, "N", out tmp);
    }
  }
  
}
