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
  public class ServiceConfigurationEntryTable : TableBase<ServiceConfigurationEntry>
  {
    public static string GetColumnNames()
    {
      return TableBase<ServiceConfigurationEntry>.GetColumnNames(string.Empty, ServiceConfigurationEntryTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<ServiceConfigurationEntry>.GetColumnNames(tablePrefix, ServiceConfigurationEntryTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription ServiceConfigurationEntryID = new ColumnDescription("ServiceConfigurationEntryID", 0, typeof(int));
			public static readonly ColumnDescription ServiceConfigurationID = new ColumnDescription("ServiceConfigurationID", 1, typeof(int));
			public static readonly ColumnDescription CountryID = new ColumnDescription("CountryID", 2, typeof(int));
			public static readonly ColumnDescription MobileOperatorID = new ColumnDescription("MobileOperatorID", 3, typeof(int));
			public static readonly ColumnDescription Shortcode = new ColumnDescription("Shortcode", 4, typeof(int));
			public static readonly ColumnDescription Keyword = new ColumnDescription("Keyword", 5, typeof(string));
			public static readonly ColumnDescription IsAgeVerificationRequired = new ColumnDescription("IsAgeVerificationRequired", 6, typeof(bool));
			public static readonly ColumnDescription IsActive = new ColumnDescription("IsActive", 7, typeof(bool));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 8, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 9, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				ServiceConfigurationEntryID,
				ServiceConfigurationID,
				CountryID,
				MobileOperatorID,
				Shortcode,
				Keyword,
				IsAgeVerificationRequired,
				IsActive,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public ServiceConfigurationEntryTable(SqlQuery query) : base(query) { }
    public ServiceConfigurationEntryTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int ServiceConfigurationEntryID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ServiceConfigurationEntryID)); } }
		public int ServiceConfigurationID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ServiceConfigurationID)); } }
		public int CountryID { get { return this.Reader.GetInt32(this.GetIndex(Columns.CountryID)); } }
		
		public int? MobileOperatorID 
		{
			get
			{
				int index = this.GetIndex(Columns.MobileOperatorID);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetInt32(index);
			}
		}

		public int Shortcode { get { return this.Reader.GetInt32(this.GetIndex(Columns.Shortcode)); } }
		public string Keyword { get { return this.Reader.GetString(this.GetIndex(Columns.Keyword)); } }
		public bool IsAgeVerificationRequired { get { return this.Reader.GetBoolean(this.GetIndex(Columns.IsAgeVerificationRequired)); } }
		public bool IsActive { get { return this.Reader.GetBoolean(this.GetIndex(Columns.IsActive)); } }
		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public ServiceConfigurationEntry CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new ServiceConfigurationEntry(this.ServiceConfigurationEntryID,new ServiceConfiguration(this.ServiceConfigurationID), this.CountryID,this.MobileOperatorID,this.Shortcode,this.Keyword,this.IsAgeVerificationRequired,this.IsActive,this.Updated,this.Created); 
		}
		public ServiceConfigurationEntry CreateInstance(ServiceConfiguration serviceConfiguration)  
		{ 
			if (!this.HasData) return null;
			return new ServiceConfigurationEntry(this.ServiceConfigurationEntryID,serviceConfiguration ?? new ServiceConfiguration(this.ServiceConfigurationID), this.CountryID,this.MobileOperatorID,this.Shortcode,this.Keyword,this.IsAgeVerificationRequired,this.IsActive,this.Updated,this.Created); 
		}
		

  }
}

