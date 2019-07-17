using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface IReportManager : IDataManager<Report> 
  {
	

  }

  public partial class Report : MobiChatObject<IReportManager> 
  {
		private ReportLink _reportLink;
		private int? _pxid = -1;
		private string _additionalData = String.Empty;
		

		public ReportLink ReportLink 
		{
			get
			{
				if (this._reportLink != null &&
						this._reportLink.IsEmpty)
					if (this.ConnectionContext != null)
						this._reportLink = ReportLink.CreateManager().LazyLoad(this.ConnectionContext, this._reportLink.ID) as ReportLink;
					else
						this._reportLink = ReportLink.CreateManager().LazyLoad(this._reportLink.ID) as ReportLink;
				return this._reportLink;
			}
			set { _reportLink = value; }
		}

		public int? Pxid{ get {return this._pxid; } set { this._pxid = value;} }
		public string AdditionalData{ get {return this._additionalData; } set { this._additionalData = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public Report()
    { 
    }

    public Report(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public Report(int id,  ReportLink reportLink, int? pxid, string additionalData, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._reportLink = reportLink;
			this._pxid = pxid;
			this._additionalData = additionalData;
			
    }

    public override object Clone(bool deepClone)
    {
      return new Report(-1,  this.ReportLink,this.Pxid,this.AdditionalData, DateTime.Now, DateTime.Now);
    }
  }
}

