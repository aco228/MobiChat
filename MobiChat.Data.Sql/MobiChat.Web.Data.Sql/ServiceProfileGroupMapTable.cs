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
  public class ServiceProfileGroupMapTable : TableBase<ServiceProfileGroupMap>
  {
    public static string GetColumnNames()
    {
      return TableBase<ServiceProfileGroupMap>.GetColumnNames(string.Empty, ServiceProfileGroupMapTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<ServiceProfileGroupMap>.GetColumnNames(tablePrefix, ServiceProfileGroupMapTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription ServiceProfileGroupMapID = new ColumnDescription("ServiceProfileGroupMapID", 0, typeof(int));
			public static readonly ColumnDescription ServiceID = new ColumnDescription("ServiceID", 1, typeof(int));
			public static readonly ColumnDescription ProfileGroupID = new ColumnDescription("ProfileGroupID", 2, typeof(int));
			public static readonly ColumnDescription IsActive = new ColumnDescription("IsActive", 3, typeof(bool));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 4, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 5, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				ServiceProfileGroupMapID,
				ServiceID,
				ProfileGroupID,
				IsActive,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public ServiceProfileGroupMapTable(SqlQuery query) : base(query) { }
    public ServiceProfileGroupMapTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int ServiceProfileGroupMapID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ServiceProfileGroupMapID)); } }
		public int ServiceID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ServiceID)); } }
		public int ProfileGroupID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ProfileGroupID)); } }
		public bool IsActive { get { return this.Reader.GetBoolean(this.GetIndex(Columns.IsActive)); } }
		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public ServiceProfileGroupMap CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new ServiceProfileGroupMap(this.ServiceProfileGroupMapID,this.ServiceID,new ProfileGroup(this.ProfileGroupID), this.IsActive,this.Updated,this.Created); 
		}
		public ServiceProfileGroupMap CreateInstance(ProfileGroup profileGroup)  
		{ 
			if (!this.HasData) return null;
			return new ServiceProfileGroupMap(this.ServiceProfileGroupMapID,this.ServiceID,profileGroup ?? new ProfileGroup(this.ProfileGroupID), this.IsActive,this.Updated,this.Created); 
		}
		

  }
}

