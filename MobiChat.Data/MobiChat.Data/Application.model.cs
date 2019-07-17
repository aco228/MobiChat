using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface IApplicationManager : IDataManager<Application> 
  {
	

  }

  public partial class Application : MobiChatObject<IApplicationManager> 
  {
		private Instance _instance;
		private ApplicationType _applicationType;
		private RuntimeType _runtimeType;
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

		public ApplicationType ApplicationType 
		{
			get
			{
				if (this._applicationType != null &&
						this._applicationType.IsEmpty)
					if (this.ConnectionContext != null)
						this._applicationType = ApplicationType.CreateManager().LazyLoad(this.ConnectionContext, this._applicationType.ID) as ApplicationType;
					else
						this._applicationType = ApplicationType.CreateManager().LazyLoad(this._applicationType.ID) as ApplicationType;
				return this._applicationType;
			}
			set { _applicationType = value; }
		}

		public RuntimeType RuntimeType 
		{
			get
			{
				if (this._runtimeType != null &&
						this._runtimeType.IsEmpty)
					if (this.ConnectionContext != null)
						this._runtimeType = RuntimeType.CreateManager().LazyLoad(this.ConnectionContext, this._runtimeType.ID) as RuntimeType;
					else
						this._runtimeType = RuntimeType.CreateManager().LazyLoad(this._runtimeType.ID) as RuntimeType;
				return this._runtimeType;
			}
			set { _runtimeType = value; }
		}

		public string Name{ get {return this._name; } set { this._name = value;} }
		public string Description{ get {return this._description; } set { this._description = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public Application()
    { 
    }

    public Application(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public Application(int id,  Instance instance, ApplicationType applicationType, RuntimeType runtimeType, string name, string description, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._instance = instance;
			this._applicationType = applicationType;
			this._runtimeType = runtimeType;
			this._name = name;
			this._description = description;
			
    }

    public override object Clone(bool deepClone)
    {
      return new Application(-1,  this.Instance, this.ApplicationType, this.RuntimeType,this.Name,this.Description, DateTime.Now, DateTime.Now);
    }
  }
}

