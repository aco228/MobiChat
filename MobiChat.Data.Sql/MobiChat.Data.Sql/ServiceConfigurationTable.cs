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
  public class ServiceConfigurationTable : TableBase<ServiceConfiguration>
  {
    public static string GetColumnNames()
    {
      return TableBase<ServiceConfiguration>.GetColumnNames(string.Empty, ServiceConfigurationTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<ServiceConfiguration>.GetColumnNames(tablePrefix, ServiceConfigurationTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription ServiceConfigurationID = new ColumnDescription("ServiceConfigurationID", 0, typeof(int));
			public static readonly ColumnDescription InstanceID = new ColumnDescription("InstanceID", 1, typeof(int));
			public static readonly ColumnDescription PaymentConfigurationID = new ColumnDescription("PaymentConfigurationID", 2, typeof(int));
			public static readonly ColumnDescription ExternalID = new ColumnDescription("ExternalID", 3, typeof(string));
			public static readonly ColumnDescription Name = new ColumnDescription("Name", 4, typeof(string));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 5, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 6, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				ServiceConfigurationID,
				InstanceID,
				PaymentConfigurationID,
				ExternalID,
				Name,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public ServiceConfigurationTable(SqlQuery query) : base(query) { }
    public ServiceConfigurationTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int ServiceConfigurationID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ServiceConfigurationID)); } }
		public int InstanceID { get { return this.Reader.GetInt32(this.GetIndex(Columns.InstanceID)); } }
		public int PaymentConfigurationID { get { return this.Reader.GetInt32(this.GetIndex(Columns.PaymentConfigurationID)); } }
		
		public string ExternalID 
		{
			get
			{
				int index = this.GetIndex(Columns.ExternalID);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		public string Name { get { return this.Reader.GetString(this.GetIndex(Columns.Name)); } }
		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public ServiceConfiguration CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new ServiceConfiguration(this.ServiceConfigurationID,this.InstanceID,new PaymentConfiguration(this.PaymentConfigurationID), this.ExternalID,this.Name,this.Updated,this.Created); 
		}
		public ServiceConfiguration CreateInstance(PaymentConfiguration paymentConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new ServiceConfiguration(this.ServiceConfigurationID,this.InstanceID,paymentConfiguration ?? new PaymentConfiguration(this.PaymentConfigurationID), this.ExternalID,this.Name,this.Updated,this.Created); 
		}
		

  }
}

