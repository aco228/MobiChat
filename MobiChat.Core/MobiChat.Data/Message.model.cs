using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

using MobiChat.Web.Data; 

namespace MobiChat.Web.Data 
{
  public partial interface IMessageManager : IDataManager<Message> 
  {
	

  }

  public partial class Message : MobiChatObject<IMessageManager> 
  {
		private Guid _guid;
		private int? _externalID = -1;
		private Service _service;
		private Customer _customer;
		private string _mobileOperatorName = String.Empty;
		private MobileOperator _mobileOperator;
		private MessageDirection _messageDirection;
		private MessageType _messageType;
		private MessageStatus _messageStatus;
		private string _text = String.Empty;
		private int? _shorcode = -1;
		private string _keyword = String.Empty;
		private int? _trackingID = -1;
		

		public Guid Guid { get { return this._guid; } set { _guid = value; } }
		public int? ExternalID{ get {return this._externalID; } set { this._externalID = value;} }
		public Service Service 
		{
			get
			{
				if (this._service != null &&
						this._service.IsEmpty)
					if (this.ConnectionContext != null)
						this._service = Service.CreateManager().LazyLoad(this.ConnectionContext, this._service.ID) as Service;
					else
						this._service = Service.CreateManager().LazyLoad(this._service.ID) as Service;
				return this._service;
			}
			set { _service = value; }
		}

		public Customer Customer 
		{
			get
			{
				if (this._customer != null &&
						this._customer.IsEmpty)
					if (this.ConnectionContext != null)
						this._customer = Customer.CreateManager().LazyLoad(this.ConnectionContext, this._customer.ID) as Customer;
					else
						this._customer = Customer.CreateManager().LazyLoad(this._customer.ID) as Customer;
				return this._customer;
			}
			set { _customer = value; }
		}

		public string MobileOperatorName{ get {return this._mobileOperatorName; } set { this._mobileOperatorName = value;} }
		public MobileOperator MobileOperator 
		{
			get
			{
				if (this._mobileOperator != null &&
						this._mobileOperator.IsEmpty)
					if (this.ConnectionContext != null)
						this._mobileOperator = MobileOperator.CreateManager().LazyLoad(this.ConnectionContext, this._mobileOperator.ID) as MobileOperator;
					else
						this._mobileOperator = MobileOperator.CreateManager().LazyLoad(this._mobileOperator.ID) as MobileOperator;
				return this._mobileOperator;
			}
			set { _mobileOperator = value; }
		}

		public MessageDirection MessageDirection  { get { return this._messageDirection; } set { this._messageDirection = value; } }
		public MessageType MessageType  { get { return this._messageType; } set { this._messageType = value; } }
		public MessageStatus MessageStatus  { get { return this._messageStatus; } set { this._messageStatus = value; } }
		public string Text{ get {return this._text; } set { this._text = value;} }
		public int? Shorcode{ get {return this._shorcode; } set { this._shorcode = value;} }
		public string Keyword{ get {return this._keyword; } set { this._keyword = value;} }
		public int? TrackingID{ get {return this._trackingID; } set { this._trackingID = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public Message()
    { 
    }

    public Message(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public Message(int id,  Guid guid, int? externalID, Service service, Customer customer, string mobileOperatorName, MobileOperator mobileOperator, MessageDirection messageDirection, MessageType messageType, MessageStatus messageStatus, string text, int? shorcode, string keyword, int? trackingID, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._guid = guid;
			this._externalID = externalID;
			this._service = service;
			this._customer = customer;
			this._mobileOperatorName = mobileOperatorName;
			this._mobileOperator = mobileOperator;
			this._messageDirection = messageDirection;
			this._messageType = messageType;
			this._messageStatus = messageStatus;
			this._text = text;
			this._shorcode = shorcode;
			this._keyword = keyword;
			this._trackingID = trackingID;
			
    }

    public override object Clone(bool deepClone)
    {
      return new Message(-1, this.Guid,this.ExternalID, this.Service, this.Customer,this.MobileOperatorName, this.MobileOperator, this.MessageDirection, this.MessageType, this.MessageStatus,this.Text,this.Shorcode,this.Keyword,this.TrackingID, DateTime.Now, DateTime.Now);
    }
  }
}

