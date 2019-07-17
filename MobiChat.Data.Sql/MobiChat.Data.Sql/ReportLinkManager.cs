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
  public partial class ReportLinkManager : IReportLinkManager
  {


    public List<ReportLink> Load()
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection);
    }

    public List<ReportLink> Load(IConnectionInfo connection)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection);
    }

    public List<ReportLink> Load(ISqlConnectionInfo connection)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      return this.LoadMany(connection, parameters);
    }


    public List<ReportLink> Load(ReportLinkGroup group)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, group);
    }

    public List<ReportLink> Load(IConnectionInfo connection, ReportLinkGroup group)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, group);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, group);
    }

    public List<ReportLink> Load(ISqlConnectionInfo connection, ReportLinkGroup group)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[rl].ReportLinkGroupID=@ReportLinkGroupID";
      parameters.Arguments.Add("ReportLinkGroupID", group.ID);
      return this.LoadMany(connection, parameters);
    }



  }
}

