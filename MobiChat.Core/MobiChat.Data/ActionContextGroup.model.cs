using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface IActionContextGroupManager : IDataManager<ActionContextGroup> 
  {
	

  }

  public partial class ActionContextGroup : MobiChatObject<IActionContextGroupManager> 
  {
		private string _name = String.Empty;
		

		public string Name{ get {return this._name; } set { this._name = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public ActionContextGroup()
    { 
    }

    public ActionContextGroup(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public ActionContextGroup(int id,  string name, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._name = name;
			
    }

    public override object Clone(bool deepClone)
    {
      return new ActionContextGroup(-1, this.Name, DateTime.Now, DateTime.Now);
    }
  }
}

