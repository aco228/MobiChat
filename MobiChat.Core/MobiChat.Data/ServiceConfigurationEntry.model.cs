using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface IServiceConfigurationEntryManager : IDataManager<ServiceConfigurationEntry> 
  {
	

  }

  public partial class ServiceConfigurationEntry : MobiChatObject<IServiceConfigurationEntryManager> 
  {
		private ServiceConfiguration _serviceConfiguration;
		private int _countryID = -1;
		private int? _mobileOperatorID = -1;
		private int _shortcode = -1;
		private string _keyword = String.Empty;
		private bool _isAgeVerificationRequired = false;
		private bool _isActive = false;
		

		public ServiceConfiguration ServiceConfiguration 
		{
			get
			{
				if (this._serviceConfiguration != null &&
						this._serviceConfiguration.IsEmpty)
					if (this.ConnectionContext != null)
						this._serviceConfiguration = ServiceConfiguration.CreateManager().LazyLoad(this.ConnectionContext, this._serviceConfiguration.ID) as ServiceConfiguration;
					else
						this._serviceConfiguration = ServiceConfiguration.CreateManager().LazyLoad(this._serviceConfiguration.ID) as ServiceConfiguration;
				return this._serviceConfiguration;
			}
			set { _serviceConfiguration = value; }
		}

		public int CountryID{ get {return this._countryID; } set { this._countryID = value;} }
		public int? MobileOperatorID{ get {return this._mobileOperatorID; } set { this._mobileOperatorID = value;} }
		public int Shortcode{ get {return this._shortcode; } set { this._shortcode = value;} }
		public string Keyword{ get {return this._keyword; } set { this._keyword = value;} }
		public bool IsAgeVerificationRequired {get {return this._isAgeVerificationRequired; } set { this._isAgeVerificationRequired = value;} }
		public bool IsActive {get {return this._isActive; } set { this._isActive = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public ServiceConfigurationEntry()
    { 
    }

    public ServiceConfigurationEntry(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public ServiceConfigurationEntry(int id,  ServiceConfiguration serviceConfiguration, int countryID, int? mobileOperatorID, int shortcode, string keyword, bool isAgeVerificationRequired, bool isActive, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._serviceConfiguration = serviceConfiguration;
			this._countryID = countryID;
			this._mobileOperatorID = mobileOperatorID;
			this._shortcode = shortcode;
			this._keyword = keyword;
			this._isAgeVerificationRequired = isAgeVerificationRequired;
			this._isActive = isActive;
			
    }

    public override object Clone(bool deepClone)
    {
      return new ServiceConfigurationEntry(-1,  this.ServiceConfiguration,this.CountryID,this.MobileOperatorID,this.Shortcode,this.Keyword,this.IsAgeVerificationRequired,this.IsActive, DateTime.Now, DateTime.Now);
    }
  }
}

