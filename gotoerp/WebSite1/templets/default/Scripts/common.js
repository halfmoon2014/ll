
$(function () {
    //header
    var cnav = new Array();
    var i = 0;
    $(".c-nav .navLi").each(function (i) {
        cnav[i] = $(this);
    });

    $(".c-nav .navLi").hover(
		function () {
		    var a = $(this).index();  //获取鼠标焦点在第几个li上
		    if (a <= 1) {//有下拉框的部分
		        $(this).addClass("actived no_bg");
		        //最后一个
		        if (a < cnav.length - 1) {
		            cnav[a + 1].addClass("no_bg");
		        }
		    }
		    $(".actived .listdown").show();
		},
		function () {
		    var a = $(this).index();
		    $(this).removeClass("actived no_bg");
		    if (a < cnav.length - 1) {
		        cnav[a + 1].removeClass("no_bg");
		    }
		    $(".listdown").hide();
		}
	);

    $(".foot_ul li").hover(
		function () {
		    $(this).addClass("footactived");
		    $(".footactived .twolist").show();
		},
		function () {
		    $(this).removeClass("footactived");
		    $(".twolist").hide();
		}
	);

    //主体部分高度自适应屏幕(首页，公司简介,新闻，秀场，专卖店，校园招聘，咨询留言)
    indexH();
    $(window).resize(function () {
        indexH();
    });
    function indexH() {
        var indexHeight = $(window).height();
        var Height = $(document).height();
        var main = indexHeight - 105; //105是header的高度 
        var all = Height - 105;
        if (main < 571) {
            $(".main").css("height", "591px");
        } else {
            $(".main").css("height", main);
        }

        if (main <= 600) {
            $(".news_bg").css("height", "600px");
        } else {
            $(".news_bg").css("height", main);
        }

        $(".profile").css("height", main);
        $(".school").css("height", main);
        $(".show_h").css("height", main);
        $("#tFocus").css("height", main);
        $(".advisory").css({ "height": main,"min-height":"575px" });
    }

    //底部
    $(".footer_tab").click(function () {
        var tabBottom = parseInt($(".footer").css("bottom"));
        if (tabBottom < 0) {
            $(".footer").stop().animate({ bottom: '0px' });
            $(".footer_tab").addClass("up");
        } else {
            $(".footer").stop().animate({ bottom: '-68px' });
            $(".footer_tab").removeClass("up");
        }
    });
    //二维码
    $(".two-code").hover(
		function () {
		    $(".two-code-img").show();
		},
		function () {
		    $(".two-code-img").hide();
		}
	);
    //微信号
    $(".wx2").hover(
		function () {
		    $(".wx").show();
		},
		function () {
		    $(".wx").hide();
		}
	);

    //电视广告
    $(".atc1").click(function () {
        var i = 1;
        adsSwitch(i);
    });

    $(".atc2").click(function () {
        var i = 2;
        adsSwitch(i);
    });

    $(".atc3").click(function () {
        var i = 3;
        adsSwitch(i);
    });

    function adsSwitch(i) {
        $("#player1").hide();
        $("#player2").hide();
        $("#player3").hide();

        var currentFlv = "#player" + i;
        $(currentFlv).css("display", "block");
    }

    $(".ads-thumb1").hover(
		function () {
		    $(".ads-thumb1 .ads-thumb-cover").fadeIn();
		},
		function () {
		    $(".ads-thumb1 .ads-thumb-cover").fadeOut();
		}
	);

    $(".ads-thumb2").hover(
		function () {
		    $(".ads-thumb2 .ads-thumb-cover").fadeIn();
		},
		function () {
		    $(".ads-thumb2 .ads-thumb-cover").fadeOut();
		}
	);

    $(".ads-thumb3").hover(
		function () {
		    $(".ads-thumb3 .ads-thumb-cover").fadeIn();
		},
		function () {
		    $(".ads-thumb3 .ads-thumb-cover").fadeOut();
		}
	);


    //show
    //    $(".show_click").click(function () {
    //        $(".layer2").show();
    //        var aName = $(this).attr('alt');
    //        var location = $(this).attr('location');
    //        var div = $('.' + aName);
    //        var img = $('.' + aName + ' .show_pic');
    //        enlarge(aName, div, img, location);
    //        $(".big_img").css("padding", "10px");
    //        $(".show_close").show();
    //    });

    //    $(".show_close").click(function () {
    //        $(".big_img").css("padding", "0px");
    //        $(".show_close").hide();
    //        var aName = $(this).attr('alt');
    //        var location = $(this).attr('location');
    //        var div = $('.' + aName);
    //        var img = $('.' + aName + ' .show_pic');
    //        $(".layer2").fadeOut();
    //        Narrow(aName, div, img, location);
    //        setTimeout(function () { $(div).removeClass("s_after_c"); }, 750);
    //    });

    //    function enlarge(aName, div, img, location) {//放大
    //        var time = 750;
    //        if (location == "item1") {
    //            $(div).stop().addClass("s_after_c").animate({ top: '100px', left: "10%" }, time);
    //            $(img).stop().animate({ width: '350px' }, time);
    //        } else if (location == "item2") {
    //            $(div).stop().addClass("s_after_c").animate({ top: '120px', left: "24%" }, time);
    //            $(img).stop().animate({ width: '350px' }, time);
    //        } else if (location == "item3") {
    //            $(div).stop().addClass("s_after_c").animate({ top: '60px', left: "45%" }, time);
    //            $(img).stop().animate({ width: '380px' }, time);
    //        } else if (location == "item4") {
    //            $(div).stop().addClass("s_after_c").animate({ top: '60px', left: "65%" }, time);
    //            $(img).stop().animate({ width: '350px' }, time);
    //        } else if (location == "item5") {
    //            $(div).stop().addClass("s_after_c").animate({ top: '90px', left: "68%" }, time);
    //            $(img).stop().animate({ width: '350px' }, time);
    //        }

    //    }

    //    function Narrow(aName, div, img, location) {//缩小
    //        var time = 750;
    //        $(img).stop().animate({ width: '0px' }, time);
    //        if (location == "item1") {
    //            $(div).stop().animate({ top: '47%', left: "18%" }, time);
    //        } else if (location == "item2") {
    //            $(div).stop().animate({ top: '62%', left: "37%" }, time);
    //        } else if (location == "item3") {
    //            $(div).stop().animate({ top: '50%', left: "55%" }, time);
    //        } else if (location == "item4") {
    //            $(div).stop().animate({ top: '26%', left: "74%" }, time);
    //        } else if (location == "item5") {
    //            $(div).stop().animate({ top: '67%', left: "81%" }, time);
    //        }
    //    }



});

