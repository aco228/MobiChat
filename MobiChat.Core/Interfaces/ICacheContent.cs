using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Core
{
  public interface ICacheContent
  {
    int ID { get; }
    object Data { get; }
    object DefaultThumbnail { get; }
    string Url { get; }
    string ThumbnailUrl { get; }

  }
}
