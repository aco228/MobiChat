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
  public class RouteTable : TableBase<Route>
  {
    public static string GetColumnNames()
    {
      return TableBase<Route>.GetColumnNames(string.Empty, RouteTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<Route>.GetColumnNames(tablePrefix, RouteTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription RouteID = new ColumnDescription("RouteID", 0, typeof(int));
			public static readonly ColumnDescription RouteSetID = new ColumnDescription("RouteSetID", 1, typeof(int));
			public static readonly ColumnDescription Name = new ColumnDescription("Name", 2, typeof(string));
			public static readonly ColumnDescription Action = new ColumnDescription("Action", 3, typeof(string));
			public static readonly ColumnDescription Controller = new ColumnDescription("Controller", 4, typeof(string));
			public static readonly ColumnDescription Pattern = new ColumnDescription("Pattern", 5, typeof(string));
			public static readonly ColumnDescription IsIgnore = new ColumnDescription("IsIgnore", 6, typeof(bool));
			public static readonly ColumnDescription IsEnabled = new ColumnDescription("IsEnabled", 7, typeof(bool));
			public static readonly ColumnDescription Index = new ColumnDescription("Index", 8, typeof(int));
			public static readonly ColumnDescription IsSessionRoute = new ColumnDescription("IsSessionRoute", 9, typeof(bool));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 10, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 11, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				RouteID,
				RouteSetID,
				Name,
				Action,
				Controller,
				Pattern,
				IsIgnore,
				IsEnabled,
				Index,
				IsSessionRoute,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public RouteTable(SqlQuery query) : base(query) { }
    public RouteTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int RouteID { get { return this.Reader.GetInt32(this.GetIndex(Columns.RouteID)); } }
		public int RouteSetID { get { return this.Reader.GetInt32(this.GetIndex(Columns.RouteSetID)); } }
		public string Name { get { return this.Reader.GetString(this.GetIndex(Columns.Name)); } }
		
		public string Action 
		{
			get
			{
				int index = this.GetIndex(Columns.Action);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		
		public string Controller 
		{
			get
			{
				int index = this.GetIndex(Columns.Controller);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		public string Pattern { get { return this.Reader.GetString(this.GetIndex(Columns.Pattern)); } }
		
		public bool? IsIgnore 
		{
			get
			{
				int index = this.GetIndex(Columns.IsIgnore);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetBoolean(index);
			}
		}

		
		public bool? IsEnabled 
		{
			get
			{
				int index = this.GetIndex(Columns.IsEnabled);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetBoolean(index);
			}
		}

		public int Index { get { return this.Reader.GetInt32(this.GetIndex(Columns.Index)); } }
		public bool IsSessionRoute { get { return this.Reader.GetBoolean(this.GetIndex(Columns.IsSessionRoute)); } }
		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public Route CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new Route(this.RouteID,new RouteSet(this.RouteSetID), this.Name,this.Action,this.Controller,this.Pattern,this.IsIgnore,this.IsEnabled,this.Index,this.IsSessionRoute,this.Updated,this.Created); 
		}
		public Route CreateInstance(RouteSet routeSet)  
		{ 
			if (!this.HasData) return null;
			return new Route(this.RouteID,routeSet ?? new RouteSet(this.RouteSetID), this.Name,this.Action,this.Controller,this.Pattern,this.IsIgnore,this.IsEnabled,this.Index,this.IsSessionRoute,this.Updated,this.Created); 
		}
		

  }
}

