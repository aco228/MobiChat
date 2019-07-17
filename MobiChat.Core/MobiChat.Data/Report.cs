using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

 

namespace MobiChat.Data 
{
  public partial interface IReportManager 
  {
  }

  public partial class Report
  {
    #region #logging#

    private static ILog _log = null;

    protected static ILog Log
    {
      get
      {
        if (Report._log == null)
          Report._log = LogManager.GetLogger(typeof(Report));
        return Report._log;
      }
    }

    #endregion #logging#

    public string Url = string.Empty;

    public static void TryReportPxid(HttpRequest request)
    {
      Report.TryReportPxid(request["pxid"]);
    }
        
    public static void TryReportPxid(string pxid)
    {
      int intPxid = -1;
      if (string.IsNullOrEmpty(pxid) || !Int32.TryParse(pxid, out intPxid))
        return;

      Report.SendReport("pxid", intPxid, string.Empty);
    }

    public static void SendReport(string group, string data)
    {
      Report.SendReport(group, null, data);
    }

    public static void SendReport(string group, int? pxid, string data)
    {
      ReportLinkGroup linkGroup = ReportLinkGroup.CreateManager().Load(group);
      if (group == null)
        return;

      List<ReportLink> links = ReportLink.CreateManager().Load(linkGroup);
      foreach(ReportLink link in links)
      {
        if (!link.IsActive)
          continue;

        string url = link.Url.Replace("[pxid]", pxid.ToString()).Replace("[data]", data);
        Log.Info("REPORT: url:" + url);

        Report report = new Report(-1, link, pxid, data, DateTime.Now, DateTime.Now);
        report.Url = url;
        Task.Factory.StartNew(report.SendRequest);
        report.Insert();
      }
    }

    public static void SendLiveReport(string klass, string text)
    {
      ReportLinkGroup group = ReportLinkGroup.CreateManager().Load("live");
      ReportLink link = ReportLink.CreateManager().Load(group).FirstOrDefault();
      if(link == null)
        return;

      string url = link.Url.Replace("[data]", text).Replace("[klass]", klass);

      Report report = new Report(-1, link, null, url, DateTime.Now, DateTime.Now);
      report.Url = url;
      Task.Factory.StartNew(report.SendRequest);
      report.Insert();
    }

    public void SendRequest()
    {
      try
      {
        WebRequest wssRequest = WebRequest.Create(this.Url);
        wssRequest.Method = "GET";
        WebResponse wssResponse = wssRequest.GetResponse();
        StreamReader ssReader = new StreamReader(wssResponse.GetResponseStream());
        wssResponse.Close();
        ssReader.Close();
        Log.Info("Report sent to " + this.Url);
      }
      catch(Exception e)
      {
        Log.Error("Fatal error on ShortMessage:SendRequest", e);
      }
    }

  }
}

