using MobiChat.Core;
using Senti.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 

namespace MobiChat.Data 
{
  public partial interface ISendNumberTypeManager 
  {
  }

  public partial class SendNumberType
  {

    public ISendNumber Instantiate(ServiceSendNumberMap map)
    {
      return TypeFactory.Instantiate<ISendNumber, ServiceSendNumberMap>(this.TypeName, map);
    }
  }
}

