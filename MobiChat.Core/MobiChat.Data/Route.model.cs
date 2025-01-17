using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface IRouteManager : IDataManager<Route> 
  {
	

  }

  public partial class Route : MobiChatObject<IRouteManager> 
  {
		private RouteSet _routeSet;
		private string _name = String.Empty;
		private string _action = String.Empty;
		private string _controller = String.Empty;
		private string _pattern = String.Empty;
		private bool? _isIgnore = false;
		private bool? _isEnabled = false;
		private int _index = -1;
		private bool _isSessionRoute = false;
		

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

		public string Name{ get {return this._name; } set { this._name = value;} }
		public string Action{ get {return this._action; } set { this._action = value;} }
		public string Controller{ get {return this._controller; } set { this._controller = value;} }
		public string Pattern{ get {return this._pattern; } set { this._pattern = value;} }
		public bool? IsIgnore {get {return this._isIgnore; } set { this._isIgnore = value;} }
		public bool? IsEnabled {get {return this._isEnabled; } set { this._isEnabled = value;} }
		public int Index{ get {return this._index; } set { this._index = value;} }
		public bool IsSessionRoute {get {return this._isSessionRoute; } set { this._isSessionRoute = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public Route()
    { 
    }

    public Route(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public Route(int id,  RouteSet routeSet, string name, string action, string controller, string pattern, bool? isIgnore, bool? isEnabled, int index, bool isSessionRoute, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._routeSet = routeSet;
			this._name = name;
			this._action = action;
			this._controller = controller;
			this._pattern = pattern;
			this._isIgnore = isIgnore;
			this._isEnabled = isEnabled;
			this._index = index;
			this._isSessionRoute = isSessionRoute;
			
    }

    public override object Clone(bool deepClone)
    {
      return new Route(-1,  this.RouteSet,this.Name,this.Action,this.Controller,this.Pattern,this.IsIgnore,this.IsEnabled,this.Index,this.IsSessionRoute, DateTime.Now, DateTime.Now);
    }
  }
}

