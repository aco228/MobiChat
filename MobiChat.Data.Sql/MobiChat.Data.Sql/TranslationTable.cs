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
  public class TranslationTable : TableBase<Translation>
  {
    public static string GetColumnNames()
    {
      return TableBase<Translation>.GetColumnNames(string.Empty, TranslationTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<Translation>.GetColumnNames(tablePrefix, TranslationTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription TranslationID = new ColumnDescription("TranslationID", 0, typeof(int));
			public static readonly ColumnDescription TranslationTypeID = new ColumnDescription("TranslationTypeID", 1, typeof(int));
			public static readonly ColumnDescription Name = new ColumnDescription("Name", 2, typeof(string));
			public static readonly ColumnDescription Description = new ColumnDescription("Description", 3, typeof(string));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 4, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 5, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				TranslationID,
				TranslationTypeID,
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

    public TranslationTable(SqlQuery query) : base(query) { }
    public TranslationTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int TranslationID { get { return this.Reader.GetInt32(this.GetIndex(Columns.TranslationID)); } }
		public int TranslationTypeID { get { return this.Reader.GetInt32(this.GetIndex(Columns.TranslationTypeID)); } }
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
		

	  public Translation CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new Translation(this.TranslationID,new TranslationType(this.TranslationTypeID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Translation CreateInstance(TranslationType translationType)  
		{ 
			if (!this.HasData) return null;
			return new Translation(this.TranslationID,translationType ?? new TranslationType(this.TranslationTypeID), this.Name,this.Description,this.Updated,this.Created); 
		}
		

  }
}

