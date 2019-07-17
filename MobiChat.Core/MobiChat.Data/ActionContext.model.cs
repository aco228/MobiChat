using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface IActionContextManager : IDataManager<ActionContext> 
  {
	

  }

  public partial class ActionContext : MobiChatObject<IActionContextManager> 
  {
		private ActionContextGroup _actionContextGroup;
		

		public ActionContextGroup ActionContextGroup 
		{
			get
			{
				if (this._actionContextGroup != null &&
						this._actionContextGroup.IsEmpty)
					if (this.ConnectionContext != null)
						this._actionContextGroup = ActionContextGroup.CreateManager().LazyLoad(this.ConnectionContext, this._actionContextGroup.ID) as ActionContextGroup;
					else
						this._actionContextGroup = ActionContextGroup.CreateManager().LazyLoad(this._actionContextGroup.ID) as ActionContextGroup;
				return this._actionContextGroup;
			}
			set { _actionContextGroup = value; }
		}

		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public ActionContext()
    { 
    }

    public ActionContext(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public ActionContext(int id,  ActionContextGroup actionContextGroup, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._actionContextGroup = actionContextGroup;
			
    }

    public override object Clone(bool deepClone)
    {
      return new ActionContext(-1,  this.ActionContextGroup, DateTime.Now, DateTime.Now);
    }
  }
}

