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
  public class ShortMessageRequestTable : TableBase<ShortMessageRequest>
  {
    public static string GetColumnNames()
    {
      return TableBase<ShortMessageRequest>.GetColumnNames(string.Empty, ShortMessageRequestTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<ShortMessageRequest>.GetColumnNames(tablePrefix, ShortMessageRequestTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription ShortMessageRequestID = new ColumnDescription("ShortMessageRequestID", 0, typeof(int));
			public static readonly ColumnDescription ShortMessageRequestGuid = new ColumnDescription("ShortMessageRequestGuid", 1, typeof(Guid));
			public static readonly ColumnDescription ShortMessageID = new ColumnDescription("ShortMessageID", 2, typeof(int));
			public static readonly ColumnDescription UserID = new ColumnDescription("UserID", 3, typeof(int));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 4, typeof(DateTime));
			public static readonly ColumnDescription Creatred = new ColumnDescription("Creatred", 5, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				ShortMessageRequestID,
				ShortMessageRequestGuid,
				ShortMessageID,
				UserID,
				Updated,
				Creatred
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public ShortMessageRequestTable(SqlQuery query) : base(query) { }
    public ShortMessageRequestTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int ShortMessageRequestID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ShortMessageRequestID)); } }
		public Guid ShortMessageRequestGuid { get { return this.Reader.GetGuid(this.GetIndex(Columns.ShortMessageRequestGuid)); } }
		public int ShortMessageID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ShortMessageID)); } }
		public int UserID { get { return this.Reader.GetInt32(this.GetIndex(Columns.UserID)); } }
		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Creatred { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Creatred)); } }
		

	  public ShortMessageRequest CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new ShortMessageRequest(this.ShortMessageRequestID,this.ShortMessageRequestGuid,new ShortMessage(this.ShortMessageID), new User(this.UserID), this.Updated,this.Creatred); 
		}
		public ShortMessageRequest CreateInstance(ShortMessage shortMessage)  
		{ 
			if (!this.HasData) return null;
			return new ShortMessageRequest(this.ShortMessageRequestID,this.ShortMessageRequestGuid,shortMessage ?? new ShortMessage(this.ShortMessageID), new User(this.UserID), this.Updated,this.Creatred); 
		}
		public ShortMessageRequest CreateInstance(User user)  
		{ 
			if (!this.HasData) return null;
			return new ShortMessageRequest(this.ShortMessageRequestID,this.ShortMessageRequestGuid,new ShortMessage(this.ShortMessageID), user ?? new User(this.UserID), this.Updated,this.Creatred); 
		}
		public ShortMessageRequest CreateInstance(ShortMessage shortMessage, User user)  
		{ 
			if (!this.HasData) return null;
			return new ShortMessageRequest(this.ShortMessageRequestID,this.ShortMessageRequestGuid,shortMessage ?? new ShortMessage(this.ShortMessageID), user ?? new User(this.UserID), this.Updated,this.Creatred); 
		}
		

  }
}

