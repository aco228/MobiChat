using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface IMerchantManager : IDataManager<Merchant> 
  {
	

  }

  public partial class Merchant : MobiChatObject<IMerchantManager> 
  {
		private Instance _instance;
		private Template _template;
		private string _name = String.Empty;
		private string _address = String.Empty;
		private string _phone = String.Empty;
		private string _email = String.Empty;
		private string _registrationNo = String.Empty;
		private string _vatNo = String.Empty;
		

		public Instance Instance 
		{
			get
			{
				if (this._instance != null &&
						this._instance.IsEmpty)
					if (this.ConnectionContext != null)
						this._instance = Instance.CreateManager().LazyLoad(this.ConnectionContext, this._instance.ID) as Instance;
					else
						this._instance = Instance.CreateManager().LazyLoad(this._instance.ID) as Instance;
				return this._instance;
			}
			set { _instance = value; }
		}

		public Template Template 
		{
			get
			{
				if (this._template != null &&
						this._template.IsEmpty)
					if (this.ConnectionContext != null)
						this._template = Template.CreateManager().LazyLoad(this.ConnectionContext, this._template.ID) as Template;
					else
						this._template = Template.CreateManager().LazyLoad(this._template.ID) as Template;
				return this._template;
			}
			set { _template = value; }
		}

		public string Name{ get {return this._name; } set { this._name = value;} }
		public string Address{ get {return this._address; } set { this._address = value;} }
		public string Phone{ get {return this._phone; } set { this._phone = value;} }
		public string Email{ get {return this._email; } set { this._email = value;} }
		public string RegistrationNo{ get {return this._registrationNo; } set { this._registrationNo = value;} }
		public string VatNo{ get {return this._vatNo; } set { this._vatNo = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public Merchant()
    { 
    }

    public Merchant(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public Merchant(int id,  Instance instance, Template template, string name, string address, string phone, string email, string registrationNo, string vatNo, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._instance = instance;
			this._template = template;
			this._name = name;
			this._address = address;
			this._phone = phone;
			this._email = email;
			this._registrationNo = registrationNo;
			this._vatNo = vatNo;
			
    }

    public override object Clone(bool deepClone)
    {
      return new Merchant(-1,  this.Instance, this.Template,this.Name,this.Address,this.Phone,this.Email,this.RegistrationNo,this.VatNo, DateTime.Now, DateTime.Now);
    }
  }
}

