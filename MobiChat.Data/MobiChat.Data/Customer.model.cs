using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface ICustomerManager : IDataManager<Customer> 
  {
	

  }

  public partial class Customer : MobiChatObject<ICustomerManager> 
  {
		private Guid _guid;
		private User _user;
		private int _serviceID = -1;
		private int _countryID = -1;
		private int? _languageID = -1;
		private int _mobileOperatorID = -1;
		private string _msisdn = String.Empty;
		private string _encryptedMsisdn = String.Empty;
		

		public Guid Guid { get { return this._guid; } set { _guid = value; } }
		public User User 
		{
			get
			{
				if (this._user != null &&
						this._user.IsEmpty)
					if (this.ConnectionContext != null)
						this._user = User.CreateManager().LazyLoad(this.ConnectionContext, this._user.ID) as User;
					else
						this._user = User.CreateManager().LazyLoad(this._user.ID) as User;
				return this._user;
			}
			set { _user = value; }
		}

		public int ServiceID{ get {return this._serviceID; } set { this._serviceID = value;} }
		public int CountryID{ get {return this._countryID; } set { this._countryID = value;} }
		public int? LanguageID{ get {return this._languageID; } set { this._languageID = value;} }
		public int MobileOperatorID{ get {return this._mobileOperatorID; } set { this._mobileOperatorID = value;} }
		public string Msisdn{ get {return this._msisdn; } set { this._msisdn = value;} }
		public string EncryptedMsisdn{ get {return this._encryptedMsisdn; } set { this._encryptedMsisdn = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public Customer()
    { 
    }

    public Customer(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public Customer(int id,  Guid guid, User user, int serviceID, int countryID, int? languageID, int mobileOperatorID, string msisdn, string encryptedMsisdn, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._guid = guid;
			this._user = user;
			this._serviceID = serviceID;
			this._countryID = countryID;
			this._languageID = languageID;
			this._mobileOperatorID = mobileOperatorID;
			this._msisdn = msisdn;
			this._encryptedMsisdn = encryptedMsisdn;
			
    }

    public override object Clone(bool deepClone)
    {
      return new Customer(-1, this.Guid, this.User,this.ServiceID,this.CountryID,this.LanguageID,this.MobileOperatorID,this.Msisdn,this.EncryptedMsisdn, DateTime.Now, DateTime.Now);
    }
  }
}

