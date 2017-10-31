<%@ Page Language="C#" AutoEventWireup="true" CodeFile="loginok.aspx.cs" Inherits="loginok" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    
    <link href="s/style/util.css" rel="stylesheet" type="text/css" />
    <link href="s/style/operation.css" rel="stylesheet" type="text/css" />
    <link href="s/style/dealers.css" rel="stylesheet" type="text/css" />
    <link href="s/style/page.css" rel="stylesheet" type="text/css" />
    <style>
        .urllink
        {
            margin: 50px auto;
            text-align: center;
        }
        .urllink a
        {
            background-color: #444;
            color: #ccc;
            display: block;
            font-size: 16px;
            font-weight: bold;
            height: 30px;
            line-height: 30px;
            margin: 0 auto;
            text-align: center;
            text-decoration: none;
            width: 260px;
        }
        .urllink a:hover
        {
            background-color: #666;
        }
        .outlink
        {
        }
        .outlink a
        {
            color: #ccc;
            display: block;
            font-size: 12px;
            line-height: 22px;
            text-decoration: none;
        }
    </style>
</head>
<body>   
	
    <div class="wrapper">
        <div class="century_img"><img src="s/pics/strategy_03.gif"></div>
	</div>
	<div class="wrapper">

		<div class="lilanz_title">首页 &gt; 供应商专区
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

            <div class="operation_right left">
                <h2 class="lilanz_main_title">
                    ERP入口</h2>
                ok<div id="urllink" runat="server" class="urllink">
                    
                </div>
            </div>
        </div>        
		
	</div>      
    

</body>
</html>
