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
  public class PaymentProviderTable : TableBase<PaymentProvider>
  {
    public static string GetColumnNames()
    {
      return TableBase<PaymentProvider>.GetColumnNames(string.Empty, PaymentProviderTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<PaymentProvider>.GetColumnNames(tablePrefix, PaymentProviderTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription PaymentProviderID = new ColumnDescription("PaymentProviderID", 0, typeof(int));
			public static readonly ColumnDescription ExternalPaymentProviderGuid = new ColumnDescription("ExternalPaymentProviderGuid", 1, typeof(Guid));
			public static readonly ColumnDescription Name = new ColumnDescription("Name", 2, typeof(string));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 3, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 4, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				PaymentProviderID,
				ExternalPaymentProviderGuid,
				Name,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public PaymentProviderTable(SqlQuery query) : base(query) { }
    public PaymentProviderTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int PaymentProviderID { get { return this.Reader.GetInt32(this.GetIndex(Columns.PaymentProviderID)); } }
		
		public Guid? ExternalPaymentProviderGuid 
		{
			get
			{
				int index = this.GetIndex(Columns.ExternalPaymentProviderGuid);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetGuid(index);
			}
		}

		public string Name { get { return this.Reader.GetString(this.GetIndex(Columns.Name)); } }
		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public PaymentProvider CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new PaymentProvider(this.PaymentProviderID,this.ExternalPaymentProviderGuid,this.Name,this.Updated,this.Created); 
		}
		

  }
}

