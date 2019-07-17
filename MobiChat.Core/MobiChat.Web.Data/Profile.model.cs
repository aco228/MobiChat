using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

using MobiChat.Web.Data; 

namespace MobiChat.Web.Data 
{
  public partial interface IProfileManager : IDataManager<Profile> 
  {
	

  }

  public partial class Profile : MobiChatObject<IProfileManager> 
  {
		private ProfileGroup _profileGroup;
		

		public ProfileGroup ProfileGroup 
		{
			get
			{
				if (this._profileGroup != null &&
						this._profileGroup.IsEmpty)
					if (this.ConnectionContext != null)
						this._profileGroup = ProfileGroup.CreateManager().LazyLoad(this.ConnectionContext, this._profileGroup.ID) as ProfileGroup;
					else
						this._profileGroup = ProfileGroup.CreateManager().LazyLoad(this._profileGroup.ID) as ProfileGroup;
				return this._profileGroup;
			}
			set { _profileGroup = value; }
		}

		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public Profile()
    { 
    }

    public Profile(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public Profile(int id,  ProfileGroup profileGroup, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._profileGroup = profileGroup;
			
    }

    public override object Clone(bool deepClone)
    {
      return new Profile(-1,  this.ProfileGroup, DateTime.Now, DateTime.Now);
    }
  }
}

