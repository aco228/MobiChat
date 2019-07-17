using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface IUserStatusHistoryManager : IDataManager<UserStatusHistory> 
  {
	

  }

  public partial class UserStatusHistory : MobiChatObject<IUserStatusHistoryManager> 
  {
		private User _user;
		private UserStatus _userStatus;
		private string _note = String.Empty;
		

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

		public UserStatus UserStatus  { get { return this._userStatus; } set { this._userStatus = value; } }
		public string Note{ get {return this._note; } set { this._note = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public UserStatusHistory()
    { 
    }

    public UserStatusHistory(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public UserStatusHistory(int id,  User user, UserStatus userStatus, string note, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._user = user;
			this._userStatus = userStatus;
			this._note = note;
			
    }

    public override object Clone(bool deepClone)
    {
      return new UserStatusHistory(-1,  this.User, this.UserStatus,this.Note, DateTime.Now, DateTime.Now);
    }
  }
}

