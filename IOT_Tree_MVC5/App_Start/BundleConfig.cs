﻿using System.Web;
using System.Web.Optimization;

namespace IOT_Tree_MVC5
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/AdminCP/Js").Include(
                "~/AdminCP/vendor/jquery/jquery-3.3.1.min.js",
                "~/AdminCP/vendor/bootstrap/js/bootstrap.bundle.js",
                "~/AdminCP/vendor/slimscroll/jquery.slimscroll.js",
                "~/AdminCP/libs/js/main-js.js",
                "~/Scripts/MyJs.js"
                ));

            bundles.Add(new StyleBundle("~/AdminCP/Css").Include(
                "~/AdminCP/vendor/bootstrap/css/bootstrap.min.css",
                "~/AdminCP/vendor/fonts/circular-std/style.css",
                "~/AdminCP/libs/css/style.css"
                ));
            BundleTable.EnableOptimizations = true;
        }
    }
}
