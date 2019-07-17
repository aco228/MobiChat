using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface ITranslationKeyManager : IDataManager<TranslationKey> 
  {
	

  }

  public partial class TranslationKey : MobiChatObject<ITranslationKeyManager> 
  {
		private TranslationKey _fallbackTranslationKey;
		private Translation _translation;
		private int? _languageID = -1;
		private Service _service;
		private string _name = String.Empty;
		

		public TranslationKey FallbackTranslationKey 
		{
			get
			{
				if (this._fallbackTranslationKey != null &&
						this._fallbackTranslationKey.IsEmpty)
					if (this.ConnectionContext != null)
						this._fallbackTranslationKey = TranslationKey.CreateManager().LazyLoad(this.ConnectionContext, this._fallbackTranslationKey.ID) as TranslationKey;
					else
						this._fallbackTranslationKey = TranslationKey.CreateManager().LazyLoad(this._fallbackTranslationKey.ID) as TranslationKey;
				return this._fallbackTranslationKey;
			}
			set { _fallbackTranslationKey = value; }
		}

		public Translation Translation 
		{
			get
			{
				if (this._translation != null &&
						this._translation.IsEmpty)
					if (this.ConnectionContext != null)
						this._translation = Translation.CreateManager().LazyLoad(this.ConnectionContext, this._translation.ID) as Translation;
					else
						this._translation = Translation.CreateManager().LazyLoad(this._translation.ID) as Translation;
				return this._translation;
			}
			set { _translation = value; }
		}

		public int? LanguageID{ get {return this._languageID; } set { this._languageID = value;} }
		public Service Service 
		{
			get
			{
				if (this._service != null &&
						this._service.IsEmpty)
					if (this.ConnectionContext != null)
						this._service = Service.CreateManager().LazyLoad(this.ConnectionContext, this._service.ID) as Service;
					else
						this._service = Service.CreateManager().LazyLoad(this._service.ID) as Service;
				return this._service;
			}
			set { _service = value; }
		}

		public string Name{ get {return this._name; } set { this._name = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public TranslationKey()
    { 
    }

    public TranslationKey(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public TranslationKey(int id,  TranslationKey fallbackTranslationKey, Translation translation, int? languageID, Service service, string name, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._fallbackTranslationKey = fallbackTranslationKey;
			this._translation = translation;
			this._languageID = languageID;
			this._service = service;
			this._name = name;
			
    }

    public override object Clone(bool deepClone)
    {
      return new TranslationKey(-1,  this.FallbackTranslationKey, this.Translation,this.LanguageID, this.Service,this.Name, DateTime.Now, DateTime.Now);
    }
  }
}

