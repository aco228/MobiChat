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
  public class MTMessageTable : TableBase<MTMessage>
  {
    public static string GetColumnNames()
    {
      return TableBase<MTMessage>.GetColumnNames(string.Empty, MTMessageTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<MTMessage>.GetColumnNames(tablePrefix, MTMessageTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription MTMessageID = new ColumnDescription("MTMessageID", 0, typeof(int));
			public static readonly ColumnDescription MessageID = new ColumnDescription("MessageID", 1, typeof(int));
			public static readonly ColumnDescription AppID = new ColumnDescription("AppID", 2, typeof(string));
			public static readonly ColumnDescription To = new ColumnDescription("To", 3, typeof(string));
			public static readonly ColumnDescription MsgID = new ColumnDescription("MsgID", 4, typeof(string));
			public static readonly ColumnDescription Time = new ColumnDescription("Time", 5, typeof(string));
			public static readonly ColumnDescription State = new ColumnDescription("State", 6, typeof(string));
			public static readonly ColumnDescription Error = new ColumnDescription("Error", 7, typeof(string));
			public static readonly ColumnDescription ReasonCode = new ColumnDescription("ReasonCode", 8, typeof(string));
			public static readonly ColumnDescription Retry = new ColumnDescription("Retry", 9, typeof(string));
			public static readonly ColumnDescription AppMsgID = new ColumnDescription("AppMsgID", 10, typeof(string));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 11, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 12, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				MTMessageID,
				MessageID,
				AppID,
				To,
				MsgID,
				Time,
				State,
				Error,
				ReasonCode,
				Retry,
				AppMsgID,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public MTMessageTable(SqlQuery query) : base(query) { }
    public MTMessageTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int MTMessageID { get { return this.Reader.GetInt32(this.GetIndex(Columns.MTMessageID)); } }
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

		
		public string To 
		{
			get
			{
				int index = this.GetIndex(Columns.To);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		
		public string MsgID 
		{
			get
			{
				int index = this.GetIndex(Columns.MsgID);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		
		public string Time 
		{
			get
			{
				int index = this.GetIndex(Columns.Time);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		
		public string State 
		{
			get
			{
				int index = this.GetIndex(Columns.State);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		
		public string Error 
		{
			get
			{
				int index = this.GetIndex(Columns.Error);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		
		public string ReasonCode 
		{
			get
			{
				int index = this.GetIndex(Columns.ReasonCode);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		
		public string Retry 
		{
			get
			{
				int index = this.GetIndex(Columns.Retry);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		
		public string AppMsgID 
		{
			get
			{
				int index = this.GetIndex(Columns.AppMsgID);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public MTMessage CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new MTMessage(this.MTMessageID,new Message(this.MessageID), this.AppID,this.To,this.MsgID,this.Time,this.State,this.Error,this.ReasonCode,this.Retry,this.AppMsgID,this.Updated,this.Created); 
		}
		public MTMessage CreateInstance(Message message)  
		{ 
			if (!this.HasData) return null;
			return new MTMessage(this.MTMessageID,message ?? new Message(this.MessageID), this.AppID,this.To,this.MsgID,this.Time,this.State,this.Error,this.ReasonCode,this.Retry,this.AppMsgID,this.Updated,this.Created); 
		}
		

  }
}

