using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface IShortMessageManager : IDataManager<ShortMessage> 
  {
	

  }

  public partial class ShortMessage : MobiChatObject<IShortMessageManager> 
  {
		private Guid _guid;
		private ActionContext _actionContext;
		private Service _service;
		private MobileOperator _mobileOperator;
		private Customer _customer;
		private ShortMessageDirection _shortMessageDirection;
		private ShortMessageStatus _shortMessageStatus;
		private string _text = String.Empty;
		private int _shortcode = -1;
		private string _keyword = String.Empty;
		

		public Guid Guid { get { return this._guid; } set { _guid = value; } }
		public ActionContext ActionContext 
		{
			get
			{
				if (this._actionContext != null &&
						this._actionContext.IsEmpty)
					if (this.ConnectionContext != null)
						this._actionContext = ActionContext.CreateManager().LazyLoad(this.ConnectionContext, this._actionContext.ID) as ActionContext;
					else
						this._actionContext = ActionContext.CreateManager().LazyLoad(this._actionContext.ID) as ActionContext;
				return this._actionContext;
			}
			set { _actionContext = value; }
		}

		public Service Service 
		{
			get
			{
				if (this._service != null &&
						this._service.IsEmpty)
					if (this.ConnectionContext != null)
						this._service = Service.CreateManager().LazyLoad(this.ConnectionContext, this._service.ID) as Service;
					else
						this._service = Service.CreateManager().LazyLoad(this._service.ID) as Service;
				return this._service;
			}
			set { _service = value; }
		}

		public MobileOperator MobileOperator 
		{
			get
			{
				if (this._mobileOperator != null &&
						this._mobileOperator.IsEmpty)
					if (this.ConnectionContext != null)
						this._mobileOperator = MobileOperator.CreateManager().LazyLoad(this.ConnectionContext, this._mobileOperator.ID) as MobileOperator;
					else
						this._mobileOperator = MobileOperator.CreateManager().LazyLoad(this._mobileOperator.ID) as MobileOperator;
				return this._mobileOperator;
			}
			set { _mobileOperator = value; }
		}

		public Customer Customer 
		{
			get
			{
				if (this._customer != null &&
						this._customer.IsEmpty)
					if (this.ConnectionContext != null)
						this._customer = Customer.CreateManager().LazyLoad(this.ConnectionContext, this._customer.ID) as Customer;
					else
						this._customer = Customer.CreateManager().LazyLoad(this._customer.ID) as Customer;
				return this._customer;
			}
			set { _customer = value; }
		}

		public ShortMessageDirection ShortMessageDirection  { get { return this._shortMessageDirection; } set { this._shortMessageDirection = value; } }
		public ShortMessageStatus ShortMessageStatus  { get { return this._shortMessageStatus; } set { this._shortMessageStatus = value; } }
		public string Text{ get {return this._text; } set { this._text = value;} }
		public int Shortcode{ get {return this._shortcode; } set { this._shortcode = value;} }
		public string Keyword{ get {return this._keyword; } set { this._keyword = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public ShortMessage()
    { 
    }

    public ShortMessage(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public ShortMessage(int id,  Guid guid, ActionContext actionContext, Service service, MobileOperator mobileOperator, Customer customer, ShortMessageDirection shortMessageDirection, ShortMessageStatus shortMessageStatus, string text, int shortcode, string keyword, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._guid = guid;
			this._actionContext = actionContext;
			this._service = service;
			this._mobileOperator = mobileOperator;
			this._customer = customer;
			this._shortMessageDirection = shortMessageDirection;
			this._shortMessageStatus = shortMessageStatus;
			this._text = text;
			this._shortcode = shortcode;
			this._keyword = keyword;
			
    }

    public override object Clone(bool deepClone)
    {
      return new ShortMessage(-1, this.Guid, this.ActionContext, this.Service, this.MobileOperator, this.Customer, this.ShortMessageDirection, this.ShortMessageStatus,this.Text,this.Shortcode,this.Keyword, DateTime.Now, DateTime.Now);
    }
  }
}

