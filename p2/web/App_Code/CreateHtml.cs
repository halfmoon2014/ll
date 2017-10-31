using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
///CreateHtml 的摘要说明
/// </summary>
public class CreateHtml
{
    public CreateHtml()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //        
    }
    /// <summary>
    /// 创建login.html文件
    /// </summary>
    /// <returns></returns>
    public bool CreateLogin(ref string msg)
    {
        WEB.Components.WriteHtml writehtml = new WEB.Components.WriteHtml();
        string template = "template/login.t";
        string path = "";
        string htmlname = "login.html";
        Dictionary<string, string> dic = new Dictionary<string, string>();
        List<String> css = new List<string>();
        css.Add("<link rel=\"stylesheet\" type=\"text/css\" href=\"css/jey/pepper-grinder/easyui.css\"/>");
        css.Add("<link rel=\"stylesheet\" type=\"text/css\" href=\"css/jey/icon.css\"/> ");
        //css.Add(" <link rel=\"stylesheet\" type=\"text/css\" href=\"css/jey/mycss.css\"/>");
        css.Add("<link rel=\"stylesheet\" type=\"text/css\" href=\"css/login/login.css\"/> ");
        List<String> js = new List<string>();
        js.Add("<script language=\"javascript\" type=\"text/javascript\" src=\"javascripts/jquery-1.8.0.min.js\"></script>");
        js.Add(" <script language=\"javascript\" type=\"text/javascript\" src=\"javascripts/jey/jquery.easyui.min.js\"></script> ");        
        js.Add(" <script language=\"javascript\" type=\"text/javascript\" src=\"javascripts/utils.js\"></script>");
        js.Add("  <script language=\"javascript\" type=\"text/javascript\" src=\"javascripts/login/login.js\"></script> ");
        dic.Add("$css$", string.Join("", css.ToArray()));
        dic.Add("$javascripts$", string.Join("", js.ToArray()));
        dic.Add("$title$", "Login");        
        return writehtml.Create(template, path, htmlname, dic, ref msg);

    }
}