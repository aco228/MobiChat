using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti;
using Senti.Data;
using Senti.Data.Sql;



namespace MobiChat.Data.Sql
{
  public partial class CustomerManager : ICustomerManager
  {

    public List<Customer> Load(Service service, string value, CustomerIdentifier identifier)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, service, value, identifier);
    }

    public List<Customer> Load(IConnectionInfo connection, Service service, string value, CustomerIdentifier identifier)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, service, value, identifier);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, service, value, identifier);
    }

    public List<Customer> Load(ISqlConnectionInfo connection, Service service, string value, CustomerIdentifier identifier)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      string parameter = string.Format("{0}", identifier.ToString());
      parameters.Where = string.Format("[c].{0} = @{0}", parameter);
      if (service != null)
      {
        parameters.Where += " AND [c_s].ServiceID = @ServiceID";
        parameters.Arguments.Add("ServiceID", service.ID);
      }
      parameters.OrderBy = "[c].Created DESC";
      parameters.Arguments.Add(parameter, value);
      return this.LoadMany(connection, parameters);
    }


    public List<Customer> Load(Service service)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, service);
    }

    public List<Customer> Load(IConnectionInfo connection, Service service)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, service);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, service);
    }

    public List<Customer> Load(ISqlConnectionInfo connection, Service service)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[c].ServiceID = @ServiceID";
      parameters.Arguments.Add("ServiceID", service.ID);
      return this.LoadMany(connection, parameters);
    }

    public Customer Load(string name)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, name);
    }

    public Customer Load(IConnectionInfo connection, string name)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, name);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, name);
    }

    public Customer Load(ISqlConnectionInfo connection, string name)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[i].Name = @Name";
      parameters.Arguments.Add("Name", name);
      return this.Load(connection, parameters);
     
    }


     public List<Customer> Load()
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection);
    }

    public List<Customer> Load(IConnectionInfo connection )
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection);
    }

    public List<Customer> Load(ISqlConnectionInfo connection)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      return this.LoadMany(connection, parameters);
    }


    public Customer Load(Guid customerGuid)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, customerGuid);
    }

    public Customer Load(IConnectionInfo connection, Guid customerGuid)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, customerGuid);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, customerGuid);
    }

    public Customer Load(ISqlConnectionInfo connection, Guid customerGuid)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[c].CustomerGuid = @CustomerGuid";
      parameters.Arguments.Add("CustomerGuid", customerGuid);
      return this.Load(connection, parameters);
    }


  }
}

