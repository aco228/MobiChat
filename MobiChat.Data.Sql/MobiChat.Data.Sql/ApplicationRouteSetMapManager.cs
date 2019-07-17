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
  public partial class ApplicationRouteSetMapManager : IApplicationRouteSetMapManager
  {

    public List<ApplicationRouteSetMap> Load(Application application)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, application);
    }

    public List<ApplicationRouteSetMap> Load(IConnectionInfo connection, Application application)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, application);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, application);
    }

    public List<ApplicationRouteSetMap> Load(ISqlConnectionInfo connection, Application application)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[arsm].ApplicationID = @ApplicationID";
      parameters.Arguments.Add("ApplicationID", application.ID);
      return this.LoadMany(connection, parameters);
    }
  }
}

