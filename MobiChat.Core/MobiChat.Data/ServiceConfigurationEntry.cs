using Senti.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 

namespace MobiChat.Data 
{
  public partial interface IServiceConfigurationEntryManager 
  {
    
    List<ServiceConfigurationEntry> Load(Service service);
    List<ServiceConfigurationEntry> Load(IConnectionInfo connection, Service service);
    
    ServiceConfigurationEntry Load(Service service, Country country);
    ServiceConfigurationEntry Load(IConnectionInfo connection, Service service, Country country);

    
    ServiceConfigurationEntry Load(Service service, Country country, MobileOperator mobileOperator);
    ServiceConfigurationEntry Load(IConnectionInfo connection, Service service, Country country, MobileOperator mobileOperator);

    
    ServiceConfigurationEntry Load(string keyword, int shortcode, Country country);
    ServiceConfigurationEntry Load(IConnectionInfo connection, string keyword, int shortcode, Country country);









    
  }

  public partial class ServiceConfigurationEntry
  {
  }
}

