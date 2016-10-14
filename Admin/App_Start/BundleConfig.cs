using System.Web;
using System.Web.Optimization;

namespace Admin
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region 通用css
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                            "~/Content/Static/H-ui/css/H-ui.min.css",
                            "~/Content/Static/H-ui.admin/css/h-ui.admin.css",
                            "~/Content/Lib/Hui-iconfont/1.0.7/iconfont.css",
                            "~/Content/Lib/icheck/icheck.css",
                            "~/Content/Static/H-ui.admin/skin/default/skin.css",
                            "~/Content/Static/H-ui.admin/css/style.css"));
            #endregion

            #region 通用js
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                       "~/Content/Lib/jquery/1.9.1/jquery.min.js",
                       "~/Content/Lib/layer/2.1/layer.js",
                       "~/Content/Static/H-ui/js/H-ui.js",
                       "~/Content/Static/H-ui.admin/js/h-ui.admin.js",
                       "~/Content/Lib/respond.min.js"));
            #endregion

            #region IE9
            bundles.Add(new ScriptBundle("~/bundles/ie9").Include(
                       "~/Content/Lib/html5.js",
                        "~/Content/Lib/respond.min.js",
                         "~/Content/Lib/PIE_IE678.js"));
            #endregion

            #region 分页
            bundles.Add(new ScriptBundle("~/bundles/page").Include(
                       "~/Content/Lib/1.2/laypage.js"));
            #endregion

            #region 时间控件
            bundles.Add(new ScriptBundle("~/bundles/time").Include(
                       "~/Content/Lib/My97DatePicker/WdatePicker.js"));
            #endregion

            #region 系统自带js引用
            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Content/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Content/Scripts/bootstrap.js",
            //          "~/Content/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/Styles/bootstrap.css",
            //          "~/Content/Styles/site.css")); 
            #endregion
        }
    }
}
