using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Senti.Data;

 

namespace MobiChat.Data 
{
  public partial interface IPaymentCredentialsManager 
  {
    List<PaymentCredentials> Load();
    List<PaymentCredentials> Load(IConnectionInfo connection);
  }

  public partial class PaymentCredentials
  {
  }
}

