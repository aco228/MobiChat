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
  public class TranslationValueTable : TableBase<TranslationValue>
  {
    public static string GetColumnNames()
    {
      return TableBase<TranslationValue>.GetColumnNames(string.Empty, TranslationValueTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<TranslationValue>.GetColumnNames(tablePrefix, TranslationValueTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription TranslationValueID = new ColumnDescription("TranslationValueID", 0, typeof(int));
			public static readonly ColumnDescription TranslationKeyID = new ColumnDescription("TranslationKeyID", 1, typeof(int));
			public static readonly ColumnDescription TranslationGroupKeyID = new ColumnDescription("TranslationGroupKeyID", 2, typeof(int));
			public static readonly ColumnDescription Value = new ColumnDescription("Value", 3, typeof(string));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 4, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 5, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				TranslationValueID,
				TranslationKeyID,
				TranslationGroupKeyID,
				Value,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public TranslationValueTable(SqlQuery query) : base(query) { }
    public TranslationValueTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int TranslationValueID { get { return this.Reader.GetInt32(this.GetIndex(Columns.TranslationValueID)); } }
		public int TranslationKeyID { get { return this.Reader.GetInt32(this.GetIndex(Columns.TranslationKeyID)); } }
		public int TranslationGroupKeyID { get { return this.Reader.GetInt32(this.GetIndex(Columns.TranslationGroupKeyID)); } }
		public string Value { get { return this.Reader.GetString(this.GetIndex(Columns.Value)); } }
		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public TranslationValue CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new TranslationValue(this.TranslationValueID,new TranslationKey(this.TranslationKeyID), new TranslationGroupKey(this.TranslationGroupKeyID), this.Value,this.Updated,this.Created); 
		}
		public TranslationValue CreateInstance(TranslationGroupKey translationGroupKey)  
		{ 
			if (!this.HasData) return null;
			return new TranslationValue(this.TranslationValueID,new TranslationKey(this.TranslationKeyID), translationGroupKey ?? new TranslationGroupKey(this.TranslationGroupKeyID), this.Value,this.Updated,this.Created); 
		}
		public TranslationValue CreateInstance(TranslationKey translationKey)  
		{ 
			if (!this.HasData) return null;
			return new TranslationValue(this.TranslationValueID,translationKey ?? new TranslationKey(this.TranslationKeyID), new TranslationGroupKey(this.TranslationGroupKeyID), this.Value,this.Updated,this.Created); 
		}
		public TranslationValue CreateInstance(TranslationKey translationKey, TranslationGroupKey translationGroupKey)  
		{ 
			if (!this.HasData) return null;
			return new TranslationValue(this.TranslationValueID,translationKey ?? new TranslationKey(this.TranslationKeyID), translationGroupKey ?? new TranslationGroupKey(this.TranslationGroupKeyID), this.Value,this.Updated,this.Created); 
		}
		

  }
}

