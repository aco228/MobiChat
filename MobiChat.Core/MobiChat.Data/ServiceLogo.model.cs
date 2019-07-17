using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface IServiceLogoManager : IDataManager<ServiceLogo> 
  {
	

  }

  public partial class ServiceLogo : MobiChatObject<IServiceLogoManager> 
  {
		private Service _service;
		private byte[] _data = null;
		

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

		public byte[] Data { get { return this._data; } set { this._data = value;}  }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public ServiceLogo()
    { 
    }

    public ServiceLogo(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public ServiceLogo(int id,  Service service, byte[] data, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._service = service;
			this._data = data;
			
    }

    public override object Clone(bool deepClone)
    {
      return new ServiceLogo(-1,  this.Service,this.Data, DateTime.Now, DateTime.Now);
    }
  }
}

