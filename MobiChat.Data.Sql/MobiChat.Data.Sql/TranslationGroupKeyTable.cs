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
  public class TranslationGroupKeyTable : TableBase<TranslationGroupKey>
  {
    public static string GetColumnNames()
    {
      return TableBase<TranslationGroupKey>.GetColumnNames(string.Empty, TranslationGroupKeyTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<TranslationGroupKey>.GetColumnNames(tablePrefix, TranslationGroupKeyTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription TranslationGroupKeyID = new ColumnDescription("TranslationGroupKeyID", 0, typeof(int));
			public static readonly ColumnDescription TranslationGroupID = new ColumnDescription("TranslationGroupID", 1, typeof(int));
			public static readonly ColumnDescription Name = new ColumnDescription("Name", 2, typeof(string));
			public static readonly ColumnDescription Comment = new ColumnDescription("Comment", 3, typeof(string));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 4, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 5, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				TranslationGroupKeyID,
				TranslationGroupID,
				Name,
				Comment,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public TranslationGroupKeyTable(SqlQuery query) : base(query) { }
    public TranslationGroupKeyTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int TranslationGroupKeyID { get { return this.Reader.GetInt32(this.GetIndex(Columns.TranslationGroupKeyID)); } }
		public int TranslationGroupID { get { return this.Reader.GetInt32(this.GetIndex(Columns.TranslationGroupID)); } }
		public string Name { get { return this.Reader.GetString(this.GetIndex(Columns.Name)); } }
		
		public string Comment 
		{
			get
			{
				int index = this.GetIndex(Columns.Comment);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public TranslationGroupKey CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new TranslationGroupKey(this.TranslationGroupKeyID,new TranslationGroup(this.TranslationGroupID), this.Name,this.Comment,this.Updated,this.Created); 
		}
		public TranslationGroupKey CreateInstance(TranslationGroup translationGroup)  
		{ 
			if (!this.HasData) return null;
			return new TranslationGroupKey(this.TranslationGroupKeyID,translationGroup ?? new TranslationGroup(this.TranslationGroupID), this.Name,this.Comment,this.Updated,this.Created); 
		}
		

  }
}

