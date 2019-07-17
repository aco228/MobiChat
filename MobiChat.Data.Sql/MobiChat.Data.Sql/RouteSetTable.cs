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
  public class RouteSetTable : TableBase<RouteSet>
  {
    public static string GetColumnNames()
    {
      return TableBase<RouteSet>.GetColumnNames(string.Empty, RouteSetTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<RouteSet>.GetColumnNames(tablePrefix, RouteSetTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription RouteSetID = new ColumnDescription("RouteSetID", 0, typeof(int));
			public static readonly ColumnDescription InstanceID = new ColumnDescription("InstanceID", 1, typeof(int));
			public static readonly ColumnDescription Name = new ColumnDescription("Name", 2, typeof(string));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 3, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 4, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				RouteSetID,
				InstanceID,
				Name,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public RouteSetTable(SqlQuery query) : base(query) { }
    public RouteSetTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int RouteSetID { get { return this.Reader.GetInt32(this.GetIndex(Columns.RouteSetID)); } }
		public int InstanceID { get { return this.Reader.GetInt32(this.GetIndex(Columns.InstanceID)); } }
		public string Name { get { return this.Reader.GetString(this.GetIndex(Columns.Name)); } }
		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public RouteSet CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new RouteSet(this.RouteSetID,new Instance(this.InstanceID), this.Name,this.Updated,this.Created); 
		}
		public RouteSet CreateInstance(Instance instance)  
		{ 
			if (!this.HasData) return null;
			return new RouteSet(this.RouteSetID,instance ?? new Instance(this.InstanceID), this.Name,this.Updated,this.Created); 
		}
		

  }
}
