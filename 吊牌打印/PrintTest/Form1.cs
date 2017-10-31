using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ThoughtWorks.QRCode.Codec;
using GenCode128;
using LiLanzModel;
using System.Threading;
using System.Collections;
using UILogin;
namespace PrintTest
{
    public partial class Form1 : Form
    {
        static public int LeftMargin = 0, TopMargin = 0, printType = 1;
        PageLabelinfo labelinfo;
        public static readonly log4net.ILog log =
           log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static string UserName = "";

        //enum OrderStatus { , Monday, Tuesday, Wednesday, Thursday, Friday, Saturday };

        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 没有用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPrt_Click(object sender, EventArgs e)
        {
            toolStripProgressBar1.Visible = true;

            Thread thread = new Thread(LoadDetail);
            thread.IsBackground = true;
            thread.Start();
        }       
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Login frm = new Login();
            frm.ShowDialog();
            if (Login.UserName == "")
            {
                log.Info("登录不成功");
                this.Close();
            }
            Control.CheckForIllegalCrossThreadCalls = false;
            txtdateStart.Value = DateTime.Now.AddDays(-30);
            txtdateEnd.Value = DateTime.Now;
            log.Info("初始化成功");
        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            //serv.list();
        }

        private void btnQuerySubmit_Click(object sender, EventArgs e)
        {
            listViewOrder.Items.Clear();
            WebService.LabelPrint serv = new WebService.LabelPrint();
            string _val = serv.list(txtdateStart.Value, txtdateEnd.Value);
            List<OrderList> list = Serializer.XmlDeSerialize<List<OrderList>>(_val);
            foreach (OrderList order in list) 
            {
                if (checkBoxStatus.Checked && !bool.Parse(order.Isqs))
                    continue;

                if (bool.Parse(order.Isqs))
                    order.Isqs = "已签收";
                else
                    order.Isqs = "未签收";

                if (TxtBillSn.Text.TrimEnd().Length > 0 && order.Ordersn.IndexOf(TxtBillSn.Text.TrimEnd()) < 0)
                    continue;
                ListViewItem lvi = new ListViewItem(new string[] { order.Odate, order.Ordersn, order.Note, order.Chdm, order.Isqs, order.Creater });
                lvi.Tag = order;
                listViewOrder.Items.Add(lvi);
            }
            panel1.Visible = false;
        }
        private void LoadDetail() 
        {
          
            if (listViewOrder.SelectedItems.Count < 1)
                return;

            OrderList _order = (OrderList)listViewOrder.SelectedItems[0].Tag;
            int id = int.Parse(_order.Id);

            WebService.LabelPrint serv = new WebService.LabelPrint();
            List<OrderLabelDetail> detaillist = new List<OrderLabelDetail>();

            foreach (ListViewItem item in listViewDetail.Items)
            {
                if (item.Checked)
                {
                    labelLoading.Text = String.Format("正在下载{0}信息", item.SubItems[0].Text);
                    string _val = serv.orderDetailItem(id, item.SubItems[0].Text);
                    //log.Info(_val);
                    List<OrderLabelDetail> _detaillist = Serializer.XmlDeSerialize<List<OrderLabelDetail>>(_val);
                    log.InfoFormat("记录数：{0}", _detaillist.Count);
                    detaillist.AddRange(_detaillist);
                }
               
            }
            labelLoading.Text = "开始打印...";

            LabelPrint14 _print = new LabelPrint14(printType);

            _print.PageLableCount = 12;
            _print.LabelHeigth = 108;
            _print.LabelTotalHeigth = 203;
            _print.LabelWidth = 45;

            /*获取订单明细记录*/
            _print.detaillist = detaillist;

            /*获取标签内容*/
            string _strval = serv.ItemInfo(id);

            log.InfoFormat("标签内容：{0}", _strval);

            _print.DictLabel = common.List2Dict(Serializer.XmlDeSerialize<List<OrderLabelInfo>>(_strval));
            _print.Order = _order;

            _print.print();
            labelinfo = _print.pagelabel; //返回页面打印内容情况
            labelinfo.info = String.Format("订单号：{0}订单日期：{1}", _order.Ordersn, _order.Odate);

            LoadHide();
        }
        /// <summary>
        /// 打印标签
        /// </summary>
        private void PrintLabel()
        {
            if (listViewOrder.SelectedItems.Count < 1)
                return;

            OrderList _order = (OrderList)listViewOrder.SelectedItems[0].Tag;
            int id = int.Parse(_order.Id);

            WebService.LabelPrint serv = new WebService.LabelPrint();
            string _val = serv.orderDetail40mm(id);
            List<OrderLabelDetail> detaillist = Serializer.XmlDeSerialize<List<OrderLabelDetail>>(_val);

            log.InfoFormat("条码:{0}", _val);

            LabelPrint14 _print = new LabelPrint14(printType);

            /*获取订单明细记录*/
            _print.detaillist = LabelDetailGenerate(DataFilter(detaillist));//此处添加筛选

            /*获取标签内容*/
            _val = serv.ItemInfo(id);
           
            _print.DictLabel = common.List2Dict(Serializer.XmlDeSerialize<List<OrderLabelInfo>>(_val));
            _print.Order = _order;

            _print.print();
            labelinfo = _print.pagelabel; //返回页面打印内容情况
            labelinfo.info = String.Format("订单号：{0}订单日期：{1}", _order.Ordersn, _order.Odate);

            LoadHide();
        }

