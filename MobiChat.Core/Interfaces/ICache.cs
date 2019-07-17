using MobiChat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Core
{
  public interface ICache
  {
    Application ApplicationData { get; }
    List<ICacheContent> Content { get; }
    int Count { get; }

    ICacheContent Get(int id);
    List<ICacheContent> Take(int num, int from);
    List<ICacheContent> Take(int num);

    void CacheService(IService service);
  }
}
