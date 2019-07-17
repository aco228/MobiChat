using MobiChat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Statistics.Core
{
  public class StatisticsUserSession : UserSessionBase
  {

    public StatisticsUserSession(UserSession userSession)
      :base(userSession)
    {

    }

  }
}
