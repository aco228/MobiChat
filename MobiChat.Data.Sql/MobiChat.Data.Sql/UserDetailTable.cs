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
  public class UserDetailTable : TableBase<UserDetail>
  {
    public static string GetColumnNames()
    {
      return TableBase<UserDetail>.GetColumnNames(string.Empty, UserDetailTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<UserDetail>.GetColumnNames(tablePrefix, UserDetailTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription UserDetailID = new ColumnDescription("UserDetailID", 0, typeof(int));
			public static readonly ColumnDescription UserID = new ColumnDescription("UserID", 1, typeof(int));
			public static readonly ColumnDescription CountryID = new ColumnDescription("CountryID", 2, typeof(int));
			public static readonly ColumnDescription GenderID = new ColumnDescription("GenderID", 3, typeof(int));
			public static readonly ColumnDescription FirstName = new ColumnDescription("FirstName", 4, typeof(string));
			public static readonly ColumnDescription LastName = new ColumnDescription("LastName", 5, typeof(string));
			public static readonly ColumnDescription Address = new ColumnDescription("Address", 6, typeof(string));
			public static readonly ColumnDescription Mail = new ColumnDescription("Mail", 7, typeof(string));
			public static readonly ColumnDescription Contact = new ColumnDescription("Contact", 8, typeof(string));
			public static readonly ColumnDescription BirthDate = new ColumnDescription("BirthDate", 9, typeof(DateTime));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 10, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 11, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				UserDetailID,
				UserID,
				CountryID,
				GenderID,
				FirstName,
				LastName,
				Address,
				Mail,
				Contact,
				BirthDate,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public UserDetailTable(SqlQuery query) : base(query) { }
    public UserDetailTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int UserDetailID { get { return this.Reader.GetInt32(this.GetIndex(Columns.UserDetailID)); } }
		public int UserID { get { return this.Reader.GetInt32(this.GetIndex(Columns.UserID)); } }
		public int CountryID { get { return this.Reader.GetInt32(this.GetIndex(Columns.CountryID)); } }
		public int GenderID { get { return this.Reader.GetInt32(this.GetIndex(Columns.GenderID)); } }
		public string FirstName { get { return this.Reader.GetString(this.GetIndex(Columns.FirstName)); } }
		public string LastName { get { return this.Reader.GetString(this.GetIndex(Columns.LastName)); } }
		
		public string Address 
		{
			get
			{
				int index = this.GetIndex(Columns.Address);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		public string Mail { get { return this.Reader.GetString(this.GetIndex(Columns.Mail)); } }
		public string Contact { get { return this.Reader.GetString(this.GetIndex(Columns.Contact)); } }
		
		public DateTime? BirthDate 
		{
			get
			{
				int index = this.GetIndex(Columns.BirthDate);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetDateTime(index);
			}
		}

		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public UserDetail CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new UserDetail(this.UserDetailID,new User(this.UserID), this.CountryID,new Gender(this.GenderID), this.FirstName,this.LastName,this.Address,this.Mail,this.Contact,this.BirthDate,this.Updated,this.Created); 
		}
		public UserDetail CreateInstance(Gender gender)  
		{ 
			if (!this.HasData) return null;
			return new UserDetail(this.UserDetailID,new User(this.UserID), this.CountryID,gender ?? new Gender(this.GenderID), this.FirstName,this.LastName,this.Address,this.Mail,this.Contact,this.BirthDate,this.Updated,this.Created); 
		}
		public UserDetail CreateInstance(User user)  
		{ 
			if (!this.HasData) return null;
			return new UserDetail(this.UserDetailID,user ?? new User(this.UserID), this.CountryID,new Gender(this.GenderID), this.FirstName,this.LastName,this.Address,this.Mail,this.Contact,this.BirthDate,this.Updated,this.Created); 
		}
		public UserDetail CreateInstance(User user, Gender gender)  
		{ 
			if (!this.HasData) return null;
			return new UserDetail(this.UserDetailID,user ?? new User(this.UserID), this.CountryID,gender ?? new Gender(this.GenderID), this.FirstName,this.LastName,this.Address,this.Mail,this.Contact,this.BirthDate,this.Updated,this.Created); 
		}
		

  }
}

