using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Senti.Data;
 

namespace MobiChat.Data 
{
  public partial interface IProductManager 
  {
    Product Load(Guid value, GuidType type);
    Product Load(IConnectionInfo connection, Guid value, GuidType type);

    Product Load(string name);
    Product Load(IConnectionInfo connection, string name);

    Product Load(Instance instance, string name);
    Product Load(IConnectionInfo connection, Instance instance, string name);

    List<Product> Load();
    List<Product> Load(IConnectionInfo connection);

    List<Product> Load(Instance instance);
    List<Product> Load(IConnectionInfo connection, Instance instance);
  }

  public partial class Product
  {
  }
}

