using log4net;
using MobiChat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Web.Core
{
  public class SwitzerlandSendNumberManager : SendNumberBase
  {

    #region #logging#

    private static ILog _log = null;

    protected static ILog Log
    {
      get
      {
        if (SwitzerlandSendNumberManager._log == null)
          SwitzerlandSendNumberManager._log = LogManager.GetLogger(typeof(SwitzerlandSendNumberManager));
        return SwitzerlandSendNumberManager._log;
      }
    }

    #endregion #logging#

    public SwitzerlandSendNumberManager(ServiceSendNumberMap map)
    : base(map)
    {

    }

    //Wikipedia(
    //Swisscomm 75,79
    //Sunrise 76
    //Salt/Orange 78)


    public override bool TryParseMobileOperator()
    {
      if (!this.Msisnd.StartsWith("41"))
        this.Msisnd = "41" + this.Msisnd;


      //SimTest: Swisscom 0041787472088, Swisscom2 0041797745371  
      if (this.Msisnd.StartsWith("4177") ||
          this.Msisnd.StartsWith("4179"))
      {
        this.MobileOperator = MobileOperator.CreateManager().Load(322);
        return false;
      }


      ///SimTest: CH_Salt 0041765005727  , DB: Orange
      else if (this.Msisnd.StartsWith("4178"))
      {
        this.MobileOperator = MobileOperator.CreateManager().Load(321);
        return false;
      }


      //SimTest : Ch Sunrise : 41795541571
      else if (this.Msisnd.StartsWith("4176"))
      {
        this.MobileOperator = MobileOperator.CreateManager().Load(318);
        return false;
      }

      Log.Error("ISendNumber:: MobileOperator is not loaded for some reason (" + this.Msisnd + ")");
      this.Status = false;
      this.Message = this.ErrorMessage;
      return true;

    }
  }
}
