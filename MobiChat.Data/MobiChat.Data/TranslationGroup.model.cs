using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface ITranslationGroupManager : IDataManager<TranslationGroup> 
  {
	

  }

  public partial class TranslationGroup : MobiChatObject<ITranslationGroupManager> 
  {
		private Translation _translation;
		private string _name = String.Empty;
		private string _comment = String.Empty;
		

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

		public string Name{ get {return this._name; } set { this._name = value;} }
		public string Comment{ get {return this._comment; } set { this._comment = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public TranslationGroup()
    { 
    }

    public TranslationGroup(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public TranslationGroup(int id,  Translation translation, string name, string comment, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._translation = translation;
			this._name = name;
			this._comment = comment;
			
    }

    public override object Clone(bool deepClone)
    {
      return new TranslationGroup(-1,  this.Translation,this.Name,this.Comment, DateTime.Now, DateTime.Now);
    }
  }
}

