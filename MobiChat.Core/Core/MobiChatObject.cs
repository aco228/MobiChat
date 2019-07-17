using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;

namespace MobiChat.Data
{
  public abstract class MobiChatObject<DataManagerInterfaceType> 
    : DataObject<DataManagerInterfaceType>, IMobiChatObject
    where DataManagerInterfaceType : class, IDataManager
  {

    public new static DataManagerInterfaceType CreateManager()
    {
      return DataObject<DataManagerInterfaceType>.CreateManager() as DataManagerInterfaceType;
    }

    public MobiChatObject()
    {
    }

    public MobiChatObject(int id, DateTime updated, DateTime created, bool isEmpty)
      : base(id, updated, created, isEmpty)
    {
    }
  }

  public abstract class MobiChatObject : DataObject, IMobiChatObject
  {
    public MobiChatObject()
    {
    }

    public MobiChatObject(int id, DateTime updated, DateTime created, bool isEmpty)
      : base(id, updated, created, isEmpty)
    {
    }
  }
}

