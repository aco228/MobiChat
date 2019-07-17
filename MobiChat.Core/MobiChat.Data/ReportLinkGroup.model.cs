using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface IReportLinkGroupManager : IDataManager<ReportLinkGroup> 
  {
	

  }

  public partial class ReportLinkGroup : MobiChatObject<IReportLinkGroupManager> 
  {
		private string _name = String.Empty;
		private string _description = String.Empty;
		

		public string Name{ get {return this._name; } set { this._name = value;} }
		public string Description{ get {return this._description; } set { this._description = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public ReportLinkGroup()
    { 
    }

    public ReportLinkGroup(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public ReportLinkGroup(int id,  string name, string description, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._name = name;
			this._description = description;
			
    }

    public override object Clone(bool deepClone)
    {
      return new ReportLinkGroup(-1, this.Name,this.Description, DateTime.Now, DateTime.Now);
    }
  }
}

