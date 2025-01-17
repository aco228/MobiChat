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
  public partial class RouteParameterManager : IRouteParameterManager
  {
    public List<RouteParameter> Load(Route route)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, route);
    }

    public List<RouteParameter> Load(IConnectionInfo connection, Route route)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, route);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, route);
    }

    public List<RouteParameter> Load(ISqlConnectionInfo connection, Route route)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[rp].RouteID=@RouteID";
      parameters.Arguments.Add("RouteID", route.ID);
      return this.LoadMany(connection, parameters);
    }
  }
}

