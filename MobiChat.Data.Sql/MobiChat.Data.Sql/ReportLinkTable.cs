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
  public class ReportLinkTable : TableBase<ReportLink>
  {
    public static string GetColumnNames()
    {
      return TableBase<ReportLink>.GetColumnNames(string.Empty, ReportLinkTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<ReportLink>.GetColumnNames(tablePrefix, ReportLinkTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription ReportLinkID = new ColumnDescription("ReportLinkID", 0, typeof(int));
			public static readonly ColumnDescription ReportLinkGroupID = new ColumnDescription("ReportLinkGroupID", 1, typeof(int));
			public static readonly ColumnDescription Url = new ColumnDescription("Url", 2, typeof(string));
			public static readonly ColumnDescription IsActive = new ColumnDescription("IsActive", 3, typeof(bool));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 4, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 5, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				ReportLinkID,
				ReportLinkGroupID,
				Url,
				IsActive,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public ReportLinkTable(SqlQuery query) : base(query) { }
    public ReportLinkTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int ReportLinkID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ReportLinkID)); } }
		public int ReportLinkGroupID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ReportLinkGroupID)); } }
		public string Url { get { return this.Reader.GetString(this.GetIndex(Columns.Url)); } }
		public bool IsActive { get { return this.Reader.GetBoolean(this.GetIndex(Columns.IsActive)); } }
		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public ReportLink CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new ReportLink(this.ReportLinkID,new ReportLinkGroup(this.ReportLinkGroupID), this.Url,this.IsActive,this.Updated,this.Created); 
		}
		public ReportLink CreateInstance(ReportLinkGroup reportLinkGroup)  
		{ 
			if (!this.HasData) return null;
			return new ReportLink(this.ReportLinkID,reportLinkGroup ?? new ReportLinkGroup(this.ReportLinkGroupID), this.Url,this.IsActive,this.Updated,this.Created); 
		}
		

  }
}

