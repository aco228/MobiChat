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
  public partial class ApplicationManager : IApplicationManager
  {

    public Application Load(string applicationName, Instance instance)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, applicationName, instance);
    }

    public Application Load(IConnectionInfo connection, string applicationName, Instance instance)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, applicationName, instance);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, applicationName, instance);
    }

    public Application Load(ISqlConnectionInfo connection, string applicationName, Instance instance)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[a].Name=@Name AND InstanceID=@InstanceID";
      parameters.Arguments.Add("Name", applicationName);
      parameters.Arguments.Add("InstanceID", instance.ID);
      return this.Load(connection, parameters);
    }

    public List<Application> Load(Instance instance)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, instance);
    }

    public List<Application> Load(IConnectionInfo connection, Instance instance)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, instance);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, instance);
    }

    public List<Application> Load(ISqlConnectionInfo connection, Instance instance)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[a].InstanceID=@InstanceID";
      parameters.Arguments.Add("InstanceID", instance.ID);
      return this.LoadMany(connection, parameters);
    }

    public List<Application> Load()
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection);
    }

    public List<Application> Load(IConnectionInfo connection)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection);
    }

    public List<Application> Load(ISqlConnectionInfo connection)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      return this.LoadMany(connection, parameters);
    }

    public Application Load(string applicationName)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, applicationName);
    }

    public Application Load(IConnectionInfo connection, string applicationName)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, applicationName);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, applicationName);
    }

    public Application Load(ISqlConnectionInfo connection, string applicationName)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[a].Name = @Name";
      parameters.Arguments.Add("Name", applicationName);
      return this.Load(connection, parameters);
    }

  }
}

