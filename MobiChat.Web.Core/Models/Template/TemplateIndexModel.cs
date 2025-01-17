﻿using MobiChat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Web.Core.Models.Template
{
  public class TemplateIndexModel : TemplateModelBase
  {

    private Service _service = null;
    private bool _extendedAccess = false;
    //private TemplateServiceInfo _info = null;
    //private TemplateServiceNote _note = null;
    private int _userSessions = 0;
    private int _transactions = 0;
    private int _activeUserSessions = 0;

    public Service Service { get { return this._service; } }
    public bool ExtendedAccess { get { return this._extendedAccess; } }
    //public string Contact { get { return this._info != null ? this._info.Contact : string.Empty; } }
    //public string Price { get { return this._info != null ? this._info.Price : string.Empty; } }
    //public string NoteDate { get { return this._note != null ? this._note.Created.ToString() : string.Empty; } }
    //public string NoteText { get { return this._note != null ? this._note.Text : string.Empty; } }
    public string UserSessions { get { return this._userSessions.ToString(); } }
    public string Transactions { get { return this._transactions.ToString(); } }

    public string UserSessionTransactions
    {
      get
      {
        if (this._userSessions == 0 || this._activeUserSessions == 0) return "0";
        return Math.Round((((double)100 / (double)this._userSessions) * (double)this._transactions), 2, MidpointRounding.AwayFromZero).ToString();
      }
    }
    public string ActiveUserSessions { get { return this._activeUserSessions.ToString(); } }

    public TemplateIndexModel(MobiContext context, bool extenderAccess)
      : base(context, extenderAccess)
    {
      this._service = context.Service.ServiceData;

      //this._info = TemplateServiceInfo.CreateManager().Load(this._service);
      //this._note = TemplateServiceNote.CreateManager().Load(this._service, 1).FirstOrDefault();

      //this._transactions = DirectTransactionTable.TransactionCount(this.Context.Service.ServiceData);
      //this._userSessions = DirectUserSessionTable.UserSessionCount(this.Context.Service.ServiceData);
      //this._activeUserSessions = DirectUserSessionTable.UserSessionsActive(this.Context.Service.ServiceData);
    }

  }
}
