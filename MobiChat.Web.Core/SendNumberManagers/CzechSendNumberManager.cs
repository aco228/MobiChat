using log4net;
using MobiChat.Core;
using MobiChat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Web.Core
{
  public class CzechSendNumberManager : SendNumberBase
  {

    #region #logging#

    private static ILog _log = null;

    protected static ILog Log
    {
      get
      {
        if (CzechSendNumberManager._log == null)
          CzechSendNumberManager._log = LogManager.GetLogger(typeof(CzechSendNumberManager));
        return CzechSendNumberManager._log;
      }
    }

    #endregion #logging#

    public CzechSendNumberManager(ServiceSendNumberMap map)
      : base(map)
    {

    }
    
    public override bool TryParseMobileOperator()
    {
      if (!this.Msisnd.StartsWith("420"))
        this.Msisnd = "420" + this.Msisnd;

      // TMObile
      if (this.Msisnd.StartsWith("42073") ||
          this.Msisnd.StartsWith("420603") ||
          this.Msisnd.StartsWith("420604") ||
          this.Msisnd.StartsWith("420605"))
      {
        this.MobileOperator = MobileOperator.CreateManager().Load(50);
        return false;
      }

      // O2
      else if (this.Msisnd.StartsWith("42072") ||
               this.Msisnd.StartsWith("42070") ||
               this.Msisnd.StartsWith("420601") ||
               this.Msisnd.StartsWith("420602") ||
               this.Msisnd.StartsWith("420606") ||
               this.Msisnd.StartsWith("420607"))
      {
        this.MobileOperator = MobileOperator.CreateManager().Load(49);
        return false;
      }

      // VODAFONE
      else if (this.Msisnd.StartsWith("42077") ||
               this.Msisnd.StartsWith("420608"))
      {
        this.MobileOperator = MobileOperator.CreateManager().Load(53);
        return false;
      }

      // Ufone
      else if (this.Msisnd.StartsWith("42079"))
      {
        this.MobileOperator = MobileOperator.CreateManager().Load(52);
        return false;
      }

      Log.Error("ISendNumber:: MobileOperator is not loaded for some reason (" + this.Msisnd + ")");
      this.Status = false;
      this.Message = this.ErrorMessage;
      return true;
    }

  }
}
