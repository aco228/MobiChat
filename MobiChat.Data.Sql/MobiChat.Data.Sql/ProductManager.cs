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
  public partial class ProductManager : IProductManager
  {
    public Product Load(Guid value, GuidType type)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, value, type);
    }

    public Product Load(IConnectionInfo connection, Guid value, GuidType type)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, value, type);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, value, type);
    }

    public Product Load(ISqlConnectionInfo connection, Guid value, GuidType type)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      string parameter = type == GuidType.External ? "ExternalProductGuid" : "ProductGuid";
      parameters.Where = string.Format("[p].{0} = @{0}", parameter);
      parameters.Arguments.Add(parameter, value);
      return this.Load(connection, parameters);
    }

    public Product Load(string name)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, name);
    }

    public Product Load(IConnectionInfo connection, string name)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, name);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, name);
    }

    public Product Load(ISqlConnectionInfo connection, string name)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[p].Name = @Name";
      parameters.Arguments.Add("Name", name);
      return this.Load(connection, parameters);
      //return this.LoadMany(connection, parameters);
    }

    public Product Load(Instance instance, string name)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, instance, name);
    }

    public Product Load(IConnectionInfo connection, Instance instance, string name)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, instance, name);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, instance, name);
    }

    public Product Load(ISqlConnectionInfo connection, Instance instance, string name)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[p].InstanceID = @InstanceID AND Name = @Name";
      parameters.Arguments.Add("InstanceID", instance.ID);
      parameters.Arguments.Add("Name", name);
      return this.Load(connection, parameters);
    }

    public List<Product> Load()
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection);
    }

    public List<Product> Load(IConnectionInfo connection)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection);
    }

    public List<Product> Load(ISqlConnectionInfo connection)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      return this.LoadMany(connection, parameters);
    }

    public List<Product> Load(Instance instance)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, instance);
    }

    public List<Product> Load(IConnectionInfo connection, Instance instance)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, instance);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, instance);
    }

    public List<Product> Load(ISqlConnectionInfo connection, Instance instance)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[p].InstanceID=@InstanceID";
      parameters.Arguments.Add("InstanceID", instance.ID);
      return this.LoadMany(connection, parameters);
    }
  }
}

