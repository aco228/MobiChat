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
  public class LocalizationTable : TableBase<Localization>
  {
    public static string GetColumnNames()
    {
      return TableBase<Localization>.GetColumnNames(string.Empty, LocalizationTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<Localization>.GetColumnNames(tablePrefix, LocalizationTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription LocalizationID = new ColumnDescription("LocalizationID", 0, typeof(int));
			public static readonly ColumnDescription ApplicationID = new ColumnDescription("ApplicationID", 1, typeof(int));
			public static readonly ColumnDescription ProductID = new ColumnDescription("ProductID", 2, typeof(int));
			public static readonly ColumnDescription TranslationID = new ColumnDescription("TranslationID", 3, typeof(int));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 4, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 5, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				LocalizationID,
				ApplicationID,
				ProductID,
				TranslationID,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public LocalizationTable(SqlQuery query) : base(query) { }
    public LocalizationTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int LocalizationID { get { return this.Reader.GetInt32(this.GetIndex(Columns.LocalizationID)); } }
		public int ApplicationID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ApplicationID)); } }
		
		public int? ProductID 
		{
			get
			{
				int index = this.GetIndex(Columns.ProductID);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetInt32(index);
			}
		}

		public int TranslationID { get { return this.Reader.GetInt32(this.GetIndex(Columns.TranslationID)); } }
		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public Localization CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new Localization(this.LocalizationID,new Application(this.ApplicationID), (ProductID.HasValue ? new Product(this.ProductID.Value) : null), new Translation(this.TranslationID), this.Updated,this.Created); 
		}
		public Localization CreateInstance(Application application)  
		{ 
			if (!this.HasData) return null;
			return new Localization(this.LocalizationID,application ?? new Application(this.ApplicationID), (ProductID.HasValue ? new Product(this.ProductID.Value) : null), new Translation(this.TranslationID), this.Updated,this.Created); 
		}
		public Localization CreateInstance(Product product)  
		{ 
			if (!this.HasData) return null;
			return new Localization(this.LocalizationID,new Application(this.ApplicationID), product ?? (this.ProductID.HasValue ? new Product(this.ProductID.Value) : null), new Translation(this.TranslationID), this.Updated,this.Created); 
		}
		public Localization CreateInstance(Translation translation)  
		{ 
			if (!this.HasData) return null;
			return new Localization(this.LocalizationID,new Application(this.ApplicationID), (ProductID.HasValue ? new Product(this.ProductID.Value) : null), translation ?? new Translation(this.TranslationID), this.Updated,this.Created); 
		}
		public Localization CreateInstance(Application application, Product product)  
		{ 
			if (!this.HasData) return null;
			return new Localization(this.LocalizationID,application ?? new Application(this.ApplicationID), product ?? (this.ProductID.HasValue ? new Product(this.ProductID.Value) : null), new Translation(this.TranslationID), this.Updated,this.Created); 
		}
		public Localization CreateInstance(Application application, Translation translation)  
		{ 
			if (!this.HasData) return null;
			return new Localization(this.LocalizationID,application ?? new Application(this.ApplicationID), (ProductID.HasValue ? new Product(this.ProductID.Value) : null), translation ?? new Translation(this.TranslationID), this.Updated,this.Created); 
		}
		public Localization CreateInstance(Product product, Translation translation)  
		{ 
			if (!this.HasData) return null;
			return new Localization(this.LocalizationID,new Application(this.ApplicationID), product ?? (this.ProductID.HasValue ? new Product(this.ProductID.Value) : null), translation ?? new Translation(this.TranslationID), this.Updated,this.Created); 
		}
		public Localization CreateInstance(Application application, Product product, Translation translation)  
		{ 
			if (!this.HasData) return null;
			return new Localization(this.LocalizationID,application ?? new Application(this.ApplicationID), product ?? (this.ProductID.HasValue ? new Product(this.ProductID.Value) : null), translation ?? new Translation(this.TranslationID), this.Updated,this.Created); 
		}
		

  }
}

