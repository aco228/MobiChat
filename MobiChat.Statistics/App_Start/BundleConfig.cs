﻿using System.Web;
using System.Web.Optimization;

namespace MobiChat.Statistics
{
  public class BundleConfig
  {
    // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
    public static void RegisterBundles(BundleCollection bundles)
    {
      bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                   "~/Scripts/moment.js",
                   "~/Scripts/jquery-2.1.1.min.js",
                  "~/Scripts/jquery-ui.js"
                  ));

      bundles.Add(new ScriptBundle("~/bundles/sidebar").Include(
             // "~/Scripts/gentelella/autosize.js",
             // "~/Scripts/gentelella/bootstrap-progressbar.js",
              "~/Scripts/gentelella/fastclick.js",
              "~/Scripts/UsersScript.js",
             // "~/Scripts/gentelella/icheck.js",
              "~/Scripts/gentelella/nprogress.js",
           //   "~/Scripts/gentelella/select2.js",
           //   "~/Scripts/gentelella/starrr.js",
            //  "~/Scripts/gentelella/switchery.js",
              "~/Scripts/gentelella/custom.js"
           //   "~/Scripts/gentelella/jquery.mCustomScrollbar.concat.min.js"
               ));

      bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                  "~/Scripts/jquery.validate*"));

      // Use the development version of Modernizr to develop with and learn from. Then, when you're
      // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
      bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                  "~/Scripts/modernizr-*"));
      
      bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/mainStats.js",
                "~/Scripts/bootstrap-datetimepicker.min.js",
                "~/Scripts/respond.js"));

      bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-datetimepicker.min.css",
                "~/Content/bootstrap-theme.min.css",
                "~/Content/jquery-ui.css",         
                "~/Content/site.css"
                 ));

      bundles.Add(new StyleBundle("~/Content/gentelella").Include(
               "~/Content/gentelella/jquery.mCustomScrollbar.css",
               "~/Content/gentelella/custom.css",
               "~/Content/gentelella/font-awesome/css/font-awesome.css",
               "~/Content/gentelella/nprogress.css",
               "~/Content/gentelella/select2.css",
               "~/Content/gentelella/starr.css",
               "~/Content/gentelella/switchery.css"
                ));


      // Set EnableOptimizations to false for debugging. For more information,
      // visit http://go.microsoft.com/fwlink/?LinkId=301862
      BundleTable.EnableOptimizations = false;
    }
  }
}
