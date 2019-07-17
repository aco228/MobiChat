using MobiChat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Core
{
  public class CustomerUser : UserBase
  {
    public CustomerUser(User user)
      :base(user)
    {

    }
  }
}
