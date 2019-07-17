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
  public class ActionContextGroupTable : TableBase<ActionContextGroup>
  {
    public static string GetColumnNames()
    {
      return TableBase<ActionContextGroup>.GetColumnNames(string.Empty, ActionContextGroupTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<ActionContextGroup>.GetColumnNames(tablePrefix, ActionContextGroupTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription ActionContextGroupID = new ColumnDescription("ActionContextGroupID", 0, typeof(int));
			public static readonly ColumnDescription Name = new ColumnDescription("Name", 1, typeof(string));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 2, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 3, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				ActionContextGroupID,
				Name,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public ActionContextGroupTable(SqlQuery query) : base(query) { }
    public ActionContextGroupTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int ActionContextGroupID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ActionContextGroupID)); } }
		
		public string Name 
		{
			get
			{
				int index = this.GetIndex(Columns.Name);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public ActionContextGroup CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new ActionContextGroup(this.ActionContextGroupID,this.Name,this.Updated,this.Created); 
		}
		

  }
}

