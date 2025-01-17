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
  public partial class TransactionManager : ITransactionManager
  {
    public Transaction Load(Guid transactionGuid, GuidType guidType)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, transactionGuid, guidType);
    }

    public Transaction Load(IConnectionInfo connection, Guid transactionGuid, GuidType guidType)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, transactionGuid, guidType);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, transactionGuid, guidType);
    }

    public Transaction Load(ISqlConnectionInfo connection, Guid transactionGuid, GuidType guidType)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      string parameter = guidType == GuidType.External ? "ExternalTransactionGuid" : "InternalTransactionGuid";
      parameters.Where = string.Format("[t].{0} = @{0}", parameter);
      parameters.Arguments.Add(parameter, transactionGuid);
      return this.Load(connection, parameters);
    }


    public Transaction Load(Guid transactionGroupGuid, Guid transactionGuid, GuidType guidType)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, transactionGroupGuid, transactionGuid, guidType);
    }

    public Transaction Load(IConnectionInfo connection, Guid transactionGroupGuid, Guid transactionGuid, GuidType guidType)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, transactionGroupGuid, transactionGuid, guidType);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, transactionGroupGuid, transactionGuid, guidType);
    }

    public Transaction Load(ISqlConnectionInfo connection, Guid transactionGroupGuid, Guid transactionGuid, GuidType guidType)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      string parameter = guidType == GuidType.External ? "ExternalTransactionGuid" : "InternalTransactionGuid";
      parameters.Where = string.Format("[t].ExternalTransactionGroupGuid = @ExternalTransactionGroupGuid AND [t].{0} = @{0}", parameter);
      parameters.Arguments.Add(parameter, transactionGuid);
      parameters.Arguments.Add("ExternalTransactionGroupGuid", transactionGroupGuid);
      return this.Load(connection, parameters);
    }


    public List<Transaction> Load(DateTime? from, DateTime? to)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, from, to);
    }

    public List<Transaction> Load(IConnectionInfo connection, DateTime? from, DateTime? to)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, from, to);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, from, to);
    }

    public List<Transaction> Load(ISqlConnectionInfo connection, DateTime? from, DateTime? to)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[t].Created >= ISNULL(CONVERT(DATE, @From), CONVERT(DATE, GETDATE())) AND [t].Created <= ISNULL(@To, GETDATE())";
      parameters.Arguments.Add("From", from == null ? (object)DBNull.Value : from.Value);
      parameters.Arguments.Add("To", to == null ? (object)DBNull.Value : to.Value);
      return this.LoadMany(connection, parameters);
    }
  }
}

