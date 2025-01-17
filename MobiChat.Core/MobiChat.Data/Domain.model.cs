using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface IDomainManager : IDataManager<Domain> 
  {
	

  }

  public partial class Domain : MobiChatObject<IDomainManager> 
  {
		private Service _service;
		private string _domainName = String.Empty;
		

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

		public string DomainName{ get {return this._domainName; } set { this._domainName = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public Domain()
    { 
    }

    public Domain(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public Domain(int id,  Service service, string domainName, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._service = service;
			this._domainName = domainName;
			
    }

    public override object Clone(bool deepClone)
    {
      return new Domain(-1,  this.Service,this.DomainName, DateTime.Now, DateTime.Now);
    }
  }
}

