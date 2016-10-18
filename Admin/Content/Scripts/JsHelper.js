//表单验证
function validate(id, rules, func) {
    $("#" + id).validate({
        rules: rules,
        onkeyup: false,
        focusCleanup: true,
        submitHandler: function (form) {
            if (func) {
                $(form).ajaxSubmit({
                    success: function (data) {
                        func(data);
                    }
                });
            }
            else {
                $(form).ajaxSubmit();
            }
        }
    });
}
//关闭窗口
function closePage() {
    var index = parent.layer.getFrameIndex(window.name);
    parent.$('.btn-refresh').click();
    parent.layer.close(index);
}
//弹窗
function layerAlert(content, param, func) {
        if (typeof param=="function") {
            func=param;
            param = null;
        }
        layer.alert(content, param, function () {
            if (func) {
                func();
            }
            closePage();
        });

}