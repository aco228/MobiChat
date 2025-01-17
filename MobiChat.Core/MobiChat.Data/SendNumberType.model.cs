using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface ISendNumberTypeManager : IDataManager<SendNumberType> 
  {
	

  }

  public partial class SendNumberType : MobiChatObject<ISendNumberTypeManager> 
  {
		private string _name = String.Empty;
		private string _typeName = String.Empty;
		private string _description = String.Empty;
		

		public string Name{ get {return this._name; } set { this._name = value;} }
		public string TypeName{ get {return this._typeName; } set { this._typeName = value;} }
		public string Description{ get {return this._description; } set { this._description = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public SendNumberType()
    { 
    }

    public SendNumberType(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public SendNumberType(int id,  string name, string typeName, string description, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._name = name;
			this._typeName = typeName;
			this._description = description;
			
    }

    public override object Clone(bool deepClone)
    {
      return new SendNumberType(-1, this.Name,this.TypeName,this.Description, DateTime.Now, DateTime.Now);
    }
  }
}

