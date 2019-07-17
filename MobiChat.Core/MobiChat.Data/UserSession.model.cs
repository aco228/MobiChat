using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface IUserSessionManager : IDataManager<UserSession> 
  {
	

  }

  public partial class UserSession : MobiChatObject<IUserSessionManager> 
  {
		private Guid _guid;
		private UserSessionType _userSessionType;
		private Service _service;
		private Application _application;
		private Domain _domain;
		private User _user;
		private Country _country;
		private Language _language;
		private MobileOperator _mobileOperator;
		private int? _trackingID = -1;
		private string _iPAddress = String.Empty;
		private string _userAgent = String.Empty;
		private string _entranceUrl = String.Empty;
		private string _refferer = String.Empty;
		private bool _hasVerifiedAge = false;
		private DateTime _validUntil = DateTime.MinValue;
		

		public Guid Guid { get { return this._guid; } set { _guid = value; } }
		public UserSessionType UserSessionType 
		{
			get
			{
				if (this._userSessionType != null &&
						this._userSessionType.IsEmpty)
					if (this.ConnectionContext != null)
						this._userSessionType = UserSessionType.CreateManager().LazyLoad(this.ConnectionContext, this._userSessionType.ID) as UserSessionType;
					else
						this._userSessionType = UserSessionType.CreateManager().LazyLoad(this._userSessionType.ID) as UserSessionType;
				return this._userSessionType;
			}
			set { _userSessionType = value; }
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

		public Application Application 
		{
			get
			{
				if (this._application != null &&
						this._application.IsEmpty)
					if (this.ConnectionContext != null)
						this._application = Application.CreateManager().LazyLoad(this.ConnectionContext, this._application.ID) as Application;
					else
						this._application = Application.CreateManager().LazyLoad(this._application.ID) as Application;
				return this._application;
			}
			set { _application = value; }
		}

		public Domain Domain 
		{
			get
			{
				if (this._domain != null &&
						this._domain.IsEmpty)
					if (this.ConnectionContext != null)
						this._domain = Domain.CreateManager().LazyLoad(this.ConnectionContext, this._domain.ID) as Domain;
					else
						this._domain = Domain.CreateManager().LazyLoad(this._domain.ID) as Domain;
				return this._domain;
			}
			set { _domain = value; }
		}

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

		public int? TrackingID{ get {return this._trackingID; } set { this._trackingID = value;} }
		public string IPAddress{ get {return this._iPAddress; } set { this._iPAddress = value;} }
		public string UserAgent{ get {return this._userAgent; } set { this._userAgent = value;} }
		public string EntranceUrl{ get {return this._entranceUrl; } set { this._entranceUrl = value;} }
		public string Refferer{ get {return this._refferer; } set { this._refferer = value;} }
		public bool HasVerifiedAge {get {return this._hasVerifiedAge; } set { this._hasVerifiedAge = value;} }
		public DateTime ValidUntil { get { return this._validUntil; } set { this._validUntil = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public UserSession()
    { 
    }

    public UserSession(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public UserSession(int id,  Guid guid, UserSessionType userSessionType, Service service, Application application, Domain domain, User user, Country country, Language language, MobileOperator mobileOperator, int? trackingID, string iPAddress, string userAgent, string entranceUrl, string refferer, bool hasVerifiedAge, DateTime validUntil, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._guid = guid;
			this._userSessionType = userSessionType;
			this._service = service;
			this._application = application;
			this._domain = domain;
			this._user = user;
			this._country = country;
			this._language = language;
			this._mobileOperator = mobileOperator;
			this._trackingID = trackingID;
			this._iPAddress = iPAddress;
			this._userAgent = userAgent;
			this._entranceUrl = entranceUrl;
			this._refferer = refferer;
			this._hasVerifiedAge = hasVerifiedAge;
			this._validUntil = validUntil;
			
    }

    public override object Clone(bool deepClone)
    {
      return new UserSession(-1, this.Guid, this.UserSessionType, this.Service, this.Application, this.Domain, this.User, this.Country, this.Language, this.MobileOperator,this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil, DateTime.Now, DateTime.Now);
    }
  }
}

