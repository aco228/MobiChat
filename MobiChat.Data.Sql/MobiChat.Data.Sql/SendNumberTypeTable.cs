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
  public class SendNumberTypeTable : TableBase<SendNumberType>
  {
    public static string GetColumnNames()
    {
      return TableBase<SendNumberType>.GetColumnNames(string.Empty, SendNumberTypeTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<SendNumberType>.GetColumnNames(tablePrefix, SendNumberTypeTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription SendNumberTypeID = new ColumnDescription("SendNumberTypeID", 0, typeof(int));
			public static readonly ColumnDescription Name = new ColumnDescription("Name", 1, typeof(string));
			public static readonly ColumnDescription TypeName = new ColumnDescription("TypeName", 2, typeof(string));
			public static readonly ColumnDescription Description = new ColumnDescription("Description", 3, typeof(string));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 4, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 5, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				SendNumberTypeID,
				Name,
				TypeName,
				Description,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public SendNumberTypeTable(SqlQuery query) : base(query) { }
    public SendNumberTypeTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int SendNumberTypeID { get { return this.Reader.GetInt32(this.GetIndex(Columns.SendNumberTypeID)); } }
		public string Name { get { return this.Reader.GetString(this.GetIndex(Columns.Name)); } }
		public string TypeName { get { return this.Reader.GetString(this.GetIndex(Columns.TypeName)); } }
		
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
		

	  public SendNumberType CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new SendNumberType(this.SendNumberTypeID,this.Name,this.TypeName,this.Description,this.Updated,this.Created); 
		}
		

  }
}

