$(function () {
    if (getCookie("myc_lur") != null) {
        $("#usr").attr("value", getCookie("myc_lur"))
        $("#psw").focus();

    } else {
        $("#usr").focus();
    }
    $("#div_ok").bind("click", function () { okClick(); });
    $("#psw").bind("keydown", function (event) { OnKey(event); });
});

function okClick() {
    var lur = $("#usr").attr("value");
    var lps = $("#psw").attr("value");
    if ($("#div_ok").html() == "连接中") { return false; }
    $("#div_ok").html("连接中");
    if (lur != " " && lps != "") {        
        $.ajax({ type: 'post',
            url: 'webuser/WebService.asmx/login',
            data: { usr: lur, psw: lps },
            dataType: 'json',
            error: function () {                
                $("#div_ok").html("登陆");
                document.getElementById("msg").innerHTML = "连接错误,请检查!";
            },
            success: function (r) {
                if (r.r == "true") {
                    SetCookie("myc_lur", lur)
                    window.location.href = "ChooseTz.aspx";
                } else {
                    
                    $("#div_ok").html("登陆");
                    document.getElementById("msg").innerHTML = "登陆失败,请检查用户名与密码是否正确!";                    
                    $("#psw").focus();
                    

                }
            }
        })
    } else if (lur == "") {
        
        document.getElementById("msg").innerHTML = "请输入用户名";
        $("#usr").focus();
        
    } else {
        
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


