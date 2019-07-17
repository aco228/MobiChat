using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface IServiceManager : IDataManager<Service> 
  {
	

  }

  public partial class Service : MobiChatObject<IServiceManager> 
  {
		private Guid _guid;
		private Application _application;
		private Product _product;
		private Merchant _merchant;
		private ServiceStatus _serviceStatus;
		private ServiceType _serviceType;
		private UserSessionType _userSessionType;
		private Country _fallbackCountry;
		private Language _fallbackLanguage;
		private ServiceConfigurationEntry _serviceConfiguration;
		private Template _template;
		private string _name = String.Empty;
		private string _description = String.Empty;
		

		public Guid Guid { get { return this._guid; } set { _guid = value; } }
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

		public Product Product 
		{
			get
			{
				if (this._product != null &&
						this._product.IsEmpty)
					if (this.ConnectionContext != null)
						this._product = Product.CreateManager().LazyLoad(this.ConnectionContext, this._product.ID) as Product;
					else
						this._product = Product.CreateManager().LazyLoad(this._product.ID) as Product;
				return this._product;
			}
			set { _product = value; }
		}

		public Merchant Merchant 
		{
			get
			{
				if (this._merchant != null &&
						this._merchant.IsEmpty)
					if (this.ConnectionContext != null)
						this._merchant = Merchant.CreateManager().LazyLoad(this.ConnectionContext, this._merchant.ID) as Merchant;
					else
						this._merchant = Merchant.CreateManager().LazyLoad(this._merchant.ID) as Merchant;
				return this._merchant;
			}
			set { _merchant = value; }
		}

		public ServiceStatus ServiceStatus  { get { return this._serviceStatus; } set { this._serviceStatus = value; } }
		public ServiceType ServiceType 
		{
			get
			{
				if (this._serviceType != null &&
						this._serviceType.IsEmpty)
					if (this.ConnectionContext != null)
						this._serviceType = ServiceType.CreateManager().LazyLoad(this.ConnectionContext, this._serviceType.ID) as ServiceType;
					else
						this._serviceType = ServiceType.CreateManager().LazyLoad(this._serviceType.ID) as ServiceType;
				return this._serviceType;
			}
			set { _serviceType = value; }
		}

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

		public Country FallbackCountry 
		{
			get
			{
				if (this._fallbackCountry != null &&
						this._fallbackCountry.IsEmpty)
					if (this.ConnectionContext != null)
						this._fallbackCountry = Country.CreateManager().LazyLoad(this.ConnectionContext, this._fallbackCountry.ID) as Country;
					else
						this._fallbackCountry = Country.CreateManager().LazyLoad(this._fallbackCountry.ID) as Country;
				return this._fallbackCountry;
			}
			set { _fallbackCountry = value; }
		}

		public Language FallbackLanguage 
		{
			get
			{
				if (this._fallbackLanguage != null &&
						this._fallbackLanguage.IsEmpty)
					if (this.ConnectionContext != null)
						this._fallbackLanguage = Language.CreateManager().LazyLoad(this.ConnectionContext, this._fallbackLanguage.ID) as Language;
					else
						this._fallbackLanguage = Language.CreateManager().LazyLoad(this._fallbackLanguage.ID) as Language;
				return this._fallbackLanguage;
			}
			set { _fallbackLanguage = value; }
		}

		public ServiceConfigurationEntry ServiceConfiguration 
		{
			get
			{
				if (this._serviceConfiguration != null &&
						this._serviceConfiguration.IsEmpty)
					if (this.ConnectionContext != null)
						this._serviceConfiguration = ServiceConfigurationEntry.CreateManager().LazyLoad(this.ConnectionContext, this._serviceConfiguration.ID) as ServiceConfigurationEntry;
					else
						this._serviceConfiguration = ServiceConfigurationEntry.CreateManager().LazyLoad(this._serviceConfiguration.ID) as ServiceConfigurationEntry;
				return this._serviceConfiguration;
			}
			set { _serviceConfiguration = value; }
		}

		public Template Template 
		{
			get
			{
				if (this._template != null &&
						this._template.IsEmpty)
					if (this.ConnectionContext != null)
						this._template = Template.CreateManager().LazyLoad(this.ConnectionContext, this._template.ID) as Template;
					else
						this._template = Template.CreateManager().LazyLoad(this._template.ID) as Template;
				return this._template;
			}
			set { _template = value; }
		}

		public string Name{ get {return this._name; } set { this._name = value;} }
		public string Description{ get {return this._description; } set { this._description = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public Service()
    { 
    }

    public Service(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public Service(int id,  Guid guid, Application application, Product product, Merchant merchant, ServiceStatus serviceStatus, ServiceType serviceType, UserSessionType userSessionType, Country fallbackCountry, Language fallbackLanguage, ServiceConfigurationEntry serviceConfiguration, Template template, string name, string description, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._guid = guid;
			this._application = application;
			this._product = product;
			this._merchant = merchant;
			this._serviceStatus = serviceStatus;
			this._serviceType = serviceType;
			this._userSessionType = userSessionType;
			this._fallbackCountry = fallbackCountry;
			this._fallbackLanguage = fallbackLanguage;
			this._serviceConfiguration = serviceConfiguration;
			this._template = template;
			this._name = name;
			this._description = description;
			
    }

    public override object Clone(bool deepClone)
    {
      return new Service(-1, this.Guid, this.Application, this.Product, this.Merchant, this.ServiceStatus, this.ServiceType, this.UserSessionType, this.FallbackCountry, this.FallbackLanguage, this.ServiceConfiguration, this.Template,this.Name,this.Description, DateTime.Now, DateTime.Now);
    }
  }
}

