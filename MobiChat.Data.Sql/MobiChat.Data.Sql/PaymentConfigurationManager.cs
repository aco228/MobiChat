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
  public partial class PaymentConfigurationManager : IPaymentConfigurationManager
  {
    public List<PaymentConfiguration> Load()
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection);
    }

    public List<PaymentConfiguration> Load(IConnectionInfo connection)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection);
    }

    public List<PaymentConfiguration> Load(ISqlConnectionInfo connection)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      return this.LoadMany(connection, parameters);
    }


    public PaymentConfiguration Load(BehaviorModel behaviorModel)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, behaviorModel);
    }

    public PaymentConfiguration Load(IConnectionInfo connection, BehaviorModel behaviorModel)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, behaviorModel);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, behaviorModel);
    }

    public PaymentConfiguration Load(ISqlConnectionInfo connection, BehaviorModel behaviorModel)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[pc].BehaviorModelID = @BehaviorModelID";
      parameters.Arguments.Add("BehaviorModelID", behaviorModel.ID);
      return this.Load(connection, parameters);
    }


    public PaymentConfiguration Load(string name)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, name);
    }

    public PaymentConfiguration Load(IConnectionInfo connection, string name)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, name);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, name);
    }

    public PaymentConfiguration Load(ISqlConnectionInfo connection, string name)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[pc].name = @Name";
      parameters.Arguments.Add("Name", name);
      return this.Load(connection, parameters);
    }
  }
}

