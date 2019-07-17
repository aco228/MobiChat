using MobiChat.Data;
using MobiChat.Web.Core;
using MobiChat.Web.Core.Filters;
using MobiChat.Web.Core.Models.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobiChat.Web.Controllers
{
  public partial class TemplateController : MobiController
  {
    
    public string Service()
    {
      Report.SendLiveReport("test", "someone came to test");
      return "";
    }

  }
}