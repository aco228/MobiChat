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
  public class ProductTable : TableBase<Product>
  {
    public static string GetColumnNames()
    {
      return TableBase<Product>.GetColumnNames(string.Empty, ProductTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<Product>.GetColumnNames(tablePrefix, ProductTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription ProductID = new ColumnDescription("ProductID", 0, typeof(int));
			public static readonly ColumnDescription InstanceID = new ColumnDescription("InstanceID", 1, typeof(int));
			public static readonly ColumnDescription ProductGuid = new ColumnDescription("ProductGuid", 2, typeof(Guid));
			public static readonly ColumnDescription ExternalProductGuid = new ColumnDescription("ExternalProductGuid", 3, typeof(Guid));
			public static readonly ColumnDescription Name = new ColumnDescription("Name", 4, typeof(string));
			public static readonly ColumnDescription Description = new ColumnDescription("Description", 5, typeof(string));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 6, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 7, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				ProductID,
				InstanceID,
				ProductGuid,
				ExternalProductGuid,
				Name,
				Description,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public ProductTable(SqlQuery query) : base(query) { }
    public ProductTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int ProductID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ProductID)); } }
		public int InstanceID { get { return this.Reader.GetInt32(this.GetIndex(Columns.InstanceID)); } }
		public Guid ProductGuid { get { return this.Reader.GetGuid(this.GetIndex(Columns.ProductGuid)); } }
		public Guid ExternalProductGuid { get { return this.Reader.GetGuid(this.GetIndex(Columns.ExternalProductGuid)); } }
		public string Name { get { return this.Reader.GetString(this.GetIndex(Columns.Name)); } }
		
		public string Description 
		{
			get
			{
				int index = this.GetIndex(Columns.Description);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public Product CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new Product(this.ProductID,new Instance(this.InstanceID), this.ProductGuid,this.ExternalProductGuid,this.Name,this.Description,this.Updated,this.Created); 
		}
		public Product CreateInstance(Instance instance)  
		{ 
			if (!this.HasData) return null;
			return new Product(this.ProductID,instance ?? new Instance(this.InstanceID), this.ProductGuid,this.ExternalProductGuid,this.Name,this.Description,this.Updated,this.Created); 
		}
		

  }
}

