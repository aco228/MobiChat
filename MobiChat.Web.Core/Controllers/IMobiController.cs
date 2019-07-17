using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Web.Core
{
  public interface IMobiController
  {
    WebApplication MobiApplication { get; }
    MobiContext MobiContext { get; }
  }
}
