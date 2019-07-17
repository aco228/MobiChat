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
  public class UserStatusHistoryTable : TableBase<UserStatusHistory>
  {
    public static string GetColumnNames()
    {
      return TableBase<UserStatusHistory>.GetColumnNames(string.Empty, UserStatusHistoryTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<UserStatusHistory>.GetColumnNames(tablePrefix, UserStatusHistoryTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription UserStatusHistoryID = new ColumnDescription("UserStatusHistoryID", 0, typeof(int));
			public static readonly ColumnDescription UserID = new ColumnDescription("UserID", 1, typeof(int));
			public static readonly ColumnDescription UserStatusID = new ColumnDescription("UserStatusID", 2, typeof(int));
			public static readonly ColumnDescription Note = new ColumnDescription("Note", 3, typeof(string));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 4, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 5, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				UserStatusHistoryID,
				UserID,
				UserStatusID,
				Note,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public UserStatusHistoryTable(SqlQuery query) : base(query) { }
    public UserStatusHistoryTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int UserStatusHistoryID { get { return this.Reader.GetInt32(this.GetIndex(Columns.UserStatusHistoryID)); } }
		public int UserID { get { return this.Reader.GetInt32(this.GetIndex(Columns.UserID)); } }
		public int UserStatusID { get { return this.Reader.GetInt32(this.GetIndex(Columns.UserStatusID)); } }
		
		public string Note 
		{
			get
			{
				int index = this.GetIndex(Columns.Note);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public UserStatusHistory CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new UserStatusHistory(this.UserStatusHistoryID,new User(this.UserID), (UserStatus)this.UserStatusID,this.Note,this.Updated,this.Created); 
		}
		public UserStatusHistory CreateInstance(User user)  
		{ 
			if (!this.HasData) return null;
			return new UserStatusHistory(this.UserStatusHistoryID,user ?? new User(this.UserID), (UserStatus)this.UserStatusID,this.Note,this.Updated,this.Created); 
		}
		

  }
}

