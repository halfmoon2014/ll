using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
namespace eSignage
{
    public partial class FormMain : Form
    {
        borcast _borcast;
        Thread thread;
        List<Dictionary<string, object>> list;
        int page = 0;
        int size = 8;
        int sec = 0;
        #region 内存回收
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        /// <summary>
        /// 释放内存
        /// </summary>
        public static void ClearMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
        #endregion
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;

            float SH = Properties.Settings.Default.heigth; //Screen.PrimaryScreen.Bounds.Height;
            float SW = Properties.Settings.Default.width;//Screen.PrimaryScreen.Bounds.Width;
            double scale = 1920f / SW;
            SH = (float)(1080f / scale); //按1080f标准
            this.Height = (Int32)SH;
            this.Width = (Int32)SW;
            //Console.WriteLine("heigth:{0}",SH);
            //if(Screen.AllScreens.Length > 1)
            //{
            //    SH = Screen.AllScreens[1].Bounds.Height;
            //    SW = Screen.AllScreens[1].Bounds.Width;
            //}
            string str = System.IO.Directory.GetCurrentDirectory() + @"/bg.png";
            Bitmap bitmap = new Bitmap(str);
            Bitmap newbitmap = new Bitmap((Int32)SW, (Int32)SH);
            Rectangle rect = new Rectangle(0, 0, (Int32)SW, (Int32)SH);
            Graphics g = Graphics.FromImage(newbitmap);
            g.DrawImage(bitmap, rect);
            this.BackgroundImage = newbitmap;

            
            labelShowTimer.Top = (Int32)(labelShowTimer.Top / scale);
            labelShowTimer.Left = (Int32)(labelShowTimer.Left / scale);
            float fontsize = (float)(labelShowTimer.Font.Size / scale);
            Font newfont = new System.Drawing.Font("微软雅黑", fontsize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            labelShowTimer.Font = newfont;

            panelbody.Top = (Int32)(panelbody.Top / scale);
            panelbody.Left = (Int32)(panelbody.Left / scale);
            panelbody.Width = (Int32)(panelbody.Width / scale);
            panelbody.Height = (Int32)(panelbody.Height / scale);

            int len = panelbody.Controls.Count - 1;
            Console.WriteLine("开始控件数{0}", len);

            for (int i = 0; i < size; i++)
            {
                eList item = new eList();
                item.ScreenWith = SW;
                item.Hide();
                panelbody.Controls.Add(item);
            }
            len = panelbody.Controls.Count - 1;
            thread = new Thread(Load_Item);
            thread.Start();
            _borcast = new borcast();
        }
        void Load_Item()
        {
            Thread.Sleep(1000);
            load_list();
        }
        void load_show()
        {
            //Console.WriteLine("开始执行显示");
            int first = page * size,
                last = (page + 1) * size;
            if (last > list.Count)
                last = list.Count;

            int idx = 0;
            for (int i = first; i < last; i++)
            {
                this.Invoke(new MethodInvoker(delegate{
                    eList item = (eList)panelbody.Controls[idx];
                    item.GoodName = list[i]["sphh"].ToString();
                    item.number = list[i]["sl"].ToString();
                    if (list[i]["sjsl"] != null)
                        item.number2 = list[i]["sjsl"].ToString();
                    item.CutSn = list[i]["ch"].ToString();
                    item.Group = list[i]["bmmc"].ToString();
                    item.Unit = list[i]["dw"].ToString();
                    item.CatName = list[i]["CatName"].ToString();
                    item.MaterialName = list[i]["chmc"].ToString();
                    item.status = int.Parse(list[i]["ddzt"].ToString());
                    item.MaterialCode = list[i]["chdm"].ToString();
                    item.RequestTime = DateTime.Parse(list[i]["bfsqrq"].ToString());
                    if (list[i].ContainsKey("ccblr"))
                    {//测试
                        item.ccblr = list[i]["ccblr"].ToString();
                    }
                    if (list[i].ContainsKey("cjllr"))
                    {
                        item.cjllr= list[i]["cjllr"].ToString();
                    }

                    item.load_data();
                    if (int.Parse(list[i]["ddzt"].ToString()) == 4)
                    {//通知领料的是绿色
                        item.BackColor = Color.Green;
                    }
                    item.Show();
                    Application.DoEvents();       
                    idx++;
                    if (item.status == 1)
                        _borcast.add(item.Group, item.GoodName, item.CutSn);
                }));  
                  
                Thread.Sleep(100);
                
            }
            Thread.Sleep(120000);
            //Application.DoEvents();
            //Console.WriteLine("开始执行Hide");
            load_hide();
            if (last == list.Count) //最后1页，重新加载,非最后页加载下一页         
            {
                list = null;
                load_list();
            }
            else
            {
                page++;
                load_show();
            }
        }
        void load_list()
        {
            ServiceEsign.ServiceESignage serv = new ServiceEsign.ServiceESignage();
            string json = serv.CutInfo();
            list = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);
            page = 0;//从0页重新开始
            serv.Dispose();
            serv = null;
            load_show();
        }
        void load_hide()
        {
            int len = panelbody.Controls.Count - 1;
            //Console.WriteLine("控件数{0}", len);
            for (int i = len; i >= 0; i--)
            {
               this.Invoke(new MethodInvoker(delegate{
                   panelbody.Controls[i].Hide();
                   Application.DoEvents();                       
               }));
               Thread.Sleep(100);
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            thread.Abort();
            _borcast.stop();
        }

        private void TimerShow_Tick(object sender, EventArgs e)
        {
            if (sec == 20)
            {
                ClearMemory();
                sec = 0;
            }
            labelShowTimer.Text = string.Format("{0:yyyy-MM-dd hh:mm:ss}",DateTime.Now);
            sec++;
        }
    }
}
