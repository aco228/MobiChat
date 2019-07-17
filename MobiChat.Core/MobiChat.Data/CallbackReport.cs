using Senti.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 

namespace MobiChat.Data 
{
  public partial interface ICallbackReportManager 
  {
    
    List<CallbackReport> Load(CallbackNotificationType type);
    List<CallbackReport> Load(IConnectionInfo connection, CallbackNotificationType type);

  }

  public partial class CallbackReport
  {
  }
}

