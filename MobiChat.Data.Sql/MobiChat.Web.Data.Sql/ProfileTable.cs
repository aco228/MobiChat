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
  public class ProfileTable : TableBase<Profile>
  {
    public static string GetColumnNames()
    {
      return TableBase<Profile>.GetColumnNames(string.Empty, ProfileTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<Profile>.GetColumnNames(tablePrefix, ProfileTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription ProfileID = new ColumnDescription("ProfileID", 0, typeof(int));
			public static readonly ColumnDescription ProfileGroupID = new ColumnDescription("ProfileGroupID", 1, typeof(int));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 2, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 3, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				ProfileID,
				ProfileGroupID,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public ProfileTable(SqlQuery query) : base(query) { }
    public ProfileTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int ProfileID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ProfileID)); } }
		public int ProfileGroupID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ProfileGroupID)); } }
		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public Profile CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new Profile(this.ProfileID,new ProfileGroup(this.ProfileGroupID), this.Updated,this.Created); 
		}
		public Profile CreateInstance(ProfileGroup profileGroup)  
		{ 
			if (!this.HasData) return null;
			return new Profile(this.ProfileID,profileGroup ?? new ProfileGroup(this.ProfileGroupID), this.Updated,this.Created); 
		}
		

  }
}

