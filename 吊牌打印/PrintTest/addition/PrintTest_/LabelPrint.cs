using System;
using System.Collections.Generic;
using System.Text;
using ThoughtWorks.QRCode.Codec;
using GenCode128;
using LiLanzModel;
using System.Drawing;
using System.Windows.Forms;

namespace PrintTest
{
    class LabelPrint
    {
        Font font = new Font("微软雅黑", 6, FontStyle.Regular);
        Font FontTitle = new Font("微软雅黑", 6, FontStyle.Bold);
        Font FontName = new Font("微软雅黑", 6, FontStyle.Bold);
        Brush brush = new SolidBrush(Color.Black);
        Pen pen = new Pen(Color.Gray, 0.1f);
        Font FontCode128 = new Font("微软雅黑", 7, FontStyle.Regular);
        Font font5 = new Font("微软雅黑", 5, FontStyle.Regular);
        
        System.Drawing.Printing.PrintDocument PrintDoc 
            = new System.Drawing.Printing.PrintDocument();
        int curr = 0;
        int currY = 0;
        /// <summary>
        /// 总页数
        /// </summary>
        int total = 0;
        int currPage = 0;

        /// <summary>
        /// 标签流水号
        /// </summary>
        public List<OrderLabelDetail> detaillist;

        /// <summary>
        /// 标签信息，弃用，改用直接传入索引
        /// </summary>
        public List<OrderLabelInfo> LabelInfo;

        public int LeftMargin = 0, topMargin = 0;
        public int PrintType = 0;
        
        /// <summary>
        /// 页面打印的信息
        /// </summary>
        public PageLabelinfo pagelabel = new PageLabelinfo();

        /// <summary>
        /// 订单信息
        /// </summary>
        public OrderList Order;

        /// <summary>
        /// 按货号索引标签信息
        /// </summary>
        public Dictionary<string, OrderLabelInfo> DictLabel
            = new Dictionary<string, OrderLabelInfo>();

