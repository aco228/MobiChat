using MobiChat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Management.Core
{
  public class ManagementUserSession : UserSessionBase
  {

    public ManagementUserSession(UserSession userSession)
      :base(userSession)
    {

    }

  }
}
