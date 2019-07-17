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
  public partial class UserDetailManager : IUserDetailManager
  {
    public UserDetail Load(User user)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, user);
    }

    public UserDetail Load(IConnectionInfo connection, User user)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, user);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, user);
    }

    public UserDetail Load(ISqlConnectionInfo connection, User user)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[ud].UserID=@UserID";
      parameters.Arguments.Add("UserID", user.ID);
      return this.Load(connection, parameters);
    }

  }
}

