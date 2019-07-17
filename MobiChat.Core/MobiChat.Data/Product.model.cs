using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface IProductManager : IDataManager<Product> 
  {
	

  }

  public partial class Product : MobiChatObject<IProductManager> 
  {
		private Instance _instance;
		private Guid _guid;
		private Guid _externalProductGuid;
		private string _name = String.Empty;
		private string _description = String.Empty;
		

		public Instance Instance 
		{
			get
			{
				if (this._instance != null &&
						this._instance.IsEmpty)
					if (this.ConnectionContext != null)
						this._instance = Instance.CreateManager().LazyLoad(this.ConnectionContext, this._instance.ID) as Instance;
					else
						this._instance = Instance.CreateManager().LazyLoad(this._instance.ID) as Instance;
				return this._instance;
			}
			set { _instance = value; }
		}

		public Guid Guid { get { return this._guid; } set { _guid = value; } }
		public Guid ExternalProductGuid { get { return this._externalProductGuid; } set { this._externalProductGuid = value;}}
		public string Name{ get {return this._name; } set { this._name = value;} }
		public string Description{ get {return this._description; } set { this._description = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public Product()
    { 
    }

    public Product(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public Product(int id,  Instance instance, Guid guid, Guid externalProductGuid, string name, string description, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._instance = instance;
			this._guid = guid;
			this._externalProductGuid = externalProductGuid;
			this._name = name;
			this._description = description;
			
    }

    public override object Clone(bool deepClone)
    {
      return new Product(-1,  this.Instance,this.Guid,this.ExternalProductGuid,this.Name,this.Description, DateTime.Now, DateTime.Now);
    }
  }
}

