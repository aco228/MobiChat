using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Senti.Data;
 

namespace MobiChat.Data 
{
  public partial interface IGenderManager 
  {
    
    List<Gender> Load();
    List<Gender> Load(IConnectionInfo connection);

  }

  public partial class Gender
  {
  }
}

