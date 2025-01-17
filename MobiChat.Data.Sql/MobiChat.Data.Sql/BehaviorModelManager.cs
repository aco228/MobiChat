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
  public partial class BehaviorModelManager : IBehaviorModelManager
  {
    public BehaviorModel Load(Guid value)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, value);
    }

    public BehaviorModel Load(IConnectionInfo connection, Guid value)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, value);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, value);
    }

    public BehaviorModel Load(ISqlConnectionInfo connection, Guid value)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[bm].ExternalBehaviorModelGuid = @ExternalBehaviorModelGuid";
      parameters.Arguments.Add("ExternalBehaviorModelGuid", value);
      return this.Load(connection, parameters);
    }

    public BehaviorModel Load(Service service, string searchPattern)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, service, searchPattern);
    }

    public BehaviorModel Load(IConnectionInfo connection, Service service, string searchPattern)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, service, searchPattern);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, service, searchPattern);
    }

    public BehaviorModel Load(ISqlConnectionInfo connection, Service service, string searchPattern)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();

      string serviceName = string.Format("{0}%", service.Name);
      string description = string.Format("%{0}%{1}%", service.Name, searchPattern);

      parameters.Where = "[bm].Name LIKE '@ServiceName' AND [bm].Description LIKE '@Description'";
      parameters.Arguments.Add("ServiceName", serviceName);
      parameters.Arguments.Add("Description", description);
      return this.Load(connection, parameters);
    }


    public List<BehaviorModel> Load(string name)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, name);
    }

    public List<BehaviorModel> Load(IConnectionInfo connection, string name)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, name);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, name);
    }

    public List<BehaviorModel> Load(ISqlConnectionInfo connection, string name)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[bm].Name=@Name";
      parameters.Arguments.Add("Name", name);
      return this.LoadMany(connection, parameters);
    }
  }
}

