using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface ILanguageManager : IDataManager<Language> 
  {
	

  }

  public partial class Language : MobiChatObject<ILanguageManager> 
  {
		private string _globalName = String.Empty;
		private string _localName = String.Empty;
		private string _charset = String.Empty;
		private string _twoLetterIsoCode = String.Empty;
		private bool _isSupported = false;
		

		public string GlobalName{ get {return this._globalName; } set { this._globalName = value;} }
		public string LocalName{ get {return this._localName; } set { this._localName = value;} }
		public string Charset{ get {return this._charset; } set { this._charset = value;} }
		public string TwoLetterIsoCode{ get {return this._twoLetterIsoCode; } set { this._twoLetterIsoCode = value;} }
		public bool IsSupported {get {return this._isSupported; } set { this._isSupported = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public Language()
    { 
    }

    public Language(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public Language(int id,  string globalName, string localName, string charset, string twoLetterIsoCode, bool isSupported, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._globalName = globalName;
			this._localName = localName;
			this._charset = charset;
			this._twoLetterIsoCode = twoLetterIsoCode;
			this._isSupported = isSupported;
			
    }

    public override object Clone(bool deepClone)
    {
      return new Language(-1, this.GlobalName,this.LocalName,this.Charset,this.TwoLetterIsoCode,this.IsSupported, DateTime.Now, DateTime.Now);
    }
  }
}

