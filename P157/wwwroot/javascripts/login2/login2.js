$(function () {
    if (getCookie("lur") != null) {
        $("#usr").attr("value", getCookie("lur"))
        $("#psw").focus();
    } else {
        $("#usr").focus();
    }
    $("#ok").bind("click", function () { okClick(); });
    $("#psw").bind("keydown", function (event) { onKey(event); });
});

function okClick() {
    $.getJSON("http://localhost:55180/api/products/",
       function (data) {
           // On success, 'data' contains a list of products.
           // 成功时，'data'含有一组产品列表
           $.each(data, function (key, val) {
               // Format the text to display.
               // 格式化文本，以便显示
               var str = val.Name + ': $' + val.Price;
               // Add a list item for the product.
               // 添加一个产品列表项
               $('<li/>', { text: str })
               .appendTo($('#products'));
           });
       });

    var lur = $("#usr").attr("value");
    var lps = $("#psw").attr("value");
    if (lur != "" && lps != "") {
        $("#ok").attr("disabled", true);
        $.ajax({ type: 'post',
            url: 'http://localhost:55180/api/products',
            data: { ur: lur, ps: lps },           
            error: function () {
                $("#ok").removeAttr("disabled");
                $("#msg").html("连接错误,请检查!");
            },
            success: function (data) {
                r = myAjaxData(data);
                if (r.r == "true") {
                    if ($("#rememberme").get(0).checked) {
                        setCookie("lur", lur)
                    }
                    window.location.href = "ChooseTz.aspx";
                } else {
                    $("#ok").removeAttr("disabled");
                    $("#msg").html("登陆失败,请检查用户名与密码是否正确!");
                    $("#psw").focus();
                }
            }
        })
    } else if (lur == "") {        
        $("#msg").html("请输入用户名");
        $("#usr").focus();

    } else if (lps == "") {        
        $("#msg").html("请输入密码!");
        $("#psw").focus();
        
    }
}
//回车执行登陆操作
function onKey(e) {
    var keyn;
    if (getUserBrowser() == "IE") {
        keyn = e.keyCode;
    } else if (e.which) {
        keyn = e.which;
    }
    if (keyn == 13) {
        okClick();
    }
}


