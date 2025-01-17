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
  public class PaymentCredentialsTable : TableBase<PaymentCredentials>
  {
    public static string GetColumnNames()
    {
      return TableBase<PaymentCredentials>.GetColumnNames(string.Empty, PaymentCredentialsTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<PaymentCredentials>.GetColumnNames(tablePrefix, PaymentCredentialsTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription PaymentCredentialsID = new ColumnDescription("PaymentCredentialsID", 0, typeof(int));
			public static readonly ColumnDescription Username = new ColumnDescription("Username", 1, typeof(string));
			public static readonly ColumnDescription Password = new ColumnDescription("Password", 2, typeof(string));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 3, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 4, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				PaymentCredentialsID,
				Username,
				Password,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public PaymentCredentialsTable(SqlQuery query) : base(query) { }
    public PaymentCredentialsTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int PaymentCredentialsID { get { return this.Reader.GetInt32(this.GetIndex(Columns.PaymentCredentialsID)); } }
		public string Username { get { return this.Reader.GetString(this.GetIndex(Columns.Username)); } }
		public string Password { get { return this.Reader.GetString(this.GetIndex(Columns.Password)); } }
		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public PaymentCredentials CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new PaymentCredentials(this.PaymentCredentialsID,this.Username,this.Password,this.Updated,this.Created); 
		}
		

  }
}

