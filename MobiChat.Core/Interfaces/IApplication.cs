using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat
{
  public interface IApplication
  {
    Data.Application ApplicationData { get; }
  }
}
