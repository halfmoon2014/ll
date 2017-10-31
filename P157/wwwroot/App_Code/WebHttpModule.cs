using System;
using System.Web;
using Log4NetApply;

/// <summary>
/// MyHttpModule 的摘要说明
/// </summary>
public class WebHttpModule : IHttpModule
{    
    
    #region IHttpModule 成员
    public void Dispose()
    {

    }

    public void Init(HttpApplication application)
    {
        // 在应用程序启动时运行的代码
        log4net.Config.XmlConfigurator.Configure();
        application.BeginRequest += new EventHandler(Application_BeginRequest);
        application.EndRequest += new EventHandler(Application_EndRequest);
        application.AcquireRequestState += (new EventHandler(this.Application_AcquireRequestState));
    }

    private void Application_BeginRequest(object sender, EventArgs e)
    {
        
    }

    private void Application_EndRequest(object sender, EventArgs e)
    {

    }
    private void Application_AcquireRequestState(Object source, EventArgs e)
    {
        HttpApplication Application = (HttpApplication)source;
        string RawUrl = Application.Context.Request.RawUrl.ToString().Trim();
        //LogHelper.WriteLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, RawUrl);      
        LogHelper.WriteLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,new LogContent("", "", "Application_AcquireRequestState", RawUrl));
        
    }


    #endregion
}