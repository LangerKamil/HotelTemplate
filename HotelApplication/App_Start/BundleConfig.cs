using System.Web;
using System.Web.Optimization;

namespace HotelApplication
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js", // bootstrap3
                        //"~/Scripts//bootstrap/bootstrap.js", // bootstrap4
                        "~/Scripts/bootbox.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/datatables/jquery.datatables.js",
                        "~/Scripts/datepicker/js/bootstrap-datepicker.js",
                        "~/Scripts/datatables/datatables.bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/calendar").Include(
                        "~/Scripts/fullcalendar/moment.min.js",
                        "~/Scripts/fullcalendar/fullcalendar.min.js",
                        "~/Scripts/fullcalendar/jquery-ui.custom.min.js",
                        "~/Scripts/fullcalendar/scheduler.min.js"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css", // bootstrap3
                      //"~/Content/bootstrap/bootstrap.css", // bootstrap4
                      "~/content/datatables/css/datatables.bootstrap.css",
                      "~/Scripts/datepicker/css/datepicker.css",
                      "~/Content/site.css",
                      "~/Content/Service.css"));
        }
    }
}
