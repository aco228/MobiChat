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
  public class UserTable : TableBase<User>
  {
    public static string GetColumnNames()
    {
      return TableBase<User>.GetColumnNames(string.Empty, UserTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<User>.GetColumnNames(tablePrefix, UserTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription UserID = new ColumnDescription("UserID", 0, typeof(int));
			public static readonly ColumnDescription UserGuid = new ColumnDescription("UserGuid", 1, typeof(Guid));
			public static readonly ColumnDescription UserTypeID = new ColumnDescription("UserTypeID", 2, typeof(int));
			public static readonly ColumnDescription UserStatusID = new ColumnDescription("UserStatusID", 3, typeof(int));
			public static readonly ColumnDescription Username = new ColumnDescription("Username", 4, typeof(string));
			public static readonly ColumnDescription Password = new ColumnDescription("Password", 5, typeof(byte[]));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 6, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 7, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				UserID,
				UserGuid,
				UserTypeID,
				UserStatusID,
				Username,
				Password,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public UserTable(SqlQuery query) : base(query) { }
    public UserTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int UserID { get { return this.Reader.GetInt32(this.GetIndex(Columns.UserID)); } }
		public Guid UserGuid { get { return this.Reader.GetGuid(this.GetIndex(Columns.UserGuid)); } }
		public int UserTypeID { get { return this.Reader.GetInt32(this.GetIndex(Columns.UserTypeID)); } }
		public int UserStatusID { get { return this.Reader.GetInt32(this.GetIndex(Columns.UserStatusID)); } }
		public string Username { get { return this.Reader.GetString(this.GetIndex(Columns.Username)); } }
		
		public byte[] Password {
			 get
			{
				int index = this.GetIndex(Columns.Password);
				if (this.Reader.IsDBNull(index)) return null;
				long len = Reader.GetBytes(index, 0, null, 0, 0);
				Byte[] path = new Byte[len]; 
				Reader.GetBytes(index, 0, path, 0, (int)len);
				return path;
			}
		}

		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public User CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new User(this.UserID,this.UserGuid,new UserType(this.UserTypeID), (UserStatus)this.UserStatusID,this.Username,this.Password,this.Updated,this.Created); 
		}
		public User CreateInstance(UserType userType)  
		{ 
			if (!this.HasData) return null;
			return new User(this.UserID,this.UserGuid,userType ?? new UserType(this.UserTypeID), (UserStatus)this.UserStatusID,this.Username,this.Password,this.Updated,this.Created); 
		}
		

  }
}