        private void listViewOrder_DoubleClick(object sender, EventArgs e)
        {
            listViewDetail.Items.Clear();
            if (listViewOrder.SelectedItems.Count < 1)
                return;
            int id = int.Parse(((OrderList)listViewOrder.SelectedItems[0].Tag).Id);
            WebService.LabelPrint serv = new WebService.LabelPrint();
            string _val = serv.orderItem(id);
            List<OrderLabelItem> list = Serializer.XmlDeSerialize<List<OrderLabelItem>>(_val);

            foreach (OrderLabelItem item in list)
            {
                ListViewItem lvi = new ListViewItem(new string[] { item.Sphh, item.Spmc, item.Sl, item.Temp, "" });
                lvi.Checked = true;
                lvi.Tag = item;
                listViewDetail.Items.Add(lvi);
            }
        }

        private void listViewOrder_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewOrder.Items)
            {
                item.BackColor = Color.White;
            }
            if (listViewOrder.SelectedItems.Count > 0)
            {
                listViewOrder.SelectedItems[0].BackColor = Color.Yellow;
            }         
        }

        private void BtnPrintLable_Click(object sender, EventArgs e)
        {
            if (listViewOrder.SelectedItems.Count < 1)
                return;

            OrderList _order = (OrderList)listViewOrder.SelectedItems[0].Tag;

            LoadShow();
             Thread thread;
            if(_order.Chdm == "M82002845")
                thread = new Thread(LoadDetail);//PrintLabel LoadDetail
            else
                thread = new Thread(PrintLabel);

            thread.IsBackground = true;
            thread.Start();
        }

        private void btnOrderInfo_Click(object sender, EventArgs e)
        {
            //Dictionary<int, PagePrintItem> labels = labelinfo.GetAll();
            //for (int i = 0; i < labels.Count; i++)
            //    txtLog.AppendText( String.Format("位置：{0} 规格数： {1} \r\n" , i, labels[i].GetAll().Count));

            OrderInfoPrint print = new OrderInfoPrint();
            print.labels = labelinfo.GetAll();
            print.title = labelinfo.info;
            print.print();
        }

        private void BtnSet_Click(object sender, EventArgs e)
        {
            FrmSet frm = new FrmSet();
            frm.ShowDialog();
        }
        private void LoadShow()
        {
            toolStripProgressBar1.Visible = true;
            PanelLoad.Visible = true;
            BtnPrintLable.Enabled = false;
        }
        private void LoadHide()
        {
            toolStripProgressBar1.Visible = false;
            PanelLoad.Visible = false;
            BtnPrintLable.Enabled = true;
        }
        private List<OrderLabelDetail> DataFilter(List<OrderLabelDetail> labels)
        {
            Hashtable ht = new Hashtable();
            List<OrderLabelDetail> LabelsFilter = new List<OrderLabelDetail>();

            foreach (ListViewItem item in listViewDetail.Items)
            {
                if(!item.Checked)
                    ht.Add(item.SubItems[0].Text, true);
            }
            
            foreach (OrderLabelDetail orderdetail in labels)
            {
                if (!ht.ContainsKey(orderdetail.Sphh))
                    LabelsFilter.Add(orderdetail);
            }
            return LabelsFilter;
        }
      
        private void BtnRepair_Click(object sender, EventArgs e)
        {
            FrmPrintSingle frm = new FrmPrintSingle();
            frm.Show();
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            AboutBox frm = new AboutBox();
            frm.ShowDialog();
        }
        /// <summary>
        /// 条码分解
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        private List<OrderLabelDetail> LabelDetailGenerate(List<OrderLabelDetail> detail)
        {
            List<OrderLabelDetail> printdetail = new List<OrderLabelDetail>();

            foreach (OrderLabelDetail label in detail)
            {
                int num = label.Num;
                for (int i = 0; i < num; i++)
                    printdetail.Add(label);

            }

            return printdetail;
        }
    }
}
