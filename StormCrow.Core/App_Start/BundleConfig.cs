using System.Web.Optimization;

namespace StormCrow.Core
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;

            bundles.IgnoreList.Clear();
            bundles.IgnoreList.Ignore("*-vsdoc.js");
            bundles.IgnoreList.Ignore("*intellisense.js");

            bundles.Add(new ScriptBundle("~/bundles/jquery", 
                        "//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js").Include(
                        "~/Scripts/3rdPartyJS/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/3rdPartyJS/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/otherJS").Include(
                        "~/Scripts/3rdPartyJS/knockout-{version}",
                        "~/Scripts/3rdPartyJS/sammy-{version}",
                        "~/Scripts/3rdPartyJS/underscore.js",
                        "~/Scripts/3rdPartyJS/toastr.js",
                        "~/Scripts/3rdPartyJS/require.js",
                        "~/Scripts/3rdPartyJS/TrafficCop.js",
                        "~/Scripts/3rdPartyJS/infuser.js",
                        "~/Scripts/3rdPartyJS/amplify.js",
                        "~/Scripts/3rdPartyJS/moment.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/3rdPartyJS/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/3rdPartyJS/bootstrap.js",
                      "~/Scripts/3rdPartyJS/respond.js"));

            // Application Custom JS Library
            bundles.Add(new ScriptBundle("~/bundles/jsapplibs")
                   .IncludeDirectory("~/Scripts/app/", "*.js", searchSubdirectories: false));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-theme.min.css",
                      "~/Content/Site.css"));

            bundles.Add(new Bundle("~/Content/Less",
                        new LessTransform(),
                        new CssMinify())
                        .Include("~/Content/toastr.less"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }

    public class LessTransform : IBundleTransform
    {
        public void Process(BundleContext context, BundleResponse response)
        {
            response.Content = dotless.Core.Less.Parse(response.Content);
            response.ContentType = "text/css";
        }
    }
}
