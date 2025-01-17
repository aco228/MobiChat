using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface IApplicationRouteSetMapManager : IDataManager<ApplicationRouteSetMap> 
  {
	

  }

  public partial class ApplicationRouteSetMap : MobiChatObject<IApplicationRouteSetMapManager> 
  {
		private Application _application;
		private Service _service;
		private RouteSet _routeSet;
		

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

		public RouteSet RouteSet 
		{
			get
			{
				if (this._routeSet != null &&
						this._routeSet.IsEmpty)
					if (this.ConnectionContext != null)
						this._routeSet = RouteSet.CreateManager().LazyLoad(this.ConnectionContext, this._routeSet.ID) as RouteSet;
					else
						this._routeSet = RouteSet.CreateManager().LazyLoad(this._routeSet.ID) as RouteSet;
				return this._routeSet;
			}
			set { _routeSet = value; }
		}

		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public ApplicationRouteSetMap()
    { 
    }

    public ApplicationRouteSetMap(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public ApplicationRouteSetMap(int id,  Application application, Service service, RouteSet routeSet, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._application = application;
			this._service = service;
			this._routeSet = routeSet;
			
    }

    public override object Clone(bool deepClone)
    {
      return new ApplicationRouteSetMap(-1,  this.Application, this.Service, this.RouteSet, DateTime.Now, DateTime.Now);
    }
  }
}

