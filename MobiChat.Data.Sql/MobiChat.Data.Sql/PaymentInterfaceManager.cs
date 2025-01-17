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
  public partial class PaymentInterfaceManager : IPaymentInterfaceManager
  {
    public List<PaymentInterface> Load()
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection);
    }

    public List<PaymentInterface> Load(IConnectionInfo connection)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection);
    }

    public List<PaymentInterface> Load(ISqlConnectionInfo connection)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      return this.LoadMany(connection, parameters);
    }


    public PaymentInterface Load(Guid value)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, value);
    }

    public PaymentInterface Load(IConnectionInfo connection, Guid value)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, value);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, value);
    }

    public PaymentInterface Load(ISqlConnectionInfo connection, Guid value)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[pi].ExternalPaymentInterfaceGuid = @ExternalPaymentInterfaceGuid";
      parameters.Arguments.Add("ExternalPaymentInterfaceGuid", value);
      return this.Load(connection, parameters);
    }
  }
}

