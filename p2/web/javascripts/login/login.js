$(function () {
    if (getCookie("myc_lur") != null) {
        $("#usr").attr("value", getCookie("myc_lur"))
        $("#psw").focus();

    } else {
        $("#usr").focus();
    }

    $("#ok").bind("click", function () { ok_click(); });
    $("#psw").bind("keydown", function (event) { OnKey(event); });

});

function ok_click() {
    var lur = $("#usr").attr("value");
    var lps = $("#psw").attr("value");
    if (lur != " " && lps != "") {
        document.getElementById("ok").disabled = true;
        $.ajax({ type: 'post',
            url: 'webuser/WebService.asmx/login',
            data: { usr: lur, psw: lps },
            dataType: 'json',
            error: function () {
                //$.messager.alert('提示信息', '连接错误,请检查!', 'info', function () {
                document.getElementById("ok").disabled = false;
                document.getElementById("msg").innerHTML = "连接错误,请检查!";
                //});
            },
            success: function (r) {
                if (r.r == "true") {
                    SetCookie("myc_lur", lur)
                    window.location.href = "ChooseTz.aspx";
                } else {
                    //$.messager.alert('提示信息', '登陆失败,请检查用户名与密码是否正确!', 'info', function () {
                    document.getElementById("msg").innerHTML = "登陆失败,请检查用户名与密码是否正确!";
                    document.getElementById("ok").disabled = false;
                    $("#psw").focus();
                    //});

                }
            }
        })
    } else if (lur == "") {
        // alert("请输入用户名")
        // $.messager.alert('提示信息', '请输入用户名!', 'info', function () {
        document.getElementById("msg").innerHTML = "请输入用户名";
        $("#usr").focus();
        // });
    } else {
        //  alert("请输入密码")
        // $.messager.alert('提示信息', '请输入密码!', 'info', function () {
        document.getElementById("msg").innerHTML = "请输入密码!";
        $("#psw").focus();
        // });
    }
}

function OnKey(e) {

    var keyn;
    if (userBrowser() == "IE") {
        keyn = e.keyCode;
    } else if (e.which) {
        keyn = e.which;
    }

    if (keyn == 13) {

        ok_click();
    }

}

/*
function setSessionValue(newValue) {
__doPostBack('SetSessionPostBack', newValue);
}*/


