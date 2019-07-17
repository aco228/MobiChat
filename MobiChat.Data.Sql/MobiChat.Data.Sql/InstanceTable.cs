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
  public class InstanceTable : TableBase<Instance>
  {
    public static string GetColumnNames()
    {
      return TableBase<Instance>.GetColumnNames(string.Empty, InstanceTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<Instance>.GetColumnNames(tablePrefix, InstanceTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription InstanceID = new ColumnDescription("InstanceID", 0, typeof(int));
			public static readonly ColumnDescription Name = new ColumnDescription("Name", 1, typeof(string));
			public static readonly ColumnDescription Description = new ColumnDescription("Description", 2, typeof(string));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 3, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 4, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				InstanceID,
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

    public InstanceTable(SqlQuery query) : base(query) { }
    public InstanceTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int InstanceID { get { return this.Reader.GetInt32(this.GetIndex(Columns.InstanceID)); } }
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
		

	  public Instance CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new Instance(this.InstanceID,this.Name,this.Description,this.Updated,this.Created); 
		}
		

  }
}