//利郎新品图片切换
$(function () {
    $(".new-hover").click(function () {
        var alt = $(this).attr('alt');
        var slides = '#slides' + alt;
        $(".layer2").show();
        $(slides).fadeIn();
    });

    $(".close1").click(function () {
        var alt = $(this).attr('alt');
        var slides = '#slides' + alt;
        $(".layer2").fadeOut();
        $(slides).fadeOut();
    });

    new_width();

    $(window).resize(function () {
        new_width();
    });

    function new_width() {
        var newWidth = $(window).width();
        var container1 = parseInt($(".slides_container1").css("width"));        
        var left = (newWidth - container1) / 2;
        $(".slides1").css("width", newWidth);
        $(".slides_container1").css("margin-left", left);
        
    }
});


window.onload = function () {
    layer_width();

    $(window).resize(function () {
        layer_width();
    });

    function layer_width() {
        var Width = $(window).width();        
        var layer333 = 1090;
        var left1 = (Width - layer333) / 2;
        $(".layer333").css("margin-left", left1);
    }

}

//全屏图片切换
//window.onload = function () {
//    var pag = 0;
//    $(".pagination li").each(function (pag) {
//        pag++;
//        var className = 'pagin' + pag;
//        $(this).addClass(className);        
//        var n = pag % 2;
//        if (n == 0) {
//            $(this).addClass("pagin");
//        }
//    });

//    $(".pagination li a").click(function () {
//        $(".pagination li").removeClass("current");
//        $(this).parent().addClass("current");
//        $(".layer").show();
//        $("#slides").css("z-index", "10000");
//        $("#slides").animate({ opacity: '1' }, 300);
//    });

   
    

    //pagination对应当前图片
