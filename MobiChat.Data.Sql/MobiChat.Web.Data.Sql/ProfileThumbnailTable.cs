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
  public class ProfileThumbnailTable : TableBase<ProfileThumbnail>
  {
    public static string GetColumnNames()
    {
      return TableBase<ProfileThumbnail>.GetColumnNames(string.Empty, ProfileThumbnailTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<ProfileThumbnail>.GetColumnNames(tablePrefix, ProfileThumbnailTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription ProfileThumbnailID = new ColumnDescription("ProfileThumbnailID", 0, typeof(int));
			public static readonly ColumnDescription ProfileID = new ColumnDescription("ProfileID", 1, typeof(int));
			public static readonly ColumnDescription IsDefault = new ColumnDescription("IsDefault", 2, typeof(bool));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 3, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 4, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				ProfileThumbnailID,
				ProfileID,
				IsDefault,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public ProfileThumbnailTable(SqlQuery query) : base(query) { }
    public ProfileThumbnailTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int ProfileThumbnailID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ProfileThumbnailID)); } }
		public int ProfileID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ProfileID)); } }
		
		public bool? IsDefault 
		{
			get
			{
				int index = this.GetIndex(Columns.IsDefault);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetBoolean(index);
			}
		}

		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public ProfileThumbnail CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new ProfileThumbnail(this.ProfileThumbnailID,new Profile(this.ProfileID), this.IsDefault,this.Updated,this.Created); 
		}
		public ProfileThumbnail CreateInstance(Profile profile)  
		{ 
			if (!this.HasData) return null;
			return new ProfileThumbnail(this.ProfileThumbnailID,profile ?? new Profile(this.ProfileID), this.IsDefault,this.Updated,this.Created); 
		}
		

  }
}

