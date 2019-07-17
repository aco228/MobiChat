using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MobiChat.Web.Data;
using Senti.Data; 

namespace MobiChat.Web.Data 
{
  public partial interface IServiceProfileGroupMapManager 
  {
    List<ServiceProfileGroupMap> Load(MobiChat.Data.Service service);
    List<ServiceProfileGroupMap> Load(IConnectionInfo connection, MobiChat.Data.Service service);

  }

  public partial class ServiceProfileGroupMap
  {
  }
}

