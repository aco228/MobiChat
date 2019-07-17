using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

using MobiChat.Web.Data; 

namespace MobiChat.Web.Data 
{
  public partial interface IMTMessageManager : IDataManager<MTMessage> 
  {
	

  }

  public partial class MTMessage : MobiChatObject<IMTMessageManager> 
  {
		private Message _message;
		private string _appID = String.Empty;
		private string _to = String.Empty;
		private string _msgID = String.Empty;
		private string _time = String.Empty;
		private string _state = String.Empty;
		private string _error = String.Empty;
		private string _reasonCode = String.Empty;
		private string _retry = String.Empty;
		private string _appMsgID = String.Empty;
		

		public Message Message 
		{
			get
			{
				if (this._message != null &&
						this._message.IsEmpty)
					if (this.ConnectionContext != null)
						this._message = Message.CreateManager().LazyLoad(this.ConnectionContext, this._message.ID) as Message;
					else
						this._message = Message.CreateManager().LazyLoad(this._message.ID) as Message;
				return this._message;
			}
			set { _message = value; }
		}

		public string AppID{ get {return this._appID; } set { this._appID = value;} }
		public string To{ get {return this._to; } set { this._to = value;} }
		public string MsgID{ get {return this._msgID; } set { this._msgID = value;} }
		public string Time{ get {return this._time; } set { this._time = value;} }
		public string State{ get {return this._state; } set { this._state = value;} }
		public string Error{ get {return this._error; } set { this._error = value;} }
		public string ReasonCode{ get {return this._reasonCode; } set { this._reasonCode = value;} }
		public string Retry{ get {return this._retry; } set { this._retry = value;} }
		public string AppMsgID{ get {return this._appMsgID; } set { this._appMsgID = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public MTMessage()
    { 
    }

    public MTMessage(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public MTMessage(int id,  Message message, string appID, string to, string msgID, string time, string state, string error, string reasonCode, string retry, string appMsgID, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._message = message;
			this._appID = appID;
			this._to = to;
			this._msgID = msgID;
			this._time = time;
			this._state = state;
			this._error = error;
			this._reasonCode = reasonCode;
			this._retry = retry;
			this._appMsgID = appMsgID;
			
    }

    public override object Clone(bool deepClone)
    {
      return new MTMessage(-1,  this.Message,this.AppID,this.To,this.MsgID,this.Time,this.State,this.Error,this.ReasonCode,this.Retry,this.AppMsgID, DateTime.Now, DateTime.Now);
    }
  }
}

