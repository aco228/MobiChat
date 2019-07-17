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
    List<UserSession> Load(User user, Service service); 
    List<UserSession> Load(IConnectionInfo connection, User user, Service service);
    
    UserSession Load(Guid userSessionGuid);
    UserSession Load(IConnectionInfo connection, Guid userSessionGuid);



    UserSession Load(string ip, string pxid);
    UserSession Load(IConnectionInfo connection, string ip, string pxid);
  }

  public partial class UserSession
  {

    public IUserSession Instantiate(IService service)
    {
      return this.UserSessionType.Instantiate(service, this);
    }
    
  }
}

