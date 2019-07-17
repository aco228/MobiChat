using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Senti.Data;
 

namespace MobiChat.Data 
{
  public partial interface IMerchantManager 
  {
    List<Merchant> Load();
    List<Merchant> Load(IConnectionInfo connection);
    List<Merchant> Load(Instance instance);
    List<Merchant> Load(IConnectionInfo connection, Instance instance);
  }

  public partial class Merchant
  {
  }
}

