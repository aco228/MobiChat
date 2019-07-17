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
  public class GenderTable : TableBase<Gender>
  {
    public static string GetColumnNames()
    {
      return TableBase<Gender>.GetColumnNames(string.Empty, GenderTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<Gender>.GetColumnNames(tablePrefix, GenderTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription GenderID = new ColumnDescription("GenderID", 0, typeof(int));
			public static readonly ColumnDescription Name = new ColumnDescription("Name", 1, typeof(string));
			public static readonly ColumnDescription Description = new ColumnDescription("Description", 2, typeof(string));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 3, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 4, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				GenderID,
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

    public GenderTable(SqlQuery query) : base(query) { }
    public GenderTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int GenderID { get { return this.Reader.GetInt32(this.GetIndex(Columns.GenderID)); } }
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
		

	  public Gender CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new Gender(this.GenderID,this.Name,this.Description,this.Updated,this.Created); 
		}
		

  }
}

