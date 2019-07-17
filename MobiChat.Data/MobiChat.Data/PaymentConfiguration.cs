using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Senti.Data;
 

namespace MobiChat.Data 
{
  public partial interface IPaymentConfigurationManager 
  {
    List<PaymentConfiguration> Load();
    List<PaymentConfiguration> Load(IConnectionInfo connection);

    PaymentConfiguration Load(BehaviorModel behaviorModel);
    PaymentConfiguration Load(IConnectionInfo connection, BehaviorModel behaviorModel);

    PaymentConfiguration Load(string name);
    PaymentConfiguration Load(IConnectionInfo connection, string name);
  }

  public partial class PaymentConfiguration
  {
  }
}

