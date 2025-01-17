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
  public partial class MerchantManager : IMerchantManager
  {
    public List<Merchant> Load()
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection);
    }

    public List<Merchant> Load(IConnectionInfo connection)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection);
    }

    public List<Merchant> Load(ISqlConnectionInfo connection)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      return this.LoadMany(connection, parameters);
    }


    public List<Merchant> Load(Instance instance)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, instance);
    }

    public List<Merchant> Load(IConnectionInfo connection, Instance instance)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, instance);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, instance);
    }

    public List<Merchant> Load(ISqlConnectionInfo connection, Instance instance)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[m].InstanceID=@InstanceID";
      parameters.Arguments.Add("InstanceID", instance.ID);
      return this.LoadMany(connection, parameters);
    }
  }
}

