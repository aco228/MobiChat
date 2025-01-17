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
  public partial class PaymentProviderManager : IPaymentProviderManager
  {
    public List<PaymentProvider> Load()
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection);
    }

    public List<PaymentProvider> Load(IConnectionInfo connection)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection);
    }

    public List<PaymentProvider> Load(ISqlConnectionInfo connection)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      return this.LoadMany(connection, parameters);
    }

    public PaymentProvider Load(Guid value)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, value);
    }

    public PaymentProvider Load(IConnectionInfo connection, Guid value)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, value);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, value);
    }

    public PaymentProvider Load(ISqlConnectionInfo connection, Guid value)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[pp].ExternalPaymentProviderGuid = @ExternalPaymentProviderGuid";
      parameters.Arguments.Add("ExternalPaymentProviderGuid", value);
      return this.Load(connection, parameters);
    }
  }
}

