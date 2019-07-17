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
  public class ActionContextTable : TableBase<ActionContext>
  {
    public static string GetColumnNames()
    {
      return TableBase<ActionContext>.GetColumnNames(string.Empty, ActionContextTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<ActionContext>.GetColumnNames(tablePrefix, ActionContextTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription ActionContextID = new ColumnDescription("ActionContextID", 0, typeof(int));
			public static readonly ColumnDescription ActionContextGroupID = new ColumnDescription("ActionContextGroupID", 1, typeof(int));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 2, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 3, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				ActionContextID,
				ActionContextGroupID,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public ActionContextTable(SqlQuery query) : base(query) { }
    public ActionContextTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int ActionContextID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ActionContextID)); } }
		public int ActionContextGroupID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ActionContextGroupID)); } }
		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public ActionContext CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new ActionContext(this.ActionContextID,new ActionContextGroup(this.ActionContextGroupID), this.Updated,this.Created); 
		}
		public ActionContext CreateInstance(ActionContextGroup actionContextGroup)  
		{ 
			if (!this.HasData) return null;
			return new ActionContext(this.ActionContextID,actionContextGroup ?? new ActionContextGroup(this.ActionContextGroupID), this.Updated,this.Created); 
		}
		

  }
}

