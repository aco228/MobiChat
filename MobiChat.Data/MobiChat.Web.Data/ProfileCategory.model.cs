using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

using MobiChat.Web.Data; 

namespace MobiChat.Web.Data 
{
  public partial interface IProfileCategoryManager : IDataManager<ProfileCategory> 
  {
	

  }

  public partial class ProfileCategory : MobiChatObject<IProfileCategoryManager> 
  {
		private string _name = String.Empty;
		private string _viewName = String.Empty;
		private string _description = String.Empty;
		

		public string Name{ get {return this._name; } set { this._name = value;} }
		public string ViewName{ get {return this._viewName; } set { this._viewName = value;} }
		public string Description{ get {return this._description; } set { this._description = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public ProfileCategory()
    { 
    }

    public ProfileCategory(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public ProfileCategory(int id,  string name, string viewName, string description, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._name = name;
			this._viewName = viewName;
			this._description = description;
			
    }

    public override object Clone(bool deepClone)
    {
      return new ProfileCategory(-1, this.Name,this.ViewName,this.Description, DateTime.Now, DateTime.Now);
    }
  }
}

