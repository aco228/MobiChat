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
  public partial class ServiceLogoManager : IServiceLogoManager
  {
    public ServiceLogo Load(Service service)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, service);
    }

    public ServiceLogo Load(IConnectionInfo connection, Service service)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, service);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, service);
    }

    public ServiceLogo Load(ISqlConnectionInfo connection, Service service)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[sl].ServiceID=@ServiceID";
      parameters.Arguments.Add("ServiceID", service.ID);
      return this.Load(connection, parameters);
    }
  }
}

