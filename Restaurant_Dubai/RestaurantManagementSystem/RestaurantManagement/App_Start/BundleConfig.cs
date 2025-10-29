using System.Web;
using System.Web.Optimization;

namespace RestaurantManagement
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

            bundles.Add(new ScriptBundle("~/bundles/datetime").Include(
             "~/Scripts/moment*",
             "~/Scripts/bootstrap-datetimepicker*"));

            ///admin side

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/js/jquery.min.js", "~/js/rsmenu-main.js", "~/js/bootstrap.min.js", "~/js/wow.min.js", "~/js/jquery.counterup.min.js", "~/js/waypoints.min.js", "~/js/slick.min.js", "~/js/isotope.pkgd.min.js", "~/js/imagesloaded.pkgd.min.js", "~/js/jquery.magnific-popup.min.js", "~/js/owl.carousel.min.js", "~/js/parallax.js", "~/js/jquery.datetimepicker.full.min.js", "~/js/datepicker.js", "~/js/reservation-form.js", "~/js/main.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/css/bootstrap.min.css", "~/css/font-awesome.min.css", "~/css/animate.css", "~/css/rsmenu-main.css", "~/css/rsmenu-transitions.css", "~/css/hover-min.css", "~/css/owl.carousel.css", "~/css/slick.css", "~/css/slick-theme.css", "~/css/jquery.datetimepicker.min.css", "~/css/magnific-popup.css", "~/style.css", "~/css/responsive.css"));
        }
    }
}
