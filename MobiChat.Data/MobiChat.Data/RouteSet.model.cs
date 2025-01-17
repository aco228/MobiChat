using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface IRouteSetManager : IDataManager<RouteSet> 
  {
	

  }

  public partial class RouteSet : MobiChatObject<IRouteSetManager> 
  {
		private Instance _instance;
		private string _name = String.Empty;
		

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

		public string Name{ get {return this._name; } set { this._name = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public RouteSet()
    { 
    }

    public RouteSet(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public RouteSet(int id,  Instance instance, string name, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._instance = instance;
			this._name = name;
			
    }

    public override object Clone(bool deepClone)
    {
      return new RouteSet(-1,  this.Instance,this.Name, DateTime.Now, DateTime.Now);
    }
  }
}

