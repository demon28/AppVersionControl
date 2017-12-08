using System.Web;
using System.Web.Optimization;

namespace AppVersionControl.Admin
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/assets/ace/css/acestyle").Include(
                "~/assets/ace/css/jquery.gritter.css",
                "~/assets/ace/css/bootstrap.min.css",
                "~/assets/ace/css/font-awesome.min.css",
                "~/assets/ace/css/ace.min.css",
                "~/assets/ace/css/ace-rtl.min.css",
                "~/assets/ace/css/ace-skins.min.css"
                ));

            bundles.Add(new ScriptBundle("~/assets/ace/acescripts").Include(
                "~/assets/ace/js/ace-extra.min.js",
                "~/assets/ace/js/bootstrap.min.js",
                "~/assets/ace/js/typeahead-bs2.min.js",
                "~/assets/ace/js/ace-elements.min.js",
                "~/assets/ace/js/ace.min.js"
                ));
        }
    }
}
