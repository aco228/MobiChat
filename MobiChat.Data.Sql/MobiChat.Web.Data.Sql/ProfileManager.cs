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
  public partial class ProfileManager : IProfileManager
  {

    public List<Profile> Load()
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection);
    }

    public List<Profile> Load(IConnectionInfo connection)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection);
    }

    public List<Profile> Load(ISqlConnectionInfo connection)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();

      return this.LoadMany(connection, parameters);
    }

    public List<Profile> Load(ProfileGroup profileGroup)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, profileGroup);
    }

    public List<Profile> Load(IConnectionInfo connection, ProfileGroup profileGroup)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, profileGroup);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, profileGroup);
    }

    public List<Profile> Load(ISqlConnectionInfo connection, ProfileGroup profileGroup)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[p].ProfileGroupID = @ProfileGroupID";
      parameters.Arguments.Add("ProfileGroupID", profileGroup.ID);
      return this.LoadMany(connection, parameters);
    }
  }
}

