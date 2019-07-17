using Senti.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace MobiChat.Data
{
  public partial interface IInstanceManager
  {

    List<Instance> Load();
    List<Instance> Load(IConnectionInfo connection);
    Instance Load(string name);
    Instance Load(IConnectionInfo connection, string name);

  }

  public partial class Instance
  {
  }
}

