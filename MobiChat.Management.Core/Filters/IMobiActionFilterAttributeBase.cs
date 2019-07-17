using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Management.Core
{
  public interface IMobiActionFilterAttributeBase
  {
    bool Required { get; set; }
    MobiChat.Data.ServiceConfigurationEntry Configuration { get; }
    MobiContext MobiContext { get; }
  }
}
