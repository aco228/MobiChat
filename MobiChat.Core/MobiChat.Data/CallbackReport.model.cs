using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface ICallbackReportManager : IDataManager<CallbackReport> 
  {
	

  }

  public partial class CallbackReport : MobiChatObject<ICallbackReportManager> 
  {
		private CallbackNotificationType _callbackNotificationType;
		private string _url = String.Empty;
		

		public CallbackNotificationType CallbackNotificationType  { get { return this._callbackNotificationType; } set { this._callbackNotificationType = value; } }
		public string Url{ get {return this._url; } set { this._url = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public CallbackReport()
    { 
    }

    public CallbackReport(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public CallbackReport(int id,  CallbackNotificationType callbackNotificationType, string url, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._callbackNotificationType = callbackNotificationType;
			this._url = url;
			
    }

    public override object Clone(bool deepClone)
    {
      return new CallbackReport(-1,  this.CallbackNotificationType,this.Url, DateTime.Now, DateTime.Now);
    }
  }
}

