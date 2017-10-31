<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Data" %>
<%   
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
    int supplierUserid=0;//供应商ID
    #region 验证guid ip guidtime合法性
    nrWebClass.LiLanzDAL sqlhelper = new nrWebClass.LiLanzDAL();
    if (ip == "127.0.0.1" || ip == "192.168.36.131")
    {//内部测试IP
        sqlhelper.ConnectionString = "Data Source=192.168.35.23;Persist Security Info=False;User ID=lllogin;Password=rw1894tla;Initial Catalog=tlsoft;Connect Timeout=10";
    }
    string checkSql = ("select id from  user_cooperate where guidip=@ip and guid=@guid and DATEDIFF (MINUTE,GUIDTIME,GETDATE()) <=30 ");
    SqlParameter[] checkparameters = { new SqlParameter("@ip", SqlDbType.VarChar, 15),
                                             new SqlParameter("@guid", SqlDbType.VarChar,36) }; checkparameters[0].Value = ip;
    checkparameters[1].Value = guid;
    using (IDataReader dataReader = sqlhelper.ExecuteReader(checkSql.ToString(), CommandType.Text, checkparameters))
    {
        if (dataReader.Read())
        {//请求合法
            myResult = true;
            supplierUserid=int.Parse(dataReader["id"].ToString());
        }
    }

    #endregion
    if (myResult)
    {       
        Session["supplierUserid"] = supplierUserid.ToString();
        Response.Redirect("/tl_ghs/ghs_cl_xxwh.aspx");
    }
    else
    {
        Response.Write("请求超时,请重新登陆");
        Response.End();
    }
 %>