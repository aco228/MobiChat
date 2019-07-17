using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Core.Direct
{
  public class MobiChatDirect : DirectDatabaseBase
  {

    public MobiChatDirect()
      : base("MobilePaywall", "core")
    {
      this.SetConnectionString("Data Source=192.168.11.104;Initial Catalog=MobiChat;uid=sa;pwd=m_q-6dGyRwcTf+b;");
    }
  }
}
