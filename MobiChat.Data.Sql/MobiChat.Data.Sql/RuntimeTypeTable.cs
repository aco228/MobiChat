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
  public class RuntimeTypeTable : TableBase<RuntimeType>
  {
    public static string GetColumnNames()
    {
      return TableBase<RuntimeType>.GetColumnNames(string.Empty, RuntimeTypeTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<RuntimeType>.GetColumnNames(tablePrefix, RuntimeTypeTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription RuntimeTypeID = new ColumnDescription("RuntimeTypeID", 0, typeof(int));
			public static readonly ColumnDescription Name = new ColumnDescription("Name", 1, typeof(string));
			public static readonly ColumnDescription TypeName = new ColumnDescription("TypeName", 2, typeof(string));
			public static readonly ColumnDescription Description = new ColumnDescription("Description", 3, typeof(string));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 4, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 5, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				RuntimeTypeID,
				Name,
				TypeName,
				Description,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public RuntimeTypeTable(SqlQuery query) : base(query) { }
    public RuntimeTypeTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int RuntimeTypeID { get { return this.Reader.GetInt32(this.GetIndex(Columns.RuntimeTypeID)); } }
		public string Name { get { return this.Reader.GetString(this.GetIndex(Columns.Name)); } }
		public string TypeName { get { return this.Reader.GetString(this.GetIndex(Columns.TypeName)); } }
		
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
		

	  public RuntimeType CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new RuntimeType(this.RuntimeTypeID,this.Name,this.TypeName,this.Description,this.Updated,this.Created); 
		}
		

  }
}

