using System.Web;
using System.Web.Optimization;

namespace MobiChat.Web
{
  public class BundleConfig
  {
    public static void RegisterBundles(BundleCollection bundles)
    {

      bundles.Add(new StyleBundle("~/css")
        .Include("~/Content/shared.css")
        .Include("~/Content/Visual.css"));
      bundles.Add(new ScriptBundle("~/js")
        .Include("~/Scripts/jquery-1.10.2.min.js")
        .Include("~/Scripts/_Base/System.js")
        .Include("~/Scripts/_Base/Visual.js"));

      #region # Template #

      bundles.Add(new StyleBundle("~/Style/Template").
        Include("~/Content/Template/weather-icons/css/weather-icons.min.css").
        Include("~/Content/Template/metrics-graphics/dist/metricsgraphics.css").
        Include("~/Content/Template/c3js-chart/c3.min.css").
        Include("~/Content/Template/uikit/css/uikit.almost-flat.min.css").
        Include("~/Content/Template/flags.min.css").
        Include("~/Content/Template/main.min.css"));

      bundles.Add(new ScriptBundle("~/Scripts/Template").
        Include("~/Content/Template/moment/min/moment.min.js").
        Include("~/Scripts/Template/Application.js").
        Include("~/Scripts/Template/common.min.js").
        Include("~/Scripts/Template/uikit_custom.min.js").
        Include("~/Scripts/Template/altair_admin_common.min.js").
        Include("~/Content/Template/d3/d3.min.js").
        Include("~/Content/Template/metrics-graphics/dist/metricsgraphics.min.js").
        Include("~/Content/Template/c3js-chart/c3.min.js").
        Include("~/Content/Template/maplace.js/src/maplace-0.1.3.js").
        Include("~/Content/Template/peity/jquery.peity.min.js").
        Include("~/Content/Template/jquery.easy-pie-chart/dist/jquery.easypiechart.min.js").
        Include("~/Content/Template/countUp.js/countUp.min.js").
        Include("~/Content/Template/handlebars/handlebars.min.js").
        Include("~/Scripts/Template/custom/handlebars_helpers.min.js").
        Include("~/Content/Template/clndr/src/clndr.js").
        Include("~/Content/Template/fitvids/jquery.fitvids.js").
        //Include("~/Scripts/Template/pages/dashboard.min.js").
        Include("~/Scripts/Template/pages/page_mailbox.min.js"));

      bundles.Add(new StyleBundle("~/Style/Template/Login")
        .Include("~/Content/Template/uikit/css/uikit.almost-flat.min.css").
        Include("~/Content/Template/login_page.min.css"));
      bundles.Add(new StyleBundle("~/Style/Template/Error")
        .Include("~/Content/Template/uikit/css/uikit.almost-flat.min.css").
        Include("~/Content/Template/error_page.min.css"));
      bundles.Add(new StyleBundle("~/Style/Template/TemplateModification")
        .Include("~/Content/Template/uikit/css/Editor.css"));
      bundles.Add(new StyleBundle("~/Style/Template/ServiceTehnical").
        Include("~/Content/Template/TehnicalMain.css"));
      bundles.Add(new StyleBundle("~/Style/Template/SortContent").
        Include("~/Content/Template/SortContent.css"));
      bundles.Add(new StyleBundle("~/Style/Template/FooterConfigration").
        Include("~/Content/Template/FooterConfigration.css"));
      bundles.Add(new StyleBundle("~/Style/Template/ProviderNotes").
        Include("~/Content/Template/ProviderNotes.css"));

      bundles.Add(new ScriptBundle("~/Scripts/Template/SortContent").
        Include("~/Scripts/Template/SortContent.js"));
      bundles.Add(new ScriptBundle("~/Scripts/Template/FooterConfigration").
        Include("~/Scripts/Template/FooterConfigration.js"));
      bundles.Add(new ScriptBundle("~/Scripts/Template/Login").
        Include("~/Scripts/Template/common.min.js").
        Include("~/Scripts/Template/altair_admin_common.min.js").
        Include("~/Scripts/Template/pages/login_page.min.js"));

      bundles.Add(new ScriptBundle("~/Scripts/Template/Technicals").Include("~/Scripts/Template/Technicals.js"));
      bundles.Add(new ScriptBundle("~/Scripts/Template/Automation").Include("~/Scripts/Template/Automation.js"));
      bundles.Add(new StyleBundle("~/Content/Template/Automation").Include("~/Content/Template/Automation.css"));
      bundles.Add(new ScriptBundle("~/Scripts/Template/ProviderNotes").Include("~/Scripts/Template/ProviderNotesManager.js"));

      #endregion
      #region # Template.Zero #


       bundles.Add(new StyleBundle("~/Zero/Slider/css")
         .Include("~/Content/Zero/slider.css")
        );
      
       

      bundles.Add(new StyleBundle("~/Zero/css")
        .Include("~/Content/Zero/main.css")
        );

      bundles.Add(new ScriptBundle("~/Zero/js")
        .Include("~/Scripts/Zero/appender.js")
        .Include("~/Scripts/Zero/menu.js")
        .Include("~/Scripts/Zero/jquery.glide.min.js")
        .Include("~/Scripts/Zero/jquery-1.10.2.min")
        );

      #endregion

      BundleTable.EnableOptimizations = false;
    }
  }
}
