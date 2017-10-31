using System;
using System.Collections.Generic;
using ICSharpCode.SharpZipLib.Core;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using System.Web;

public class MyNameTransfom : ICSharpCode.SharpZipLib.Core.INameTransform
{

    #region INameTransform 成员

    public string TransformDirectory(string name)
    {
        return null;
    }

    public string TransformFile(string name)
    {
        return Path.GetFileName(name);
    }

    #endregion
}
public partial class zipimg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         
        string path = "../mytestzip.txt|../mytestzip2.txt";        

        
        ZipFileDownload(path.Split('|'), DateTime.Now.ToString("yyyyMMddhhMmss") + "_检品报告书.zip");
    }

    /// <summary>
    ///  批量进行多个文件压缩到一个文件
    /// </summary>
    /// <param name="files">文件列表(绝对路径)</param> 这里用的数组，你可以用list 等或者
    /// <param name="zipFileName">生成的zip文件名称</param>
    private void ZipFileDownload(string[] files, string zipFileName)
    {
        MemoryStream ms = new MemoryStream();
        byte[] buffer = null;

        using (ZipFile file = ZipFile.Create(ms))
        {
            file.BeginUpdate();

            file.NameTransform = new MyNameTransfom();
            foreach (var item in files)
            {
                if (File.Exists(Server.MapPath(item)))
                    file.Add(Server.MapPath(item));

            }
            file.CommitUpdate();
            buffer = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(buffer, 0, buffer.Length);   //读取文件内容(1次读ms.Length/1024M)
            ms.Flush();
            ms.Close();
        }
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/x-zip-compressed";
        Response.AddHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode(zipFileName));
        Response.BinaryWrite(buffer);
        Response.Flush();
        Response.End();
    }
}