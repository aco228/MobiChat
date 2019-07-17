using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti;
using Senti.Data;
using Senti.Data.Sql;
using MobiChat.Data.Sql;



namespace MobiChat.Web.Data.Sql
{
  public partial class ServiceProfileGroupMapManager : IServiceProfileGroupMapManager
  {
    public List<ServiceProfileGroupMap> Load(MobiChat.Data.Service service)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, service);
    }

    public List<ServiceProfileGroupMap> Load(IConnectionInfo connection, MobiChat.Data.Service service)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, service);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, service);
    }

    public List<ServiceProfileGroupMap> Load(ISqlConnectionInfo connection, MobiChat.Data.Service service)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[spgm].ServiceID = @ServiceID";
      parameters.Arguments.Add("ServiceID", service.ID);
      return this.LoadMany(connection, parameters);
    }


  }
}

