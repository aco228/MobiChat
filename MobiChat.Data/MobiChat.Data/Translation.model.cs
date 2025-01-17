using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface ITranslationManager : IDataManager<Translation> 
  {
	

  }

  public partial class Translation : MobiChatObject<ITranslationManager> 
  {
		private TranslationType _translationType;
		private string _name = String.Empty;
		private string _description = String.Empty;
		

		public TranslationType TranslationType 
		{
			get
			{
				if (this._translationType != null &&
						this._translationType.IsEmpty)
					if (this.ConnectionContext != null)
						this._translationType = TranslationType.CreateManager().LazyLoad(this.ConnectionContext, this._translationType.ID) as TranslationType;
					else
						this._translationType = TranslationType.CreateManager().LazyLoad(this._translationType.ID) as TranslationType;
				return this._translationType;
			}
			set { _translationType = value; }
		}

		public string Name{ get {return this._name; } set { this._name = value;} }
		public string Description{ get {return this._description; } set { this._description = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public Translation()
    { 
    }

    public Translation(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public Translation(int id,  TranslationType translationType, string name, string description, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._translationType = translationType;
			this._name = name;
			this._description = description;
			
    }

    public override object Clone(bool deepClone)
    {
      return new Translation(-1,  this.TranslationType,this.Name,this.Description, DateTime.Now, DateTime.Now);
    }
  }
}

