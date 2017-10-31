using System;
using System.Web;
using System.Data.SqlClient;
using System.Data;
public partial class loginok : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string ip = "";
        if (Request.ServerVariables["HTTP_VIA"] != null) // using proxy
        {
            ip = Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();  // Return real client IP.
        }
        else// not using proxy or can't get the Client IP
        {
            ip = Request.ServerVariables["REMOTE_ADDR"].ToString(); //While it can't get the Client IP, it will return proxy IP.
        }
        string guid = HttpContext.Current.Request.Cookies["guid"].Value;
        bool myResult = false;
        #region 验证guid ip guidtime合法性

        nrWebClass.LiLanzDAL sqlhelper = new nrWebClass.LiLanzDAL();
        if (ip == "127.0.0.1" || ip == "192.168.36.131")
        {//内部测试IP
            sqlhelper.ConnectionString = "Data Source=192.168.35.23;Persist Security Info=False;User ID=lllogin;Password=rw1894tla;Initial Catalog=tlsoft;Connect Timeout=10";
        }
        string checkSql = ("select id from  user_cooperate where guidip=@ip and guid=@guid and DATEDIFF (MINUTE,GUIDTIME,GETDATE()) <=30 ");
        SqlParameter[] checkparameters = { new SqlParameter("@ip", SqlDbType.VarChar, 15),
                                             new SqlParameter("@guid", SqlDbType.VarChar,36) };
        checkparameters[0].Value = ip;
        checkparameters[1].Value = guid;
        using (IDataReader dataReader = sqlhelper.ExecuteReader(checkSql.ToString(), CommandType.Text, checkparameters))
        {
            if (dataReader.Read())
            {//请求合法
                myResult = true;
            }
        }        
        #endregion
        if (myResult)
        {
            urllink.InnerHtml = "您的IP地址为：" + ip + "<a href=\"gotoErp.aspx\">点击进入供应商申请专区(外网)</a>";
        }
        else
        {
            urllink.InnerHtml = "请求超时,请重新登陆";
        }

    }
}