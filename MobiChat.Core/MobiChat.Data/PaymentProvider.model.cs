using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface IPaymentProviderManager : IDataManager<PaymentProvider> 
  {
	

  }

  public partial class PaymentProvider : MobiChatObject<IPaymentProviderManager> 
  {
		private Guid? _externalPaymentProviderGuid;
		private string _name = String.Empty;
		

		public Guid? ExternalPaymentProviderGuid { get { return this._externalPaymentProviderGuid; } set { this._externalPaymentProviderGuid = value;}}
		public string Name{ get {return this._name; } set { this._name = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public PaymentProvider()
    { 
    }

    public PaymentProvider(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public PaymentProvider(int id,  Guid? externalPaymentProviderGuid, string name, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._externalPaymentProviderGuid = externalPaymentProviderGuid;
			this._name = name;
			
    }

    public override object Clone(bool deepClone)
    {
      return new PaymentProvider(-1, this.ExternalPaymentProviderGuid,this.Name, DateTime.Now, DateTime.Now);
    }
  }
}

