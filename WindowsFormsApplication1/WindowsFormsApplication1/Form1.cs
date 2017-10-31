using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.OleDb;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ArrayList argsList = new ArrayList();
            argsList.Add(@"data\test.mdb");
            argsList.Add(@"");
            argsList.Add(@"select * from mytable");
            argsList.Add("mytable");
            ReadMDB r = new ReadMDB();
            object o = new object();
            DataSet mydataset = r.MDBreader(o, argsList);
            string a="";
            foreach (DataRow dr in mydataset.Tables[0].Rows)
            {
                a += dr["myname"].ToString();
            }
            textBox1.Text = a;
        }
    }
    public class ReadMDB
    {
        public DataSet MDBreader(object data, ArrayList argsList)
        {
            #region xx
            string filepath = (string)argsList[0];
            string passWord = (string)argsList[1];
            string sqlstr = (string)argsList[2];
            string tablename = (string)argsList[3];
            OleDbDataAdapter myadapter;
            string strcon = sqlstr;
            if (passWord == "")
            {
                myadapter = new OleDbDataAdapter(strcon, InitialConnection(filepath));
            }
            else
            {
                myadapter = new OleDbDataAdapter(strcon, InitialConnection(filepath, passWord));
            }
            DataSet mydataset = new DataSet();
            myadapter.Fill(mydataset, tablename);
            return mydataset;
            #endregion
        }



        public OleDbConnection InitialConnection(string filepath)
        {
            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath;
            OleDbConnection connection = new OleDbConnection(constr);
            return connection;
        }
        public OleDbConnection InitialConnection(string filepath, string password)
        {

            string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Jet OLEDB:Database Password=" + password + ";";
            OleDbConnection connection = new OleDbConnection(constr);
            return connection;

        }
    }
}
