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
  public class IPCountryMapTable : TableBase<IPCountryMap>
  {
    public static string GetColumnNames()
    {
      return TableBase<IPCountryMap>.GetColumnNames(string.Empty, IPCountryMapTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<IPCountryMap>.GetColumnNames(tablePrefix, IPCountryMapTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription IPCountryMapID = new ColumnDescription("IPCountryMapID", 0, typeof(int));
			public static readonly ColumnDescription FromAddress = new ColumnDescription("FromAddress", 1, typeof(int));
			public static readonly ColumnDescription ToAddress = new ColumnDescription("ToAddress", 2, typeof(int));
			public static readonly ColumnDescription TwoLetterIsoCode = new ColumnDescription("TwoLetterIsoCode", 3, typeof(string));
			public static readonly ColumnDescription CountryID = new ColumnDescription("CountryID", 4, typeof(int));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 5, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 6, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				IPCountryMapID,
				FromAddress,
				ToAddress,
				TwoLetterIsoCode,
				CountryID,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public IPCountryMapTable(SqlQuery query) : base(query) { }
    public IPCountryMapTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int IPCountryMapID { get { return this.Reader.GetInt32(this.GetIndex(Columns.IPCountryMapID)); } }
		public long FromAddress { get { return this.Reader.GetInt64(this.GetIndex(Columns.FromAddress)); } }
		public long ToAddress { get { return this.Reader.GetInt64(this.GetIndex(Columns.ToAddress)); } }
		public string TwoLetterIsoCode { get { return this.Reader.GetString(this.GetIndex(Columns.TwoLetterIsoCode)); } }
		
		public int? CountryID 
		{
			get
			{
				int index = this.GetIndex(Columns.CountryID);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetInt32(index);
			}
		}

		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public IPCountryMap CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new IPCountryMap(this.IPCountryMapID,this.FromAddress,this.ToAddress,this.TwoLetterIsoCode,(CountryID.HasValue ? new Country(this.CountryID.Value) : null), this.Updated,this.Created); 
		}
		public IPCountryMap CreateInstance(Country country)  
		{ 
			if (!this.HasData) return null;
			return new IPCountryMap(this.IPCountryMapID,this.FromAddress,this.ToAddress,this.TwoLetterIsoCode,country ?? (this.CountryID.HasValue ? new Country(this.CountryID.Value) : null), this.Updated,this.Created); 
		}
    //public IPCountryMap CreateInstance(Country country)  
    //{ 
    //  if (!this.HasData) return null;
    //  return new IPCountryMap(this.IPCountryMapID,this.FromAddress,this.ToAddress,this.TwoLetterIsoCode,country ?? (this.CountryID.HasValue ? new Country(this.CountryID.Value) : null), this.Updated,this.Created); 
    //}
		

  }
}

