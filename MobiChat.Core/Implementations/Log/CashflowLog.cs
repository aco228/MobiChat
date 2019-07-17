using Cashflow.Client.Diagnostics.Log;
using log4net;
using MobiChat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat
{
  public class CashflowLog : CashflowClientLogWriter
  {
    #region #logging#
    private static ILog _log = null;

    protected static ILog Log
    {
      get
      {
        if (CashflowLog._log == null)
          CashflowLog._log = LogManager.GetLogger(typeof(CashflowLog));
        return CashflowLog._log;
      }
    }
    #endregion

    private Service _service = null;

    public Service Service { get { return this._service; } }

    public CashflowLog(Service service)
      : base()
    {
      this._service = service;
    }

    public CashflowLog()
      : base()
    {
    }

    public override void LogRequest(string message)
    {
      Log.Warn(string.Format("CASHFLOW_REQUEST:: " + message));
    }

    public override void LogResponse(string message)
    {
      Log.Warn(string.Format("CASHFLOW_RESPONSE:: " + message));
    }
  }
}
