using MobiChat.Data;
using MobiChat.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Tests
{
  class Program
  {
    static void Main(string[] args)
    {

      Guid a;
      Guid.TryParse("940ab0ff1e9a4c00b79a1e28a4b72957", out a);
      return;

      MobiChat.Data.Sql.Database dummy = null;
      Senti.Data.DataLayerRuntime r = new Senti.Data.DataLayerRuntime();

      Service service = Service.CreateManager().Load(2);
      Customer customer = Customer.CreateManager().Load(91);
      List<Message> oldMessages = Message.CreateManager().Load(customer, MessageType.MT_Free);

      Console.WriteLine();
      Console.ReadKey();
    }

    public static Customer GetCustomer(string msisdn)
    {
      Service service = Service.CreateManager().Load(2);
      Customer customer = Customer.GetCustomerByMsisdn(service, msisdn);
      if (customer != null)
        return customer;


      customer = new Customer(-1,
        Guid.NewGuid(),
        null,
        service,
        service.FallbackCountry,
        service.FallbackLanguage,
        MobileOperator.CreateManager().Load(1),
        msisdn,
        string.Empty,
        DateTime.Now, DateTime.Now);
      //customer.Insert();

      return customer;
    }



  }
}
