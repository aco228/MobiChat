using MobiChat.Core;
using Senti.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 

namespace MobiChat.Data 
{
  public partial interface IServiceSendNumberMapManager 
  {
    
    List<ServiceSendNumberMap> Load(Service service);
    List<ServiceSendNumberMap> Load(IConnectionInfo connection, Service service);

  }

  public partial class ServiceSendNumberMap
  {
    private List<string> _smsMessages = null;

    public List<string> SmsMessages
    {
      get
      {
        if (this._smsMessages != null)
          return this._smsMessages;

        this._smsMessages = this.Messages.Split('|').ToList();
        return this._smsMessages;
      }
    }

    public void AddCustomMessage(string message)
    {
      object dummy;
      if(this._smsMessages == null)
        dummy = this.SmsMessages;

      this._smsMessages.Add(message);
    }

    public ISendNumber Instantiate()
    {
      return this.SendNumberType.Instantiate(this);
    }

  }
}

