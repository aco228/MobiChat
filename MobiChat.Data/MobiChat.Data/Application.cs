using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Senti.Data;
 

namespace MobiChat.Data 
{
  public partial interface IApplicationManager 
  {

    
    List<Application> Load();
    List<Application> Load(IConnectionInfo connection);
    Application Load(string applicationName);
    Application Load(IConnectionInfo connection, string applicationName);
    List<Application> Load(Instance instance);
    List<Application> Load(IConnectionInfo connection, Instance instance);
    Application Load(string applicationName, Instance instance);
    Application Load(IConnectionInfo connection, string applicationName, Instance instance);

  }

  public partial class Application
  {
  }
}

