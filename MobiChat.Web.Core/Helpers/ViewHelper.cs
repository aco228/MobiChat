using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Web.Core.Helpers
{
  public class ViewHelper
  {
    public static string Prepare(string input)
    {
      return input.Trim().Replace("\n", "<br/>").Replace("\r\n", "<br/>");
    }
  }

}
