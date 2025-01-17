using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface ITranslationValueManager : IDataManager<TranslationValue> 
  {
	

  }

  public partial class TranslationValue : MobiChatObject<ITranslationValueManager> 
  {
		private TranslationKey _translationKey;
		private TranslationGroupKey _translationGroupKey;
		private string _value = String.Empty;
		

		public TranslationKey TranslationKey 
		{
			get
			{
				if (this._translationKey != null &&
						this._translationKey.IsEmpty)
					if (this.ConnectionContext != null)
						this._translationKey = TranslationKey.CreateManager().LazyLoad(this.ConnectionContext, this._translationKey.ID) as TranslationKey;
					else
						this._translationKey = TranslationKey.CreateManager().LazyLoad(this._translationKey.ID) as TranslationKey;
				return this._translationKey;
			}
			set { _translationKey = value; }
		}

		public TranslationGroupKey TranslationGroupKey 
		{
			get
			{
				if (this._translationGroupKey != null &&
						this._translationGroupKey.IsEmpty)
					if (this.ConnectionContext != null)
						this._translationGroupKey = TranslationGroupKey.CreateManager().LazyLoad(this.ConnectionContext, this._translationGroupKey.ID) as TranslationGroupKey;
					else
						this._translationGroupKey = TranslationGroupKey.CreateManager().LazyLoad(this._translationGroupKey.ID) as TranslationGroupKey;
				return this._translationGroupKey;
			}
			set { _translationGroupKey = value; }
		}

		public string Value{ get {return this._value; } set { this._value = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public TranslationValue()
    { 
    }

    public TranslationValue(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public TranslationValue(int id,  TranslationKey translationKey, TranslationGroupKey translationGroupKey, string value, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._translationKey = translationKey;
			this._translationGroupKey = translationGroupKey;
			this._value = value;
			
    }

    public override object Clone(bool deepClone)
    {
      return new TranslationValue(-1,  this.TranslationKey, this.TranslationGroupKey,this.Value, DateTime.Now, DateTime.Now);
    }
  }
}

