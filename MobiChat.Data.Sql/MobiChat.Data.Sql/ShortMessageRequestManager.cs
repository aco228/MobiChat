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
  public partial class ShortMessageRequestManager : IShortMessageRequestManager
  {


    public ShortMessageRequest Load(Guid guid)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, guid);
    }

    public ShortMessageRequest Load(IConnectionInfo connection, Guid guid)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, guid);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, guid);
    }

    public ShortMessageRequest Load(ISqlConnectionInfo connection, Guid guid)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[smr].ShortMessageRequestGuid = @ShortMessageRequestGuid";
      parameters.Arguments.Add("ShortMessageRequestGuid", guid);
      return this.Load(connection, parameters);
    }

  }
}

