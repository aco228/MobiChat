using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Core
{
  public class AdministratorUser : UserBase
  {

    public AdministratorUser(MobiChat.Data.User user)
      :base(user)
    {

    }

  }
}
