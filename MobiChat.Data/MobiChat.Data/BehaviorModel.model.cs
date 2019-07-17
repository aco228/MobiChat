using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface IBehaviorModelManager : IDataManager<BehaviorModel> 
  {
	

  }

  public partial class BehaviorModel : MobiChatObject<IBehaviorModelManager> 
  {
		private Guid _behaviorGuid;
		private string _name = String.Empty;
		private string _description = String.Empty;
		

		public Guid BehaviorGuid { get { return this._behaviorGuid; } set { this._behaviorGuid = value;}}
		public string Name{ get {return this._name; } set { this._name = value;} }
		public string Description{ get {return this._description; } set { this._description = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public BehaviorModel()
    { 
    }

    public BehaviorModel(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public BehaviorModel(int id,  Guid behaviorGuid, string name, string description, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._behaviorGuid = behaviorGuid;
			this._name = name;
			this._description = description;
			
    }

    public override object Clone(bool deepClone)
    {
      return new BehaviorModel(-1, this.BehaviorGuid,this.Name,this.Description, DateTime.Now, DateTime.Now);
    }
  }
}

