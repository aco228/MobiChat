using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti;
using Senti.Data;
using Senti.Data.Sql;

using MobiChat.Data;


namespace MobiChat.Data.Sql
{
  public class TransactionTable : TableBase<Transaction>
  {
    public static string GetColumnNames()
    {
      return TableBase<Transaction>.GetColumnNames(string.Empty, TransactionTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<Transaction>.GetColumnNames(tablePrefix, TransactionTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription TransactionID = new ColumnDescription("TransactionID", 0, typeof(int));
			public static readonly ColumnDescription TransactionGuid = new ColumnDescription("TransactionGuid", 1, typeof(Guid));
			public static readonly ColumnDescription ExternalTransactionGuid = new ColumnDescription("ExternalTransactionGuid", 2, typeof(Guid));
			public static readonly ColumnDescription ExternalPurchaseGuid = new ColumnDescription("ExternalPurchaseGuid", 3, typeof(Guid));
			public static readonly ColumnDescription ExternalTransactionGroupGuid = new ColumnDescription("ExternalTransactionGroupGuid", 4, typeof(Guid));
			public static readonly ColumnDescription TransactionStatusID = new ColumnDescription("TransactionStatusID", 5, typeof(int));
			public static readonly ColumnDescription TransactionTypeID = new ColumnDescription("TransactionTypeID", 6, typeof(int));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 7, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 8, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				TransactionID,
				TransactionGuid,
				ExternalTransactionGuid,
				ExternalPurchaseGuid,
				ExternalTransactionGroupGuid,
				TransactionStatusID,
				TransactionTypeID,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public TransactionTable(SqlQuery query) : base(query) { }
    public TransactionTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int TransactionID { get { return this.Reader.GetInt32(this.GetIndex(Columns.TransactionID)); } }
		public Guid TransactionGuid { get { return this.Reader.GetGuid(this.GetIndex(Columns.TransactionGuid)); } }
		public Guid ExternalTransactionGuid { get { return this.Reader.GetGuid(this.GetIndex(Columns.ExternalTransactionGuid)); } }
		public Guid ExternalPurchaseGuid { get { return this.Reader.GetGuid(this.GetIndex(Columns.ExternalPurchaseGuid)); } }
		public Guid ExternalTransactionGroupGuid { get { return this.Reader.GetGuid(this.GetIndex(Columns.ExternalTransactionGroupGuid)); } }
		public int TransactionStatusID { get { return this.Reader.GetInt32(this.GetIndex(Columns.TransactionStatusID)); } }
		public int TransactionTypeID { get { return this.Reader.GetInt32(this.GetIndex(Columns.TransactionTypeID)); } }
		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public Transaction CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new Transaction(this.TransactionID,this.TransactionGuid,this.ExternalTransactionGuid,this.ExternalPurchaseGuid,this.ExternalTransactionGroupGuid,(TransactionStatus)this.TransactionStatusID,(TransactionType)this.TransactionTypeID,this.Updated,this.Created); 
		}
		

  }
}

