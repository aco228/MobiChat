using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

using MobiChat.Web.Data; 

namespace MobiChat.Web.Data 
{
  public partial interface IProfileThumbnailManager : IDataManager<ProfileThumbnail> 
  {
	

  }

  public partial class ProfileThumbnail : MobiChatObject<IProfileThumbnailManager> 
  {
		private Profile _profile;
		private bool? _isDefault = false;
		

		public Profile Profile 
		{
			get
			{
				if (this._profile != null &&
						this._profile.IsEmpty)
					if (this.ConnectionContext != null)
						this._profile = Profile.CreateManager().LazyLoad(this.ConnectionContext, this._profile.ID) as Profile;
					else
						this._profile = Profile.CreateManager().LazyLoad(this._profile.ID) as Profile;
				return this._profile;
			}
			set { _profile = value; }
		}

		public bool? IsDefault {get {return this._isDefault; } set { this._isDefault = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public ProfileThumbnail()
    { 
    }

    public ProfileThumbnail(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public ProfileThumbnail(int id,  Profile profile, bool? isDefault, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._profile = profile;
			this._isDefault = isDefault;
			
    }

    public override object Clone(bool deepClone)
    {
      return new ProfileThumbnail(-1,  this.Profile,this.IsDefault, DateTime.Now, DateTime.Now);
    }
  }
}

