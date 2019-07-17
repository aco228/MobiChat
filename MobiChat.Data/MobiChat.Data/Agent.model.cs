using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface IAgentManager : IDataManager<Agent> 
  {
	

  }

  public partial class Agent : MobiChatObject<IAgentManager> 
  {
		private User _user;
		

		public User User 
		{
			get
			{
				if (this._user != null &&
						this._user.IsEmpty)
					if (this.ConnectionContext != null)
						this._user = User.CreateManager().LazyLoad(this.ConnectionContext, this._user.ID) as User;
					else
						this._user = User.CreateManager().LazyLoad(this._user.ID) as User;
				return this._user;
			}
			set { _user = value; }
		}

		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public Agent()
    { 
    }

    public Agent(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public Agent(int id,  User user, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._user = user;
			
    }

    public override object Clone(bool deepClone)
    {
      return new Agent(-1,  this.User, DateTime.Now, DateTime.Now);
    }
  }
}

