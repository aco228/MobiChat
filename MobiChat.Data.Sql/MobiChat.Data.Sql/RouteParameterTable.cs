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
  public class RouteParameterTable : TableBase<RouteParameter>
  {
    public static string GetColumnNames()
    {
      return TableBase<RouteParameter>.GetColumnNames(string.Empty, RouteParameterTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<RouteParameter>.GetColumnNames(tablePrefix, RouteParameterTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription RouteParameterID = new ColumnDescription("RouteParameterID", 0, typeof(int));
			public static readonly ColumnDescription RouteID = new ColumnDescription("RouteID", 1, typeof(int));
			public static readonly ColumnDescription Key = new ColumnDescription("Key", 2, typeof(string));
			public static readonly ColumnDescription Value = new ColumnDescription("Value", 3, typeof(string));
			public static readonly ColumnDescription Constraint = new ColumnDescription("Constraint", 4, typeof(string));
			public static readonly ColumnDescription IsOptional = new ColumnDescription("IsOptional", 5, typeof(bool));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 6, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 7, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				RouteParameterID,
				RouteID,
				Key,
				Value,
				Constraint,
				IsOptional,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public RouteParameterTable(SqlQuery query) : base(query) { }
    public RouteParameterTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int RouteParameterID { get { return this.Reader.GetInt32(this.GetIndex(Columns.RouteParameterID)); } }
		public int RouteID { get { return this.Reader.GetInt32(this.GetIndex(Columns.RouteID)); } }
		public string Key { get { return this.Reader.GetString(this.GetIndex(Columns.Key)); } }
		
		public string Value 
		{
			get
			{
				int index = this.GetIndex(Columns.Value);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		
		public string Constraint 
		{
			get
			{
				int index = this.GetIndex(Columns.Constraint);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		public bool IsOptional { get { return this.Reader.GetBoolean(this.GetIndex(Columns.IsOptional)); } }
		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public RouteParameter CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new RouteParameter(this.RouteParameterID,new Route(this.RouteID), this.Key,this.Value,this.Constraint,this.IsOptional,this.Updated,this.Created); 
		}
		public RouteParameter CreateInstance(Route route)  
		{ 
			if (!this.HasData) return null;
			return new RouteParameter(this.RouteParameterID,route ?? new Route(this.RouteID), this.Key,this.Value,this.Constraint,this.IsOptional,this.Updated,this.Created); 
		}
		

  }
}

