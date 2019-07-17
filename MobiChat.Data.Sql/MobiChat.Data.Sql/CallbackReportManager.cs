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
  public partial class CallbackReportManager : ICallbackReportManager
  {

    public List<CallbackReport> Load(CallbackNotificationType type)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, type);
    }

    public List<CallbackReport> Load(IConnectionInfo connection, CallbackNotificationType type)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, type);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, type);
    }

    public List<CallbackReport> Load(ISqlConnectionInfo connection, CallbackNotificationType type)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[cr].CallbackNotificationTypeID = @CallbackNotificationTypeID";
      parameters.Arguments.Add("CallbackNotificationTypeID", (int)type);
      return this.LoadMany(connection, parameters);
    }

  }
}

