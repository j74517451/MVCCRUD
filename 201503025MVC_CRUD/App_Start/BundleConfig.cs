using System.Web;
using System.Web.Optimization;

namespace _201503025MVC_CRUD
{
    public class BundleConfig
    {
        // 如需「搭配」的詳細資訊，請瀏覽 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // 準備好實際執行時，請使用 http://modernizr.com 上的建置工具，只選擇您需要的測試。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));
            //,"~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css"));
            //,"~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                "~/Scripts/angular.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/appjs").Include(
                "~/Scripts/app/Module.js",
                "~/Scripts/app/Controller.js",
                "~/Scripts/app/Service.js"));

            // 將 EnableOptimizations 設為 false 以進行偵錯。如需詳細資訊，
            // 請造訪 http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
