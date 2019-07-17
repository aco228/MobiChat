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
		private Service _service;
		private Country _country;
		private Language _language;
		private MobileOperator _mobileOperator;
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

		public Country Country 
		{
			get
			{
				if (this._country != null &&
						this._country.IsEmpty)
					if (this.ConnectionContext != null)
						this._country = Country.CreateManager().LazyLoad(this.ConnectionContext, this._country.ID) as Country;
					else
						this._country = Country.CreateManager().LazyLoad(this._country.ID) as Country;
				return this._country;
			}
			set { _country = value; }
		}

		public Language Language 
		{
			get
			{
				if (this._language != null &&
						this._language.IsEmpty)
					if (this.ConnectionContext != null)
						this._language = Language.CreateManager().LazyLoad(this.ConnectionContext, this._language.ID) as Language;
					else
						this._language = Language.CreateManager().LazyLoad(this._language.ID) as Language;
				return this._language;
			}
			set { _language = value; }
		}

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

    public Customer(int id,  Guid guid, User user, Service service, Country country, Language language, MobileOperator mobileOperator, string msisdn, string encryptedMsisdn, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._guid = guid;
			this._user = user;
			this._service = service;
			this._country = country;
			this._language = language;
			this._mobileOperator = mobileOperator;
			this._msisdn = msisdn;
			this._encryptedMsisdn = encryptedMsisdn;
			
    }

    public override object Clone(bool deepClone)
    {
      return new Customer(-1, this.Guid, this.User, this.Service, this.Country, this.Language, this.MobileOperator,this.Msisdn,this.EncryptedMsisdn, DateTime.Now, DateTime.Now);
    }
  }
}

