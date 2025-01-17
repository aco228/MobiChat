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
  public class TranslationKeyTable : TableBase<TranslationKey>
  {
    public static string GetColumnNames()
    {
      return TableBase<TranslationKey>.GetColumnNames(string.Empty, TranslationKeyTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<TranslationKey>.GetColumnNames(tablePrefix, TranslationKeyTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription TranslationKeyID = new ColumnDescription("TranslationKeyID", 0, typeof(int));
			public static readonly ColumnDescription FallbackTranslationKeyID = new ColumnDescription("FallbackTranslationKeyID", 1, typeof(int));
			public static readonly ColumnDescription TranslationID = new ColumnDescription("TranslationID", 2, typeof(int));
			public static readonly ColumnDescription LanguageID = new ColumnDescription("LanguageID", 3, typeof(int));
			public static readonly ColumnDescription ServiceID = new ColumnDescription("ServiceID", 4, typeof(int));
			public static readonly ColumnDescription Name = new ColumnDescription("Name", 5, typeof(string));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 6, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 7, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				TranslationKeyID,
				FallbackTranslationKeyID,
				TranslationID,
				LanguageID,
				ServiceID,
				Name,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public TranslationKeyTable(SqlQuery query) : base(query) { }
    public TranslationKeyTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int TranslationKeyID { get { return this.Reader.GetInt32(this.GetIndex(Columns.TranslationKeyID)); } }
		
		public int? FallbackTranslationKeyID 
		{
			get
			{
				int index = this.GetIndex(Columns.FallbackTranslationKeyID);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetInt32(index);
			}
		}

		public int TranslationID { get { return this.Reader.GetInt32(this.GetIndex(Columns.TranslationID)); } }
		
		public int? LanguageID 
		{
			get
			{
				int index = this.GetIndex(Columns.LanguageID);
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

		public string Name { get { return this.Reader.GetString(this.GetIndex(Columns.Name)); } }
		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public TranslationKey CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new TranslationKey(this.TranslationKeyID,(FallbackTranslationKeyID.HasValue ? new TranslationKey(this.FallbackTranslationKeyID.Value) : null), new Translation(this.TranslationID), (LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), this.Name,this.Updated,this.Created); 
		}
		public TranslationKey CreateInstance(Language language)  
		{ 
			if (!this.HasData) return null;
			return new TranslationKey(this.TranslationKeyID,(FallbackTranslationKeyID.HasValue ? new TranslationKey(this.FallbackTranslationKeyID.Value) : null), new Translation(this.TranslationID), language ?? (this.LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), this.Name,this.Updated,this.Created); 
		}
		public TranslationKey CreateInstance(Service service)  
		{ 
			if (!this.HasData) return null;
			return new TranslationKey(this.TranslationKeyID,(FallbackTranslationKeyID.HasValue ? new TranslationKey(this.FallbackTranslationKeyID.Value) : null), new Translation(this.TranslationID), (LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), this.Name,this.Updated,this.Created); 
		}
		public TranslationKey CreateInstance(Translation translation)  
		{ 
			if (!this.HasData) return null;
			return new TranslationKey(this.TranslationKeyID,(FallbackTranslationKeyID.HasValue ? new TranslationKey(this.FallbackTranslationKeyID.Value) : null), translation ?? new Translation(this.TranslationID), (LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), this.Name,this.Updated,this.Created); 
		}
		public TranslationKey CreateInstance(TranslationKey fallbackTranslationKey)  
		{ 
			if (!this.HasData) return null;
			return new TranslationKey(this.TranslationKeyID,fallbackTranslationKey ?? (this.FallbackTranslationKeyID.HasValue ? new TranslationKey(this.FallbackTranslationKeyID.Value) : null), new Translation(this.TranslationID), (LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), this.Name,this.Updated,this.Created); 
		}
		public TranslationKey CreateInstance(Language language, Service service)  
		{ 
			if (!this.HasData) return null;
			return new TranslationKey(this.TranslationKeyID,(FallbackTranslationKeyID.HasValue ? new TranslationKey(this.FallbackTranslationKeyID.Value) : null), new Translation(this.TranslationID), language ?? (this.LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), this.Name,this.Updated,this.Created); 
		}
		public TranslationKey CreateInstance(Translation translation, Language language)  
		{ 
			if (!this.HasData) return null;
			return new TranslationKey(this.TranslationKeyID,(FallbackTranslationKeyID.HasValue ? new TranslationKey(this.FallbackTranslationKeyID.Value) : null), translation ?? new Translation(this.TranslationID), language ?? (this.LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), this.Name,this.Updated,this.Created); 
		}
		public TranslationKey CreateInstance(TranslationKey fallbackTranslationKey, Language language)  
		{ 
			if (!this.HasData) return null;
			return new TranslationKey(this.TranslationKeyID,fallbackTranslationKey ?? (this.FallbackTranslationKeyID.HasValue ? new TranslationKey(this.FallbackTranslationKeyID.Value) : null), new Translation(this.TranslationID), language ?? (this.LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), this.Name,this.Updated,this.Created); 
		}
		public TranslationKey CreateInstance(Translation translation, Service service)  
		{ 
			if (!this.HasData) return null;
			return new TranslationKey(this.TranslationKeyID,(FallbackTranslationKeyID.HasValue ? new TranslationKey(this.FallbackTranslationKeyID.Value) : null), translation ?? new Translation(this.TranslationID), (LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), this.Name,this.Updated,this.Created); 
		}
		public TranslationKey CreateInstance(TranslationKey fallbackTranslationKey, Service service)  
		{ 
			if (!this.HasData) return null;
			return new TranslationKey(this.TranslationKeyID,fallbackTranslationKey ?? (this.FallbackTranslationKeyID.HasValue ? new TranslationKey(this.FallbackTranslationKeyID.Value) : null), new Translation(this.TranslationID), (LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), this.Name,this.Updated,this.Created); 
		}
		public TranslationKey CreateInstance(TranslationKey fallbackTranslationKey, Translation translation)  
		{ 
			if (!this.HasData) return null;
			return new TranslationKey(this.TranslationKeyID,fallbackTranslationKey ?? (this.FallbackTranslationKeyID.HasValue ? new TranslationKey(this.FallbackTranslationKeyID.Value) : null), translation ?? new Translation(this.TranslationID), (LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), this.Name,this.Updated,this.Created); 
		}
		public TranslationKey CreateInstance(Translation translation, Language language, Service service)  
		{ 
			if (!this.HasData) return null;
			return new TranslationKey(this.TranslationKeyID,(FallbackTranslationKeyID.HasValue ? new TranslationKey(this.FallbackTranslationKeyID.Value) : null), translation ?? new Translation(this.TranslationID), language ?? (this.LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), this.Name,this.Updated,this.Created); 
		}
		public TranslationKey CreateInstance(TranslationKey fallbackTranslationKey, Language language, Service service)  
		{ 
			if (!this.HasData) return null;
			return new TranslationKey(this.TranslationKeyID,fallbackTranslationKey ?? (this.FallbackTranslationKeyID.HasValue ? new TranslationKey(this.FallbackTranslationKeyID.Value) : null), new Translation(this.TranslationID), language ?? (this.LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), this.Name,this.Updated,this.Created); 
		}
		public TranslationKey CreateInstance(TranslationKey fallbackTranslationKey, Translation translation, Language language)  
		{ 
			if (!this.HasData) return null;
			return new TranslationKey(this.TranslationKeyID,fallbackTranslationKey ?? (this.FallbackTranslationKeyID.HasValue ? new TranslationKey(this.FallbackTranslationKeyID.Value) : null), translation ?? new Translation(this.TranslationID), language ?? (this.LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), this.Name,this.Updated,this.Created); 
		}
		public TranslationKey CreateInstance(TranslationKey fallbackTranslationKey, Translation translation, Service service)  
		{ 
			if (!this.HasData) return null;
			return new TranslationKey(this.TranslationKeyID,fallbackTranslationKey ?? (this.FallbackTranslationKeyID.HasValue ? new TranslationKey(this.FallbackTranslationKeyID.Value) : null), translation ?? new Translation(this.TranslationID), (LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), this.Name,this.Updated,this.Created); 
		}
		public TranslationKey CreateInstance(TranslationKey fallbackTranslationKey, Translation translation, Language language, Service service)  
		{ 
			if (!this.HasData) return null;
			return new TranslationKey(this.TranslationKeyID,fallbackTranslationKey ?? (this.FallbackTranslationKeyID.HasValue ? new TranslationKey(this.FallbackTranslationKeyID.Value) : null), translation ?? new Translation(this.TranslationID), language ?? (this.LanguageID.HasValue ? new Language(this.LanguageID.Value) : null), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), this.Name,this.Updated,this.Created); 
		}
		

  }
}

