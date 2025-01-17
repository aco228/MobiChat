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
  public class TemplateTable : TableBase<Template>
  {
    public static string GetColumnNames()
    {
      return TableBase<Template>.GetColumnNames(string.Empty, TemplateTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<Template>.GetColumnNames(tablePrefix, TemplateTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription TemplateID = new ColumnDescription("TemplateID", 0, typeof(int));
			public static readonly ColumnDescription TemplateGuid = new ColumnDescription("TemplateGuid", 1, typeof(Guid));
			public static readonly ColumnDescription Name = new ColumnDescription("Name", 2, typeof(string));
			public static readonly ColumnDescription Description = new ColumnDescription("Description", 3, typeof(string));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 4, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 5, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				TemplateID,
				TemplateGuid,
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

    public TemplateTable(SqlQuery query) : base(query) { }
    public TemplateTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int TemplateID { get { return this.Reader.GetInt32(this.GetIndex(Columns.TemplateID)); } }
		public Guid TemplateGuid { get { return this.Reader.GetGuid(this.GetIndex(Columns.TemplateGuid)); } }
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
		

	  public Template CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new Template(this.TemplateID,this.TemplateGuid,this.Name,this.Description,this.Updated,this.Created); 
		}
		

  }
}

