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
  public class MerchantTable : TableBase<Merchant>
  {
    public static string GetColumnNames()
    {
      return TableBase<Merchant>.GetColumnNames(string.Empty, MerchantTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<Merchant>.GetColumnNames(tablePrefix, MerchantTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription MerchantID = new ColumnDescription("MerchantID", 0, typeof(int));
			public static readonly ColumnDescription InstanceID = new ColumnDescription("InstanceID", 1, typeof(int));
			public static readonly ColumnDescription TemplateID = new ColumnDescription("TemplateID", 2, typeof(int));
			public static readonly ColumnDescription Name = new ColumnDescription("Name", 3, typeof(string));
			public static readonly ColumnDescription Address = new ColumnDescription("Address", 4, typeof(string));
			public static readonly ColumnDescription Phone = new ColumnDescription("Phone", 5, typeof(string));
			public static readonly ColumnDescription Email = new ColumnDescription("Email", 6, typeof(string));
			public static readonly ColumnDescription RegistrationNo = new ColumnDescription("RegistrationNo", 7, typeof(string));
			public static readonly ColumnDescription VatNo = new ColumnDescription("VatNo", 8, typeof(string));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 9, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 10, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				MerchantID,
				InstanceID,
				TemplateID,
				Name,
				Address,
				Phone,
				Email,
				RegistrationNo,
				VatNo,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public MerchantTable(SqlQuery query) : base(query) { }
    public MerchantTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int MerchantID { get { return this.Reader.GetInt32(this.GetIndex(Columns.MerchantID)); } }
		public int InstanceID { get { return this.Reader.GetInt32(this.GetIndex(Columns.InstanceID)); } }
		
		public int? TemplateID 
		{
			get
			{
				int index = this.GetIndex(Columns.TemplateID);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetInt32(index);
			}
		}

		public string Name { get { return this.Reader.GetString(this.GetIndex(Columns.Name)); } }
		
		public string Address 
		{
			get
			{
				int index = this.GetIndex(Columns.Address);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		
		public string Phone 
		{
			get
			{
				int index = this.GetIndex(Columns.Phone);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		
		public string Email 
		{
			get
			{
				int index = this.GetIndex(Columns.Email);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		
		public string RegistrationNo 
		{
			get
			{
				int index = this.GetIndex(Columns.RegistrationNo);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		
		public string VatNo 
		{
			get
			{
				int index = this.GetIndex(Columns.VatNo);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public Merchant CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new Merchant(this.MerchantID,new Instance(this.InstanceID), (TemplateID.HasValue ? new Template(this.TemplateID.Value) : null), this.Name,this.Address,this.Phone,this.Email,this.RegistrationNo,this.VatNo,this.Updated,this.Created); 
		}
		public Merchant CreateInstance(Instance instance)  
		{ 
			if (!this.HasData) return null;
			return new Merchant(this.MerchantID,instance ?? new Instance(this.InstanceID), (TemplateID.HasValue ? new Template(this.TemplateID.Value) : null), this.Name,this.Address,this.Phone,this.Email,this.RegistrationNo,this.VatNo,this.Updated,this.Created); 
		}
		public Merchant CreateInstance(Template template)  
		{ 
			if (!this.HasData) return null;
			return new Merchant(this.MerchantID,new Instance(this.InstanceID), template ?? (this.TemplateID.HasValue ? new Template(this.TemplateID.Value) : null), this.Name,this.Address,this.Phone,this.Email,this.RegistrationNo,this.VatNo,this.Updated,this.Created); 
		}
		public Merchant CreateInstance(Instance instance, Template template)  
		{ 
			if (!this.HasData) return null;
			return new Merchant(this.MerchantID,instance ?? new Instance(this.InstanceID), template ?? (this.TemplateID.HasValue ? new Template(this.TemplateID.Value) : null), this.Name,this.Address,this.Phone,this.Email,this.RegistrationNo,this.VatNo,this.Updated,this.Created); 
		}
		

  }
}

