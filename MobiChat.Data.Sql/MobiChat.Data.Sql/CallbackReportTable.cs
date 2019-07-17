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
  public class CallbackReportTable : TableBase<CallbackReport>
  {
    public static string GetColumnNames()
    {
      return TableBase<CallbackReport>.GetColumnNames(string.Empty, CallbackReportTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<CallbackReport>.GetColumnNames(tablePrefix, CallbackReportTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription CallbackReportID = new ColumnDescription("CallbackReportID", 0, typeof(int));
			public static readonly ColumnDescription CallbackNotificationTypeID = new ColumnDescription("CallbackNotificationTypeID", 1, typeof(int));
			public static readonly ColumnDescription Url = new ColumnDescription("Url", 2, typeof(string));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 3, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 4, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				CallbackReportID,
				CallbackNotificationTypeID,
				Url,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public CallbackReportTable(SqlQuery query) : base(query) { }
    public CallbackReportTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int CallbackReportID { get { return this.Reader.GetInt32(this.GetIndex(Columns.CallbackReportID)); } }
		public int CallbackNotificationTypeID { get { return this.Reader.GetInt32(this.GetIndex(Columns.CallbackNotificationTypeID)); } }
		public string Url { get { return this.Reader.GetString(this.GetIndex(Columns.Url)); } }
		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public CallbackReport CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new CallbackReport(this.CallbackReportID,(CallbackNotificationType)this.CallbackNotificationTypeID,this.Url,this.Updated,this.Created); 
		}
		

  }
}

