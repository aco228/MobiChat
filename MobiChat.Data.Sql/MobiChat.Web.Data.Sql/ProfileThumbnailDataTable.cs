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
  public class ProfileThumbnailDataTable : TableBase<ProfileThumbnailData>
  {
    public static string GetColumnNames()
    {
      return TableBase<ProfileThumbnailData>.GetColumnNames(string.Empty, ProfileThumbnailDataTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<ProfileThumbnailData>.GetColumnNames(tablePrefix, ProfileThumbnailDataTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription ProfileThumbnailDataID = new ColumnDescription("ProfileThumbnailDataID", 0, typeof(int));
			public static readonly ColumnDescription ProfileThumbnailID = new ColumnDescription("ProfileThumbnailID", 1, typeof(int));
			public static readonly ColumnDescription Data = new ColumnDescription("Data", 2, typeof(byte[]));
			public static readonly ColumnDescription IsOriginal = new ColumnDescription("IsOriginal", 3, typeof(bool));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 4, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 5, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				ProfileThumbnailDataID,
				ProfileThumbnailID,
				Data,
				IsOriginal,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public ProfileThumbnailDataTable(SqlQuery query) : base(query) { }
    public ProfileThumbnailDataTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int ProfileThumbnailDataID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ProfileThumbnailDataID)); } }
		public int ProfileThumbnailID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ProfileThumbnailID)); } }
		
		public byte[] Data {
			 get
			{
				int index = this.GetIndex(Columns.Data);
				if (this.Reader.IsDBNull(index)) return null;
				long len = Reader.GetBytes(index, 0, null, 0, 0);
				Byte[] path = new Byte[len]; 
				Reader.GetBytes(index, 0, path, 0, (int)len);
				return path;
			}
		}

		public bool IsOriginal { get { return this.Reader.GetBoolean(this.GetIndex(Columns.IsOriginal)); } }
		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public ProfileThumbnailData CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new ProfileThumbnailData(this.ProfileThumbnailDataID,new ProfileThumbnail(this.ProfileThumbnailID), this.Data,this.IsOriginal,this.Updated,this.Created); 
		}
		public ProfileThumbnailData CreateInstance(ProfileThumbnail profileThumbnail)  
		{ 
			if (!this.HasData) return null;
			return new ProfileThumbnailData(this.ProfileThumbnailDataID,profileThumbnail ?? new ProfileThumbnail(this.ProfileThumbnailID), this.Data,this.IsOriginal,this.Updated,this.Created); 
		}
		

  }
}

