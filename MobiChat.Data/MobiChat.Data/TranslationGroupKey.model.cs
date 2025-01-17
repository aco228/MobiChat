using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface ITranslationGroupKeyManager : IDataManager<TranslationGroupKey> 
  {
	

  }

  public partial class TranslationGroupKey : MobiChatObject<ITranslationGroupKeyManager> 
  {
		private TranslationGroup _translationGroup;
		private string _name = String.Empty;
		private string _comment = String.Empty;
		

		public TranslationGroup TranslationGroup 
		{
			get
			{
				if (this._translationGroup != null &&
						this._translationGroup.IsEmpty)
					if (this.ConnectionContext != null)
						this._translationGroup = TranslationGroup.CreateManager().LazyLoad(this.ConnectionContext, this._translationGroup.ID) as TranslationGroup;
					else
						this._translationGroup = TranslationGroup.CreateManager().LazyLoad(this._translationGroup.ID) as TranslationGroup;
				return this._translationGroup;
			}
			set { _translationGroup = value; }
		}

		public string Name{ get {return this._name; } set { this._name = value;} }
		public string Comment{ get {return this._comment; } set { this._comment = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public TranslationGroupKey()
    { 
    }

    public TranslationGroupKey(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public TranslationGroupKey(int id,  TranslationGroup translationGroup, string name, string comment, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._translationGroup = translationGroup;
			this._name = name;
			this._comment = comment;
			
    }

    public override object Clone(bool deepClone)
    {
      return new TranslationGroupKey(-1,  this.TranslationGroup,this.Name,this.Comment, DateTime.Now, DateTime.Now);
    }
  }
}

