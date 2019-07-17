using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface IGenderManager : IDataManager<Gender> 
  {
	

  }

  public partial class Gender : MobiChatObject<IGenderManager> 
  {
		private string _name = String.Empty;
		private string _description = String.Empty;
		

		public string Name{ get {return this._name; } set { this._name = value;} }
		public string Description{ get {return this._description; } set { this._description = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public Gender()
    { 
    }

    public Gender(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public Gender(int id,  string name, string description, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._name = name;
			this._description = description;
			
    }

    public override object Clone(bool deepClone)
    {
      return new Gender(-1, this.Name,this.Description, DateTime.Now, DateTime.Now);
    }
  }
}

