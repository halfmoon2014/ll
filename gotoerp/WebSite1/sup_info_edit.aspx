<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sup_info_edit.aspx.cs" Inherits="sup_info_edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>    
    <link href="s/style/util.css" rel="stylesheet" type="text/css" />
    <script src="templets/default/Scripts/jquery-1.4.4.min.js" type="text/javascript"></script>
 <script type="text/javascript">
     $(function () {
         $("#modify").click(function () {
             var infoObj = new Object();             
             infoObj.realname = $.trim($("#realname").attr("value"));
             infoObj.product = $.trim($("#product").attr("value"));
             infoObj.address = $.trim($("#address").attr("value"));
             infoObj.phone = $.trim($("#phone").attr("value"));
             infoObj.email = $.trim($("#email").attr("value"));
             if (check(infoObj)) {
                 $(".login").attr("disabled", true)
                 $.ajax({ type: 'post',
                     url: 'supplier.ashx',
                     contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                     data: { requestType: 'modify', 
                         realname: infoObj.realname, product: infoObj.product,
                         address: infoObj.address, phone: infoObj.phone,
                         email: mySysDate(infoObj.email)
                     },
                     error: function (e) {
                         $(".login").removeAttr("disabled");
                         console.log(e);
                     },
                     success: function (data) {
                         $(".login").removeAttr("disabled");
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
         if (infoObj.realname.length == 0) {
             alert("请输入联系人");
             return false;
         }
         if (infoObj.product.length == 0) {
             alert("请输入供应产品");
             return false;
         }
         if (infoObj.address.length == 0) {
             alert("请输入地址");
             return false;
         }
         if (infoObj.phone.length == 0) {
             alert("请输电话号码");
             return false;
         }
         if (!isEmail(infoObj.email)) {
             alert("请输入正确的E-Mail地址");
             return false;
         }
         return true;
     }
     function isEmail(strEmail) {
         if (strEmail.search(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/) != -1)
             return true;
         else
             return false;
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
                    修改资料</h2>
                <br>
                
                <table cellspacing="0" cellpadding="2" align="center" style="margin-top: 50px;" boder="0">
                    <tbody>
                        <tr>
                            <td height="30" align="right" width="185">
                                供应商名称(登录名)：
                            </td>
                            <td>                           
                                <input type="text"  id="username" runat="server"  style="width: 155px;"  disabled="disabled">
                                *
                            </td>
                            <td width="100">
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="right" width="185">
                                联系人：
                            </td>
                            <td>
                                <input type="text" runat="server"  style="width: 155px;" id="realname">
                                *
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="right">
                                供应产品：
                            </td>
                            <td>
                                <input type="text" runat="server"  style="width: 155px;" id="product">
                                *
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="right">
                                地址：
                            </td>
                            <td>
                                <input type="text"  runat="server"  style="width: 155px;" id="address"  >
                                *
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr class="password_bg">
                            <td height="30" align="right" width="185">
                                联系电话：
                            </td>
                            <td>
                                <input type="text" runat="server"   style="width: 155px;" id="phone">
                                *
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="right" width="185">
                                邮 箱：
                            </td>
                            <td>
                                <input type="text"  runat="server"  style="width: 155px;" id="email" >
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr class="password_bg">
                            <td height="90" align="center" colspan="3">
                                <table cellspacing="0" cellpadding="0" border="0" width="200">
                                    <tbody>
                                        <tr>
                                            <td>
                                            <img style="margin-left: 120px;" src="s/images/z_sub.gif"
                                                    id="modify" />                                                
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
                
            </div>
        </div>
    </div>
</body>
</html>