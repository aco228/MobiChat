using MobiChat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Web.Core
{
  public class SlovakiaSendNumberManager : SendNumberBase
  {

    public SlovakiaSendNumberManager(ServiceSendNumberMap map)
      : base(map)
    {
      
    }

    public override bool TryParseMobileOperator()
    {
      if (!this.Msisnd.StartsWith("421"))
        this.Msisnd = "421" + this.Msisnd;

      // TMObile
      if (this.Msisnd.StartsWith("421901") ||
          this.Msisnd.StartsWith("421902") ||
          this.Msisnd.StartsWith("421903") ||
          this.Msisnd.StartsWith("421904") ||
          this.Msisnd.StartsWith("421910") ||
          this.Msisnd.StartsWith("421911") ||
          this.Msisnd.StartsWith("421912") ||
          this.Msisnd.StartsWith("421913") ||
          this.Msisnd.StartsWith("421914")
          )
      {
        this.MobileOperator = MobileOperator.CreateManager().Load(255);
        return false;
      }

      // Orange
      else if (this.Msisnd.StartsWith("421905") ||
               this.Msisnd.StartsWith("421906") ||
               this.Msisnd.StartsWith("421907") ||
               this.Msisnd.StartsWith("421908") ||
               this.Msisnd.StartsWith("421915") ||
               this.Msisnd.StartsWith("421916") ||
               this.Msisnd.StartsWith("421917") ||
               this.Msisnd.StartsWith("421918"))
      {
        this.MobileOperator = MobileOperator.CreateManager().Load(254);
        return false;
      }

      // O2
      else if (this.Msisnd.StartsWith("421940") ||
               this.Msisnd.StartsWith("421944") ||
               this.Msisnd.StartsWith("421948") ||
               this.Msisnd.StartsWith("421949"))
      {
        this.MobileOperator = MobileOperator.CreateManager().Load(253);
        return false;
      }

   

      Log.Error("ISendNumber:: MobileOperator is not loaded for some reason (" + this.Msisnd + ")");
      this.Status = false;
      this.Message = this.ErrorMessage;
      return true;

    }

  }
}
