using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti;
using Senti.Data;
using Senti.Data.Sql;

using MobiChat.Data;


namespace MobiChat.Data.Sql
{
  public class UserSessionTable : TableBase<UserSession>
  {
    public static string GetColumnNames()
    {
      return TableBase<UserSession>.GetColumnNames(string.Empty, UserSessionTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<UserSession>.GetColumnNames(tablePrefix, UserSessionTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription UserSessionID = new ColumnDescription("UserSessionID", 0, typeof(int));
			public static readonly ColumnDescription UserSessionGuid = new ColumnDescription("UserSessionGuid", 1, typeof(Guid));
			public static readonly ColumnDescription UserSessionTypeID = new ColumnDescription("UserSessionTypeID", 2, typeof(int));
			public static readonly ColumnDescription ServiceID = new ColumnDescription("ServiceID", 3, typeof(int));
			public static readonly ColumnDescription ApplicationID = new ColumnDescription("ApplicationID", 4, typeof(int));
			public static readonly ColumnDescription DomainID = new ColumnDescription("DomainID", 5, typeof(int));
			public static readonly ColumnDescription UserID = new ColumnDescription("UserID", 6, typeof(int));
			public static readonly ColumnDescription CountryID = new ColumnDescription("CountryID", 7, typeof(int));
			public static readonly ColumnDescription LanguageID = new ColumnDescription("LanguageID", 8, typeof(int));
			public static readonly ColumnDescription MobileOperatorID = new ColumnDescription("MobileOperatorID", 9, typeof(int));
			public static readonly ColumnDescription TrackingID = new ColumnDescription("TrackingID", 10, typeof(int));
			public static readonly ColumnDescription IPAddress = new ColumnDescription("IPAddress", 11, typeof(string));
			public static readonly ColumnDescription UserAgent = new ColumnDescription("UserAgent", 12, typeof(string));
			public static readonly ColumnDescription EntranceUrl = new ColumnDescription("EntranceUrl", 13, typeof(string));
			public static readonly ColumnDescription Refferer = new ColumnDescription("Refferer", 14, typeof(string));
			public static readonly ColumnDescription HasVerifiedAge = new ColumnDescription("HasVerifiedAge", 15, typeof(bool));
			public static readonly ColumnDescription ValidUntil = new ColumnDescription("ValidUntil", 16, typeof(DateTime));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 17, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 18, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				UserSessionID,
				UserSessionGuid,
				UserSessionTypeID,
				ServiceID,
				ApplicationID,
				DomainID,
				UserID,
				CountryID,
				LanguageID,
				MobileOperatorID,
				TrackingID,
				IPAddress,
				UserAgent,
				EntranceUrl,
				Refferer,
				HasVerifiedAge,
				ValidUntil,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public UserSessionTable(SqlQuery query) : base(query) { }
    public UserSessionTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int UserSessionID { get { return this.Reader.GetInt32(this.GetIndex(Columns.UserSessionID)); } }
		public Guid UserSessionGuid { get { return this.Reader.GetGuid(this.GetIndex(Columns.UserSessionGuid)); } }
		public int UserSessionTypeID { get { return this.Reader.GetInt32(this.GetIndex(Columns.UserSessionTypeID)); } }
		
		public int? ServiceID 
		{
			get
			{
				int index = this.GetIndex(Columns.ServiceID);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetInt32(index);
			}
		}

		
		public int? ApplicationID 
		{
			get
			{
				int index = this.GetIndex(Columns.ApplicationID);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetInt32(index);
			}
		}

		
		public int? DomainID 
		{
			get
			{
				int index = this.GetIndex(Columns.DomainID);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetInt32(index);
			}
		}

		
		public int? UserID 
		{
			get
			{
				int index = this.GetIndex(Columns.UserID);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetInt32(index);
			}
		}

		public int CountryID { get { return this.Reader.GetInt32(this.GetIndex(Columns.CountryID)); } }
		public int LanguageID { get { return this.Reader.GetInt32(this.GetIndex(Columns.LanguageID)); } }
		
		public int? MobileOperatorID 
		{
			get
			{
				int index = this.GetIndex(Columns.MobileOperatorID);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetInt32(index);
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

		public string IPAddress { get { return this.Reader.GetString(this.GetIndex(Columns.IPAddress)); } }
		
		public string UserAgent 
		{
			get
			{
				int index = this.GetIndex(Columns.UserAgent);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		public string EntranceUrl { get { return this.Reader.GetString(this.GetIndex(Columns.EntranceUrl)); } }
		
		public string Refferer 
		{
			get
			{
				int index = this.GetIndex(Columns.Refferer);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		public bool HasVerifiedAge { get { return this.Reader.GetBoolean(this.GetIndex(Columns.HasVerifiedAge)); } }
		public DateTime ValidUntil { get { return this.Reader.GetDateTime(this.GetIndex(Columns.ValidUntil)); } }
		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public UserSession CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Application application)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Country country)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Domain domain)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(User user)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Application application, Country country)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Application application, Domain domain)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Application application, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Application application, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Application application)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Application application, User user)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Application application)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Domain domain, Country country)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Country country)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(User user, Country country)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Country country)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Domain domain, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Domain domain, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Domain domain)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Domain domain, User user)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Domain domain)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(User user, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(User user, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, User user)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, User user)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Application application, Domain domain, Country country)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Application application, Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Application application, Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Application application, Country country)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Application application, User user, Country country)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Application application, Country country)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Application application, Domain domain, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Application application, Domain domain, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Application application, Domain domain)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Application application, Domain domain, User user)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Application application, Domain domain)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Application application, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Application application, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Application application, User user, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Application application, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Application application, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Application application, User user, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Application application, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Application application, User user)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Application application)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Application application, User user)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Domain domain, Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Domain domain, Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Domain domain, Country country)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Domain domain, User user, Country country)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Domain domain, Country country)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(User user, Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(User user, Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, User user, Country country)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Country country)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, User user, Country country)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Domain domain, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Domain domain, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Domain domain, User user, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Domain domain, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Domain domain, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Domain domain, User user, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Domain domain, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Domain domain, User user)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Domain domain)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Domain domain, User user)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(User user, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, User user, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, User user, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, User user, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, User user, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, User user)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Application application, Domain domain, Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Application application, Domain domain, Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Application application, Domain domain, Country country)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Application application, Domain domain, User user, Country country)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Application application, Domain domain, Country country)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Application application, Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Application application, Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Application application, User user, Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Application application, Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Application application, Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Application application, User user, Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Application application, Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Application application, User user, Country country)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Application application, Country country)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Application application, User user, Country country)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Application application, Domain domain, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Application application, Domain domain, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Application application, Domain domain, User user, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Application application, Domain domain, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Application application, Domain domain, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Application application, Domain domain, User user, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Application application, Domain domain, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Application application, Domain domain, User user)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Application application, Domain domain)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Application application, Domain domain, User user)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Application application, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Application application, User user, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Application application, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Application application, User user, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Application application, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Application application, User user, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Application application, User user, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Application application, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Application application, User user, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Application application, User user)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Domain domain, Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Domain domain, Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Domain domain, User user, Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Domain domain, Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Domain domain, Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Domain domain, User user, Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Domain domain, Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Domain domain, User user, Country country)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Domain domain, Country country)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Domain domain, User user, Country country)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(User user, Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, User user, Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, User user, Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, User user, Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, User user, Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, User user, Country country)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Domain domain, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Domain domain, User user, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Domain domain, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Domain domain, User user, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Domain domain, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Domain domain, User user, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Domain domain, User user, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Domain domain, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Domain domain, User user, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Domain domain, User user)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, User user, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, User user, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, User user, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, User user, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Application application, Domain domain, Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Application application, Domain domain, Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Application application, Domain domain, User user, Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Application application, Domain domain, Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Application application, Domain domain, Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Application application, Domain domain, User user, Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Application application, Domain domain, Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Application application, Domain domain, User user, Country country)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Application application, Domain domain, Country country)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Application application, Domain domain, User user, Country country)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Application application, Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Application application, User user, Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Application application, Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Application application, User user, Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Application application, Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Application application, User user, Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Application application, User user, Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Application application, Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Application application, User user, Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Application application, User user, Country country)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Application application, Domain domain, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Application application, Domain domain, User user, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Application application, Domain domain, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Application application, Domain domain, User user, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Application application, Domain domain, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Application application, Domain domain, User user, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Application application, Domain domain, User user, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Application application, Domain domain, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Application application, Domain domain, User user, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Application application, Domain domain, User user)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Application application, User user, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Application application, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Application application, User user, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Application application, User user, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Application application, User user, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Domain domain, Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Domain domain, User user, Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Domain domain, Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Domain domain, User user, Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Domain domain, Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Domain domain, User user, Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Domain domain, User user, Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Domain domain, Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Domain domain, User user, Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Domain domain, User user, Country country)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, User user, Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, User user, Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, User user, Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, User user, Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Domain domain, User user, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Domain domain, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Domain domain, User user, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Domain domain, User user, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Domain domain, User user, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, User user, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Application application, Domain domain, Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Application application, Domain domain, User user, Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Application application, Domain domain, Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Application application, Domain domain, User user, Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Application application, Domain domain, Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Application application, Domain domain, User user, Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Application application, Domain domain, User user, Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Application application, Domain domain, Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Application application, Domain domain, User user, Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Application application, Domain domain, User user, Country country)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Application application, User user, Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Application application, Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Application application, User user, Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Application application, User user, Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Application application, User user, Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Application application, Domain domain, User user, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Application application, Domain domain, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Application application, Domain domain, User user, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Application application, Domain domain, User user, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Application application, Domain domain, User user, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Application application, User user, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Domain domain, User user, Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Domain domain, Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Domain domain, User user, Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Domain domain, User user, Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Domain domain, User user, Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, User user, Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Domain domain, User user, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(Service service, Application application, Domain domain, User user, Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Application application, Domain domain, Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), (UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Application application, Domain domain, User user, Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Application application, Domain domain, User user, Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Application application, Domain domain, User user, Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Application application, User user, Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), (DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Application application, Domain domain, User user, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Domain domain, User user, Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		public UserSession CreateInstance(UserSessionType userSessionType, Service service, Application application, Domain domain, User user, Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new UserSession(this.UserSessionID,this.UserSessionGuid,userSessionType ?? new UserSessionType(this.UserSessionTypeID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), application ?? (this.ApplicationID.HasValue ? new Application(this.ApplicationID.Value) : null), domain ?? (this.DomainID.HasValue ? new Domain(this.DomainID.Value) : null), user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), country ?? new Country(this.CountryID), language ?? new Language(this.LanguageID), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.TrackingID,this.IPAddress,this.UserAgent,this.EntranceUrl,this.Refferer,this.HasVerifiedAge,this.ValidUntil,this.Updated,this.Created); 
		}
		

  }
}

