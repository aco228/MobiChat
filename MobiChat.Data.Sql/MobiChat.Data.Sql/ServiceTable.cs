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
  public class ServiceTable : TableBase<Service>
  {
    public static string GetColumnNames()
    {
      return TableBase<Service>.GetColumnNames(string.Empty, ServiceTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<Service>.GetColumnNames(tablePrefix, ServiceTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription ServiceID = new ColumnDescription("ServiceID", 0, typeof(int));
			public static readonly ColumnDescription ServiceGuid = new ColumnDescription("ServiceGuid", 1, typeof(Guid));
			public static readonly ColumnDescription ApplicationID = new ColumnDescription("ApplicationID", 2, typeof(int));
			public static readonly ColumnDescription ProductID = new ColumnDescription("ProductID", 3, typeof(int));
			public static readonly ColumnDescription MerchantID = new ColumnDescription("MerchantID", 4, typeof(int));
			public static readonly ColumnDescription ServiceStatusID = new ColumnDescription("ServiceStatusID", 5, typeof(int));
			public static readonly ColumnDescription ServiceTypeID = new ColumnDescription("ServiceTypeID", 6, typeof(int));
			public static readonly ColumnDescription UserSessionTypeID = new ColumnDescription("UserSessionTypeID", 7, typeof(int));
			public static readonly ColumnDescription FallbackCountryID = new ColumnDescription("FallbackCountryID", 8, typeof(int));
			public static readonly ColumnDescription FallbackLanguageID = new ColumnDescription("FallbackLanguageID", 9, typeof(int));
			public static readonly ColumnDescription ServiceConfigurationID = new ColumnDescription("ServiceConfigurationID", 10, typeof(int));
			public static readonly ColumnDescription TemplateID = new ColumnDescription("TemplateID", 11, typeof(int));
			public static readonly ColumnDescription Name = new ColumnDescription("Name", 12, typeof(string));
			public static readonly ColumnDescription Description = new ColumnDescription("Description", 13, typeof(string));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 14, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 15, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				ServiceID,
				ServiceGuid,
				ApplicationID,
				ProductID,
				MerchantID,
				ServiceStatusID,
				ServiceTypeID,
				UserSessionTypeID,
				FallbackCountryID,
				FallbackLanguageID,
				ServiceConfigurationID,
				TemplateID,
				Name,
				Description,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public ServiceTable(SqlQuery query) : base(query) { }
    public ServiceTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int ServiceID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ServiceID)); } }
		public Guid ServiceGuid { get { return this.Reader.GetGuid(this.GetIndex(Columns.ServiceGuid)); } }
		public int ApplicationID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ApplicationID)); } }
		public int ProductID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ProductID)); } }
		public int MerchantID { get { return this.Reader.GetInt32(this.GetIndex(Columns.MerchantID)); } }
		public int ServiceStatusID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ServiceStatusID)); } }
		public int ServiceTypeID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ServiceTypeID)); } }
		public int UserSessionTypeID { get { return this.Reader.GetInt32(this.GetIndex(Columns.UserSessionTypeID)); } }
		public int FallbackCountryID { get { return this.Reader.GetInt32(this.GetIndex(Columns.FallbackCountryID)); } }
		public int FallbackLanguageID { get { return this.Reader.GetInt32(this.GetIndex(Columns.FallbackLanguageID)); } }
		public int ServiceConfigurationID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ServiceConfigurationID)); } }
		public int TemplateID { get { return this.Reader.GetInt32(this.GetIndex(Columns.TemplateID)); } }
		public string Name { get { return this.Reader.GetString(this.GetIndex(Columns.Name)); } }
		public string Description { get { return this.Reader.GetString(this.GetIndex(Columns.Description)); } }
		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public Service CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Country fallbackCountry)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(ServiceType serviceType)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(UserSessionType userSessionType)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Country fallbackCountry)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, ServiceType serviceType)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, UserSessionType userSessionType)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Country fallbackCountry, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, Country fallbackCountry)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Country fallbackCountry)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Country fallbackCountry, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(ServiceType serviceType, Country fallbackCountry)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Country fallbackCountry, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(UserSessionType userSessionType, Country fallbackCountry)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(ServiceType serviceType, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(UserSessionType userSessionType, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, ServiceType serviceType)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, UserSessionType userSessionType)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, ServiceType serviceType)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, UserSessionType userSessionType)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(ServiceType serviceType, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(UserSessionType userSessionType, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(ServiceType serviceType, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(ServiceType serviceType, UserSessionType userSessionType)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(UserSessionType userSessionType, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Country fallbackCountry, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, Country fallbackCountry)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Country fallbackCountry)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Country fallbackCountry, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, ServiceType serviceType, Country fallbackCountry)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Country fallbackCountry, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, UserSessionType userSessionType, Country fallbackCountry)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, ServiceType serviceType, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, UserSessionType userSessionType, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, ServiceType serviceType)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, UserSessionType userSessionType)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, ServiceType serviceType)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, UserSessionType userSessionType)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, ServiceType serviceType, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, UserSessionType userSessionType, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, ServiceType serviceType, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, ServiceType serviceType, UserSessionType userSessionType)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, UserSessionType userSessionType, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, Country fallbackCountry, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Country fallbackCountry, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(ServiceType serviceType, Country fallbackCountry, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Country fallbackCountry, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, Country fallbackCountry)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, Country fallbackCountry, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, ServiceType serviceType, Country fallbackCountry)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, Country fallbackCountry, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, UserSessionType userSessionType, Country fallbackCountry)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Country fallbackCountry, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, ServiceType serviceType, Country fallbackCountry)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Country fallbackCountry, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, UserSessionType userSessionType, Country fallbackCountry)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(ServiceType serviceType, Country fallbackCountry, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Country fallbackCountry, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(UserSessionType userSessionType, Country fallbackCountry, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(ServiceType serviceType, Country fallbackCountry, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(UserSessionType userSessionType, Country fallbackCountry, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, ServiceType serviceType, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, UserSessionType userSessionType, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, ServiceType serviceType, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, UserSessionType userSessionType, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(ServiceType serviceType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(UserSessionType userSessionType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(ServiceType serviceType, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(ServiceType serviceType, UserSessionType userSessionType, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(UserSessionType userSessionType, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, ServiceType serviceType)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, UserSessionType userSessionType)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, ServiceType serviceType, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, UserSessionType userSessionType, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, ServiceType serviceType, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, ServiceType serviceType, UserSessionType userSessionType)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, UserSessionType userSessionType, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, ServiceType serviceType, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, UserSessionType userSessionType, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, ServiceType serviceType, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, ServiceType serviceType, UserSessionType userSessionType)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, UserSessionType userSessionType, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(ServiceType serviceType, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(ServiceType serviceType, UserSessionType userSessionType, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(UserSessionType userSessionType, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(ServiceType serviceType, UserSessionType userSessionType, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, Country fallbackCountry, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Country fallbackCountry, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, ServiceType serviceType, Country fallbackCountry, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Country fallbackCountry, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, Country fallbackCountry)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, Country fallbackCountry, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, ServiceType serviceType, Country fallbackCountry)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, Country fallbackCountry, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, UserSessionType userSessionType, Country fallbackCountry)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Country fallbackCountry, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, ServiceType serviceType, Country fallbackCountry)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Country fallbackCountry, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, UserSessionType userSessionType, Country fallbackCountry)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, ServiceType serviceType, Country fallbackCountry, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Country fallbackCountry, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, UserSessionType userSessionType, Country fallbackCountry, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, ServiceType serviceType, Country fallbackCountry, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, UserSessionType userSessionType, Country fallbackCountry, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, ServiceType serviceType, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, UserSessionType userSessionType, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, ServiceType serviceType, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, UserSessionType userSessionType, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, ServiceType serviceType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, UserSessionType userSessionType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, ServiceType serviceType, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, ServiceType serviceType, UserSessionType userSessionType, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, UserSessionType userSessionType, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, ServiceType serviceType)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, UserSessionType userSessionType)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, ServiceType serviceType, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, UserSessionType userSessionType, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, ServiceType serviceType, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, UserSessionType userSessionType, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, ServiceType serviceType, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, UserSessionType userSessionType, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, ServiceType serviceType, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, ServiceType serviceType, UserSessionType userSessionType)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, UserSessionType userSessionType, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, ServiceType serviceType, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, ServiceType serviceType, UserSessionType userSessionType, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, UserSessionType userSessionType, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, ServiceType serviceType, UserSessionType userSessionType, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, Country fallbackCountry, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, ServiceType serviceType, Country fallbackCountry, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, Country fallbackCountry, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, ServiceType serviceType, Country fallbackCountry, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Country fallbackCountry, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(ServiceType serviceType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(ServiceType serviceType, Country fallbackCountry, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, Country fallbackCountry, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, ServiceType serviceType, Country fallbackCountry)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, Country fallbackCountry, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, UserSessionType userSessionType, Country fallbackCountry)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, ServiceType serviceType, Country fallbackCountry, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, Country fallbackCountry, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, UserSessionType userSessionType, Country fallbackCountry, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, ServiceType serviceType, Country fallbackCountry, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, UserSessionType userSessionType, Country fallbackCountry, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, ServiceType serviceType, Country fallbackCountry, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Country fallbackCountry, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, UserSessionType userSessionType, Country fallbackCountry, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, ServiceType serviceType, Country fallbackCountry, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, UserSessionType userSessionType, Country fallbackCountry, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(ServiceType serviceType, Country fallbackCountry, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(UserSessionType userSessionType, Country fallbackCountry, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, ServiceType serviceType, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, UserSessionType userSessionType, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, ServiceType serviceType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, UserSessionType userSessionType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, ServiceType serviceType, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, UserSessionType userSessionType, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, ServiceType serviceType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, UserSessionType userSessionType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, ServiceType serviceType, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, ServiceType serviceType, UserSessionType userSessionType, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, UserSessionType userSessionType, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(ServiceType serviceType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(ServiceType serviceType, UserSessionType userSessionType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(UserSessionType userSessionType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(ServiceType serviceType, UserSessionType userSessionType, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, ServiceType serviceType, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, UserSessionType userSessionType, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, ServiceType serviceType, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, UserSessionType userSessionType, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, ServiceType serviceType, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, UserSessionType userSessionType, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, ServiceType serviceType, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, ServiceType serviceType, UserSessionType userSessionType, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, UserSessionType userSessionType, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, ServiceType serviceType, UserSessionType userSessionType, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(ServiceType serviceType, UserSessionType userSessionType, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, Country fallbackCountry, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, ServiceType serviceType, Country fallbackCountry, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, Country fallbackCountry, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, ServiceType serviceType, Country fallbackCountry, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Country fallbackCountry, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, ServiceType serviceType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, ServiceType serviceType, Country fallbackCountry, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, Country fallbackCountry, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, ServiceType serviceType, Country fallbackCountry)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, Country fallbackCountry, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, UserSessionType userSessionType, Country fallbackCountry)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, ServiceType serviceType, Country fallbackCountry, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, Country fallbackCountry, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, UserSessionType userSessionType, Country fallbackCountry, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, ServiceType serviceType, Country fallbackCountry, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, UserSessionType userSessionType, Country fallbackCountry, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, ServiceType serviceType, Country fallbackCountry, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Country fallbackCountry, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, UserSessionType userSessionType, Country fallbackCountry, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, ServiceType serviceType, Country fallbackCountry, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, UserSessionType userSessionType, Country fallbackCountry, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, ServiceType serviceType, Country fallbackCountry, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, UserSessionType userSessionType, Country fallbackCountry, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, ServiceType serviceType, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, UserSessionType userSessionType, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, ServiceType serviceType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, UserSessionType userSessionType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, ServiceType serviceType, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, UserSessionType userSessionType, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, ServiceType serviceType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, UserSessionType userSessionType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, ServiceType serviceType, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, ServiceType serviceType, UserSessionType userSessionType, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, UserSessionType userSessionType, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, ServiceType serviceType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, ServiceType serviceType, UserSessionType userSessionType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, UserSessionType userSessionType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, ServiceType serviceType, UserSessionType userSessionType, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, ServiceType serviceType, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, UserSessionType userSessionType, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, ServiceType serviceType, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, UserSessionType userSessionType, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, ServiceType serviceType, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, UserSessionType userSessionType, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, ServiceType serviceType, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, ServiceType serviceType, UserSessionType userSessionType, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, UserSessionType userSessionType, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, ServiceType serviceType, UserSessionType userSessionType, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, ServiceType serviceType, UserSessionType userSessionType, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, ServiceType serviceType, Country fallbackCountry, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, Country fallbackCountry, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, ServiceType serviceType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, ServiceType serviceType, Country fallbackCountry, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, ServiceType serviceType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, ServiceType serviceType, Country fallbackCountry, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(ServiceType serviceType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, ServiceType serviceType, Country fallbackCountry, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, Country fallbackCountry, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, UserSessionType userSessionType, Country fallbackCountry, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, ServiceType serviceType, Country fallbackCountry, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, UserSessionType userSessionType, Country fallbackCountry, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, ServiceType serviceType, Country fallbackCountry, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, UserSessionType userSessionType, Country fallbackCountry, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, ServiceType serviceType, Country fallbackCountry, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, UserSessionType userSessionType, Country fallbackCountry, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, ServiceType serviceType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, UserSessionType userSessionType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, ServiceType serviceType, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, UserSessionType userSessionType, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, ServiceType serviceType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, UserSessionType userSessionType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, ServiceType serviceType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, ServiceType serviceType, UserSessionType userSessionType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, UserSessionType userSessionType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, ServiceType serviceType, UserSessionType userSessionType, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(ServiceType serviceType, UserSessionType userSessionType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, ServiceType serviceType, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, UserSessionType userSessionType, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, ServiceType serviceType, UserSessionType userSessionType, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, ServiceType serviceType, Country fallbackCountry, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, Country fallbackCountry, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, ServiceType serviceType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, ServiceType serviceType, Country fallbackCountry, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, ServiceType serviceType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, ServiceType serviceType, Country fallbackCountry, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, ServiceType serviceType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, ServiceType serviceType, Country fallbackCountry, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, Country fallbackCountry, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, UserSessionType userSessionType, Country fallbackCountry, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, ServiceType serviceType, Country fallbackCountry, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, UserSessionType userSessionType, Country fallbackCountry, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, ServiceType serviceType, Country fallbackCountry, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, UserSessionType userSessionType, Country fallbackCountry, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, ServiceType serviceType, Country fallbackCountry, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, UserSessionType userSessionType, Country fallbackCountry, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, ServiceType serviceType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, UserSessionType userSessionType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, ServiceType serviceType, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, UserSessionType userSessionType, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, ServiceType serviceType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, UserSessionType userSessionType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, ServiceType serviceType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, ServiceType serviceType, UserSessionType userSessionType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, UserSessionType userSessionType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, ServiceType serviceType, UserSessionType userSessionType, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, ServiceType serviceType, UserSessionType userSessionType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, ServiceType serviceType, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, UserSessionType userSessionType, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, ServiceType serviceType, UserSessionType userSessionType, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, ServiceType serviceType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, ServiceType serviceType, Country fallbackCountry, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, ServiceType serviceType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, ServiceType serviceType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, ServiceType serviceType, Country fallbackCountry, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, UserSessionType userSessionType, Country fallbackCountry, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, ServiceType serviceType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, UserSessionType userSessionType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, ServiceType serviceType, UserSessionType userSessionType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, ServiceType serviceType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, ServiceType serviceType, Country fallbackCountry, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, ServiceType serviceType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, ServiceType serviceType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, ServiceType serviceType, Country fallbackCountry, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, UserSessionType userSessionType, Country fallbackCountry, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, ServiceType serviceType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, UserSessionType userSessionType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, ServiceType serviceType, UserSessionType userSessionType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, ServiceType serviceType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, ServiceType serviceType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Product product, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Service CreateInstance(Application application, Product product, Merchant merchant, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, ServiceConfiguration serviceConfiguration, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Service(this.ServiceID,this.ServiceGuid,application ?? new Application(this.ApplicationID), product ?? new Product(this.ProductID), merchant ?? new Merchant(this.MerchantID), (ServiceStatus)this.ServiceStatusID,serviceType ?? new ServiceType(this.ServiceTypeID), userSessionType ?? new UserSessionType(this.UserSessionTypeID), fallbackCountry ?? new Country(this.FallbackCountryID), fallbackLanguage ?? new Language(this.FallbackLanguageID), serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), template ?? new Template(this.TemplateID), this.Name,this.Description,this.Updated,this.Created); 
		}
		

  }
}

