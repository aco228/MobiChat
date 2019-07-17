using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Senti.Data;
 

namespace MobiChat.Data 
{
  public partial interface IPaymentInterfaceManager 
  {
    List<PaymentInterface> Load();
    List<PaymentInterface> Load(IConnectionInfo connection);
    PaymentInterface Load(Guid value);
    PaymentInterface Load(IConnectionInfo connection, Guid value);
  }

  public partial class PaymentInterface
  {
  }
}

