using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MobiChat.Web.Data;
using MobiChat.Data;
using Senti.Data; 

namespace MobiChat.Web.Data 
{
  public partial interface IMessageManager 
  {
    
    List<Message> Load(Customer customer);
    List<Message> Load(IConnectionInfo connection, Customer customer);

    List<Message> Load(Customer customer, MessageType messageType);
    List<Message> Load(IConnectionInfo connection, Customer customer, MessageType messageType);

    
    Message Load(Guid messageGuid);
    Message Load(IConnectionInfo connection, Guid messageGuid);









  }

  public partial class Message
  {
  }
}

