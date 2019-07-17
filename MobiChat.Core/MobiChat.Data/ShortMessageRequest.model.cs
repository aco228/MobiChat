using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface IShortMessageRequestManager : IDataManager<ShortMessageRequest> 
  {
	

  }

  public partial class ShortMessageRequest : MobiChatObject<IShortMessageRequestManager> 
  {
		private Guid _guid;
		private ShortMessage _shortMessage;
		private User _user;
		

		public Guid Guid { get { return this._guid; } set { _guid = value; } }
		public ShortMessage ShortMessage 
		{
			get
			{
				if (this._shortMessage != null &&
						this._shortMessage.IsEmpty)
					if (this.ConnectionContext != null)
						this._shortMessage = ShortMessage.CreateManager().LazyLoad(this.ConnectionContext, this._shortMessage.ID) as ShortMessage;
					else
						this._shortMessage = ShortMessage.CreateManager().LazyLoad(this._shortMessage.ID) as ShortMessage;
				return this._shortMessage;
			}
			set { _shortMessage = value; }
		}

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

    public ShortMessageRequest()
    { 
    }

    public ShortMessageRequest(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public ShortMessageRequest(int id,  Guid guid, ShortMessage shortMessage, User user, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._guid = guid;
			this._shortMessage = shortMessage;
			this._user = user;
			
    }

    public override object Clone(bool deepClone)
    {
      return new ShortMessageRequest(-1, this.Guid, this.ShortMessage, this.User, DateTime.Now, DateTime.Now);
    }
  }
}

