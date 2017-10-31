<%@ Page Language="C#" AutoEventWireup="true" CodeFile="password_edit.aspx.cs" Inherits="password_edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="s/style/util.css" rel="stylesheet" type="text/css" />
    <script src="templets/default/Scripts/jquery-1.4.4.min.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        $(".password_button").click(function () {
            var infoObj = new Object();
            infoObj.newpw2 = $.trim($("#newpw2").attr("value"));
            infoObj.newpw1 = $.trim($("#newpw1").attr("value"));
            infoObj.oldpw = $.trim($("#oldpw").attr("value"));
            
            if (check(infoObj)) {
                $(".password_button").attr("disabled", true)
                $.ajax({ type: 'post',
                    url: 'supplier.ashx',
                    contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                    data: { requestType: 'password_edit',oldpw:infoObj.oldpw,newpw: infoObj.newpw1},
                    error: function (e) {
                        $(".password_button").removeAttr("disabled");
                        console.log(e);
                    },
                    success: function (data) {
                        $(".password_button").removeAttr("disabled");
                        var myData = eval("(" + data.replace(/\\/g, "/") + ")");                 
                        if (myData.r == "true") {
                            alert("修改成功")
                        } else {
                            alert(myData.msg);
                        }
                    }
                })
            }
        });

    });
    //编码
    function mySysDate(str) {
        return encodeURIComponent(str);
    }
    //验证
    function check(infoObj) {
        if (infoObj.oldpw.length < 6) {
            alert("请输入至少6位的原始密码");
            return false;
        }
        if (infoObj.newpw1.length < 6) {
            alert("请输入至少6位的新密码");
            return false;
        }
        if (infoObj.newpw1 != infoObj.newpw2) {
            alert("两次输入密码不一致");
            return false;
        }       
        return true;
    }       
    </script>
</head>
<body>
    <div class="wrapper">
        <div class="century_img">
            <img src="s/pics/strategy_03.gif"></div>
    </div>
    <div class="wrapper">
        <div class="lilanz_title">
            首页 &gt; 供应商专区
        </div>
        <div class="util_main">
            <div class="main_list left">
                <ul>
                    <li><a href="loginok.aspx">ERP入口</a></li>
                    <li><a href="sup_info_edit.aspx">修改资料</a></li>
                    <li><a href="password_edit.aspx">修改密码</a></li>
                    <li><a href="SupplierLogin.htm">退出登陆</a></li>
                </ul>
            </div>
            <div style="margin: 20px;" class="operation_right left">
                <h2 class="lilanz_main_title">
                    修改密码</h2>
                <br>
                <form onsubmit="return myform_submit()" method="post" action="?act=pw">
                <table cellspacing="0" cellpadding="0" align="center" width="300" boder="0">
                    <tbody>
                        <tr>
                            <td height="35" align="right" width="100">
                                原始密码：
                            </td>
                            <td>
                                <input type="password" id="oldpw" name="oldpw">
                            </td>
                        </tr>
                        <tr>
                            <td height="35" align="right" width="100">
                                新密码：
                            </td>
                            <td>
                                <input type="password" id="newpw1" name="newpw1">
                            </td>
                        </tr>
                        <tr class="password_bg">
                            <td height="35" align="right" width="100">
                                确认新密码：
                            </td>
                            <td>
                                <input type="password" id="newpw2" name="newpw2">
                            </td>
                        </tr>
                        <tr>
                            <td height="60" align="center" colspan="2">
                                <img  class="password_button"  src="s/images/z_sub.gif" />                                
                            </td>
                        </tr>
                    </tbody>
                </table>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
