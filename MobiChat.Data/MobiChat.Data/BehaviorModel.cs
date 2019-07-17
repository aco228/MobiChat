using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Senti.Data;
 

namespace MobiChat.Data 
{
  public partial interface IBehaviorModelManager 
  {

    BehaviorModel Load(Guid value);
    BehaviorModel Load(IConnectionInfo connection, Guid value);

    BehaviorModel Load(Service service, string searchPattern);
    BehaviorModel Load(IConnectionInfo connection, Service service, string searchPattern);

    List<BehaviorModel> Load(string name);
    List<BehaviorModel> Load(IConnectionInfo connection, string name);

  }

  public partial class BehaviorModel
  {
  }
}

