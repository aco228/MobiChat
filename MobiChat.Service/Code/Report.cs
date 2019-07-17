using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace MobiChat.Service.Code
{
  public static class Report
  {
    public static void Call(string url)
    {
      WebRequest wssRequest = WebRequest.Create(url);
      wssRequest.Method = "GET";
      WebResponse wssResponse = wssRequest.GetResponse();
      StreamReader ssReader = new StreamReader(wssResponse.GetResponseStream());

      wssResponse.Close();
      ssReader.Close();
    }
  }
}