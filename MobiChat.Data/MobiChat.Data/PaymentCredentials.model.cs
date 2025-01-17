using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface IPaymentCredentialsManager : IDataManager<PaymentCredentials> 
  {
	

  }

  public partial class PaymentCredentials : MobiChatObject<IPaymentCredentialsManager> 
  {
		private string _username = String.Empty;
		private string _password = String.Empty;
		

		public string Username{ get {return this._username; } set { this._username = value;} }
		public string Password{ get {return this._password; } set { this._password = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public PaymentCredentials()
    { 
    }

    public PaymentCredentials(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public PaymentCredentials(int id,  string username, string password, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._username = username;
			this._password = password;
			
    }

    public override object Clone(bool deepClone)
    {
      return new PaymentCredentials(-1, this.Username,this.Password, DateTime.Now, DateTime.Now);
    }
  }
}

