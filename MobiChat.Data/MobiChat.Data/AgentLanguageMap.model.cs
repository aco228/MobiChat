using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface IAgentLanguageMapManager : IDataManager<AgentLanguageMap> 
  {
	

  }

  public partial class AgentLanguageMap : MobiChatObject<IAgentLanguageMapManager> 
  {
		private Agent _agent;
		private Language _language;
		private bool _isActive = false;
		

		public Agent Agent 
		{
			get
			{
				if (this._agent != null &&
						this._agent.IsEmpty)
					if (this.ConnectionContext != null)
						this._agent = Agent.CreateManager().LazyLoad(this.ConnectionContext, this._agent.ID) as Agent;
					else
						this._agent = Agent.CreateManager().LazyLoad(this._agent.ID) as Agent;
				return this._agent;
			}
			set { _agent = value; }
		}

		public Language Language 
		{
			get
			{
				if (this._language != null &&
						this._language.IsEmpty)
					if (this.ConnectionContext != null)
						this._language = Language.CreateManager().LazyLoad(this.ConnectionContext, this._language.ID) as Language;
					else
						this._language = Language.CreateManager().LazyLoad(this._language.ID) as Language;
				return this._language;
			}
			set { _language = value; }
		}

		public bool IsActive {get {return this._isActive; } set { this._isActive = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public AgentLanguageMap()
    { 
    }

    public AgentLanguageMap(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public AgentLanguageMap(int id,  Agent agent, Language language, bool isActive, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._agent = agent;
			this._language = language;
			this._isActive = isActive;
			
    }

    public override object Clone(bool deepClone)
    {
      return new AgentLanguageMap(-1,  this.Agent, this.Language,this.IsActive, DateTime.Now, DateTime.Now);
    }
  }
}

