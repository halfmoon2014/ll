using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.DataBase;
public partial class Account_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        string connString=ConfigurationManager.AppSettings["DBCon"];
        string user = UserName.Text.ToString();
        string psw = Password.Text.ToString();
        if (connString!=string.Empty)
        {
            string str_sql = "select userid from [user] where [user]={0} and password={1}";
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, string.Format(str_sql, user, psw));
            if (ds.Tables[0].Rows.Count <= 0)
            {//没有找到
                 
            }
            else
            {
                HttpContext.Current.Session["userid"] = ds.Tables[0].Rows[0]["userid"];
                Response.Redirect("main.aspx");

            }
        }
    }
}
