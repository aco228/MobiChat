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
  public class ServiceSendNumberMapTable : TableBase<ServiceSendNumberMap>
  {
    public static string GetColumnNames()
    {
      return TableBase<ServiceSendNumberMap>.GetColumnNames(string.Empty, ServiceSendNumberMapTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<ServiceSendNumberMap>.GetColumnNames(tablePrefix, ServiceSendNumberMapTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription ServiceSendNumberMapID = new ColumnDescription("ServiceSendNumberMapID", 0, typeof(int));
			public static readonly ColumnDescription ServiceID = new ColumnDescription("ServiceID", 1, typeof(int));
			public static readonly ColumnDescription SendNumberTypeID = new ColumnDescription("SendNumberTypeID", 2, typeof(int));
			public static readonly ColumnDescription Messages = new ColumnDescription("Messages", 3, typeof(string));
			public static readonly ColumnDescription IsActive = new ColumnDescription("IsActive", 4, typeof(bool));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 5, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 6, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				ServiceSendNumberMapID,
				ServiceID,
				SendNumberTypeID,
				Messages,
				IsActive,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public ServiceSendNumberMapTable(SqlQuery query) : base(query) { }
    public ServiceSendNumberMapTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int ServiceSendNumberMapID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ServiceSendNumberMapID)); } }
		public int ServiceID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ServiceID)); } }
		public int SendNumberTypeID { get { return this.Reader.GetInt32(this.GetIndex(Columns.SendNumberTypeID)); } }
		
		public string Messages 
		{
			get
			{
				int index = this.GetIndex(Columns.Messages);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		public bool IsActive { get { return this.Reader.GetBoolean(this.GetIndex(Columns.IsActive)); } }
		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public ServiceSendNumberMap CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new ServiceSendNumberMap(this.ServiceSendNumberMapID,new Service(this.ServiceID), new SendNumberType(this.SendNumberTypeID), this.Messages,this.IsActive,this.Updated,this.Created); 
		}
		public ServiceSendNumberMap CreateInstance(SendNumberType sendNumberType)  
		{ 
			if (!this.HasData) return null;
			return new ServiceSendNumberMap(this.ServiceSendNumberMapID,new Service(this.ServiceID), sendNumberType ?? new SendNumberType(this.SendNumberTypeID), this.Messages,this.IsActive,this.Updated,this.Created); 
		}
		public ServiceSendNumberMap CreateInstance(Service service)  
		{ 
			if (!this.HasData) return null;
			return new ServiceSendNumberMap(this.ServiceSendNumberMapID,service ?? new Service(this.ServiceID), new SendNumberType(this.SendNumberTypeID), this.Messages,this.IsActive,this.Updated,this.Created); 
		}
		public ServiceSendNumberMap CreateInstance(Service service, SendNumberType sendNumberType)  
		{ 
			if (!this.HasData) return null;
			return new ServiceSendNumberMap(this.ServiceSendNumberMapID,service ?? new Service(this.ServiceID), sendNumberType ?? new SendNumberType(this.SendNumberTypeID), this.Messages,this.IsActive,this.Updated,this.Created); 
		}
		

  }
}

