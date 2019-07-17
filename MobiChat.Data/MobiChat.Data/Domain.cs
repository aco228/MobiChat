using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Senti.Data;

namespace MobiChat.Data 
{
  public partial interface IDomainManager 
  {

    List<Domain> Load();
    List<Domain> Load(IConnectionInfo connection);
    List<Domain> Load(Service service);
    List<Domain> Load(IConnectionInfo connection, Service service);
    List<Domain> Load(Application application);
    List<Domain> Load(IConnectionInfo connection, Application application);
     
    Domain Load(string name);
    Domain Load(IConnectionInfo connection, string name);
     
  }

  public partial class Domain
  {
  }
}

