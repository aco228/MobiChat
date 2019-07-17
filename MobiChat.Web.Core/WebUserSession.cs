using MobiChat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Web.Core
{
  public class WebUserSession : UserSessionBase
  {

    public WebUserSession(UserSession userSession)
      :base(userSession)
    {
      
    }

  }
}
