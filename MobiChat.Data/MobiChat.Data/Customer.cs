using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Senti.Data;


namespace MobiChat.Data 
{
  public partial interface ICustomerManager 
  {
    
    List<Customer> Load();
    List<Customer> Load(IConnectionInfo connection);
    List<Customer> Load(Service service);
    List<Customer> Load(IConnectionInfo connection, Service service);
    List<Customer> Load(Service service, string value, CustomerIdentifier identifier);
    List<Customer> Load(IConnectionInfo connection, Service service, string value, CustomerIdentifier identifier);

    Customer Load(string name);
    Customer Load(IConnectionInfo connection, string name);
 
    

  }

  public partial class Customer
  {
  }
}

