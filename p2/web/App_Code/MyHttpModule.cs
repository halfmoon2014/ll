using System;
using System.Collections.Generic;
using System.Web;
using WEB.Components;
using System.Collections;
/// <summary>
///MyHttpModule 的摘要说明
/// </summary>
public class MyHttpModule : IHttpModule
{
	public MyHttpModule()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    #region IHttpModule 成员

    public void Dispose()
    {

    }

    public void Init(HttpApplication application)
    {
        application.BeginRequest += new EventHandler(Application_BeginRequest);
        application.EndRequest += new EventHandler(Application_EndRequest);
        application.AcquireRequestState += (new EventHandler(this.Application_AcquireRequestState));
    }

    private void Application_BeginRequest(object sender, EventArgs e)
    {
        HttpApplication application = (HttpApplication)sender;
        HttpContext context = application.Context;
        HttpRequest request = application.Request;
        HttpResponse response = application.Response;
        if (application.Context.Request.AppRelativeCurrentExecutionFilePath == "~/login.html")
        {//访问首页
            if (application.Server.MapPath("~/login.html") != null)
            {//首页文件存在           
                            
            }
            else
            {

            }
            CreateHtml h = new CreateHtml();
            string msg = "";
            if (!h.CreateLogin(ref msg))
            {
                response.Write("<br/>发生错误:" + msg + "<br />");
                application.CompleteRequest();
            }

        }
        
        //response.Write("我来自自定义HttpModule中的BeginRequest<br />");
        //application.CompleteRequest();
        //application.Context.Response.Write("请求被终止。<br/>");
    }

    private void Application_EndRequest(object sender, EventArgs e)
    {
        HttpApplication application = (HttpApplication)sender;
        HttpContext context = application.Context;
        HttpRequest request = application.Request;
        HttpResponse response = application.Response;

        //response.Write("我来自自定义HttpModule中的EndRequest<br />");
    }
    private void Application_AcquireRequestState(Object sender, EventArgs e)
    {
        HttpApplication application = (HttpApplication)sender;
        string url = application.Context.Request.Path.ToString();
        string RawUrl = application.Context.Request.RawUrl.ToString().Trim();
        //string xml = Application.Server.MapPath("~/Url.xml");


        //if (url.ToUpper().Contains(".ASPX"))
        //{
        //    if (MyTy.XmlHelp.Check(xml, "/Root/NoLimitUrl/Site[@Name='" + url.ToUpper() + "']") != null)
        //    {

        //    }
        //    else if (url.ToUpper().Contains("DEFAULT.ASPX"))
        //    {//登陆页面

        //        if (SessionHandle.Get("userid") != null && SessionHandle.Get("tzid") != null)
        //        {
        //            string gourl = "~/webpage/MENU_.aspx";
        //            gourl = MySession.SessionHandle.Get("menupage");
        //            Application.Response.Redirect(gourl);
        //        }
        //        else if (SessionHandle.Get("userid") != null && SessionHandle.Get("tzid") == null)
        //        {
        //            string gourl = "~/ChooseTz.aspx";
        //            Application.Response.Redirect(gourl);
        //        }
        //    }
        //    else if (url.ToUpper().Contains("CHOOSETZ.ASPX"))
        //    {//套账页面

        //        if (SessionHandle.Get("userid") != null && SessionHandle.Get("tzid") != null)
        //        {
        //            string gourl = "";
        //            if (SessionHandle.Get("UrlReferrer") != null)
        //            {
        //                gourl = SessionHandle.Get("UrlReferrer").ToString();
        //                SessionHandle.Del("UrlReferrer");
        //            }
        //            else
        //            {
        //                if (Application.Request.UrlReferrer == null)
        //                {/*直接输入CHOOSETZ.ASPX地址*/
        //                    gourl = SessionHandle.Get("menupage").ToString();
        //                }
        //                else
        //                {/*更改套账*/
        //                    SessionHandle.Del("tzid");
        //                    gourl = "~/CHOOSETZ.aspx";
        //                }
        //            }
        //            Application.Response.Redirect(gourl);
        //        }
        //        else if (SessionHandle.Get("userid") == null)
        //        {
        //            string gourl = "~/Default.aspx";
        //            Application.Response.Redirect(gourl);
        //        }

        //    }
        //    else if (url.ToUpper().Contains("MENU_") && url.ToUpper().Contains(".ASPX"))
        //    //如果网页包含这2个名称就是主页
        //    {
        //        //获取当前主页是哪个页面!
        //        SessionHandle.Add("menupage", url);

        //        if (SessionHandle.Get("userid") != null && SessionHandle.Get("tzid") != null)
        //        {

        //            if (SessionHandle.Get("UrlReferrer") != null)
        //            {
        //                string gourl = SessionHandle.Get("UrlReferrer").ToString();
        //                SessionHandle.Del("UrlReferrer");
        //                Application.Response.Redirect(gourl);
        //            }

        //            FM.Business.Login lg = new FM.Business.Login();
        //            lg.CreateDbLink();//设置业务服务器上的 连接 主服务与母板的LINK
        //        }
        //        else if (SessionHandle.Get("userid") == null)
        //        {
        //            string gourl = "~/Default.aspx";
        //            Application.Response.Redirect(gourl);
        //        }
        //    }
        //    else
        //    {
        //        if (SessionHandle.Get("userid") == null || SessionHandle.Get("tzid") == null)
        //        //tzid session丢失或user session丢失
        //        //对于普通面页,不包含用户登陆与套账选择页面!
        //        {
        //            string gourl = "~/Default.aspx";
        //            SessionHandle.Add("UrlReferrer", RawUrl);
        //            Application.Response.Redirect(gourl);
        //        }
        //        else
        //        {
        //            string userid = Application.Context.Session["userid"].ToString(); //获取User            
        //            //获取客户访问的页面
        //            string module = "";//根据url得到所在的模块       
        //            if (!RightChecker.HasRight(userid, module))
        //            {
        //                Application.Context.Server.Transfer("ErrorPage.aspx");
        //            }

        //        }
        //    }
        //}

    }


    #endregion
}