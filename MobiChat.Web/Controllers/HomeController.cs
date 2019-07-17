using log4net;
using MobiChat.Core;
using MobiChat.Core.Implementations;
using MobiChat.Web.Core;
using MobiChat.Web.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobiChat.Web.Controllers
{
  public class HomeController : MobiController
  {
    #region #logging#

    private static ILog _log = null;

    protected static ILog Log
    {
      get
      {
        if (HomeController._log == null)
          HomeController._log = LogManager.GetLogger(typeof(HomeController));
        return HomeController._log;
      }
    }

    #endregion #logging#

    public ActionResult Index()
    {
      HomeListModel model = new HomeListModel(this.MobiContext);
      model.Content = MobiContext.Service.Cache.Take(8);
      model.DefaultDisplay = 8;
      model.ProfileCount = MobiContext.Service.Cache.Count;
      string homeView = this.MobiContext.Service.HomeView;

      return View(this.MobiContext.Service.HomeView, model);
    } 
      
    // SUMMARY: ajax method appending content ( d = skip, g = get )
    public ActionResult LoadMore(string d, string g)
    {
      int skip = 0, get = 0;
      if (!Int32.TryParse(d, out skip) || !Int32.TryParse(g, out get))
      {
        Log.Error("Could not parse get or skip.");
        return this.InternalError();
      }

      HomeListModel model = new HomeListModel(this.MobiContext);
      model.Content = this.MobiContext.Service.Cache.Take(get, skip);
      return PartialView(this.MobiContext.Service.PartialHomeView, model);
    }

    public string test()
    {
      return Translations.Web.Error.ErrInternal;
    }

  }
}