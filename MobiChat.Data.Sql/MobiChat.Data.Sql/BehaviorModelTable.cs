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
  public class BehaviorModelTable : TableBase<BehaviorModel>
  {
    public static string GetColumnNames()
    {
      return TableBase<BehaviorModel>.GetColumnNames(string.Empty, BehaviorModelTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<BehaviorModel>.GetColumnNames(tablePrefix, BehaviorModelTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription BehaviorModelID = new ColumnDescription("BehaviorModelID", 0, typeof(int));
			public static readonly ColumnDescription BehaviorModelGuid = new ColumnDescription("BehaviorModelGuid", 1, typeof(Guid));
			public static readonly ColumnDescription Name = new ColumnDescription("Name", 2, typeof(string));
			public static readonly ColumnDescription Description = new ColumnDescription("Description", 3, typeof(string));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 4, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 5, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				BehaviorModelID,
				BehaviorModelGuid,
				Name,
				Description,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public BehaviorModelTable(SqlQuery query) : base(query) { }
    public BehaviorModelTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int BehaviorModelID { get { return this.Reader.GetInt32(this.GetIndex(Columns.BehaviorModelID)); } }
		public Guid BehaviorModelGuid { get { return this.Reader.GetGuid(this.GetIndex(Columns.BehaviorModelGuid)); } }
		public string Name { get { return this.Reader.GetString(this.GetIndex(Columns.Name)); } }
		
		public string Description 
		{
			get
			{
				int index = this.GetIndex(Columns.Description);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public BehaviorModel CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new BehaviorModel(this.BehaviorModelID,this.BehaviorModelGuid,this.Name,this.Description,this.Updated,this.Created); 
		}
		

  }
}

