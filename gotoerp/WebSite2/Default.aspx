<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="jquery-1.4.4.min.js" type="text/javascript"></script>
    <script language="javascript">
        (function ($) {
            function hello() { alert("hello") }
            function hello2() { alert("hello2") }
            //            $.fn.nihao.init = function (obj, opts) {
            //                console.log("nihoa.init");
            //            };
            $.fn.ni = function () {
                console.log("ni");
                return this.each(function () {
                    $.fn.ni.init(this);
                });
            };
            $.fn.ni.init = function (obj) {
                console.log("ni.init");
                $(obj).attr('scrollPagination', 'enabled');
               // console.log($(this).val())
            }
        })(jQuery);

        $(function () {
            console.log("a");
            $('#mytext').ni();

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="mytext"  value="aafasldfjaslf">
     
    </div>
    </form>
</body>
</html>

