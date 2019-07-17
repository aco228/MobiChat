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
  public class ProfileGroupTable : TableBase<ProfileGroup>
  {
    public static string GetColumnNames()
    {
      return TableBase<ProfileGroup>.GetColumnNames(string.Empty, ProfileGroupTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<ProfileGroup>.GetColumnNames(tablePrefix, ProfileGroupTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription ProfileGroupID = new ColumnDescription("ProfileGroupID", 0, typeof(int));
			public static readonly ColumnDescription ProfileCategoryID = new ColumnDescription("ProfileCategoryID", 1, typeof(int));
			public static readonly ColumnDescription InstanceID = new ColumnDescription("InstanceID", 2, typeof(int));
			public static readonly ColumnDescription Name = new ColumnDescription("Name", 3, typeof(string));
			public static readonly ColumnDescription Description = new ColumnDescription("Description", 4, typeof(string));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 5, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 6, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				ProfileGroupID,
				ProfileCategoryID,
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

    public ProfileGroupTable(SqlQuery query) : base(query) { }
    public ProfileGroupTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int ProfileGroupID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ProfileGroupID)); } }
		public int ProfileCategoryID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ProfileCategoryID)); } }
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
		

	  public ProfileGroup CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new ProfileGroup(this.ProfileGroupID,new ProfileCategory(this.ProfileCategoryID), new Instance(this.InstanceID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public ProfileGroup CreateInstance(Instance instance)  
		{ 
			if (!this.HasData) return null;
			return new ProfileGroup(this.ProfileGroupID,new ProfileCategory(this.ProfileCategoryID), instance ?? new Instance(this.InstanceID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public ProfileGroup CreateInstance(ProfileCategory profileCategory)  
		{ 
			if (!this.HasData) return null;
			return new ProfileGroup(this.ProfileGroupID,profileCategory ?? new ProfileCategory(this.ProfileCategoryID), new Instance(this.InstanceID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public ProfileGroup CreateInstance(ProfileCategory profileCategory, Instance instance)  
		{ 
			if (!this.HasData) return null;
			return new ProfileGroup(this.ProfileGroupID,profileCategory ?? new ProfileCategory(this.ProfileCategoryID), instance ?? new Instance(this.InstanceID), this.Name,this.Description,this.Updated,this.Created); 
		}
		

  }
}

