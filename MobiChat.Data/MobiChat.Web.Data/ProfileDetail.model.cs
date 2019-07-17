using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

using MobiChat.Web.Data; 

namespace MobiChat.Web.Data 
{
  public partial interface IProfileDetailManager : IDataManager<ProfileDetail> 
  {
	

  }

  public partial class ProfileDetail : MobiChatObject<IProfileDetailManager> 
  {
		private Profile _profile;
		private Language _language;
		private string _name = String.Empty;
		private string _keyword = String.Empty;
		

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

		public Language Language 
		{
			get
			{
				if (this._language != null &&
						this._language.IsEmpty)
					if (this.ConnectionContext != null)
						this._language = Language.CreateManager().LazyLoad(this.ConnectionContext, this._language.ID) as Language;
					else
						this._language = Language.CreateManager().LazyLoad(this._language.ID) as Language;
				return this._language;
			}
			set { _language = value; }
		}

		public string Name{ get {return this._name; } set { this._name = value;} }
		public string Keyword{ get {return this._keyword; } set { this._keyword = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public ProfileDetail()
    { 
    }

    public ProfileDetail(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public ProfileDetail(int id,  Profile profile, Language language, string name, string keyword, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._profile = profile;
			this._language = language;
			this._name = name;
			this._keyword = keyword;
			
    }

    public override object Clone(bool deepClone)
    {
      return new ProfileDetail(-1,  this.Profile, this.Language,this.Name,this.Keyword, DateTime.Now, DateTime.Now);
    }
  }
}

