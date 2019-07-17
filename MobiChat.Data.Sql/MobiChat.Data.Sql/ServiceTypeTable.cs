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
  public class ServiceTypeTable : TableBase<ServiceType>
  {
    public static string GetColumnNames()
    {
      return TableBase<ServiceType>.GetColumnNames(string.Empty, ServiceTypeTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<ServiceType>.GetColumnNames(tablePrefix, ServiceTypeTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription ServiceTypeID = new ColumnDescription("ServiceTypeID", 0, typeof(int));
			public static readonly ColumnDescription Name = new ColumnDescription("Name", 1, typeof(string));
			public static readonly ColumnDescription TypeName = new ColumnDescription("TypeName", 2, typeof(string));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 3, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 4, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				ServiceTypeID,
				Name,
				TypeName,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public ServiceTypeTable(SqlQuery query) : base(query) { }
    public ServiceTypeTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int ServiceTypeID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ServiceTypeID)); } }
		public string Name { get { return this.Reader.GetString(this.GetIndex(Columns.Name)); } }
		public string TypeName { get { return this.Reader.GetString(this.GetIndex(Columns.TypeName)); } }
		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public ServiceType CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new ServiceType(this.ServiceTypeID,this.Name,this.TypeName,this.Updated,this.Created); 
		}
		

  }
}

