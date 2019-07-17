using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface IServiceSendNumberMapManager : IDataManager<ServiceSendNumberMap> 
  {
	

  }

  public partial class ServiceSendNumberMap : MobiChatObject<IServiceSendNumberMapManager> 
  {
		private Service _service;
		private SendNumberType _sendNumberType;
		private string _messages = String.Empty;
		private bool _isActive = false;
		

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

		public SendNumberType SendNumberType 
		{
			get
			{
				if (this._sendNumberType != null &&
						this._sendNumberType.IsEmpty)
					if (this.ConnectionContext != null)
						this._sendNumberType = SendNumberType.CreateManager().LazyLoad(this.ConnectionContext, this._sendNumberType.ID) as SendNumberType;
					else
						this._sendNumberType = SendNumberType.CreateManager().LazyLoad(this._sendNumberType.ID) as SendNumberType;
				return this._sendNumberType;
			}
			set { _sendNumberType = value; }
		}

		public string Messages{ get {return this._messages; } set { this._messages = value;} }
		public bool IsActive {get {return this._isActive; } set { this._isActive = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public ServiceSendNumberMap()
    { 
    }

    public ServiceSendNumberMap(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public ServiceSendNumberMap(int id,  Service service, SendNumberType sendNumberType, string messages, bool isActive, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._service = service;
			this._sendNumberType = sendNumberType;
			this._messages = messages;
			this._isActive = isActive;
			
    }

    public override object Clone(bool deepClone)
    {
      return new ServiceSendNumberMap(-1,  this.Service, this.SendNumberType,this.Messages,this.IsActive, DateTime.Now, DateTime.Now);
    }
  }
}

