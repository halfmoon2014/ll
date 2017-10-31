using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WEB.Components
{
    /// <summary>
    /// 生成HTML
    /// </summary>
    public class WriteHtml
    {
        /// <summary>
        /// 通过模版生成Html文件
        /// </summary>
        /// <param name="template">模版文件</param>
        /// <param name="path">生成的文件目录</param>
        /// <param name="htmlname">生成的文件名</param>
        /// <param name="dic">字典</param>
        /// <param name="message">异常消息</param>
        /// <returns></returns>
        public bool Create(string template, string path, string htmlName, Dictionary<string, string> dic, ref string message)
        {
            bool result = false;
            string templatePath = System.Web.HttpContext.Current.Server.MapPath(template);
            string htmlPath = System.Web.HttpContext.Current.Server.MapPath(path);
            string htmlNamePath = Path.Combine(htmlPath, htmlName);
            Encoding encode = Encoding.UTF8;
            StringBuilder html = new StringBuilder();

            try
            {
                //读取模版
                html.Append(File.ReadAllText(templatePath, encode));
                //System.IO.FileInfo file = new System.IO.FileInfo(templatePath);
            }
            catch (FileNotFoundException ex)
            {
                message = ex.Message;
                return false;
            }

            foreach (KeyValuePair<string,string> d in dic)
            {
                //替换数据
                html.Replace(
                    string.Format("{0}", d.Key),
                    d.Value);
            }

            try
            {
                //写入html文件
                if (!Directory.Exists(htmlPath))
                    Directory.CreateDirectory(htmlPath);
                File.WriteAllText(htmlNamePath, html.ToString(), encode);
                result = true;
            }
            catch (IOException ex)
            {
                message = ex.Message;
                return false;
            }

            return result;
        }
    }
    
}
