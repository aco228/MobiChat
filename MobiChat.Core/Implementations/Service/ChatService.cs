using log4net;
using MobiChat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Core.Implementations
{
  public class ChatService : ServiceBase
  {

    #region #logging#

    private static ILog _log = null;

    protected static ILog Log
    {
      get
      {
        if (ChatService._log == null)
          ChatService._log = LogManager.GetLogger(typeof(ChatService));
        return ChatService._log;
      }
    }

    #endregion #logging#



    public ChatService(Service service, IRuntime runtime)
      :base(service, runtime)
    {
      this._homeView = "ChatHome";
      this._partialHomeView = "_ChatProfiles";
    }

    public override void Init()
    {
      ChatCache cache = null;

      if (!this.Runtime.Cache.ContainsKey(this.ServiceData.ServiceType))
      {
        cache = new ChatCache(this.ServiceData.Application);
        this.Runtime.Cache.Add(this.ServiceData.ServiceType, cache);
      }
      else
        cache = this.Runtime.Cache[this.ServiceData.ServiceType] as ChatCache;

      cache.CacheService(this);
    }


    public override void OnSentMessageNotification(Guid shortMessageRequestGuid)
    {
      Log.Info("Chat::OnSentMessageNotification guid=" + shortMessageRequestGuid.ToString());
    }

    public override void OnReceivedMessageNotification(Guid shorMessageGuid)
    {
      Log.Info("Chat::OnReceivedMessageNotification guid=" + shorMessageGuid.ToString());
    }

    public override void OnChargedNotification(Guid transactionGuid)
    {
      Log.Info("Chat::OnChargedNotification guid=" + transactionGuid.ToString());
    }

  }
}
