using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Senti.Data;
 

namespace MobiChat.Data 
{
  public partial interface IMobileOperatorManager 
  {
    List<MobileOperator> Load();
    List<MobileOperator> Load(IConnectionInfo connection);
    MobileOperator Load(Country country, string name);
    MobileOperator Load(IConnectionInfo connection, Country country, string name);
  }

  public partial class MobileOperator
  {
  }
}

