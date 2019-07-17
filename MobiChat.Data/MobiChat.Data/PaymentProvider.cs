using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Senti.Data;
 

namespace MobiChat.Data 
{
  public partial interface IPaymentProviderManager 
  {
    List<PaymentProvider> Load();
    List<PaymentProvider> Load(IConnectionInfo connection);
    PaymentProvider Load(Guid value);
    PaymentProvider Load(IConnectionInfo connection, Guid value);
  }

  public partial class PaymentProvider
  {
  }
}

