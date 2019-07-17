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
  public class CustomerTable : TableBase<Customer>
  {
    public static string GetColumnNames()
    {
      return TableBase<Customer>.GetColumnNames(string.Empty, CustomerTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<Customer>.GetColumnNames(tablePrefix, CustomerTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription CustomerID = new ColumnDescription("CustomerID", 0, typeof(int));
			public static readonly ColumnDescription CustomerGuid = new ColumnDescription("CustomerGuid", 1, typeof(Guid));
			public static readonly ColumnDescription UserID = new ColumnDescription("UserID", 2, typeof(int));
			public static readonly ColumnDescription ServiceID = new ColumnDescription("ServiceID", 3, typeof(int));
			public static readonly ColumnDescription CountryID = new ColumnDescription("CountryID", 4, typeof(int));
			public static readonly ColumnDescription LanguageID = new ColumnDescription("LanguageID", 5, typeof(int));
			public static readonly ColumnDescription MobileOperatorID = new ColumnDescription("MobileOperatorID", 6, typeof(int));
			public static readonly ColumnDescription Msisdn = new ColumnDescription("Msisdn", 7, typeof(string));
			public static readonly ColumnDescription EncryptedMsisdn = new ColumnDescription("EncryptedMsisdn", 8, typeof(string));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 9, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 10, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				CustomerID,
				CustomerGuid,
				UserID,
				ServiceID,
				CountryID,
				LanguageID,
				MobileOperatorID,
				Msisdn,
				EncryptedMsisdn,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public CustomerTable(SqlQuery query) : base(query) { }
    public CustomerTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int CustomerID { get { return this.Reader.GetInt32(this.GetIndex(Columns.CustomerID)); } }
		public Guid CustomerGuid { get { return this.Reader.GetGuid(this.GetIndex(Columns.CustomerGuid)); } }
		
		public int? UserID 
		{
			get
			{
				int index = this.GetIndex(Columns.UserID);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetInt32(index);
			}
		}

		public int ServiceID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ServiceID)); } }
		public int CountryID { get { return this.Reader.GetInt32(this.GetIndex(Columns.CountryID)); } }
		
		public int? LanguageID 
		{
			get
			{
				int index = this.GetIndex(Columns.LanguageID);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetInt32(index);
			}
		}

		
		public int? MobileOperatorID 
		{
			get
			{
				int index = this.GetIndex(Columns.MobileOperatorID);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetInt32(index);
			}
		}

		
		public string Msisdn 
		{
			get
			{
				int index = this.GetIndex(Columns.Msisdn);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		
		public string EncryptedMsisdn 
		{
			get
			{
				int index = this.GetIndex(Columns.EncryptedMsisdn);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public Customer CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new Customer(this.CustomerID,this.CustomerGuid,(UserID.HasValue ? new User(this.UserID.Value) : null), new Service(this.ServiceID), new Country(this.CountryID), (LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.Msisdn,this.EncryptedMsisdn,this.Updated,this.Created); 
		}
		public Customer CreateInstance(Country country)  
		{ 
			if (!this.HasData) return null;
			return new Customer(this.CustomerID,this.CustomerGuid,(UserID.HasValue ? new User(this.UserID.Value) : null), new Service(this.ServiceID), country ?? new Country(this.CountryID), (LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.Msisdn,this.EncryptedMsisdn,this.Updated,this.Created); 
		}
		public Customer CreateInstance(Language language)  
		{ 
			if (!this.HasData) return null;
			return new Customer(this.CustomerID,this.CustomerGuid,(UserID.HasValue ? new User(this.UserID.Value) : null), new Service(this.ServiceID), new Country(this.CountryID), language ?? (this.LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.Msisdn,this.EncryptedMsisdn,this.Updated,this.Created); 
		}
		public Customer CreateInstance(MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new Customer(this.CustomerID,this.CustomerGuid,(UserID.HasValue ? new User(this.UserID.Value) : null), new Service(this.ServiceID), new Country(this.CountryID), (LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.Msisdn,this.EncryptedMsisdn,this.Updated,this.Created); 
		}
		public Customer CreateInstance(Service service)  
		{ 
			if (!this.HasData) return null;
			return new Customer(this.CustomerID,this.CustomerGuid,(UserID.HasValue ? new User(this.UserID.Value) : null), service ?? new Service(this.ServiceID), new Country(this.CountryID), (LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.Msisdn,this.EncryptedMsisdn,this.Updated,this.Created); 
		}
		public Customer CreateInstance(User user)  
		{ 
			if (!this.HasData) return null;
			return new Customer(this.CustomerID,this.CustomerGuid,user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Service(this.ServiceID), new Country(this.CountryID), (LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.Msisdn,this.EncryptedMsisdn,this.Updated,this.Created); 
		}
		public Customer CreateInstance(Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new Customer(this.CustomerID,this.CustomerGuid,(UserID.HasValue ? new User(this.UserID.Value) : null), new Service(this.ServiceID), country ?? new Country(this.CountryID), language ?? (this.LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.Msisdn,this.EncryptedMsisdn,this.Updated,this.Created); 
		}
		public Customer CreateInstance(Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new Customer(this.CustomerID,this.CustomerGuid,(UserID.HasValue ? new User(this.UserID.Value) : null), new Service(this.ServiceID), country ?? new Country(this.CountryID), (LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.Msisdn,this.EncryptedMsisdn,this.Updated,this.Created); 
		}
		public Customer CreateInstance(Service service, Country country)  
		{ 
			if (!this.HasData) return null;
			return new Customer(this.CustomerID,this.CustomerGuid,(UserID.HasValue ? new User(this.UserID.Value) : null), service ?? new Service(this.ServiceID), country ?? new Country(this.CountryID), (LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.Msisdn,this.EncryptedMsisdn,this.Updated,this.Created); 
		}
		public Customer CreateInstance(User user, Country country)  
		{ 
			if (!this.HasData) return null;
			return new Customer(this.CustomerID,this.CustomerGuid,user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Service(this.ServiceID), country ?? new Country(this.CountryID), (LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.Msisdn,this.EncryptedMsisdn,this.Updated,this.Created); 
		}
		public Customer CreateInstance(Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new Customer(this.CustomerID,this.CustomerGuid,(UserID.HasValue ? new User(this.UserID.Value) : null), new Service(this.ServiceID), new Country(this.CountryID), language ?? (this.LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.Msisdn,this.EncryptedMsisdn,this.Updated,this.Created); 
		}
		public Customer CreateInstance(Service service, Language language)  
		{ 
			if (!this.HasData) return null;
			return new Customer(this.CustomerID,this.CustomerGuid,(UserID.HasValue ? new User(this.UserID.Value) : null), service ?? new Service(this.ServiceID), new Country(this.CountryID), language ?? (this.LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.Msisdn,this.EncryptedMsisdn,this.Updated,this.Created); 
		}
		public Customer CreateInstance(User user, Language language)  
		{ 
			if (!this.HasData) return null;
			return new Customer(this.CustomerID,this.CustomerGuid,user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Service(this.ServiceID), new Country(this.CountryID), language ?? (this.LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.Msisdn,this.EncryptedMsisdn,this.Updated,this.Created); 
		}
		public Customer CreateInstance(Service service, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new Customer(this.CustomerID,this.CustomerGuid,(UserID.HasValue ? new User(this.UserID.Value) : null), service ?? new Service(this.ServiceID), new Country(this.CountryID), (LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.Msisdn,this.EncryptedMsisdn,this.Updated,this.Created); 
		}
		public Customer CreateInstance(User user, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new Customer(this.CustomerID,this.CustomerGuid,user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Service(this.ServiceID), new Country(this.CountryID), (LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.Msisdn,this.EncryptedMsisdn,this.Updated,this.Created); 
		}
		public Customer CreateInstance(User user, Service service)  
		{ 
			if (!this.HasData) return null;
			return new Customer(this.CustomerID,this.CustomerGuid,user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), service ?? new Service(this.ServiceID), new Country(this.CountryID), (LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.Msisdn,this.EncryptedMsisdn,this.Updated,this.Created); 
		}
		public Customer CreateInstance(Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new Customer(this.CustomerID,this.CustomerGuid,(UserID.HasValue ? new User(this.UserID.Value) : null), new Service(this.ServiceID), country ?? new Country(this.CountryID), language ?? (this.LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.Msisdn,this.EncryptedMsisdn,this.Updated,this.Created); 
		}
		public Customer CreateInstance(Service service, Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new Customer(this.CustomerID,this.CustomerGuid,(UserID.HasValue ? new User(this.UserID.Value) : null), service ?? new Service(this.ServiceID), country ?? new Country(this.CountryID), language ?? (this.LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.Msisdn,this.EncryptedMsisdn,this.Updated,this.Created); 
		}
		public Customer CreateInstance(User user, Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new Customer(this.CustomerID,this.CustomerGuid,user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Service(this.ServiceID), country ?? new Country(this.CountryID), language ?? (this.LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.Msisdn,this.EncryptedMsisdn,this.Updated,this.Created); 
		}
		public Customer CreateInstance(Service service, Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new Customer(this.CustomerID,this.CustomerGuid,(UserID.HasValue ? new User(this.UserID.Value) : null), service ?? new Service(this.ServiceID), country ?? new Country(this.CountryID), (LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.Msisdn,this.EncryptedMsisdn,this.Updated,this.Created); 
		}
		public Customer CreateInstance(User user, Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new Customer(this.CustomerID,this.CustomerGuid,user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Service(this.ServiceID), country ?? new Country(this.CountryID), (LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.Msisdn,this.EncryptedMsisdn,this.Updated,this.Created); 
		}
		public Customer CreateInstance(User user, Service service, Country country)  
		{ 
			if (!this.HasData) return null;
			return new Customer(this.CustomerID,this.CustomerGuid,user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), service ?? new Service(this.ServiceID), country ?? new Country(this.CountryID), (LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.Msisdn,this.EncryptedMsisdn,this.Updated,this.Created); 
		}
		public Customer CreateInstance(Service service, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new Customer(this.CustomerID,this.CustomerGuid,(UserID.HasValue ? new User(this.UserID.Value) : null), service ?? new Service(this.ServiceID), new Country(this.CountryID), language ?? (this.LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.Msisdn,this.EncryptedMsisdn,this.Updated,this.Created); 
		}
		public Customer CreateInstance(User user, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new Customer(this.CustomerID,this.CustomerGuid,user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Service(this.ServiceID), new Country(this.CountryID), language ?? (this.LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.Msisdn,this.EncryptedMsisdn,this.Updated,this.Created); 
		}
		public Customer CreateInstance(User user, Service service, Language language)  
		{ 
			if (!this.HasData) return null;
			return new Customer(this.CustomerID,this.CustomerGuid,user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), service ?? new Service(this.ServiceID), new Country(this.CountryID), language ?? (this.LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.Msisdn,this.EncryptedMsisdn,this.Updated,this.Created); 
		}
		public Customer CreateInstance(User user, Service service, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new Customer(this.CustomerID,this.CustomerGuid,user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), service ?? new Service(this.ServiceID), new Country(this.CountryID), (LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.Msisdn,this.EncryptedMsisdn,this.Updated,this.Created); 
		}
		public Customer CreateInstance(Service service, Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new Customer(this.CustomerID,this.CustomerGuid,(UserID.HasValue ? new User(this.UserID.Value) : null), service ?? new Service(this.ServiceID), country ?? new Country(this.CountryID), language ?? (this.LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.Msisdn,this.EncryptedMsisdn,this.Updated,this.Created); 
		}
		public Customer CreateInstance(User user, Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new Customer(this.CustomerID,this.CustomerGuid,user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), new Service(this.ServiceID), country ?? new Country(this.CountryID), language ?? (this.LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.Msisdn,this.EncryptedMsisdn,this.Updated,this.Created); 
		}
		public Customer CreateInstance(User user, Service service, Country country, Language language)  
		{ 
			if (!this.HasData) return null;
			return new Customer(this.CustomerID,this.CustomerGuid,user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), service ?? new Service(this.ServiceID), country ?? new Country(this.CountryID), language ?? (this.LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.Msisdn,this.EncryptedMsisdn,this.Updated,this.Created); 
		}
		public Customer CreateInstance(User user, Service service, Country country, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new Customer(this.CustomerID,this.CustomerGuid,user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), service ?? new Service(this.ServiceID), country ?? new Country(this.CountryID), (LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.Msisdn,this.EncryptedMsisdn,this.Updated,this.Created); 
		}
		public Customer CreateInstance(User user, Service service, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new Customer(this.CustomerID,this.CustomerGuid,user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), service ?? new Service(this.ServiceID), new Country(this.CountryID), language ?? (this.LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.Msisdn,this.EncryptedMsisdn,this.Updated,this.Created); 
		}
		public Customer CreateInstance(User user, Service service, Country country, Language language, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new Customer(this.CustomerID,this.CustomerGuid,user ?? (this.UserID.HasValue ? new User(this.UserID.Value) : null), service ?? new Service(this.ServiceID), country ?? new Country(this.CountryID), language ?? (this.LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), this.Msisdn,this.EncryptedMsisdn,this.Updated,this.Created); 
		}
		

  }
}

