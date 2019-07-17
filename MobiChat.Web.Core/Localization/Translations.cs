using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobiChat.Web.Core.Localization;

namespace MobiChat.Web.Core
{

  public static class Translations
  {
    public static MobiChatWebLocalization Web { get { return MobiContext.Current.GetLocalization() as MobiChatWebLocalization; } }
  }

}