        public LabelPrint(int type)
        {
            if (type == 1)
                PrintDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDoc2_PrintPage);
            else
                PrintDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDoc_PrintPage);
        }
        public void print()
        {
            //foreach (OrderLabelInfo lable in LabelInfo) 
            //    DictLabel.Add(lable.Sphh, lable);
            
            PrintDialog MyPrintDg = new PrintDialog();
            MyPrintDg.Document = PrintDoc;
            if (MyPrintDg.ShowDialog() == DialogResult.OK)
            {
                total = (int)Math.Ceiling((Double)detaillist.Count / 12);
                Form1.log.InfoFormat("打印总页数：{0}", total);
                try
                {                  
                    PrintDoc.Print();
                }
                catch (Exception ex)
                {   //停止打印
                    MessageBox.Show(ex.ToString());
                    PrintDoc.PrintController.OnEndPrint(PrintDoc, new System.Drawing.Printing.PrintEventArgs());
                }
            }
        }
        private void PrintDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = System.Drawing.GraphicsUnit.Millimeter; //单位为毫米
            /*绘制辅助线*/
            /*
            int h = 2;
            int count = 10;
            for (int i = 0; i < count; i++)
            {
                e.Graphics.DrawLine(pen, new Point(10 * i, 0), new Point(10 * i, h));
            }

            for (int i = 0; i < count; i++)
            {
                e.Graphics.DrawLine(pen, new Point(0, 10 * i), new Point(2, 10 * i));
            }
            */
            for (int i = 0; i < 12; i++)
            {
                Form1.log.InfoFormat("标签：{0}", curr);
                if (curr >= detaillist.Count)
                {
                    break;
                }
                if (i < 6)
                    Tag_Draw(LeftMargin + i * 45, topMargin + 95, e.Graphics, detaillist[curr]);
                else
                    Tag_Draw(LeftMargin + (i - 6) * 45, topMargin + 298 + 6, e.Graphics, detaillist[curr]);

                curr++;
            }
            //if (curr < detaillist.Count && curr < 12)
            if (curr < detaillist.Count)
            {
                e.HasMorePages = true;
            }
            else
                e.HasMorePages = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintDoc2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = System.Drawing.GraphicsUnit.Millimeter; //单位为毫米
            for (int i = 0; i < 12; i++)
            {
                curr = total * i  + currPage;
                //Form1.log.InfoFormat("当前：{0} 总的个数：{1}", curr, detaillist.Count);
                if (curr >= detaillist.Count)
                {
                    continue;
                }

                if (i < 6)
                    Tag_Draw(LeftMargin + i * 45, topMargin + 95, e.Graphics, detaillist[curr]);
                else
                    Tag_Draw(LeftMargin + (i - 6) * 45, topMargin + 298 + 6, e.Graphics, detaillist[curr]);
                pagelabel.label(i, detaillist[curr].Sphh + '_' + detaillist[curr].Hx);             
            }
            //写页信息
            e.Graphics.DrawString(String.Format("共{0}页 第 {1} 页", total, currPage + 1), font, brush, new Point(5, 435));

            currPage++;
            if (currPage < total)
            {              
                e.HasMorePages = true;
            }
            else
                e.HasMorePages = false;
        }
        /// <summary>
        /// 绘制一张标签
        /// </summary>
        /// <param name="topx"></param>
        /// <param name="topy"></param>
        /// <param name="grap"></param>
        /// <param name="detail"></param>
        private void Tag_Draw(int topx, int topy, Graphics grap, OrderLabelDetail detail)
        {
            OrderLabelInfo currLable = DictLabel[detail.Sphh];

            //Form1.log.InfoFormat("货号：{0} 品名：{1} QRCOE:{2} Spid:{3}",
            //    detail.Sphh, currLable.Pm, detail.Qrcode, detail.Spid);

            string tm = "http://tm.lilanz.com/tm.aspx?id=" + detail.Qrcode;
            QRCodeEncoder qrcode = new QRCodeEncoder();
            qrcode.QRCodeScale = 1;
            qrcode.QRCodeVersion = 4;
            Bitmap bitQR = qrcode.Encode(tm);

            Image ImgCode128 = Code128Rendering.MakeBarcodeImage(detail.Spid, 1, false);

            Bitmap bitCode128 = new Bitmap(ImgCode128);
            /*ean 13*/

            Ean13 _ean13 = new Ean13(detail.Tm);
            _ean13.Scale = 1f;

            grap.DrawString("合 格 证", FontTitle, brush, new Point(topx + 18, topy + 10));

            DrawItem(grap, "品名：", currLable.Pm, topx + 5, topy + 15);

            DrawItem2(grap, "货号：", detail.Sphh, topx + 5, topy + 18);

            DrawItem2(grap, "号型：", detail.Hx, topx + 5, topy + 21);
          
            DrawMaterial(grap, currLable.Material, topx + 5, topy + 24);//纤维含量

            currY += 3;
            DrawItem(grap, "等级：", currLable.Dj + " 检验：合格" + detail.Sn, topx + 5, currY);
            currY += 3;
            DrawStandard(grap, currLable.Zxbz, topx + 5, currY);
            currY += 3;
            DrawSecurity(grap, currLable.Aqlb, topx + 5, currY);

            DrawItemPrice(grap, String.Format("¥{0}",detail.Lsdj), topx, topy + 63);

            _ean13.DrawEan13Barcode(grap, new Point(topx + 5, topy + 70));//ean 13

            grap.DrawImage(bitCode128, new Rectangle(topx + 4, topy + 80, 38, 6), 0, 0,
                bitCode128.Width, bitCode128.Height, GraphicsUnit.Pixel);

            grap.DrawString(detail.Spid, FontCode128, brush, new Point(topx + 8, topy + 86));

            grap.DrawString("(仅供内部使用)", font5, brush, new Point(topx + 16, topy + 89));

            grap.DrawImage(bitQR, new Rectangle(topx + 16, topy + 92, 13, 13), 0, 0, bitQR.Width, bitQR.Height, GraphicsUnit.Pixel);
        }
        private void DrawItem(Graphics g, string name, string value, int left, int top)
        {
            float FontWidth = g.MeasureString(name, FontName).Width;
            g.DrawString(name, FontName, brush, new Point(left, top));
            g.DrawString(value, font, brush, new Point(left + (int)FontWidth, top));
        }
        /// <summary>
        ///内容加粗
        /// </summary>
        /// <param name="g"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="left"></param>
        /// <param name="top"></param>
        private void DrawItem2(Graphics g, string name, string value, int left, int top)
        {
            float FontWidth = g.MeasureString(name, FontName).Width;
            g.DrawString(name, FontName, brush, new Point(left, top));
            g.DrawString(value, FontName, brush, new Point(left + (int)FontWidth, top));
        }
        private void DrawItemPrice(Graphics g, string value, int left, int top)
        {
            Font FontNamePrice = new Font("微软雅黑", 10, FontStyle.Bold);
            Font FontNameValue = new Font("微软雅黑", 16, FontStyle.Bold);

            float FontWidth = g.MeasureString("零售价：", FontNamePrice).Width;
            float ValueFontWidth = g.MeasureString(value, FontNameValue).Width;

            left += (int) (47 - FontWidth - ValueFontWidth) / 2; //居中显示
          
            g.DrawString("零售价：", FontNamePrice, brush, new Point(left, top));
            g.DrawString(value, FontNameValue, brush, new Point(left + (int)FontWidth - 2, top - 1));
        }

        private void DrawMaterial(Graphics g, List<MaterialInfo> list, int left, int top)
        {
            currY = top;
            g.DrawString("纤维含量：", FontName, brush, new Point(left, top));
                      
            foreach (MaterialInfo material in list)
            {
                currY += 3;
                float FontWidth = 0;
                if (material.Title == null)
                    material.Title = "";
                if (material.Title.Length > 0)
                {
                    g.DrawString(material.Title + "：", font, brush, new Point(left, currY));
                    FontWidth = g.MeasureString(material.Title + "：", font).Width;
                }
                string[] ValArr = material.Value.Split(' ');
                currY -= 3;
                foreach (string val in ValArr) 
                {
                    currY += 3;
                    g.DrawString(val, font, brush, new Point(left + (int)FontWidth, currY));                  
                }               
            }
        }
        /// <summary>
        /// 绘制执行标准
        /// </summary>
        /// <param name="g"></param>
        /// <param name="value"></param>
        /// <param name="left"></param>
        /// <param name="top"></param>
        private void DrawStandard(Graphics g, string value, int left, int top) 
        {
            float FontWidth = g.MeasureString("执行标准：", FontName).Width;
            g.DrawString("执行标准：", FontName, brush, new Point(left, top));
            if (value.IndexOf('、') > 0) 
            {
                string[] arr = value.Split('、');
           
                g.DrawString(arr[0], font, brush, new Point(left + (int)FontWidth, top));
                g.DrawString(arr[1], font, brush, new Point(left + (int)FontWidth, top + 3));
                currY += 3;
            }
            else
                g.DrawString(value, font, brush, new Point(left + (int)FontWidth, top));
        }
        /// <summary>
        /// 安全类别
        /// </summary>
        /// <param name="g"></param>
        /// <param name="value"></param>
        /// <param name="left"></param>
        /// <param name="top"></param>
        private void DrawSecurity(Graphics g, string value, int left, int top)
        {
            float FontWidth = g.MeasureString("安全技术类别：", FontName).Width;
            g.DrawString("安全技术类别：", FontName, brush, new Point(left, top));
            if (value.IndexOf('、') > 0)
            {
                string[] arr = value.Split('、');

                g.DrawString(arr[0], font, brush, new Point(left + (int)FontWidth, top));
                g.DrawString(arr[1], font, brush, new Point(left + (int)FontWidth, top + 3));
                currY += 3;
            }
            else
                g.DrawString(value, font, brush, new Point(left + (int)FontWidth, top));
        }
    }
}
