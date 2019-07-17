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
  public partial class ServiceConfigurationManager : IServiceConfigurationManager
  {


    public ServiceConfiguration Load(string appID)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, appID);
    }

    public ServiceConfiguration Load(IConnectionInfo connection, string appID)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, appID);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, appID);
    }

    public ServiceConfiguration Load(ISqlConnectionInfo connection, string appID)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[sc].ExternalID = @appID";
      parameters.Arguments.Add("appID", appID);
      return this.Load(connection, parameters);
    }

  }
}

