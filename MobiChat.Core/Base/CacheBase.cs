using log4net;
using MobiChat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Core
{
  public abstract class CacheBase : ICache
  {

    #region #logging#

    private static ILog _log = null;

    protected static ILog Log
    {
      get
      {
        if (CacheBase._log == null)
          CacheBase._log = LogManager.GetLogger(typeof(CacheBase));
        return CacheBase._log;
      }
    }

    #endregion #logging#

    protected Application _application = null;
    protected List<ICacheContent> _content = null;

    public Data.Application ApplicationData { get { return this._application; } }
    public List<ICacheContent> Content { get { return this._content; } }
    public int Count { get { return this._content == null ? 0 : this._content.Count; } }

    public abstract void CacheService(IService service);
    
    public CacheBase(Application application)
    {
      this._application = application;
    }

    public ICacheContent Get(int id)
    {
      return (from c in this._content where c.ID == id select c).FirstOrDefault();
    }

    public List<ICacheContent> Take(int num, int from)
    {
      if(from < 0) from = 0;
      if(num < 0) num = 0;
      if(from > this.Count)
      {
        from = this.Count - 1;
        num = 1;
      }

      if(from + num > this.Count)
        num = this.Count - from;

      return this._content.Skip(from).Take(num).ToList();
    }

    public List<ICacheContent> Take(int num)
    {
      num = num > this.Count ? this.Count : num;
      return this._content.Take(num).ToList();
    }
  }
}
