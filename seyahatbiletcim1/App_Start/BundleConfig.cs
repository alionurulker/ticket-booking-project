using System.Web;
using System.Web.Optimization;

namespace seyahatsadaka
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {


            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/assets/js/bootstrap.js",
                        "~/assets/js/jquery-1.11.1.min.js",
                        "~/assets/js/jquery.prettyPhoto.js",
                        "~/assets/js/main.js",
                        "~/assets/Scripts/bootstrap-datepicker.js",
                        "~/assets/js/modernizr-2.6.2.min.js",
                        "~/assets/js/owl.carousel.js",
                        "~/assets/js/owl.carousel.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include());

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include());

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/assets/css/bootstrap.css",
                      "~/assets/css/bootstrap.css.map",
                      "~/assets/css/font-awesome.min.css",
                      "~/assets/css/owl.carousel.css",
                      "~/assets/css/prettyPhoto.css",
                      "~/assets/Content/bootstrap-datepicker.css",
                      "~/assets/css/style.css"));
        }
    }
}
