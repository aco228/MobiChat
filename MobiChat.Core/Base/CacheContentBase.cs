using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Core
{
  public abstract class CacheContentBase : ICacheContent
  {
    protected int _id = -1;
    protected object _data = null;
    protected object _defaultThumbnail = null;
    protected string _url = string.Empty;
    protected string _thumbnailUrl = string.Empty;

    public object Data { get { return this._data; } }
    public object DefaultThumbnail { get { return this._defaultThumbnail; } }
    public int ID { get { return this._id; } }
    public string Url { get { return this._url; } }
    public string ThumbnailUrl { get { return this._thumbnailUrl; } }

    public CacheContentBase(object data)
    {
      this._data = data;
    }
  }
}
