using log4net;
using MobiChat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Web.Core
{
  public class AustriaSendNumberManager : SendNumberBase
  {

    #region #logging#

    private static ILog _log = null;

    protected static ILog Log
    {
      get
      {
        if (AustriaSendNumberManager._log == null)
          AustriaSendNumberManager._log = LogManager.GetLogger(typeof(AustriaSendNumberManager));
        return AustriaSendNumberManager._log;
      }
    }

    #endregion #logging#

    public AustriaSendNumberManager(ServiceSendNumberMap map)
      : base(map)
    {

    }

    public override bool TryParseMobileOperator()
    {
      //Country calling code
      if (!this.Msisnd.StartsWith("43"))
        this.Msisnd = "43" + this.Msisnd;

      //A1 MobilKom
      if (this.Msisnd.StartsWith("43664"))
      {
        this.MobileOperator = MobileOperator.CreateManager().Load(10);
        return false;
      }

      //H3G
      else if (this.Msisnd.StartsWith("43660"))
      {
        this.MobileOperator = MobileOperator.CreateManager().Load(13);
        return false;
      }

      //T-Mobile
      else if (this.Msisnd.StartsWith("43676") ||
               (this.Msisnd.StartsWith("43650"))) 
      {
        this.MobileOperator = MobileOperator.CreateManager().Load(11);
        return false;
      }

      //Tele2
      else if (this.Msisnd.StartsWith("43688"))
      {
        this.MobileOperator = MobileOperator.CreateManager().Load(17);
        return false;
      }

      //Tele2
      else if (this.Msisnd.StartsWith("43699"))
      {
        this.MobileOperator = MobileOperator.CreateManager().Load(14);
        return false;
      }

      Log.Error("ISend:: MobileOperator is not loaded for some reason (" + this.Msisnd + ")");
      this.Status = false;
      this.Message = this.ErrorMessage;
      return true;
    }

  }
}
