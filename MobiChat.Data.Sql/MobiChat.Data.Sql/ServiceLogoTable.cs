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
  public class ServiceLogoTable : TableBase<ServiceLogo>
  {
    public static string GetColumnNames()
    {
      return TableBase<ServiceLogo>.GetColumnNames(string.Empty, ServiceLogoTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<ServiceLogo>.GetColumnNames(tablePrefix, ServiceLogoTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription ServiceLogoID = new ColumnDescription("ServiceLogoID", 0, typeof(int));
			public static readonly ColumnDescription ServiceID = new ColumnDescription("ServiceID", 1, typeof(int));
			public static readonly ColumnDescription Data = new ColumnDescription("Data", 2, typeof(byte[]));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 3, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 4, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				ServiceLogoID,
				ServiceID,
				Data,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public ServiceLogoTable(SqlQuery query) : base(query) { }
    public ServiceLogoTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int ServiceLogoID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ServiceLogoID)); } }
		public int ServiceID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ServiceID)); } }
		
		public byte[] Data {
			 get
			{
				int index = this.GetIndex(Columns.Data);
				if (this.Reader.IsDBNull(index)) return null;
				long len = Reader.GetBytes(index, 0, null, 0, 0);
				Byte[] path = new Byte[len]; 
				Reader.GetBytes(index, 0, path, 0, (int)len);
				return path;
			}
		}

		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public ServiceLogo CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new ServiceLogo(this.ServiceLogoID,new Service(this.ServiceID), this.Data,this.Updated,this.Created); 
		}
		public ServiceLogo CreateInstance(Service service)  
		{ 
			if (!this.HasData) return null;
			return new ServiceLogo(this.ServiceLogoID,service ?? new Service(this.ServiceID), this.Data,this.Updated,this.Created); 
		}
		

  }
}

