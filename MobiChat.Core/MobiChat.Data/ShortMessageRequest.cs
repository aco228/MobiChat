using Senti.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 

namespace MobiChat.Data 
{
  public partial interface IShortMessageRequestManager 
  {
    
    ShortMessageRequest Load(Guid guid);
    ShortMessageRequest Load(IConnectionInfo connection, Guid guid);


  }

  public partial class ShortMessageRequest
  {
  }
}

