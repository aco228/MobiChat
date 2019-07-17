using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MobiChat.Web.Data;
using Senti.Data; 

namespace MobiChat.Web.Data 
{
  public partial interface IProfileGroupManager 
  {

    ProfileGroup Load(MobiChat.Data.Instance instance, string name);
    ProfileGroup Load(IConnectionInfo connection, MobiChat.Data.Instance instance, string name);
    
  }

  public partial class ProfileGroup
  {
  }
}

