using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface IIPCountryMapManager : IDataManager<IPCountryMap> 
  {
	

  }

  public partial class IPCountryMap : MobiChatObject<IIPCountryMapManager> 
  {
		private long _fromAddress = -1;
		private long _toAddress = -1;
		private string _twoLetterIsoCode = String.Empty;
		private Country _country;
		

		public long FromAddress{ get {return this._fromAddress; } set { this._fromAddress = value;} }
		public long ToAddress{ get {return this._toAddress; } set { this._toAddress = value;} }
		public string TwoLetterIsoCode{ get {return this._twoLetterIsoCode; } set { this._twoLetterIsoCode = value;} }
		public Country Country 
		{
			get
			{
				if (this._country != null &&
						this._country.IsEmpty)
					if (this.ConnectionContext != null)
						this._country = Country.CreateManager().LazyLoad(this.ConnectionContext, this._country.ID) as Country;
					else
						this._country = Country.CreateManager().LazyLoad(this._country.ID) as Country;
				return this._country;
			}
			set { _country = value; }
		}

		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public IPCountryMap()
    { 
    }

    public IPCountryMap(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public IPCountryMap(int id,  long fromAddress, long toAddress, string twoLetterIsoCode, Country country, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._fromAddress = fromAddress;
			this._toAddress = toAddress;
			this._twoLetterIsoCode = twoLetterIsoCode;
			this._country = country;
			
    }

    public override object Clone(bool deepClone)
    {
      return new IPCountryMap(-1, this.FromAddress, this.ToAddress, this.TwoLetterIsoCode, this.Country, DateTime.Now, DateTime.Now);
      return null;
    }
  }
}

