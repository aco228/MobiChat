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
    MobileOperator Load(int id, IDType idType);
    MobileOperator Load(IConnectionInfo connection, int id, IDType idType);
    List<MobileOperator> Load(Country country);
    List<MobileOperator> Load(IConnectionInfo connection, Country country);
   

  }

  public partial class MobileOperator
  {
  }
}

