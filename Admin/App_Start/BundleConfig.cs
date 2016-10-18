using System.Web.Optimization;

namespace Admin
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region 通用头部js

            bundles.Add(new ScriptBundle("~/bundles/js/header").Include(
                            "~/Content/Lib/jquery/1.8.3/jquery.min.js",
                            "~/Content/Scripts/JsHelper.js"));

            #endregion

            #region 通用头部css

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                            "~/Content/Static/H-ui/css/H-ui.min.css",
                            "~/Content/Static/H-ui.admin/css/h-ui.admin.css",
                            "~/Content/Lib/Hui-iconfont/1.0.7/iconfont.css",
                            "~/Content/Lib/icheck/icheck.css",
                            "~/Content/Static/H-ui.admin/skin/default/skin.css",
                            "~/Content/Static/H-ui.admin/css/style.css",
                            "~/Content/Lib/layer/2.1/skin/layer.css"
                            ));

            #endregion

            #region 通用底部js

            bundles.Add(new ScriptBundle("~/bundles/js/footer").Include(
                            "~/Content/Lib/layer/2.1/layer.js",
                            "~/Content/Static/H-ui/js/H-ui.js",
                            "~/Content/Static/H-ui.admin/js/h-ui.admin.js",
                            "~/Content/Lib/respond.min.js"));

            #endregion

            #region 表单验证

            bundles.Add(new ScriptBundle("~/bundles/validate").Include(
                            "~/Content/Lib/jquery.validation/1.14.0/jquery.validate.min.js",
                            "~/Content/Lib/jquery.validation/1.14.0/validate-methods.js",
                            "~/Content/Lib/jquery.validation/1.14.0/messages_zh.min.js",
                            "~/Content/Lib/jquery.form/3.51/jquery.form.min.js"
                ));

            #endregion

            #region IE9

            bundles.Add(new ScriptBundle("~/bundles/ie9").Include(
                            "~/Content/Lib/html5.js",
                            "~/Content/Lib/respond.min.js",
                            "~/Content/Lib/PIE-2.0beta1/PIE_IE9.js",
                            "~/Content/Lib/PIE-2.0beta1/PIE_IE678.js"));

            #endregion

            #region 分页

            bundles.Add(new ScriptBundle("~/bundles/laypage").Include(
                            "~/Content/Lib/1.2/laypage.js"));

            #endregion

            #region 按钮

            bundles.Add(new ScriptBundle("~/bundles/icheck").Include(
                "~/Content/Lib/icheck/jquery.icheck.min.js"));

            #endregion

            #region 时间控件

            bundles.Add(new ScriptBundle("~/bundles/wdate").Include(
                            "~/Content/Lib/My97DatePicker/WdatePicker.js"));

            #endregion

        }
    }
}