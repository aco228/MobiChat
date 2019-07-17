using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti;
using Senti.Data;
using Senti.Data.Sql;

using MobiChat.Data;


namespace MobiChat.Data.Sql
{
  public class PaymentConfigurationTable : TableBase<PaymentConfiguration>
  {
    public static string GetColumnNames()
    {
      return TableBase<PaymentConfiguration>.GetColumnNames(string.Empty, PaymentConfigurationTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<PaymentConfiguration>.GetColumnNames(tablePrefix, PaymentConfigurationTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription PaymentConfigurationID = new ColumnDescription("PaymentConfigurationID", 0, typeof(int));
			public static readonly ColumnDescription PaymentCredentialsID = new ColumnDescription("PaymentCredentialsID", 1, typeof(int));
			public static readonly ColumnDescription PaymentInterfaceID = new ColumnDescription("PaymentInterfaceID", 2, typeof(int));
			public static readonly ColumnDescription PaymentProviderID = new ColumnDescription("PaymentProviderID", 3, typeof(int));
			public static readonly ColumnDescription BehaviorModelID = new ColumnDescription("BehaviorModelID", 4, typeof(int));
			public static readonly ColumnDescription Name = new ColumnDescription("Name", 5, typeof(string));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 6, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 7, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				PaymentConfigurationID,
				PaymentCredentialsID,
				PaymentInterfaceID,
				PaymentProviderID,
				BehaviorModelID,
				Name,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public PaymentConfigurationTable(SqlQuery query) : base(query) { }
    public PaymentConfigurationTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int PaymentConfigurationID { get { return this.Reader.GetInt32(this.GetIndex(Columns.PaymentConfigurationID)); } }
		public int PaymentCredentialsID { get { return this.Reader.GetInt32(this.GetIndex(Columns.PaymentCredentialsID)); } }
		public int PaymentInterfaceID { get { return this.Reader.GetInt32(this.GetIndex(Columns.PaymentInterfaceID)); } }
		public int PaymentProviderID { get { return this.Reader.GetInt32(this.GetIndex(Columns.PaymentProviderID)); } }
		public int BehaviorModelID { get { return this.Reader.GetInt32(this.GetIndex(Columns.BehaviorModelID)); } }
		public string Name { get { return this.Reader.GetString(this.GetIndex(Columns.Name)); } }
		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public PaymentConfiguration CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new PaymentConfiguration(this.PaymentConfigurationID,new PaymentCredentials(this.PaymentCredentialsID), new PaymentInterface(this.PaymentInterfaceID), new PaymentProvider(this.PaymentProviderID), new BehaviorModel(this.BehaviorModelID), this.Name,this.Updated,this.Created); 
		}
		public PaymentConfiguration CreateInstance(BehaviorModel behaviorModel)  
		{ 
			if (!this.HasData) return null;
			return new PaymentConfiguration(this.PaymentConfigurationID,new PaymentCredentials(this.PaymentCredentialsID), new PaymentInterface(this.PaymentInterfaceID), new PaymentProvider(this.PaymentProviderID), behaviorModel ?? new BehaviorModel(this.BehaviorModelID), this.Name,this.Updated,this.Created); 
		}
		public PaymentConfiguration CreateInstance(PaymentCredentials paymentCredentials)  
		{ 
			if (!this.HasData) return null;
			return new PaymentConfiguration(this.PaymentConfigurationID,paymentCredentials ?? new PaymentCredentials(this.PaymentCredentialsID), new PaymentInterface(this.PaymentInterfaceID), new PaymentProvider(this.PaymentProviderID), new BehaviorModel(this.BehaviorModelID), this.Name,this.Updated,this.Created); 
		}
		public PaymentConfiguration CreateInstance(PaymentInterface paymentInterface)  
		{ 
			if (!this.HasData) return null;
			return new PaymentConfiguration(this.PaymentConfigurationID,new PaymentCredentials(this.PaymentCredentialsID), paymentInterface ?? new PaymentInterface(this.PaymentInterfaceID), new PaymentProvider(this.PaymentProviderID), new BehaviorModel(this.BehaviorModelID), this.Name,this.Updated,this.Created); 
		}
		public PaymentConfiguration CreateInstance(PaymentProvider paymentProvider)  
		{ 
			if (!this.HasData) return null;
			return new PaymentConfiguration(this.PaymentConfigurationID,new PaymentCredentials(this.PaymentCredentialsID), new PaymentInterface(this.PaymentInterfaceID), paymentProvider ?? new PaymentProvider(this.PaymentProviderID), new BehaviorModel(this.BehaviorModelID), this.Name,this.Updated,this.Created); 
		}
		public PaymentConfiguration CreateInstance(PaymentCredentials paymentCredentials, BehaviorModel behaviorModel)  
		{ 
			if (!this.HasData) return null;
			return new PaymentConfiguration(this.PaymentConfigurationID,paymentCredentials ?? new PaymentCredentials(this.PaymentCredentialsID), new PaymentInterface(this.PaymentInterfaceID), new PaymentProvider(this.PaymentProviderID), behaviorModel ?? new BehaviorModel(this.BehaviorModelID), this.Name,this.Updated,this.Created); 
		}
		public PaymentConfiguration CreateInstance(PaymentInterface paymentInterface, BehaviorModel behaviorModel)  
		{ 
			if (!this.HasData) return null;
			return new PaymentConfiguration(this.PaymentConfigurationID,new PaymentCredentials(this.PaymentCredentialsID), paymentInterface ?? new PaymentInterface(this.PaymentInterfaceID), new PaymentProvider(this.PaymentProviderID), behaviorModel ?? new BehaviorModel(this.BehaviorModelID), this.Name,this.Updated,this.Created); 
		}
		public PaymentConfiguration CreateInstance(PaymentProvider paymentProvider, BehaviorModel behaviorModel)  
		{ 
			if (!this.HasData) return null;
			return new PaymentConfiguration(this.PaymentConfigurationID,new PaymentCredentials(this.PaymentCredentialsID), new PaymentInterface(this.PaymentInterfaceID), paymentProvider ?? new PaymentProvider(this.PaymentProviderID), behaviorModel ?? new BehaviorModel(this.BehaviorModelID), this.Name,this.Updated,this.Created); 
		}
		public PaymentConfiguration CreateInstance(PaymentCredentials paymentCredentials, PaymentInterface paymentInterface)  
		{ 
			if (!this.HasData) return null;
			return new PaymentConfiguration(this.PaymentConfigurationID,paymentCredentials ?? new PaymentCredentials(this.PaymentCredentialsID), paymentInterface ?? new PaymentInterface(this.PaymentInterfaceID), new PaymentProvider(this.PaymentProviderID), new BehaviorModel(this.BehaviorModelID), this.Name,this.Updated,this.Created); 
		}
		public PaymentConfiguration CreateInstance(PaymentCredentials paymentCredentials, PaymentProvider paymentProvider)  
		{ 
			if (!this.HasData) return null;
			return new PaymentConfiguration(this.PaymentConfigurationID,paymentCredentials ?? new PaymentCredentials(this.PaymentCredentialsID), new PaymentInterface(this.PaymentInterfaceID), paymentProvider ?? new PaymentProvider(this.PaymentProviderID), new BehaviorModel(this.BehaviorModelID), this.Name,this.Updated,this.Created); 
		}
		public PaymentConfiguration CreateInstance(PaymentInterface paymentInterface, PaymentProvider paymentProvider)  
		{ 
			if (!this.HasData) return null;
			return new PaymentConfiguration(this.PaymentConfigurationID,new PaymentCredentials(this.PaymentCredentialsID), paymentInterface ?? new PaymentInterface(this.PaymentInterfaceID), paymentProvider ?? new PaymentProvider(this.PaymentProviderID), new BehaviorModel(this.BehaviorModelID), this.Name,this.Updated,this.Created); 
		}
		public PaymentConfiguration CreateInstance(PaymentCredentials paymentCredentials, PaymentInterface paymentInterface, BehaviorModel behaviorModel)  
		{ 
			if (!this.HasData) return null;
			return new PaymentConfiguration(this.PaymentConfigurationID,paymentCredentials ?? new PaymentCredentials(this.PaymentCredentialsID), paymentInterface ?? new PaymentInterface(this.PaymentInterfaceID), new PaymentProvider(this.PaymentProviderID), behaviorModel ?? new BehaviorModel(this.BehaviorModelID), this.Name,this.Updated,this.Created); 
		}
		public PaymentConfiguration CreateInstance(PaymentCredentials paymentCredentials, PaymentProvider paymentProvider, BehaviorModel behaviorModel)  
		{ 
			if (!this.HasData) return null;
			return new PaymentConfiguration(this.PaymentConfigurationID,paymentCredentials ?? new PaymentCredentials(this.PaymentCredentialsID), new PaymentInterface(this.PaymentInterfaceID), paymentProvider ?? new PaymentProvider(this.PaymentProviderID), behaviorModel ?? new BehaviorModel(this.BehaviorModelID), this.Name,this.Updated,this.Created); 
		}
		public PaymentConfiguration CreateInstance(PaymentInterface paymentInterface, PaymentProvider paymentProvider, BehaviorModel behaviorModel)  
		{ 
			if (!this.HasData) return null;
			return new PaymentConfiguration(this.PaymentConfigurationID,new PaymentCredentials(this.PaymentCredentialsID), paymentInterface ?? new PaymentInterface(this.PaymentInterfaceID), paymentProvider ?? new PaymentProvider(this.PaymentProviderID), behaviorModel ?? new BehaviorModel(this.BehaviorModelID), this.Name,this.Updated,this.Created); 
		}
		public PaymentConfiguration CreateInstance(PaymentCredentials paymentCredentials, PaymentInterface paymentInterface, PaymentProvider paymentProvider)  
		{ 
			if (!this.HasData) return null;
			return new PaymentConfiguration(this.PaymentConfigurationID,paymentCredentials ?? new PaymentCredentials(this.PaymentCredentialsID), paymentInterface ?? new PaymentInterface(this.PaymentInterfaceID), paymentProvider ?? new PaymentProvider(this.PaymentProviderID), new BehaviorModel(this.BehaviorModelID), this.Name,this.Updated,this.Created); 
		}
		public PaymentConfiguration CreateInstance(PaymentCredentials paymentCredentials, PaymentInterface paymentInterface, PaymentProvider paymentProvider, BehaviorModel behaviorModel)  
		{ 
			if (!this.HasData) return null;
			return new PaymentConfiguration(this.PaymentConfigurationID,paymentCredentials ?? new PaymentCredentials(this.PaymentCredentialsID), paymentInterface ?? new PaymentInterface(this.PaymentInterfaceID), paymentProvider ?? new PaymentProvider(this.PaymentProviderID), behaviorModel ?? new BehaviorModel(this.BehaviorModelID), this.Name,this.Updated,this.Created); 
		}
		

  }
}

