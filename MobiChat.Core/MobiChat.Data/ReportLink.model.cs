using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface IReportLinkManager : IDataManager<ReportLink> 
  {
	

  }

  public partial class ReportLink : MobiChatObject<IReportLinkManager> 
  {
		private ReportLinkGroup _reportLinkGroup;
		private string _url = String.Empty;
		private bool _isActive = false;
		

		public ReportLinkGroup ReportLinkGroup 
		{
			get
			{
				if (this._reportLinkGroup != null &&
						this._reportLinkGroup.IsEmpty)
					if (this.ConnectionContext != null)
						this._reportLinkGroup = ReportLinkGroup.CreateManager().LazyLoad(this.ConnectionContext, this._reportLinkGroup.ID) as ReportLinkGroup;
					else
						this._reportLinkGroup = ReportLinkGroup.CreateManager().LazyLoad(this._reportLinkGroup.ID) as ReportLinkGroup;
				return this._reportLinkGroup;
			}
			set { _reportLinkGroup = value; }
		}

		public string Url{ get {return this._url; } set { this._url = value;} }
		public bool IsActive {get {return this._isActive; } set { this._isActive = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public ReportLink()
    { 
    }

    public ReportLink(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public ReportLink(int id,  ReportLinkGroup reportLinkGroup, string url, bool isActive, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._reportLinkGroup = reportLinkGroup;
			this._url = url;
			this._isActive = isActive;
			
    }

    public override object Clone(bool deepClone)
    {
      return new ReportLink(-1,  this.ReportLinkGroup,this.Url,this.IsActive, DateTime.Now, DateTime.Now);
    }
  }
}

