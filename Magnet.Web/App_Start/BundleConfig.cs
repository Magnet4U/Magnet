using System.Web;
using System.Web.Optimization;

namespace Magnet.Web
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
                        "~/Scripts/modernizr-*"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/customScript").Include(
                      "~/Scripts/CustomScript.js"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                      "~/Scripts/moment.min.js"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrapC").Include(
                "~/Content/bootstrap.min.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-datetimepicker").Include(
                "~/Content/bootstrap-datetimepicker.min.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-datetimepickerSc").Include(
                "~/Script/bootstrap-datetimepicker.min.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            #region Template Design
            bundles.Add(new ScriptBundle("~/template/js").Include(
                      "~/Scripts/jquery.min.js",
                      "~/Scripts/bootstrap.bundle.min.js",
                      "~/Scripts/isotope.pkgd.min.js",
                      "~/Scripts/stickyfill.min.js",
                      "~/Scripts/jquery.fancybox.min.js",
                      "~/Scripts/jquery.easing.1.3.js",
                      "~/Scripts/jquery.waypoints.min.js",
                      "~/Scripts/jquery.animateNumber.min.js",
                      "~/Scripts/owl.carousel.min.js",
                      "~/Scripts/bootstrap-select.min.js",
                      "~/Scripts/custom.js"
               ));

            bundles.Add(new StyleBundle("~/template/css").Include(
                     "~/Content/css/custom-bs.css",
                      "~/Content/css/jquery.fancybox.min.css",
                      "~/Content/css/bootstrap-select.min.css",
                      "~/Content/css/owl.carousel.min.css",
                      "~/Content/css/animate.min.css",
                           "~/fonts/fonts/icomoon/style.css",
                          "~/fonts/fonts/style.css",
                         "~/Content/css/style.css"));

            #endregion
        }
    }
}
