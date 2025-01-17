using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti;
using Senti.Data;
using Senti.Data.Sql;

using MobiChat.Data;


namespace MobiChat.Web.Data.Sql
{
  public class ProfileCategoryTable : TableBase<ProfileCategory>
  {
    public static string GetColumnNames()
    {
      return TableBase<ProfileCategory>.GetColumnNames(string.Empty, ProfileCategoryTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<ProfileCategory>.GetColumnNames(tablePrefix, ProfileCategoryTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription ProfileCategoryID = new ColumnDescription("ProfileCategoryID", 0, typeof(int));
			public static readonly ColumnDescription Name = new ColumnDescription("Name", 1, typeof(string));
			public static readonly ColumnDescription ViewName = new ColumnDescription("ViewName", 2, typeof(string));
			public static readonly ColumnDescription Description = new ColumnDescription("Description", 3, typeof(string));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 4, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 5, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				ProfileCategoryID,
				Name,
				ViewName,
				Description,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public ProfileCategoryTable(SqlQuery query) : base(query) { }
    public ProfileCategoryTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int ProfileCategoryID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ProfileCategoryID)); } }
		public string Name { get { return this.Reader.GetString(this.GetIndex(Columns.Name)); } }
		public string ViewName { get { return this.Reader.GetString(this.GetIndex(Columns.ViewName)); } }
		
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
		

	  public ProfileCategory CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new ProfileCategory(this.ProfileCategoryID,this.Name,this.ViewName,this.Description,this.Updated,this.Created); 
		}
		

  }
}

