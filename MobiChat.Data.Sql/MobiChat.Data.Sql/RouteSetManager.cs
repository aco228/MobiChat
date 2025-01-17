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
  public partial class RouteSetManager : IRouteSetManager
  {
    public List<RouteSet> Load(Instance instance)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, instance);
    }

    public List<RouteSet> Load(IConnectionInfo connection, Instance instance)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, instance);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, instance);
    }

    public List<RouteSet> Load(ISqlConnectionInfo connection, Instance instance)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[rs].InstanceID=@InstanceID";
      parameters.Arguments.Add("InstanceID", instance.ID);
      return this.LoadMany(connection, parameters);
    }
  }
}

