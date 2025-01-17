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
  public class UserSessionTypeTable : TableBase<UserSessionType>
  {
    public static string GetColumnNames()
    {
      return TableBase<UserSessionType>.GetColumnNames(string.Empty, UserSessionTypeTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<UserSessionType>.GetColumnNames(tablePrefix, UserSessionTypeTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription UserSessionTypeID = new ColumnDescription("UserSessionTypeID", 0, typeof(int));
			public static readonly ColumnDescription Name = new ColumnDescription("Name", 1, typeof(string));
			public static readonly ColumnDescription TypeName = new ColumnDescription("TypeName", 2, typeof(string));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 3, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 4, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				UserSessionTypeID,
				Name,
				TypeName,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public UserSessionTypeTable(SqlQuery query) : base(query) { }
    public UserSessionTypeTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int UserSessionTypeID { get { return this.Reader.GetInt32(this.GetIndex(Columns.UserSessionTypeID)); } }
		public string Name { get { return this.Reader.GetString(this.GetIndex(Columns.Name)); } }
		public string TypeName { get { return this.Reader.GetString(this.GetIndex(Columns.TypeName)); } }
		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public UserSessionType CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new UserSessionType(this.UserSessionTypeID,this.Name,this.TypeName,this.Updated,this.Created); 
		}
		

  }
}

