$(function () {
    if (getCookie("myc_lur") != null) {
        $("#usr").attr("value", getCookie("myc_lur"))
        $("#psw").focus();

    } else {
        $("#usr").focus();
    }
    $("#ok").bind("click", function () { okClick(); });
    $("#psw").bind("keydown", function (event) { OnKey(event); });
});

function okClick() {
    var lur = $("#usr").attr("value");
    var lps = $("#psw").attr("value");
    if (lur != "" && lps != "") {
        $("#ok").attr("disabled", true);
        $.ajax({ type: 'post',
            url: 'webuser/WebService.asmx/login',
            data: { usr: lur, psw: lps },
            dataType: 'json',
            error: function () {
                $("#ok").removeAttr("disabled");
                document.getElementById("msg").innerHTML = "连接错误,请检查!";
            },
            success: function (r) {
                if (r.r == "true") {
                    if ($("#rememberme").get(0).checked) {
                        SetCookie("myc_lur", lur)
                    }
                    window.location.href = "ChooseTz.aspx";
                } else {

                    $("#ok").removeAttr("disabled");
                    document.getElementById("msg").innerHTML = "登陆失败,请检查用户名与密码是否正确!";
                    $("#psw").focus();
                }
            }
        })
    } else if (lur == "") {
        
        document.getElementById("msg").innerHTML = "请输入用户名";
        $("#usr").focus();

    } else if (lps == "") {
        
        document.getElementById("msg").innerHTML = "请输入密码!";
        $("#psw").focus();
        
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
        okClick();
    }
}


