using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti;
using Senti.Data;
using Senti.Data.Sql;

using MobiChat.Data;


namespace MobiChat.Web.Data.Sql
{
  public class MOMessageTable : TableBase<MOMessage>
  {
    public static string GetColumnNames()
    {
      return TableBase<MOMessage>.GetColumnNames(string.Empty, MOMessageTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<MOMessage>.GetColumnNames(tablePrefix, MOMessageTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription MOMessageID = new ColumnDescription("MOMessageID", 0, typeof(int));
			public static readonly ColumnDescription MessageID = new ColumnDescription("MessageID", 1, typeof(int));
			public static readonly ColumnDescription AppID = new ColumnDescription("AppID", 2, typeof(string));
			public static readonly ColumnDescription From = new ColumnDescription("From", 3, typeof(string));
			public static readonly ColumnDescription Operator = new ColumnDescription("Operator", 4, typeof(string));
			public static readonly ColumnDescription To = new ColumnDescription("To", 5, typeof(string));
			public static readonly ColumnDescription Keyword = new ColumnDescription("Keyword", 6, typeof(string));
			public static readonly ColumnDescription Tariff = new ColumnDescription("Tariff", 7, typeof(string));
			public static readonly ColumnDescription MessageText = new ColumnDescription("MessageText", 8, typeof(string));
			public static readonly ColumnDescription SmsID = new ColumnDescription("SmsID", 9, typeof(string));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 10, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 11, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				MOMessageID,
				MessageID,
				AppID,
				From,
				Operator,
				To,
				Keyword,
				Tariff,
				MessageText,
				SmsID,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public MOMessageTable(SqlQuery query) : base(query) { }
    public MOMessageTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int MOMessageID { get { return this.Reader.GetInt32(this.GetIndex(Columns.MOMessageID)); } }
		public int MessageID { get { return this.Reader.GetInt32(this.GetIndex(Columns.MessageID)); } }
		
		public string AppID 
		{
			get
			{
				int index = this.GetIndex(Columns.AppID);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		
		public string From 
		{
			get
			{
				int index = this.GetIndex(Columns.From);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		
		public string Operator 
		{
			get
			{
				int index = this.GetIndex(Columns.Operator);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		
		public string To 
		{
			get
			{
				int index = this.GetIndex(Columns.To);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		
		public string Keyword 
		{
			get
			{
				int index = this.GetIndex(Columns.Keyword);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		
		public string Tariff 
		{
			get
			{
				int index = this.GetIndex(Columns.Tariff);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		
		public string MessageText 
		{
			get
			{
				int index = this.GetIndex(Columns.MessageText);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		
		public string SmsID 
		{
			get
			{
				int index = this.GetIndex(Columns.SmsID);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public MOMessage CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new MOMessage(this.MOMessageID,new Message(this.MessageID), this.AppID,this.From,this.Operator,this.To,this.Keyword,this.Tariff,this.MessageText,this.SmsID,this.Updated,this.Created); 
		}
		public MOMessage CreateInstance(Message message)  
		{ 
			if (!this.HasData) return null;
			return new MOMessage(this.MOMessageID,message ?? new Message(this.MessageID), this.AppID,this.From,this.Operator,this.To,this.Keyword,this.Tariff,this.MessageText,this.SmsID,this.Updated,this.Created); 
		}
		

  }
}

