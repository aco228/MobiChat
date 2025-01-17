using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface IRouteParameterManager : IDataManager<RouteParameter> 
  {
	

  }

  public partial class RouteParameter : MobiChatObject<IRouteParameterManager> 
  {
		private Route _route;
		private string _key = String.Empty;
		private string _value = String.Empty;
		private string _constraint = String.Empty;
		private bool _isOptional = false;
		

		public Route Route 
		{
			get
			{
				if (this._route != null &&
						this._route.IsEmpty)
					if (this.ConnectionContext != null)
						this._route = Route.CreateManager().LazyLoad(this.ConnectionContext, this._route.ID) as Route;
					else
						this._route = Route.CreateManager().LazyLoad(this._route.ID) as Route;
				return this._route;
			}
			set { _route = value; }
		}

		public string Key{ get {return this._key; } set { this._key = value;} }
		public string Value{ get {return this._value; } set { this._value = value;} }
		public string Constraint{ get {return this._constraint; } set { this._constraint = value;} }
		public bool IsOptional {get {return this._isOptional; } set { this._isOptional = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public RouteParameter()
    { 
    }

    public RouteParameter(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public RouteParameter(int id,  Route route, string key, string value, string constraint, bool isOptional, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._route = route;
			this._key = key;
			this._value = value;
			this._constraint = constraint;
			this._isOptional = isOptional;
			
    }

    public override object Clone(bool deepClone)
    {
      return new RouteParameter(-1,  this.Route,this.Key,this.Value,this.Constraint,this.IsOptional, DateTime.Now, DateTime.Now);
    }
  }
}

