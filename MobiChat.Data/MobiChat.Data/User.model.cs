using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface IUserManager : IDataManager<User> 
  {
	

  }

  public partial class User : MobiChatObject<IUserManager> 
  {
		private Guid _guid;
		private UserType _userType;
		private UserStatus _userStatus;
		private string _username = String.Empty;
		private byte[] _password = null;
		

		public Guid Guid { get { return this._guid; } set { _guid = value; } }
		public UserType UserType 
		{
			get
			{
				if (this._userType != null &&
						this._userType.IsEmpty)
					if (this.ConnectionContext != null)
						this._userType = UserType.CreateManager().LazyLoad(this.ConnectionContext, this._userType.ID) as UserType;
					else
						this._userType = UserType.CreateManager().LazyLoad(this._userType.ID) as UserType;
				return this._userType;
			}
			set { _userType = value; }
		}

		public UserStatus UserStatus  { get { return this._userStatus; } set { this._userStatus = value; } }
		public string Username{ get {return this._username; } set { this._username = value;} }
		public byte[] Password { get { return this._password; } set { this._password = value;}  }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public User()
    { 
    }

    public User(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public User(int id,  Guid guid, UserType userType, UserStatus userStatus, string username, byte[] password, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._guid = guid;
			this._userType = userType;
			this._userStatus = userStatus;
			this._username = username;
			this._password = password;
			
    }

    public override object Clone(bool deepClone)
    {
      return new User(-1, this.Guid, this.UserType, this.UserStatus,this.Username,this.Password, DateTime.Now, DateTime.Now);
    }
  }
}

