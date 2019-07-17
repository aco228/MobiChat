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
  public class MessageTable : TableBase<Message>
  {
    public static string GetColumnNames()
    {
      return TableBase<Message>.GetColumnNames(string.Empty, MessageTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<Message>.GetColumnNames(tablePrefix, MessageTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription MessageID = new ColumnDescription("MessageID", 0, typeof(int));
			public static readonly ColumnDescription MessageGuid = new ColumnDescription("MessageGuid", 1, typeof(Guid));
			public static readonly ColumnDescription ExternalID = new ColumnDescription("ExternalID", 2, typeof(int));
			public static readonly ColumnDescription ServiceID = new ColumnDescription("ServiceID", 3, typeof(int));
			public static readonly ColumnDescription CustomerID = new ColumnDescription("CustomerID", 4, typeof(int));
			public static readonly ColumnDescription MobileOperatorName = new ColumnDescription("MobileOperatorName", 5, typeof(string));
			public static readonly ColumnDescription MobileOperatorID = new ColumnDescription("MobileOperatorID", 6, typeof(int));
			public static readonly ColumnDescription MessageDirectionID = new ColumnDescription("MessageDirectionID", 7, typeof(int));
			public static readonly ColumnDescription MessageTypeID = new ColumnDescription("MessageTypeID", 8, typeof(int));
			public static readonly ColumnDescription MessageStatusID = new ColumnDescription("MessageStatusID", 9, typeof(int));
			public static readonly ColumnDescription Text = new ColumnDescription("Text", 10, typeof(string));
			public static readonly ColumnDescription Shorcode = new ColumnDescription("Shorcode", 11, typeof(int));
			public static readonly ColumnDescription Keyword = new ColumnDescription("Keyword", 12, typeof(string));
			public static readonly ColumnDescription TrackingID = new ColumnDescription("TrackingID", 13, typeof(int));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 14, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 15, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				MessageID,
				MessageGuid,
				ExternalID,
				ServiceID,
				CustomerID,
				MobileOperatorName,
				MobileOperatorID,
				MessageDirectionID,
				MessageTypeID,
				MessageStatusID,
				Text,
				Shorcode,
				Keyword,
				TrackingID,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public MessageTable(SqlQuery query) : base(query) { }
    public MessageTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int MessageID { get { return this.Reader.GetInt32(this.GetIndex(Columns.MessageID)); } }
		public Guid MessageGuid { get { return this.Reader.GetGuid(this.GetIndex(Columns.MessageGuid)); } }
		
		public int? ExternalID 
		{
			get
			{
				int index = this.GetIndex(Columns.ExternalID);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetInt32(index);
			}
		}

		public int ServiceID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ServiceID)); } }
		
		public int? CustomerID 
		{
			get
			{
				int index = this.GetIndex(Columns.CustomerID);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetInt32(index);
			}
		}

		
		public string MobileOperatorName 
		{
			get
			{
				int index = this.GetIndex(Columns.MobileOperatorName);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		
		public int? MobileOperatorID 
		{
			get
			{
				int index = this.GetIndex(Columns.MobileOperatorID);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetInt32(index);
			}
		}

		public int MessageDirectionID { get { return this.Reader.GetInt32(this.GetIndex(Columns.MessageDirectionID)); } }
		public int MessageTypeID { get { return this.Reader.GetInt32(this.GetIndex(Columns.MessageTypeID)); } }
		public int MessageStatusID { get { return this.Reader.GetInt32(this.GetIndex(Columns.MessageStatusID)); } }
		
		public string Text 
		{
			get
			{
				int index = this.GetIndex(Columns.Text);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		
		public int? Shorcode 
		{
			get
			{
				int index = this.GetIndex(Columns.Shorcode);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetInt32(index);
			}
		}

		
		public string Keyword 
		{
			get
			{
				int index = this.GetIndex(Columns.Keyword);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		
		public int? TrackingID 
		{
			get
			{
				int index = this.GetIndex(Columns.TrackingID);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetInt32(index);
			}
		}

		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public Message CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new Message(this.MessageID,this.MessageGuid,this.ExternalID,new Service(this.ServiceID), (CustomerID.HasValue ? new Customer(this.CustomerID.Value) : null), this.MobileOperatorName,(MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), (MessageDirection)this.MessageDirectionID,(MessageType)this.MessageTypeID,(MessageStatus)this.MessageStatusID,this.Text,this.Shorcode,this.Keyword,this.TrackingID,this.Updated,this.Created); 
		}
		public Message CreateInstance(Customer customer)  
		{ 
			if (!this.HasData) return null;
			return new Message(this.MessageID,this.MessageGuid,this.ExternalID,new Service(this.ServiceID), customer ?? (this.CustomerID.HasValue ? new Customer(this.CustomerID.Value) : null), this.MobileOperatorName,(MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), (MessageDirection)this.MessageDirectionID,(MessageType)this.MessageTypeID,(MessageStatus)this.MessageStatusID,this.Text,this.Shorcode,this.Keyword,this.TrackingID,this.Updated,this.Created); 
		}
		public Message CreateInstance(MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new Message(this.MessageID,this.MessageGuid,this.ExternalID,new Service(this.ServiceID), (CustomerID.HasValue ? new Customer(this.CustomerID.Value) : null), this.MobileOperatorName,mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), (MessageDirection)this.MessageDirectionID,(MessageType)this.MessageTypeID,(MessageStatus)this.MessageStatusID,this.Text,this.Shorcode,this.Keyword,this.TrackingID,this.Updated,this.Created); 
		}
		public Message CreateInstance(Service service)  
		{ 
			if (!this.HasData) return null;
			return new Message(this.MessageID,this.MessageGuid,this.ExternalID,service ?? new Service(this.ServiceID), (CustomerID.HasValue ? new Customer(this.CustomerID.Value) : null), this.MobileOperatorName,(MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), (MessageDirection)this.MessageDirectionID,(MessageType)this.MessageTypeID,(MessageStatus)this.MessageStatusID,this.Text,this.Shorcode,this.Keyword,this.TrackingID,this.Updated,this.Created); 
		}
		public Message CreateInstance(Customer customer, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new Message(this.MessageID,this.MessageGuid,this.ExternalID,new Service(this.ServiceID), customer ?? (this.CustomerID.HasValue ? new Customer(this.CustomerID.Value) : null), this.MobileOperatorName,mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), (MessageDirection)this.MessageDirectionID,(MessageType)this.MessageTypeID,(MessageStatus)this.MessageStatusID,this.Text,this.Shorcode,this.Keyword,this.TrackingID,this.Updated,this.Created); 
		}
		public Message CreateInstance(Service service, Customer customer)  
		{ 
			if (!this.HasData) return null;
			return new Message(this.MessageID,this.MessageGuid,this.ExternalID,service ?? new Service(this.ServiceID), customer ?? (this.CustomerID.HasValue ? new Customer(this.CustomerID.Value) : null), this.MobileOperatorName,(MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), (MessageDirection)this.MessageDirectionID,(MessageType)this.MessageTypeID,(MessageStatus)this.MessageStatusID,this.Text,this.Shorcode,this.Keyword,this.TrackingID,this.Updated,this.Created); 
		}
		public Message CreateInstance(Service service, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new Message(this.MessageID,this.MessageGuid,this.ExternalID,service ?? new Service(this.ServiceID), (CustomerID.HasValue ? new Customer(this.CustomerID.Value) : null), this.MobileOperatorName,mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), (MessageDirection)this.MessageDirectionID,(MessageType)this.MessageTypeID,(MessageStatus)this.MessageStatusID,this.Text,this.Shorcode,this.Keyword,this.TrackingID,this.Updated,this.Created); 
		}
		public Message CreateInstance(Service service, Customer customer, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new Message(this.MessageID,this.MessageGuid,this.ExternalID,service ?? new Service(this.ServiceID), customer ?? (this.CustomerID.HasValue ? new Customer(this.CustomerID.Value) : null), this.MobileOperatorName,mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), (MessageDirection)this.MessageDirectionID,(MessageType)this.MessageTypeID,(MessageStatus)this.MessageStatusID,this.Text,this.Shorcode,this.Keyword,this.TrackingID,this.Updated,this.Created); 
		}
		

  }
}

