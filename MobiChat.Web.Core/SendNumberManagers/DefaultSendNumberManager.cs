using MobiChat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Web.Core
{
  public class DefaultSendNumberManager : SendNumberBase
  {

    public DefaultSendNumberManager(ServiceSendNumberMap map)
      : base(map)
    {

    }
    
    public override bool TryParseMobileOperator()
    {
      return true;
    }
  }
}
