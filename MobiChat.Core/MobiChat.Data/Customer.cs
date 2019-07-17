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
    
    Customer Load(Guid customerGuid);
    Customer Load(IConnectionInfo connection, Guid customerGuid);

  }

  public partial class Customer
  {

    public static Customer GetCustomerByMsisdn(Service service, string msisnd)
    {
      Customer customer = null;
      using(ConnectionInfo connection = new ConnectionInfo(System.Data.IsolationLevel.ReadUncommitted))
        customer = Customer.CreateManager().Load(service, msisnd, CustomerIdentifier.Msisdn).FirstOrDefault();
      return customer;
    }

  }
}

