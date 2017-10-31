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
    class LabelPrint14
    {
        Font font = new Font("微软雅黑", 6, FontStyle.Regular);

        Font font7 = new Font("微软雅黑", 7, FontStyle.Bold);

        Font FontTitle = new Font("微软雅黑", 6, FontStyle.Bold);
        Font FontName = new Font("微软雅黑", 6, FontStyle.Bold);
        Brush brush = new SolidBrush(Color.Black);
        Pen pen = new Pen(Color.Gray, 0.1f);
        Pen penBlack = new Pen(Color.Black, 0.1f);

        Pen penWhite = new Pen(Color.White, 0.1f);

        Font FontCode128 = new Font("微软雅黑", 7, FontStyle.Regular);
        Font font5 = new Font("微软雅黑", 5, FontStyle.Regular);
        
        System.Drawing.Printing.PrintDocument PrintDoc 
            = new System.Drawing.Printing.PrintDocument();

        private string CurrentTemp = "";
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

        public int LeftMargin = 0, topMargin = 0;
        public int PrintType = 0;
        /// <summary>
        ///每一个页面标签数
        /// </summary>
        public int PageLableCount = 14;

        /// <summary>
        /// 每列标签数
        /// </summary>
        private int PageLabelRowCount = 7;

        /// <summary>
        /// 标签打印部分高度
        /// </summary>
        public int LabelHeigth = 96;

        /// <summary>
        /// 标签打印部分宽度
        /// </summary>
        public int LabelWidth = 40;
        /// <summary>
        /// 标签总的高度
        /// </summary>
        public int LabelTotalHeigth = 180;
        
        /// <summary>
        /// 页面打印的信息
        /// </summary>
        public PageLabelinfo pagelabel;

        /// <summary>
        /// 订单信息
        /// </summary>
        public OrderList Order;

        /// <summary>
        /// 按货号索引标签信息
        /// </summary>
        public Dictionary<string, OrderLabelInfo> DictLabel
            = new Dictionary<string, OrderLabelInfo>();

        public LabelPrint14(int type)
        {
            if (type == 1)
                PrintDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDoc2_PrintPage);
            else
                PrintDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDoc_PrintPage);         
        }
        public void print()
        {
            LeftMargin = (320 - LabelWidth * (PageLableCount / 2)) / 2;
            topMargin = (445 - (LabelTotalHeigth * 2 + 6)) / 2;
            PageLabelRowCount = PageLableCount / 2;
            pagelabel = new PageLabelinfo(PageLableCount);

            PrintDialog MyPrintDg = new PrintDialog();
            MyPrintDg.Document = PrintDoc;
            if (MyPrintDg.ShowDialog() == DialogResult.OK)
            {
                total = (int)Math.Ceiling((Double)detaillist.Count / PageLableCount);
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
            for (int i = 0; i < 12; i++)
            {
                Form1.log.InfoFormat("标签：{0}", curr);
                if (curr >= detaillist.Count)
                {
                    break;
                }
                if (i < 6)
                    Tag_Draw(LeftMargin + i * LabelWidth, topMargin + 95, e.Graphics, detaillist[curr]);
                else
                    Tag_Draw(LeftMargin + (i - 6) * LabelWidth, topMargin + 298 + 6, e.Graphics, detaillist[curr]);

                curr++;
            }
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
    
            for (int i = 0; i < PageLableCount; i++)
            {
                curr = total * i  + currPage;
                if (curr >= detaillist.Count)             
                    continue;

                if (i < PageLabelRowCount)
                    Tag_Draw(LeftMargin + i * LabelWidth, topMargin + LabelTotalHeigth - LabelHeigth, e.Graphics, detaillist[curr]);
                else
                    Tag_Draw(LeftMargin + (i - PageLabelRowCount) * LabelWidth, topMargin + LabelTotalHeigth * 2 - LabelHeigth + 6, e.Graphics, detaillist[curr]);
                pagelabel.label(i, detaillist[curr].Sphh + '_' + detaillist[curr].Hx);             
            }
            //写页信息
            Font font7 = new Font("微软雅黑", 7, FontStyle.Regular);
            e.Graphics.DrawString(String.Format("共{0}页 第 {1} 页 订单号: {2} 模板: {3}", total, currPage + 1, Order.Ordersn,
                CurrentTemp), font7, brush, new Point(250, 3));
            e.Graphics.DrawString(String.Format("共{0}页 第 {1} 页 订单号: {2} 模板: {3}", total, currPage + 1, Order.Ordersn,
                CurrentTemp), font7, brush, new Point(5, 435));
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
            CurrentTemp = currLable.Template;
       
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
            /*
            grap.DrawEllipse(pen, topx + 22, topy +  6, 1, 1);
            grap.DrawEllipse(penWhite, topx + 22, topy - 8, 1, 1);
            */
            //grap.DrawRectangle(pen, topx, topy, LabelWidth, LabelHeigth);

            grap.DrawString("合 格 证", FontTitle, brush, new Point(topx + (LabelWidth - 8) / 2, topy + 10));

            DrawItem(grap, "品名：", currLable.Pm, topx + 5, topy + 15);

            DrawItem2(grap, "货号：", detail.Sphh, topx + 5, topy + 18);

            currY = topy + 21;

            if (detail.Gg == null)
                detail.Gg = "";
            if (detail.Hx == null)
                detail.Hx = "";
            
            if (detail.Hx.TrimEnd().Length > 0 || detail.Gg.TrimEnd().Length > 0)
            {
                if (detail.Hx.TrimEnd().Length > 0)
                    DrawItem2(grap, "号型：", detail.Hx, topx + 5, currY);
                else
                    DrawItem2(grap, "规格：", detail.Gg, topx + 5, currY);              
                currY = currY + 3;
            }
            /*
             * 40mm促销品
             */
            if (LabelWidth == 40)
            {
                DrawItem(grap, "颜色：", currLable.Iname.Split('-')[1], topx + 5, currY);
                currY = currY + 3;
            }

            if (currLable.Template.TrimEnd().ToUpper() != "K")
                DrawMaterial(grap, "纤维含量：", currLable.Material, topx + 5, currY);//纤维含量
            else
            {
                DrawMaterial(grap, "材质：", currLable.Material, topx + 5, currY);//纤维含量
                currY += 3;
                DrawItem(grap, "生产日期：", currLable.ProDate.ToString("yyyy-MM-dd"), topx + 5, currY);
                /*
                * J版需要打生产日期、商标
                */
            }
         
            currY += 3;
            DrawLevel(grap, currLable.Dj, detail.Sn, topx + 5, currY); //等级

            currY += 3;
            DrawStandard(grap, currLable.Zxbz, topx + 5, currY);
            currY += 3;
            DrawSecurity(grap, currLable.Aqlb, topx + 5, currY);

            currY = topy + (LabelHeigth - 43);

            DrawItemPrice(grap, String.Format("¥{0}", currLable.Lsdj), topx, currY);

            _ean13.DrawEan13Barcode(grap, new Point(topx + (LabelWidth - 36) / 2, currY));//ean 13

            currY += 10;
            grap.DrawImage(bitCode128, new Rectangle(topx + 3, currY, (LabelWidth - 6), 6), 0, 0,
                bitCode128.Width, bitCode128.Height, GraphicsUnit.Pixel); //左右各留3mm
         
            currY += 6;
            float FontWidth = grap.MeasureString(detail.Spid, FontCode128).Width;
            grap.DrawString(detail.Spid, FontCode128, brush, new Point(topx + (LabelWidth - (int)FontWidth)/2, currY));

            currY += 3;
            grap.DrawString("(仅供内部使用)", font5, brush, new Point(topx + (LabelWidth - 12)/2, currY));

            currY += 3;
            grap.DrawImage(bitQR, new Rectangle(topx + (LabelWidth  - 13)/2, currY, 13, 13), 0, 0, bitQR.Width, bitQR.Height, GraphicsUnit.Pixel);
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
            value = value.TrimEnd();
           
            float FontWidth = g.MeasureString(name, FontName).Width;
            g.DrawString(name, FontName, brush, new Point(left, top));
            if (value.IndexOf(' ') < 0)
                g.DrawString(value, font7, brush, new Point(left + (int)FontWidth, top));
            else
            {
                g.DrawString(value.Split(' ')[0], font7, brush, new Point(left + (int)FontWidth, currY));
                currY = currY + 3;
                g.DrawString(value.Split(' ')[1], font7, brush, new Point(left + (int)FontWidth, currY));
            }
        }
        private void DrawItemPrice(Graphics g, string value, int left, int top)
        {
            int sizeName = 10, sizeValue = 16;

            if(LabelWidth == 40){
                sizeName = 9;
                sizeValue = 14;
            }

            Font FontNamePrice = new Font("微软雅黑", sizeName, FontStyle.Bold);
            Font FontNameValue = new Font("微软雅黑", sizeValue, FontStyle.Bold);

            float FontWidth = g.MeasureString("零售价：", FontNamePrice).Width;
            float ValueFontWidth = g.MeasureString(value, FontNameValue).Width;
            float FontHeigth = g.MeasureString(value, FontNameValue).Height;

            currY = top + (int)FontHeigth - 2;//高度偏移

            left += (int)(LabelWidth - FontWidth - ValueFontWidth) / 2; //居中显示
            left += 2;
          
            g.DrawString("零售价：", FontNamePrice, brush, new Point(left, top));
            g.DrawString(value, FontNameValue, brush, new Point(left + (int)FontWidth - 2, top - 1));
        }

        private void DrawMaterial(Graphics g, String name, List<MaterialInfo> list, int left, int top)
        {
            Font fontMaterial = new Font("微软雅黑", 5, FontStyle.Regular);

            currY = top;
            g.DrawString(name, FontName, brush, new Point(left, top));

            currY += 3;
            foreach (MaterialInfo material in list)
            {          
                float FontWidth = 0, TotalFontWith = 0;
                if (material.Title == null)
                    material.Title = "";
                if (material.Title.Length > 0)
                {
                    g.DrawString(material.Title + "：", fontMaterial, brush, new Point(left, currY));
                    FontWidth = g.MeasureString(material.Title + "：", fontMaterial).Width;
                    TotalFontWith = FontWidth;
                }           

                string[] ValArr = material.Value.Split(' ');
                //currY -= 3;
                foreach (string val in ValArr) 
                {
                    //currY += 3;
                    if ((TotalFontWith + g.MeasureString(val, fontMaterial).Width) > (LabelWidth - 10))
                    {
                        currY = currY + 3;
                        //Form1.log.InfoFormat("currY {0}", currY);
                        TotalFontWith = FontWidth;
                    }
                    //else
                    //    currY = currY - 3;
                    //Form1.log.InfoFormat("TotalFontWith {0} Y: {1} val : {2} 宽 {3} ", TotalFontWith, currY, val, g.MeasureString(val, font).Width);
                    g.DrawString(val, fontMaterial, brush, new Point(left + (int)TotalFontWith, currY));
                    TotalFontWith += g.MeasureString(val, fontMaterial).Width;
                    //if (TotalFontWith > LabelWidth)                   
                    //currY += 3;
                }
                currY += 3;
            }
            currY -= 3;
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
        /// 安全类别,内容如果没有则不打印
        /// </summary>
        /// <param name="g"></param>
        /// <param name="value"></param>
        /// <param name="left"></param>
        /// <param name="top"></param>
        private void DrawSecurity(Graphics g, string value, int left, int top)
        {
            if (value.TrimEnd() == "")
                return;
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
        private void DrawLevel(Graphics g, string val1, string val2, int left, int top)
        {
            float FontWidth = g.MeasureString("等级：", FontName).Width;
            g.DrawString("等级：", FontName, brush, new Point(left, top));

            left += Convert.ToInt32(FontWidth);
            g.DrawString(val1, font, brush, new Point(left, top));

            FontWidth = g.MeasureString(val1, font).Width;
            left += Convert.ToInt32(FontWidth);
            g.DrawString(" 检验：", FontName, brush, new Point(left, top));

            FontWidth = g.MeasureString(" 检验：", FontName).Width;
            left += Convert.ToInt32(FontWidth);

            g.DrawString("合格" + val2, font, brush, new Point(left, top));
        }
    }
}
