using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

using MobiChat.Web.Data; 

namespace MobiChat.Web.Data 
{
  public partial interface IProfileGroupManager : IDataManager<ProfileGroup> 
  {
	

  }

  public partial class ProfileGroup : MobiChatObject<IProfileGroupManager> 
  {
		private ProfileCategory _profileCategory;
		private string _name = String.Empty;
		private string _description = String.Empty;
		

		public ProfileCategory ProfileCategory 
		{
			get
			{
				if (this._profileCategory != null &&
						this._profileCategory.IsEmpty)
					if (this.ConnectionContext != null)
						this._profileCategory = ProfileCategory.CreateManager().LazyLoad(this.ConnectionContext, this._profileCategory.ID) as ProfileCategory;
					else
						this._profileCategory = ProfileCategory.CreateManager().LazyLoad(this._profileCategory.ID) as ProfileCategory;
				return this._profileCategory;
			}
			set { _profileCategory = value; }
		}

		public string Name{ get {return this._name; } set { this._name = value;} }
		public string Description{ get {return this._description; } set { this._description = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public ProfileGroup()
    { 
    }

    public ProfileGroup(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public ProfileGroup(int id,  ProfileCategory profileCategory, string name, string description, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._profileCategory = profileCategory;
			this._name = name;
			this._description = description;
			
    }

    public override object Clone(bool deepClone)
    {
      return new ProfileGroup(-1,  this.ProfileCategory,this.Name,this.Description, DateTime.Now, DateTime.Now);
    }
  }
}

