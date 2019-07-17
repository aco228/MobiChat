using Senti.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 

namespace MobiChat.Data 
{
  public partial interface ITransactionManager 
  {
    List<Transaction> Load(DateTime? from, DateTime? to);
    List<Transaction> Load(IConnectionInfo connection, DateTime? from, DateTime? to);

    Transaction Load(Guid transactionGuid, GuidType guidType);
    Transaction Load(IConnectionInfo connection, Guid transactionGuid, GuidType guidType);
    Transaction Load(Guid transactionGroupGuid, Guid transactionGuid, GuidType guidType);
    Transaction Load(IConnectionInfo connection, Guid transactionGroupGuid, Guid transactionGuid, GuidType guidType);
  }

  public partial class Transaction
  {
  }
}

