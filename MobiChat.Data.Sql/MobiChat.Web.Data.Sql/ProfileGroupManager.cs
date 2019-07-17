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
  public partial class ProfileGroupManager : IProfileGroupManager
  {

    public ProfileGroup Load(MobiChat.Data.Instance instance, string name)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, instance, name);
    }

    public ProfileGroup Load(IConnectionInfo connection, MobiChat.Data.Instance instance, string name)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, instance, name);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, instance, name);
    }

    public ProfileGroup Load(ISqlConnectionInfo connection, MobiChat.Data.Instance instance, string name)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[pg].InstanceID=@InstanceID AND [pg].Name = @Name";
      parameters.Arguments.Add("InstanceID", instance.ID);
      parameters.Arguments.Add("Name", name);
      return this.Load(connection, parameters);
    }

  }
}

