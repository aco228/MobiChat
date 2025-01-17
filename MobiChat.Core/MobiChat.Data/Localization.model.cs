using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface ILocalizationManager : IDataManager<Localization> 
  {
	

  }

  public partial class Localization : MobiChatObject<ILocalizationManager> 
  {
		private Application _application;
		private Product _product;
		private Translation _translation;
		

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

		public Translation Translation 
		{
			get
			{
				if (this._translation != null &&
						this._translation.IsEmpty)
					if (this.ConnectionContext != null)
						this._translation = Translation.CreateManager().LazyLoad(this.ConnectionContext, this._translation.ID) as Translation;
					else
						this._translation = Translation.CreateManager().LazyLoad(this._translation.ID) as Translation;
				return this._translation;
			}
			set { _translation = value; }
		}

		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public Localization()
    { 
    }

    public Localization(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public Localization(int id,  Application application, Product product, Translation translation, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._application = application;
			this._product = product;
			this._translation = translation;
			
    }

    public override object Clone(bool deepClone)
    {
      return new Localization(-1,  this.Application, this.Product, this.Translation, DateTime.Now, DateTime.Now);
    }
  }
}

