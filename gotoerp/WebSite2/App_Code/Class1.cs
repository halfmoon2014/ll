using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
/// <summary>
///Class1 的摘要说明
/// </summary>
public class Class1
{
	public Class1()
	{

	}
    public DataSet getDataSet()
    {

        //创建DbConnection对象连接数据库
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = "server=.;uid=sa;password=Hello123456!; database=test; max pool size=300;";

        //创建DataAdapter、Command对象，读取数据
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT top 11 * FROM mytesttable";
        da.SelectCommand = cmd;

        //创建DataSet对象，存储数据，建立与物理表的映射
        DataSet ds = new DataSet();
        da.Fill(ds, "TEST");
        return ds;
    }
}