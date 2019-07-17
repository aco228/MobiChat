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
  public class ReportTable : TableBase<Report>
  {
    public static string GetColumnNames()
    {
      return TableBase<Report>.GetColumnNames(string.Empty, ReportTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<Report>.GetColumnNames(tablePrefix, ReportTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription ReportID = new ColumnDescription("ReportID", 0, typeof(int));
			public static readonly ColumnDescription ReportLinkID = new ColumnDescription("ReportLinkID", 1, typeof(int));
			public static readonly ColumnDescription Pxid = new ColumnDescription("Pxid", 2, typeof(int));
			public static readonly ColumnDescription AdditionalData = new ColumnDescription("AdditionalData", 3, typeof(string));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 4, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 5, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				ReportID,
				ReportLinkID,
				Pxid,
				AdditionalData,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public ReportTable(SqlQuery query) : base(query) { }
    public ReportTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int ReportID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ReportID)); } }
		public int ReportLinkID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ReportLinkID)); } }
		
		public int? Pxid 
		{
			get
			{
				int index = this.GetIndex(Columns.Pxid);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetInt32(index);
			}
		}

		
		public string AdditionalData 
		{
			get
			{
				int index = this.GetIndex(Columns.AdditionalData);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public Report CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new Report(this.ReportID,new ReportLink(this.ReportLinkID), this.Pxid,this.AdditionalData,this.Updated,this.Created); 
		}
		public Report CreateInstance(ReportLink reportLink)  
		{ 
			if (!this.HasData) return null;
			return new Report(this.ReportID,reportLink ?? new ReportLink(this.ReportLinkID), this.Pxid,this.AdditionalData,this.Updated,this.Created); 
		}
		

  }
}

