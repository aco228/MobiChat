using Senti.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 

namespace MobiChat.Data 
{
  public partial interface IUserSessionManager 
  {
    List<UserSession> Load(DateTime? from, DateTime? to);
    List<UserSession> Load(IConnectionInfo connection, DateTime? from, DateTime? to);
    UserSession Load(Service service, Guid userSessionGuid);
    UserSession Load(IConnectionInfo connection, Service service, Guid userSessionGuid);
    //UserSession Load(Customer customer);
    //UserSession Load(IConnectionInfo connection, Customer customer);
    List<UserSession> Load(Customer customer, Service service); // treba li customer ili user?
    List<UserSession> Load(IConnectionInfo connection, Customer customer, Service service);


    UserSession Load(string ip, string pxid);
    UserSession Load(IConnectionInfo connection, string ip, string pxid);
  }

  public partial class UserSession
  {
  }
}

