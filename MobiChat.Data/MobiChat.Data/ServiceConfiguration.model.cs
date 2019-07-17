using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface IServiceConfigurationManager : IDataManager<ServiceConfiguration> 
  {
	

  }

  public partial class ServiceConfiguration : MobiChatObject<IServiceConfigurationManager> 
  {
		private int _instanceID = -1;
		private PaymentConfiguration _paymentConfiguration;
		private string _name = String.Empty;
		

		public int InstanceID{ get {return this._instanceID; } set { this._instanceID = value;} }
		public PaymentConfiguration PaymentConfiguration 
		{
			get
			{
				if (this._paymentConfiguration != null &&
						this._paymentConfiguration.IsEmpty)
					if (this.ConnectionContext != null)
						this._paymentConfiguration = PaymentConfiguration.CreateManager().LazyLoad(this.ConnectionContext, this._paymentConfiguration.ID) as PaymentConfiguration;
					else
						this._paymentConfiguration = PaymentConfiguration.CreateManager().LazyLoad(this._paymentConfiguration.ID) as PaymentConfiguration;
				return this._paymentConfiguration;
			}
			set { _paymentConfiguration = value; }
		}

		public string Name{ get {return this._name; } set { this._name = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public ServiceConfiguration()
    { 
    }

    public ServiceConfiguration(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public ServiceConfiguration(int id,  int instanceID, PaymentConfiguration paymentConfiguration, string name, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._instanceID = instanceID;
			this._paymentConfiguration = paymentConfiguration;
			this._name = name;
			
    }

    public override object Clone(bool deepClone)
    {
      return new ServiceConfiguration(-1, this.InstanceID, this.PaymentConfiguration,this.Name, DateTime.Now, DateTime.Now);
    }
  }
}

