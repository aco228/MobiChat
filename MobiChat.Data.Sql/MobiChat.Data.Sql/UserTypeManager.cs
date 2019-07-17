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
  public partial class UserTypeManager : IUserTypeManager
  {

    public List<UserType> Load()
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection);
    }

    public List<UserType> Load(IConnectionInfo connection)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection);
    }

    public List<UserType> Load(ISqlConnectionInfo connection)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      return this.LoadMany(connection, parameters);
    }

  }
}
