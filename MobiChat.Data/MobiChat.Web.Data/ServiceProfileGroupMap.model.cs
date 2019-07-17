using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

using MobiChat.Web.Data; 

namespace MobiChat.Web.Data 
{
  public partial interface IServiceProfileGroupMapManager : IDataManager<ServiceProfileGroupMap> 
  {
	

  }

  public partial class ServiceProfileGroupMap : MobiChatObject<IServiceProfileGroupMapManager> 
  {
		private int _serviceID = -1;
		private ProfileGroup _profileGroup;
		private bool _isActive = false;
		

		public int ServiceID{ get {return this._serviceID; } set { this._serviceID = value;} }
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

		public bool IsActive {get {return this._isActive; } set { this._isActive = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public ServiceProfileGroupMap()
    { 
    }

    public ServiceProfileGroupMap(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public ServiceProfileGroupMap(int id,  int serviceID, ProfileGroup profileGroup, bool isActive, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._serviceID = serviceID;
			this._profileGroup = profileGroup;
			this._isActive = isActive;
			
    }

    public override object Clone(bool deepClone)
    {
      return new ServiceProfileGroupMap(-1, this.ServiceID, this.ProfileGroup,this.IsActive, DateTime.Now, DateTime.Now);
    }
  }
}