//    window.cs = function () {
//        var cs1 = $(".cs1").css("display");
//        var cs2 = $(".cs2").css("display");
//        var cs3 = $(".cs3").css("display");
//        var cs4 = $(".cs4").css("display");
//        var cs5 = $(".cs5").css("display");
//        var cs6 = $(".cs6").css("display");
//        var cs7 = $(".cs7").css("display");
//        var cs8 = $(".cs8").css("display");
//        $(".pagination li").removeClass("current");
//        if (cs1 == "block") {
//            $(".pagin1").addClass("current");
//        } else if (cs2 == "block") {
//            $(".pagin2").addClass("current");
//        } else if (cs3 == "block") {
//            $(".pagin3").addClass("current");
//        } else if (cs4 == "block") {
//            $(".pagin4").addClass("current");
//        } else if (cs5 == "block") {
//            $(".pagin5").addClass("current");
//        } else if (cs6 == "block") {
//            $(".pagin6").addClass("current");
//        } else if (cs7 == "block") {
//            $(".pagin7").addClass("current");
//        } else if (cs8 == "block") {
//            $(".pagin8").addClass("current");
//        }
//        window.setTimeout("cs()", 500);
//    }
//    cs();

//}

$(function () {

    $("#slides .close").click(function () {
        $(".layer").fadeOut();
        $("#slides").animate({ opacity: '0' }, 300);
        $("#slides").css("z-index", "-10000");
    });

});


$(function () {
    //公司介绍 更多
    $(".show_more img,.show_more span").click(function () {
        $(".more_intro").show();
        $(".profile .intro").css("margin-top", "-232px");
        $(".intro_p").css({ "text-align": "left", "text-indent": "2em" });
        $(".show_more").hide();
        $(".pack_up").show();
    });

    $(".pack_up img,.pack_up span").click(function () {
        $(".more_intro").hide();
        $(".profile .intro").css("margin-top", "-184px");
        $(".intro_p").css({ "text-align": "center", "text-indent": "0em" });
        $(".show_more").show();
        $(".pack_up").hide();
    });

    //加盟合作
    $(".frame .aff p").click(function () {
        $(".frame .aff p").removeClass("aff-active");
        $(this).addClass("aff-active");
        var aName = $(this).attr('alt');
        var div = $('.aff-tab' + aName);
        $(".aff-tab").hide();
        div.show();
    });

    //定制
    $(".twolist a[alt='custom1']").click(function () {
        $(".custom-nav li[alt='custom1']").click();
		initImages(".custom1");
        customized ();
    });

    $(".twolist a[alt='custom2']").click(function () {
        $(".custom-nav li[alt='custom2']").click();
		initImages(".custom2");
        customized ();
    });

    $(".twolist a[alt='custom3']").click(function () {
        $(".custom-nav li[alt='custom3']").click();
		initImages(".custom3");
        customized ();
    });

    $(".twolist a[alt='custom4']").click(function () {
        $(".custom-nav li[alt='custom4']").click();
		initImages(".custom4");
        customized ();
    });

    $(".twolist a[alt='custom5']").click(function () {
        $(".custom-nav li[alt='custom5']").click();
		initImages(".custom5");
        customized ();
    });

    $(".custom-content .close").click(function () {
        $(".customized").stop().animate({ opacity: '0' }, 300);
        $(".customized").css("z-index","-9999");
    });
    
    $('.flexslider').flexslider({
        animation: "slide",
        slideshow: false, 
    });

    $(".custom-nav li").click(function () {
        $(".custom-nav li").removeClass("active");
        $(this).addClass("active");
        var aName = $(this).attr('alt');
			initImages("." + aName);
        $(".custom-tab").hide();
        $("."+aName).show();
    });
    
    $(".custom3 .case li").hover(
		function () {
		    $(this).children(".bottom").stop().animate({ bottom: '0px' });
		},
		function () {
		    $(this).children(".bottom").stop().animate({ bottom: '-34px' });
		}
	);

    $(".custom4 .main>li").hover(
		function () {
		    $(this).children(".flex-custom-in").css("z-index","9999").stop().animate({ opacity: '1' }, 300);
		},
		function () {
		    $(this).children(".flex-custom-in").stop().animate({ opacity: '0' }, 300).css("z-index","-9999");
		}
	);

    //投资者关系
    //切换报表
    $('.finan-main .year-list li').click(function () {
        $(this).addClass("active").siblings().removeClass("active");
        //reports部分
        var year = $(this).attr("data");
        $(".finan-main .reports").removeClass("active");
        var row = '.finan-main .reports[data-year=' + year + ']';
        $(row).addClass("active");

    });

});


function customized () {
    $(".customized").css("z-index","9999");
    $(".customized").stop().animate({ opacity: '1' }, 300);
}

function initImages(el)
{
	var con = $(el);
		con.find("img[data-src]").each(function(index, element) {
            var ths = $(element);
				ths.attr("src",ths.attr("data-src"));
				ths.removeAttr("data-src");
        });	
}



















