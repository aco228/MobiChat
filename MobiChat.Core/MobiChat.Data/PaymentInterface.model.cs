using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface IPaymentInterfaceManager : IDataManager<PaymentInterface> 
  {
	

  }

  public partial class PaymentInterface : MobiChatObject<IPaymentInterfaceManager> 
  {
		private Guid _externalPaymentInterfaceGuid;
		private string _name = String.Empty;
		

		public Guid ExternalPaymentInterfaceGuid { get { return this._externalPaymentInterfaceGuid; } set { this._externalPaymentInterfaceGuid = value;}}
		public string Name{ get {return this._name; } set { this._name = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public PaymentInterface()
    { 
    }

    public PaymentInterface(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public PaymentInterface(int id,  Guid externalPaymentInterfaceGuid, string name, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._externalPaymentInterfaceGuid = externalPaymentInterfaceGuid;
			this._name = name;
			
    }

    public override object Clone(bool deepClone)
    {
      return new PaymentInterface(-1, this.ExternalPaymentInterfaceGuid,this.Name, DateTime.Now, DateTime.Now);
    }
  }
}

