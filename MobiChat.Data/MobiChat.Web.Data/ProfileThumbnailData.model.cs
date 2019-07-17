using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

using MobiChat.Web.Data; 

namespace MobiChat.Web.Data 
{
  public partial interface IProfileThumbnailDataManager : IDataManager<ProfileThumbnailData> 
  {
	

  }

  public partial class ProfileThumbnailData : MobiChatObject<IProfileThumbnailDataManager> 
  {
		private ProfileThumbnail _profileThumbnail;
		private byte[] _data = null;
		private bool _isOriginal = false;
		

		public ProfileThumbnail ProfileThumbnail 
		{
			get
			{
				if (this._profileThumbnail != null &&
						this._profileThumbnail.IsEmpty)
					if (this.ConnectionContext != null)
						this._profileThumbnail = ProfileThumbnail.CreateManager().LazyLoad(this.ConnectionContext, this._profileThumbnail.ID) as ProfileThumbnail;
					else
						this._profileThumbnail = ProfileThumbnail.CreateManager().LazyLoad(this._profileThumbnail.ID) as ProfileThumbnail;
				return this._profileThumbnail;
			}
			set { _profileThumbnail = value; }
		}

		public byte[] Data { get { return this._data; } set { this._data = value;}  }
		public bool IsOriginal {get {return this._isOriginal; } set { this._isOriginal = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public ProfileThumbnailData()
    { 
    }

    public ProfileThumbnailData(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public ProfileThumbnailData(int id,  ProfileThumbnail profileThumbnail, byte[] data, bool isOriginal, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._profileThumbnail = profileThumbnail;
			this._data = data;
			this._isOriginal = isOriginal;
			
    }

    public override object Clone(bool deepClone)
    {
      return new ProfileThumbnailData(-1,  this.ProfileThumbnail,this.Data,this.IsOriginal, DateTime.Now, DateTime.Now);
    }
  }
}

