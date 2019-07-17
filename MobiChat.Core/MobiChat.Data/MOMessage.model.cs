using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

using MobiChat.Web.Data; 

namespace MobiChat.Web.Data 
{
  public partial interface IMOMessageManager : IDataManager<MOMessage> 
  {
	

  }

  public partial class MOMessage : MobiChatObject<IMOMessageManager> 
  {
		private Message _message;
		private string _appID = String.Empty;
		private string _from = String.Empty;
		private string _operator = String.Empty;
		private string _to = String.Empty;
		private string _keyword = String.Empty;
		private string _tariff = String.Empty;
		private string _messageText = String.Empty;
		private string _smsID = String.Empty;
		

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
		public string From{ get {return this._from; } set { this._from = value;} }
		public string Operator{ get {return this._operator; } set { this._operator = value;} }
		public string To{ get {return this._to; } set { this._to = value;} }
		public string Keyword{ get {return this._keyword; } set { this._keyword = value;} }
		public string Tariff{ get {return this._tariff; } set { this._tariff = value;} }
		public string MessageText{ get {return this._messageText; } set { this._messageText = value;} }
		public string SmsID{ get {return this._smsID; } set { this._smsID = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public MOMessage()
    { 
    }

    public MOMessage(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public MOMessage(int id,  Message message, string appID, string from, string @operator, string to, string keyword, string tariff, string messageText, string smsID, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._message = message;
			this._appID = appID;
			this._from = from;
			this._operator = @operator;
			this._to = to;
			this._keyword = keyword;
			this._tariff = tariff;
			this._messageText = messageText;
			this._smsID = smsID;
			
    }

    public override object Clone(bool deepClone)
    {
      return new MOMessage(-1,  this.Message,this.AppID,this.From,this.Operator,this.To,this.Keyword,this.Tariff,this.MessageText,this.SmsID, DateTime.Now, DateTime.Now);
    }
  }
}

