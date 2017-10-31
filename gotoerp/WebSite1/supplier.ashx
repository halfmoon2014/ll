<%@ WebHandler Language="C#" Class="supplier" %>

using System;
using System.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;
public class supplier : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string ip = "";
        if (context.Request.ServerVariables["HTTP_VIA"] != null) // using proxy
        {
            ip = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();  // Return real client IP.
        }
        else// not using proxy or can't get the Client IP
        {
            ip = context.Request.ServerVariables["REMOTE_ADDR"].ToString(); //While it can't get the Client IP, it will return proxy IP.
        }
        nrWebClass.LiLanzDAL sqlhelper = new nrWebClass.LiLanzDAL();
        if (ip == "127.0.0.1" || ip == "192.168.36.131")
        {//内部测试IP
            sqlhelper.ConnectionString = "Data Source=192.168.35.23;Persist Security Info=False;User ID=lllogin;Password=rw1894tla;Initial Catalog=tlsoft;Connect Timeout=10";
        }
        string requestType = MySysDate(context.Request.Form["requestType"].ToString());
        if (requestType == "register")
        {//注册
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into user_cooperate(");
            strSql.Append("user_name,password,real_name,email,product,address,phone,ip)");
            strSql.Append(" values (");
            strSql.Append("@user_name,@password,@real_name,@email,@product,@address,@phone,@ip)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@user_name", SqlDbType.VarChar,250),
					new SqlParameter("@password", SqlDbType.VarChar,100),				
					new SqlParameter("@real_name", SqlDbType.VarChar,250),
					new SqlParameter("@email", SqlDbType.VarChar,100),
					new SqlParameter("@product", SqlDbType.VarChar,100),
					new SqlParameter("@address", SqlDbType.VarChar,100),				
					new SqlParameter("@phone", SqlDbType.VarChar,20),
                    new SqlParameter("@ip", SqlDbType.VarChar,15)
					};
            parameters[0].Value = MySysDate(context.Request.Form["username"].ToString());
            parameters[1].Value = nrWebClass.Security.String2MD5(MySysDate(context.Request.Form["password"].ToString()));
            parameters[2].Value = MySysDate(context.Request.Form["realname"].ToString());
            parameters[3].Value = MySysDate(context.Request.Form["email"].ToString());
            parameters[4].Value = MySysDate(context.Request.Form["product"].ToString());
            parameters[5].Value = MySysDate(context.Request.Form["address"].ToString());
            parameters[6].Value = MySysDate(context.Request.Form["phone"].ToString());
            parameters[7].Value = ip;
            string myResult = "false";
            string msg = "注册失败";

            StringBuilder checkSql = new StringBuilder();
            checkSql.Append("select * from  user_cooperate where user_name=@user_name");
            SqlParameter[] checkParameters = { new SqlParameter("@user_name", SqlDbType.VarChar, 100) };
            checkParameters[0].Value = context.Request.Form["username"].ToString();
            using (IDataReader dataReader = sqlhelper.ExecuteReader(checkSql.ToString(), CommandType.Text, checkParameters))
            {
                if (dataReader.Read())
                {
                    myResult = "false";
                    msg = "登录名已存在";
                }
                else
                {
                    if (sqlhelper.ExecuteNonQuery(strSql.ToString(), CommandType.Text, parameters) > 0)
                    {
                        myResult = "true";
                        msg = "";
                    }
                    else
                        myResult = "false";
                }
            }
            context.Response.Clear();
            context.Response.Write("{r:'" + myResult + "',msg:'" + msg + "'}");
        }
        else if (requestType == "login")
        {//登陆
            string myResult = ""; string msg = ""; string guid = "";
            StringBuilder checkSql = new StringBuilder();
            checkSql.Append("select  * from  user_cooperate where user_name=@user_name and password=@password");
            SqlParameter[] checkparameters = { 
                    new SqlParameter("@user_name", SqlDbType.VarChar, 250),                                             
                    new SqlParameter("@password", SqlDbType.VarChar,100) 
                    };
            checkparameters[0].Value = context.Request.Form["username"].ToString();
            checkparameters[1].Value = nrWebClass.Security.String2MD5(context.Request.Form["password"].ToString());

            using (IDataReader dataReader = sqlhelper.ExecuteReader(checkSql.ToString(), CommandType.Text, checkparameters))
            {
                if (dataReader.Read())
                {//登陆成功
                    myResult = "true";
                    guid = (Guid.NewGuid()).ToString();
                    msg = "loginok.aspx";//跳转地址
                    #region 更新数据库中的guid,生成时间和IP
                    StringBuilder upGuidSql = new StringBuilder();
                    upGuidSql.Append("update user_cooperate set guid=@guid,guidtime=getdate(),guidip=@guidip where user_name=@user_name and password=@password");
                    SqlParameter[] upGuidParameters = { 
                            new SqlParameter("@user_name", SqlDbType.VarChar, 250),
                            new SqlParameter("@password", SqlDbType.VarChar,100),	
                            new SqlParameter("@guid", SqlDbType.VarChar,36),
                            new SqlParameter("@guidip", SqlDbType.VarChar,15)
                            };
                    upGuidParameters[0].Value = context.Request.Form["username"].ToString();
                    upGuidParameters[1].Value = nrWebClass.Security.String2MD5(context.Request.Form["password"].ToString());
                    upGuidParameters[2].Value = guid;
                    upGuidParameters[3].Value = ip;
                    if (sqlhelper.ExecuteNonQuery(upGuidSql.ToString(), CommandType.Text, upGuidParameters) > 0)
                    {//更新成功
                    }
                    else
                    {
                        myResult = "false";
                        msg = "登陆失败,请联系利郎供管委管理员";
                    }
                    #endregion
                }
                else
                {//登陆失败
                    myResult = "false";
                    msg = "用户名密码错误";
                }
            }


            context.Response.Clear();
            context.Response.Write("{r:'" + myResult + "',msg:'" + msg + "',guid:'" + guid + "'}");
        }
        else if (requestType == "password_edit")
        {
            //修改密码
            string myResult = ""; string msg = "";
            #region 验证连接有效性
            string guid = HttpContext.Current.Request.Cookies["guid"].Value;
            StringBuilder checkSql = new StringBuilder();
            checkSql.Append(" declare @myErrorInt int;");
            checkSql.Append("if  exists (select id from  user_cooperate where guidip=@ip and guid=@guid)" +
                            " begin  " +
                            "  select @myErrorInt= case when  DATEDIFF (MINUTE,GUIDTIME,GETDATE()) >30 then  2 when  password <> @password then 3 else 0 end  from  user_cooperate where guidip=@ip and guid=@guid;  " +
                            " end " +
                            "else " +
                            " begin " +
                            "  select @myErrorInt=1;" +
                            " end " +
                            "select @myErrorInt;");
            SqlParameter[] checkparameters = { 
                    new SqlParameter("@ip", SqlDbType.VarChar, 15),
                    new SqlParameter("@password", SqlDbType.VarChar,100),                                                 
                    new SqlParameter("@guid", SqlDbType.VarChar,36) 
                    };
            checkparameters[0].Value = ip;
            checkparameters[1].Value = nrWebClass.Security.String2MD5(context.Request.Form["oldpw"].ToString());
            checkparameters[2].Value = guid;
            int myErrorInt = int.Parse(sqlhelper.ExecuteScalar(checkSql.ToString(), CommandType.Text, checkparameters).ToString());
            #endregion
            if (myErrorInt == 0)
            {//验证成功

                #region 更改密码
                StringBuilder upPassworldSql = new StringBuilder();
                upPassworldSql.Append("update user_cooperate set password=@password where guidip=@ip and guid=@guid");
                SqlParameter[] upPassworldParameters = { 
                        new SqlParameter("@password", SqlDbType.VarChar,100),	
                        new SqlParameter("@guid", SqlDbType.VarChar,36),
                        new SqlParameter("@ip", SqlDbType.VarChar,15)
                        };
                upPassworldParameters[0].Value = nrWebClass.Security.String2MD5(context.Request.Form["newpw"].ToString()); ;
                upPassworldParameters[1].Value = guid;
                upPassworldParameters[2].Value = ip;
                if (sqlhelper.ExecuteNonQuery(upPassworldSql.ToString(), CommandType.Text, upPassworldParameters) > 0)
                {//更新成功
                    myResult = "true";
                }
                else
                {
                    myResult = "false";
                    msg = "密码修改失败";
                }
                #endregion
            }
            else if (myErrorInt == 1)
            {
                myResult = "false";
                msg = "无效连接,请重新登陆";
            }
            else if (myErrorInt == 2)
            {
                myResult = "false";
                msg = "连接超时,请重新登陆";
            }
            else if (myErrorInt == 3)
            {
                myResult = "false";
                msg = "原始密码错误,请重新输入";
            }
            else if (myErrorInt == 99)
            {
                myResult = "false";
                msg = "连接失败,请联系利郎供管委管理员";
            }
            context.Response.Clear();
            context.Response.Write("{r:'" + myResult + "',msg:'" + msg + "'}");
        }
        else if (requestType == "modify")
        {
            string myResult = ""; string msg = "";
            #region 验证连接有效性
            string guid = HttpContext.Current.Request.Cookies["guid"].Value;
            StringBuilder checkSql = new StringBuilder();
            checkSql.Append(" declare @myErrorInt int;");
            checkSql.Append("if  exists (select id from  user_cooperate where guidip=@ip and guid=@guid)" +
                            " begin  " +
                            "  select @myErrorInt=0 " +
                            " end " +
                            "else " +
                            " begin " +
                            "  select @myErrorInt=1;" +
                            " end " +
                            "select @myErrorInt;");
            SqlParameter[] checkparameters = { new SqlParameter("@ip", SqlDbType.VarChar, 15),                                                                                
                                             new SqlParameter("@guid", SqlDbType.VarChar,36) };
            checkparameters[0].Value = ip;
            checkparameters[1].Value = guid;
            int myErrorInt = int.Parse(sqlhelper.ExecuteScalar(checkSql.ToString(), CommandType.Text, checkparameters).ToString());
            #endregion
            if (myErrorInt == 0)
            {//验证成功

                #region 更新数据库中的guid,生成时间和IP
                StringBuilder upInfoSql = new StringBuilder();
                upInfoSql.Append("update user_cooperate set real_name=@real_name,email=@email,product=@product,address=@address,phone=@phone,ip=@ip where guidip=@ip and guid=@guid");
                SqlParameter[] upInfoParameters = { 					    
					    new SqlParameter("@real_name", SqlDbType.VarChar,250),
					    new SqlParameter("@email", SqlDbType.VarChar,100),
					    new SqlParameter("@product", SqlDbType.VarChar,100),
					    new SqlParameter("@address", SqlDbType.VarChar,100),				
					    new SqlParameter("@phone", SqlDbType.VarChar,20),
                        new SqlParameter("@ip", SqlDbType.VarChar,15),
                        new SqlParameter("@guid", SqlDbType.VarChar,36)                                                      
                        };                
                upInfoParameters[0].Value = MySysDate(context.Request.Form["realname"].ToString());
                upInfoParameters[1].Value = MySysDate(context.Request.Form["email"].ToString());
                upInfoParameters[2].Value = MySysDate(context.Request.Form["product"].ToString());
                upInfoParameters[3].Value = MySysDate(context.Request.Form["address"].ToString());
                upInfoParameters[4].Value = MySysDate(context.Request.Form["phone"].ToString());
                upInfoParameters[5].Value = ip;
                upInfoParameters[6].Value = guid;
                if (sqlhelper.ExecuteNonQuery(upInfoSql.ToString(), CommandType.Text, upInfoParameters) > 0)
                {//更新成功
                    myResult = "true";
                }
                else
                {
                    myResult = "false";
                    msg = "资料修改失败";
                }
                #endregion
            }
            else if (myErrorInt == 1)
            {
                myResult = "false";
                msg = "无效连接,请重新登陆";
            }
            context.Response.Clear();
            context.Response.Write("{r:'" + myResult + "',msg:'" + msg + "'}");
        }

    }

    /// <summary>
    /// 解码
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string MySysDate(string str)
    {
        return HttpContext.Current.Server.UrlDecode(str);
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}