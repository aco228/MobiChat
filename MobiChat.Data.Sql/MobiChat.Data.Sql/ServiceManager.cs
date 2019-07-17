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
  public partial class ServiceManager : IServiceManager
  {


    public Service Load(string serviceName)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, serviceName);
    }

    public Service Load(IConnectionInfo connection, string serviceName)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, serviceName);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, serviceName);
    }

    public Service Load(ISqlConnectionInfo connection, string serviceName)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[s].ServiceName = @ServiceName";
      parameters.Arguments.Add("ServiceName", serviceName);
      return this.Load(connection, parameters);
    }

    public List<Service> Load(Application application)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, application);
    }

    public List<Service> Load(IConnectionInfo connection, Application application)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, application);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, application);
    }

    public List<Service> Load(ISqlConnectionInfo connection, Application application)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[s].ApplicationID = @ApplicationID";
      parameters.Arguments.Add("ApplicationID", application.ID);
      return this.LoadMany(connection, parameters);
    }


    public Service Load(ServiceConfiguration serviceConfiguration)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, serviceConfiguration);
    }

    public Service Load(IConnectionInfo connection, ServiceConfiguration serviceConfiguration)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, serviceConfiguration);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, serviceConfiguration);
    }

    public Service Load(ISqlConnectionInfo connection, ServiceConfiguration serviceConfiguration)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[s].ServiceConfigurationID = @ServiceConfigurationID";
      parameters.Arguments.Add("ServiceConfigurationID", serviceConfiguration.ID);
      return this.Load(connection, parameters);
    }

  }
}

