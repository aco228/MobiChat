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
  public class PaymentInterfaceTable : TableBase<PaymentInterface>
  {
    public static string GetColumnNames()
    {
      return TableBase<PaymentInterface>.GetColumnNames(string.Empty, PaymentInterfaceTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<PaymentInterface>.GetColumnNames(tablePrefix, PaymentInterfaceTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription PaymentInterfaceID = new ColumnDescription("PaymentInterfaceID", 0, typeof(int));
			public static readonly ColumnDescription ExternalPaymentInterfaceGuid = new ColumnDescription("ExternalPaymentInterfaceGuid", 1, typeof(Guid));
			public static readonly ColumnDescription Name = new ColumnDescription("Name", 2, typeof(string));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 3, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 4, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				PaymentInterfaceID,
				ExternalPaymentInterfaceGuid,
				Name,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public PaymentInterfaceTable(SqlQuery query) : base(query) { }
    public PaymentInterfaceTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int PaymentInterfaceID { get { return this.Reader.GetInt32(this.GetIndex(Columns.PaymentInterfaceID)); } }
		public Guid ExternalPaymentInterfaceGuid { get { return this.Reader.GetGuid(this.GetIndex(Columns.ExternalPaymentInterfaceGuid)); } }
		public string Name { get { return this.Reader.GetString(this.GetIndex(Columns.Name)); } }
		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public PaymentInterface CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new PaymentInterface(this.PaymentInterfaceID,this.ExternalPaymentInterfaceGuid,this.Name,this.Updated,this.Created); 
		}
		

  }
}

