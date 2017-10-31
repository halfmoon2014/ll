using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LiLanzModel;
using System.Threading;

namespace PrintTest
{
    public partial class FrmPrintSingle : Form
    {
        Dictionary<string, OrderLabelInfo> dictLable = new Dictionary<string, OrderLabelInfo>();
        List<OrderLabelDetail> DetailList = new List<OrderLabelDetail>();
        LoadFace loading;

        public FrmPrintSingle()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            loading = new LoadFace(this);
        }

        private void txtBarCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && txtBarCode.Text.Length > 0) 
            {
                loading.show();
                Thread thread = new Thread(LoadData);
                thread.IsBackground = true;
                thread.Start();
            }
        }

        private void FrmPrintSingle_Load(object sender, EventArgs e)
        {
            
        }
        private void LoadData()
        {
            WebService.LabelPrint serv = new WebService.LabelPrint();
            string rel = serv.BarCodeOrderId(txtBarCode.Text);
            List<OrderLabelInfo> Labels = Serializer.XmlDeSerialize<List<OrderLabelInfo>>(rel);
            if (Labels.Count == 0)
            {
                MessageBox.Show("找不到该条码");
                return;
            }
            foreach (OrderLabelInfo lable in Labels)
            {
                if (!dictLable.ContainsKey(lable.Sphh))
                    dictLable.Add(lable.Sphh, lable);
            }
            /*条码明细*/
            rel = serv.BarCodeDetail(txtBarCode.Text);
            OrderLabelDetail detail = Serializer.XmlDeSerialize<OrderLabelDetail>(rel);
            ListViewItem lvi = new ListViewItem(new string[] { detail.Spid, detail.Tm, detail.Qrcode, detail.Hx, detail.Lsdj });
            DetailList.Add(detail);

            listView1.Items.Add(lvi);
            txtBarCode.Text = "";

            loading.hide();
        }
        private void PrintLable()
        {
            LabelPrint _print = new LabelPrint(0);
            _print.LeftMargin = (320 - 45 * 6) / 2;
            _print.topMargin = (440 - 203 * 2) / 2;

            /*获取订单明细记录*/
            _print.detaillist = DetailList;

            /*获取标签内容*/
            _print.DictLabel = dictLable;

            _print.print();
            //labelinfo = _print.pagelabel; //返回页面打印内容情况
            //labelinfo.info = String.Format("订单号：{0}订单日期：{1}", _order.Ordersn, _order.Odate);
            loading.hide();
        }

        private void BtnPrintLable_Click(object sender, EventArgs e)
        {
            loading.show();
            Thread thread = new Thread(PrintLable);
            thread.IsBackground = true;
            thread.Start();
        }
    }
}
