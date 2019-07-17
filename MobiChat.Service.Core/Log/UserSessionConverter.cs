using log4net.Layout.Pattern;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Service.Core.Log
{
  public class UserSessionConverter : PatternLayoutConverter
  {

    protected override void Convert(TextWriter writer, log4net.Core.LoggingEvent loggingEvent)
    {
      MobiContext context = MobiContext.Current;
      string id = context != null && context.SessionGuid != null ?
        context.SessionGuid.ToString() : Guid.Empty.ToString();
      writer.Write(id);
    }
  }
}
