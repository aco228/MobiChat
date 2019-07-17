using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MobiChat
{
  public interface IMobiChatContext
  {
    HttpContext HttpContext { get; }
    IRuntime Runtime { get; }
  }
}
