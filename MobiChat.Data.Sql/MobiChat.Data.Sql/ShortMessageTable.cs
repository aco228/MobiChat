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
  public class ShortMessageTable : TableBase<ShortMessage>
  {
    public static string GetColumnNames()
    {
      return TableBase<ShortMessage>.GetColumnNames(string.Empty, ShortMessageTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<ShortMessage>.GetColumnNames(tablePrefix, ShortMessageTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription ShortMessageID = new ColumnDescription("ShortMessageID", 0, typeof(int));
			public static readonly ColumnDescription ShortMessageGuid = new ColumnDescription("ShortMessageGuid", 1, typeof(Guid));
			public static readonly ColumnDescription ActionContextID = new ColumnDescription("ActionContextID", 2, typeof(int));
			public static readonly ColumnDescription ServiceID = new ColumnDescription("ServiceID", 3, typeof(int));
			public static readonly ColumnDescription MobileOperatorID = new ColumnDescription("MobileOperatorID", 4, typeof(int));
			public static readonly ColumnDescription CustomerID = new ColumnDescription("CustomerID", 5, typeof(int));
			public static readonly ColumnDescription ShortMessageDirectionID = new ColumnDescription("ShortMessageDirectionID", 6, typeof(int));
			public static readonly ColumnDescription ShortMessageStatusID = new ColumnDescription("ShortMessageStatusID", 7, typeof(int));
			public static readonly ColumnDescription Text = new ColumnDescription("Text", 8, typeof(string));
			public static readonly ColumnDescription Shortcode = new ColumnDescription("Shortcode", 9, typeof(int));
			public static readonly ColumnDescription Keyword = new ColumnDescription("Keyword", 10, typeof(string));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 11, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 12, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				ShortMessageID,
				ShortMessageGuid,
				ActionContextID,
				ServiceID,
				MobileOperatorID,
				CustomerID,
				ShortMessageDirectionID,
				ShortMessageStatusID,
				Text,
				Shortcode,
				Keyword,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public ShortMessageTable(SqlQuery query) : base(query) { }
    public ShortMessageTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int ShortMessageID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ShortMessageID)); } }
		public Guid ShortMessageGuid { get { return this.Reader.GetGuid(this.GetIndex(Columns.ShortMessageGuid)); } }
		
		public int? ActionContextID 
		{
			get
			{
				int index = this.GetIndex(Columns.ActionContextID);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetInt32(index);
			}
		}

		
		public int? ServiceID 
		{
			get
			{
				int index = this.GetIndex(Columns.ServiceID);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetInt32(index);
			}
		}

		
		public int? MobileOperatorID 
		{
			get
			{
				int index = this.GetIndex(Columns.MobileOperatorID);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetInt32(index);
			}
		}

		public int CustomerID { get { return this.Reader.GetInt32(this.GetIndex(Columns.CustomerID)); } }
		public int ShortMessageDirectionID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ShortMessageDirectionID)); } }
		public int ShortMessageStatusID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ShortMessageStatusID)); } }
		public string Text { get { return this.Reader.GetString(this.GetIndex(Columns.Text)); } }
		public int Shortcode { get { return this.Reader.GetInt32(this.GetIndex(Columns.Shortcode)); } }
		public string Keyword { get { return this.Reader.GetString(this.GetIndex(Columns.Keyword)); } }
		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public ShortMessage CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new ShortMessage(this.ShortMessageID,this.ShortMessageGuid,(ActionContextID.HasValue ? new ActionContext(this.ActionContextID.Value) : null), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), new Customer(this.CustomerID), (ShortMessageDirection)this.ShortMessageDirectionID,(ShortMessageStatus)this.ShortMessageStatusID,this.Text,this.Shortcode,this.Keyword,this.Updated,this.Created); 
		}
		public ShortMessage CreateInstance(ActionContext actionContext)  
		{ 
			if (!this.HasData) return null;
			return new ShortMessage(this.ShortMessageID,this.ShortMessageGuid,actionContext ?? (this.ActionContextID.HasValue ? new ActionContext(this.ActionContextID.Value) : null), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), new Customer(this.CustomerID), (ShortMessageDirection)this.ShortMessageDirectionID,(ShortMessageStatus)this.ShortMessageStatusID,this.Text,this.Shortcode,this.Keyword,this.Updated,this.Created); 
		}
		public ShortMessage CreateInstance(Customer customer)  
		{ 
			if (!this.HasData) return null;
			return new ShortMessage(this.ShortMessageID,this.ShortMessageGuid,(ActionContextID.HasValue ? new ActionContext(this.ActionContextID.Value) : null), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), customer ?? new Customer(this.CustomerID), (ShortMessageDirection)this.ShortMessageDirectionID,(ShortMessageStatus)this.ShortMessageStatusID,this.Text,this.Shortcode,this.Keyword,this.Updated,this.Created); 
		}
		public ShortMessage CreateInstance(MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new ShortMessage(this.ShortMessageID,this.ShortMessageGuid,(ActionContextID.HasValue ? new ActionContext(this.ActionContextID.Value) : null), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), new Customer(this.CustomerID), (ShortMessageDirection)this.ShortMessageDirectionID,(ShortMessageStatus)this.ShortMessageStatusID,this.Text,this.Shortcode,this.Keyword,this.Updated,this.Created); 
		}
		public ShortMessage CreateInstance(Service service)  
		{ 
			if (!this.HasData) return null;
			return new ShortMessage(this.ShortMessageID,this.ShortMessageGuid,(ActionContextID.HasValue ? new ActionContext(this.ActionContextID.Value) : null), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), new Customer(this.CustomerID), (ShortMessageDirection)this.ShortMessageDirectionID,(ShortMessageStatus)this.ShortMessageStatusID,this.Text,this.Shortcode,this.Keyword,this.Updated,this.Created); 
		}
		public ShortMessage CreateInstance(ActionContext actionContext, Customer customer)  
		{ 
			if (!this.HasData) return null;
			return new ShortMessage(this.ShortMessageID,this.ShortMessageGuid,actionContext ?? (this.ActionContextID.HasValue ? new ActionContext(this.ActionContextID.Value) : null), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), customer ?? new Customer(this.CustomerID), (ShortMessageDirection)this.ShortMessageDirectionID,(ShortMessageStatus)this.ShortMessageStatusID,this.Text,this.Shortcode,this.Keyword,this.Updated,this.Created); 
		}
		public ShortMessage CreateInstance(ActionContext actionContext, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new ShortMessage(this.ShortMessageID,this.ShortMessageGuid,actionContext ?? (this.ActionContextID.HasValue ? new ActionContext(this.ActionContextID.Value) : null), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), new Customer(this.CustomerID), (ShortMessageDirection)this.ShortMessageDirectionID,(ShortMessageStatus)this.ShortMessageStatusID,this.Text,this.Shortcode,this.Keyword,this.Updated,this.Created); 
		}
		public ShortMessage CreateInstance(ActionContext actionContext, Service service)  
		{ 
			if (!this.HasData) return null;
			return new ShortMessage(this.ShortMessageID,this.ShortMessageGuid,actionContext ?? (this.ActionContextID.HasValue ? new ActionContext(this.ActionContextID.Value) : null), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), new Customer(this.CustomerID), (ShortMessageDirection)this.ShortMessageDirectionID,(ShortMessageStatus)this.ShortMessageStatusID,this.Text,this.Shortcode,this.Keyword,this.Updated,this.Created); 
		}
		public ShortMessage CreateInstance(MobileOperator mobileOperator, Customer customer)  
		{ 
			if (!this.HasData) return null;
			return new ShortMessage(this.ShortMessageID,this.ShortMessageGuid,(ActionContextID.HasValue ? new ActionContext(this.ActionContextID.Value) : null), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), customer ?? new Customer(this.CustomerID), (ShortMessageDirection)this.ShortMessageDirectionID,(ShortMessageStatus)this.ShortMessageStatusID,this.Text,this.Shortcode,this.Keyword,this.Updated,this.Created); 
		}
		public ShortMessage CreateInstance(Service service, Customer customer)  
		{ 
			if (!this.HasData) return null;
			return new ShortMessage(this.ShortMessageID,this.ShortMessageGuid,(ActionContextID.HasValue ? new ActionContext(this.ActionContextID.Value) : null), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), customer ?? new Customer(this.CustomerID), (ShortMessageDirection)this.ShortMessageDirectionID,(ShortMessageStatus)this.ShortMessageStatusID,this.Text,this.Shortcode,this.Keyword,this.Updated,this.Created); 
		}
		public ShortMessage CreateInstance(Service service, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new ShortMessage(this.ShortMessageID,this.ShortMessageGuid,(ActionContextID.HasValue ? new ActionContext(this.ActionContextID.Value) : null), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), new Customer(this.CustomerID), (ShortMessageDirection)this.ShortMessageDirectionID,(ShortMessageStatus)this.ShortMessageStatusID,this.Text,this.Shortcode,this.Keyword,this.Updated,this.Created); 
		}
		public ShortMessage CreateInstance(ActionContext actionContext, MobileOperator mobileOperator, Customer customer)  
		{ 
			if (!this.HasData) return null;
			return new ShortMessage(this.ShortMessageID,this.ShortMessageGuid,actionContext ?? (this.ActionContextID.HasValue ? new ActionContext(this.ActionContextID.Value) : null), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), customer ?? new Customer(this.CustomerID), (ShortMessageDirection)this.ShortMessageDirectionID,(ShortMessageStatus)this.ShortMessageStatusID,this.Text,this.Shortcode,this.Keyword,this.Updated,this.Created); 
		}
		public ShortMessage CreateInstance(ActionContext actionContext, Service service, Customer customer)  
		{ 
			if (!this.HasData) return null;
			return new ShortMessage(this.ShortMessageID,this.ShortMessageGuid,actionContext ?? (this.ActionContextID.HasValue ? new ActionContext(this.ActionContextID.Value) : null), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), (MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), customer ?? new Customer(this.CustomerID), (ShortMessageDirection)this.ShortMessageDirectionID,(ShortMessageStatus)this.ShortMessageStatusID,this.Text,this.Shortcode,this.Keyword,this.Updated,this.Created); 
		}
		public ShortMessage CreateInstance(ActionContext actionContext, Service service, MobileOperator mobileOperator)  
		{ 
			if (!this.HasData) return null;
			return new ShortMessage(this.ShortMessageID,this.ShortMessageGuid,actionContext ?? (this.ActionContextID.HasValue ? new ActionContext(this.ActionContextID.Value) : null), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), new Customer(this.CustomerID), (ShortMessageDirection)this.ShortMessageDirectionID,(ShortMessageStatus)this.ShortMessageStatusID,this.Text,this.Shortcode,this.Keyword,this.Updated,this.Created); 
		}
		public ShortMessage CreateInstance(Service service, MobileOperator mobileOperator, Customer customer)  
		{ 
			if (!this.HasData) return null;
			return new ShortMessage(this.ShortMessageID,this.ShortMessageGuid,(ActionContextID.HasValue ? new ActionContext(this.ActionContextID.Value) : null), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), customer ?? new Customer(this.CustomerID), (ShortMessageDirection)this.ShortMessageDirectionID,(ShortMessageStatus)this.ShortMessageStatusID,this.Text,this.Shortcode,this.Keyword,this.Updated,this.Created); 
		}
		public ShortMessage CreateInstance(ActionContext actionContext, Service service, MobileOperator mobileOperator, Customer customer)  
		{ 
			if (!this.HasData) return null;
			return new ShortMessage(this.ShortMessageID,this.ShortMessageGuid,actionContext ?? (this.ActionContextID.HasValue ? new ActionContext(this.ActionContextID.Value) : null), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), mobileOperator ?? (this.MobileOperatorID.HasValue ? new MobileOperator(this.MobileOperatorID.Value) : null), customer ?? new Customer(this.CustomerID), (ShortMessageDirection)this.ShortMessageDirectionID,(ShortMessageStatus)this.ShortMessageStatusID,this.Text,this.Shortcode,this.Keyword,this.Updated,this.Created); 
		}
		

  }
}

