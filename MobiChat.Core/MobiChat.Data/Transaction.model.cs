using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface ITransactionManager : IDataManager<Transaction> 
  {
	

  }

  public partial class Transaction : MobiChatObject<ITransactionManager> 
  {
		private Guid _guid;
		private Guid _externalTransactionGuid;
		private Guid _externalPurchaseGuid;
		private Guid _externalTransactionGroupGuid;
		private TransactionStatus _transactionStatus;
		private TransactionType _transactionType;
		

		public Guid Guid { get { return this._guid; } set { _guid = value; } }
		public Guid ExternalTransactionGuid { get { return this._externalTransactionGuid; } set { this._externalTransactionGuid = value;}}
		public Guid ExternalPurchaseGuid { get { return this._externalPurchaseGuid; } set { this._externalPurchaseGuid = value;}}
		public Guid ExternalTransactionGroupGuid { get { return this._externalTransactionGroupGuid; } set { this._externalTransactionGroupGuid = value;}}
		public TransactionStatus TransactionStatus  { get { return this._transactionStatus; } set { this._transactionStatus = value; } }
		public TransactionType TransactionType  { get { return this._transactionType; } set { this._transactionType = value; } }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public Transaction()
    { 
    }

    public Transaction(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public Transaction(int id,  Guid guid, Guid externalTransactionGuid, Guid externalPurchaseGuid, Guid externalTransactionGroupGuid, TransactionStatus transactionStatus, TransactionType transactionType, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._guid = guid;
			this._externalTransactionGuid = externalTransactionGuid;
			this._externalPurchaseGuid = externalPurchaseGuid;
			this._externalTransactionGroupGuid = externalTransactionGroupGuid;
			this._transactionStatus = transactionStatus;
			this._transactionType = transactionType;
			
    }

    public override object Clone(bool deepClone)
    {
      return new Transaction(-1, this.Guid,this.ExternalTransactionGuid,this.ExternalPurchaseGuid,this.ExternalTransactionGroupGuid, this.TransactionStatus, this.TransactionType, DateTime.Now, DateTime.Now);
    }
  }
}

