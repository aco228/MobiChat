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
  public partial class ServiceTypeManager : IServiceTypeManager
  {
    public List<ServiceType> Load()
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection);
    }

    public List<ServiceType> Load(IConnectionInfo connection)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection);
    }

    public List<ServiceType> Load(ISqlConnectionInfo connection)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      return this.LoadMany(connection, parameters);
    }


    public ServiceType Load(string name)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, name);
    }

    public ServiceType Load(IConnectionInfo connection, string name)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, name);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, name);
    }

    public ServiceType Load(ISqlConnectionInfo connection, string name)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "Name=@Name";
      parameters.Arguments.Add("Name", name);
      return this.Load(connection, parameters);
    }
  }
}

