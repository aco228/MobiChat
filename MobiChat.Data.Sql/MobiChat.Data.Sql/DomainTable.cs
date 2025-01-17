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
  public class DomainTable : TableBase<Domain>
  {
    public static string GetColumnNames()
    {
      return TableBase<Domain>.GetColumnNames(string.Empty, DomainTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<Domain>.GetColumnNames(tablePrefix, DomainTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription DomainID = new ColumnDescription("DomainID", 0, typeof(int));
			public static readonly ColumnDescription ServiceID = new ColumnDescription("ServiceID", 1, typeof(int));
			public static readonly ColumnDescription DomainName = new ColumnDescription("DomainName", 2, typeof(string));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 3, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 4, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				DomainID,
				ServiceID,
				DomainName,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public DomainTable(SqlQuery query) : base(query) { }
    public DomainTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int DomainID { get { return this.Reader.GetInt32(this.GetIndex(Columns.DomainID)); } }
		public int ServiceID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ServiceID)); } }
		public string DomainName { get { return this.Reader.GetString(this.GetIndex(Columns.DomainName)); } }
		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public Domain CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new Domain(this.DomainID,new Service(this.ServiceID), this.DomainName,this.Updated,this.Created); 
		}
		public Domain CreateInstance(Service service)  
		{ 
			if (!this.HasData) return null;
			return new Domain(this.DomainID,service ?? new Service(this.ServiceID), this.DomainName,this.Updated,this.Created); 
		}
		

  }
}

