using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MobiChat.Statistics.Core
{
  public class MobiController : Controller
  {
    private MobiContext _mobiContext = null;
    private StatisticsApplication _application = null;

    public MobiContext MobiContext { get { return MobiContext.Current; } }

    public ActionResult InternalError()
    {
      //ErrorViewModel model = new ErrorViewModel(this.MobiContext)
      //{
      //  Title = Translations.Web.Error.ErrTitle,
      //  Text = Translations.Web.Error.ErrInternal
      //};

      //return View("Error", model);

      // TODO: Implement this
      return null;
    }

    public StatisticsApplication MobiApplication
    {
      get
      {
        if (this._application != null)
          this._application = this.HttpContext.ApplicationInstance as StatisticsApplication;
        return this._application;
      }
    }

  }
}
