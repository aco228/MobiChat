﻿using log4net.Layout.Pattern;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Web.Core.Log
{
  public class UserSessionConverter : PatternLayoutConverter
  {
    protected override void Convert(TextWriter writer, log4net.Core.LoggingEvent loggingEvent)
    {
      MobiContext context = MobiContext.GetExisting();
      string id = context != null && context.Session != null && context.Session.SessionData != null ?
        context.Session.SessionData.ID.ToString() : "0";

      writer.Write(id);
    }
  }
}
