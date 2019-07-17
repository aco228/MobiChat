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
  public class ProfileDetailTable : TableBase<ProfileDetail>
  {
    public static string GetColumnNames()
    {
      return TableBase<ProfileDetail>.GetColumnNames(string.Empty, ProfileDetailTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<ProfileDetail>.GetColumnNames(tablePrefix, ProfileDetailTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription ProfileDetailID = new ColumnDescription("ProfileDetailID", 0, typeof(int));
			public static readonly ColumnDescription ProfileID = new ColumnDescription("ProfileID", 1, typeof(int));
			public static readonly ColumnDescription LanguageID = new ColumnDescription("LanguageID", 2, typeof(int));
			public static readonly ColumnDescription Name = new ColumnDescription("Name", 3, typeof(string));
			public static readonly ColumnDescription Keyword = new ColumnDescription("Keyword", 4, typeof(string));
			public static readonly ColumnDescription Description = new ColumnDescription("Description", 5, typeof(string));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 6, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 7, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				ProfileDetailID,
				ProfileID,
				LanguageID,
				Name,
				Keyword,
				Description,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public ProfileDetailTable(SqlQuery query) : base(query) { }
    public ProfileDetailTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int ProfileDetailID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ProfileDetailID)); } }
		public int ProfileID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ProfileID)); } }
		public int LanguageID { get { return this.Reader.GetInt32(this.GetIndex(Columns.LanguageID)); } }
		public string Name { get { return this.Reader.GetString(this.GetIndex(Columns.Name)); } }
		
		public string Keyword 
		{
			get
			{
				int index = this.GetIndex(Columns.Keyword);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		
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
		

	  public ProfileDetail CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new ProfileDetail(this.ProfileDetailID,new Profile(this.ProfileID), new Language(this.LanguageID), this.Name,this.Keyword,this.Description,this.Updated,this.Created); 
		}
		public ProfileDetail CreateInstance(Language language)  
		{ 
			if (!this.HasData) return null;
			return new ProfileDetail(this.ProfileDetailID,new Profile(this.ProfileID), language ?? new Language(this.LanguageID), this.Name,this.Keyword,this.Description,this.Updated,this.Created); 
		}
		public ProfileDetail CreateInstance(Profile profile)  
		{ 
			if (!this.HasData) return null;
			return new ProfileDetail(this.ProfileDetailID,profile ?? new Profile(this.ProfileID), new Language(this.LanguageID), this.Name,this.Keyword,this.Description,this.Updated,this.Created); 
		}
		public ProfileDetail CreateInstance(Profile profile, Language language)  
		{ 
			if (!this.HasData) return null;
			return new ProfileDetail(this.ProfileDetailID,profile ?? new Profile(this.ProfileID), language ?? new Language(this.LanguageID), this.Name,this.Keyword,this.Description,this.Updated,this.Created); 
		}
		

  }
}

