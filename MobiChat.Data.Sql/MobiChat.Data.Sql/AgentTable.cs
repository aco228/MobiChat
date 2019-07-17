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
  public class AgentTable : TableBase<Agent>
  {
    public static string GetColumnNames()
    {
      return TableBase<Agent>.GetColumnNames(string.Empty, AgentTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<Agent>.GetColumnNames(tablePrefix, AgentTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription AgentID = new ColumnDescription("AgentID", 0, typeof(int));
			public static readonly ColumnDescription UserID = new ColumnDescription("UserID", 1, typeof(int));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 2, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 3, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				AgentID,
				UserID,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public AgentTable(SqlQuery query) : base(query) { }
    public AgentTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int AgentID { get { return this.Reader.GetInt32(this.GetIndex(Columns.AgentID)); } }
		public int UserID { get { return this.Reader.GetInt32(this.GetIndex(Columns.UserID)); } }
		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public Agent CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new Agent(this.AgentID,new User(this.UserID), this.Updated,this.Created); 
		}
		public Agent CreateInstance(User user)  
		{ 
			if (!this.HasData) return null;
			return new Agent(this.AgentID,user ?? new User(this.UserID), this.Updated,this.Created); 
		}
		

  }
}

