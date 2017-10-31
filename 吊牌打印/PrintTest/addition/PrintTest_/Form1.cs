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

namespace PrintTest
{
    public partial class Form1 : Form
    {
        static public int LeftMargin = 0, TopMargin = 0, printType = 1;
        PageLabelinfo labelinfo;
        public static readonly log4net.ILog log =
           log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Form1()
        {
            InitializeComponent();
        }

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
            Control.CheckForIllegalCrossThreadCalls = false;
            log.Info("初始化");
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
                ListViewItem lvi = new ListViewItem(new string[] { order.Odate, order.Ordersn, order.Note });
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
            string _val = serv.orderDetail(id);
            List<OrderLabelDetail> detaillist = Serializer.XmlDeSerialize<List<OrderLabelDetail>>(_val);

            LabelPrint _print = new LabelPrint(printType);
            _print.LeftMargin = (320 - 45 * 6)/2;
            _print.topMargin = (440 - 203 * 2)/2;

            /*获取订单明细记录*/
            _print.detaillist = DataFilter(detaillist);//此处添加筛选

            /*获取标签内容*/
            _val = serv.ItemInfo(id);
            _print.DictLabel = common.List2Dict(Serializer.XmlDeSerialize<List<OrderLabelInfo>>(_val));

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
            LoadShow();

            Thread thread = new Thread(LoadDetail);
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
                //txtLog.AppendText(String.Format(" 货号： {0} \r\n", item.SubItems[0].Text));
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
    }
}
