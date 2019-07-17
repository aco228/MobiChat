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
  public class AgentLanguageMapTable : TableBase<AgentLanguageMap>
  {
    public static string GetColumnNames()
    {
      return TableBase<AgentLanguageMap>.GetColumnNames(string.Empty, AgentLanguageMapTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<AgentLanguageMap>.GetColumnNames(tablePrefix, AgentLanguageMapTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription AgentLanguageMapID = new ColumnDescription("AgentLanguageMapID", 0, typeof(int));
			public static readonly ColumnDescription AgentID = new ColumnDescription("AgentID", 1, typeof(int));
			public static readonly ColumnDescription LanguageID = new ColumnDescription("LanguageID", 2, typeof(int));
			public static readonly ColumnDescription IsActive = new ColumnDescription("IsActive", 3, typeof(bool));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 4, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 5, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				AgentLanguageMapID,
				AgentID,
				LanguageID,
				IsActive,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public AgentLanguageMapTable(SqlQuery query) : base(query) { }
    public AgentLanguageMapTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int AgentLanguageMapID { get { return this.Reader.GetInt32(this.GetIndex(Columns.AgentLanguageMapID)); } }
		public int AgentID { get { return this.Reader.GetInt32(this.GetIndex(Columns.AgentID)); } }
		public int LanguageID { get { return this.Reader.GetInt32(this.GetIndex(Columns.LanguageID)); } }
		public bool IsActive { get { return this.Reader.GetBoolean(this.GetIndex(Columns.IsActive)); } }
		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public AgentLanguageMap CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new AgentLanguageMap(this.AgentLanguageMapID,new Agent(this.AgentID), new Language(this.LanguageID), this.IsActive,this.Updated,this.Created); 
		}
		public AgentLanguageMap CreateInstance(Agent agent)  
		{ 
			if (!this.HasData) return null;
			return new AgentLanguageMap(this.AgentLanguageMapID,agent ?? new Agent(this.AgentID), new Language(this.LanguageID), this.IsActive,this.Updated,this.Created); 
		}
		public AgentLanguageMap CreateInstance(Language language)  
		{ 
			if (!this.HasData) return null;
			return new AgentLanguageMap(this.AgentLanguageMapID,new Agent(this.AgentID), language ?? new Language(this.LanguageID), this.IsActive,this.Updated,this.Created); 
		}
		public AgentLanguageMap CreateInstance(Agent agent, Language language)  
		{ 
			if (!this.HasData) return null;
			return new AgentLanguageMap(this.AgentLanguageMapID,agent ?? new Agent(this.AgentID), language ?? new Language(this.LanguageID), this.IsActive,this.Updated,this.Created); 
		}
		

  }
}

