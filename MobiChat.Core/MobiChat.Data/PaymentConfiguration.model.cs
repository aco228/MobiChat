using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface IPaymentConfigurationManager : IDataManager<PaymentConfiguration> 
  {
	

  }

  public partial class PaymentConfiguration : MobiChatObject<IPaymentConfigurationManager> 
  {
		private PaymentCredentials _paymentCredentials;
		private PaymentInterface _paymentInterface;
		private PaymentProvider _paymentProvider;
		private BehaviorModel _behaviorModel;
		private string _name = String.Empty;
		

		public PaymentCredentials PaymentCredentials 
		{
			get
			{
				if (this._paymentCredentials != null &&
						this._paymentCredentials.IsEmpty)
					if (this.ConnectionContext != null)
						this._paymentCredentials = PaymentCredentials.CreateManager().LazyLoad(this.ConnectionContext, this._paymentCredentials.ID) as PaymentCredentials;
					else
						this._paymentCredentials = PaymentCredentials.CreateManager().LazyLoad(this._paymentCredentials.ID) as PaymentCredentials;
				return this._paymentCredentials;
			}
			set { _paymentCredentials = value; }
		}

		public PaymentInterface PaymentInterface 
		{
			get
			{
				if (this._paymentInterface != null &&
						this._paymentInterface.IsEmpty)
					if (this.ConnectionContext != null)
						this._paymentInterface = PaymentInterface.CreateManager().LazyLoad(this.ConnectionContext, this._paymentInterface.ID) as PaymentInterface;
					else
						this._paymentInterface = PaymentInterface.CreateManager().LazyLoad(this._paymentInterface.ID) as PaymentInterface;
				return this._paymentInterface;
			}
			set { _paymentInterface = value; }
		}

		public PaymentProvider PaymentProvider 
		{
			get
			{
				if (this._paymentProvider != null &&
						this._paymentProvider.IsEmpty)
					if (this.ConnectionContext != null)
						this._paymentProvider = PaymentProvider.CreateManager().LazyLoad(this.ConnectionContext, this._paymentProvider.ID) as PaymentProvider;
					else
						this._paymentProvider = PaymentProvider.CreateManager().LazyLoad(this._paymentProvider.ID) as PaymentProvider;
				return this._paymentProvider;
			}
			set { _paymentProvider = value; }
		}

		public BehaviorModel BehaviorModel 
		{
			get
			{
				if (this._behaviorModel != null &&
						this._behaviorModel.IsEmpty)
					if (this.ConnectionContext != null)
						this._behaviorModel = BehaviorModel.CreateManager().LazyLoad(this.ConnectionContext, this._behaviorModel.ID) as BehaviorModel;
					else
						this._behaviorModel = BehaviorModel.CreateManager().LazyLoad(this._behaviorModel.ID) as BehaviorModel;
				return this._behaviorModel;
			}
			set { _behaviorModel = value; }
		}

		public string Name{ get {return this._name; } set { this._name = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public PaymentConfiguration()
    { 
    }

    public PaymentConfiguration(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public PaymentConfiguration(int id,  PaymentCredentials paymentCredentials, PaymentInterface paymentInterface, PaymentProvider paymentProvider, BehaviorModel behaviorModel, string name, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._paymentCredentials = paymentCredentials;
			this._paymentInterface = paymentInterface;
			this._paymentProvider = paymentProvider;
			this._behaviorModel = behaviorModel;
			this._name = name;
			
    }

    public override object Clone(bool deepClone)
    {
      return new PaymentConfiguration(-1,  this.PaymentCredentials, this.PaymentInterface, this.PaymentProvider, this.BehaviorModel,this.Name, DateTime.Now, DateTime.Now);
    }
  }
}

