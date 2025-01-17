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
  public partial class RouteManager : IRouteManager
  {
    public List<Route> Load(RouteSet routeSet)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, routeSet);
    }

    public List<Route> Load(IConnectionInfo connection, RouteSet routeSet)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, routeSet);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, routeSet);
    }

    public List<Route> Load(ISqlConnectionInfo connection, RouteSet routeSet)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[r].RouteSetID=@RouteSetID";
      parameters.Arguments.Add("RouteSetID", routeSet.ID);
      return this.LoadMany(connection, parameters);
    }
  }
}

