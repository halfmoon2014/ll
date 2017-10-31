<%@ WebService Language="C#" Class="WebService" %>

using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class WebService  : System.Web.Services.WebService {

    /// <summary>
    /// 用户登陆
    /// </summary>
    /// <param name="value1"></param>
    /// <param name="value2"></param>
    /// <returns></returns>
    [WebMethod(EnableSession = true)]
    public void login(string usr, string psw)
    {
        //value1 = MyTy.MyTy.MySysDate(value1);
        //value2 = MyTy.MyTy.MySysDate(value2);
        //FM.Business.Login lg = new FM.Business.Login();
        //return "{r:'" + lg.UserLogin(value1, value2) + "'}";
        Context.Response.Write ("{\"r\":\"true2\"}");
        Context.Response.End();
    }
    
}