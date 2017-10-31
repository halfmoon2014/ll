using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace PrintTest
{
    class OrderInfoPrint
    {
        System.Drawing.Printing.PrintDocument PrintDoc
           = new System.Drawing.Printing.PrintDocument();
        Pen pen = new Pen(Color.Gray, 0.1f);
        public Dictionary<int, PagePrintItem> labels;
        public string title = "";

        Font font = new Font("微软雅黑", 6, FontStyle.Regular);
        Brush brush = new SolidBrush(Color.Black);
       
        public OrderInfoPrint()
        {
            PrintDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDoc_PrintPage);
        }
        private void PrintDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = System.Drawing.GraphicsUnit.Millimeter; //单位为毫米

            e.Graphics.DrawString(title, font, brush, new Point(5, 5));

            int count = 6;
            for (int i = 1; i < count; i++)
            {
                e.Graphics.DrawLine(pen, new Point(40 * i + 5, 10), new Point(40 * i + 5, 200));
            }
            e.Graphics.DrawLine(pen, new Point(0, 100), new Point(300, 100));

            int x = 0, y = 0;
            for (int i = 0; i < labels.Count; i++)
            {

                if (i < 6)
                {
                    y = 20;
                    x = i * 40 + 5;
                }
                else
                {
                    y = 120;
                    x = (i - 6) * 40 + 5;
                }
               
                Dictionary<string,int> items = labels[i].GetAll();
                foreach (KeyValuePair<string, int> item in items)
                {
                    y += 3;    
                    e.Graphics.DrawString(String.Format("{0} 数量：{1}", item.Key.TrimEnd(), item.Value), font, brush, new Point(x, y));
                }
            }
        }
        public void print()
        {
            PrintDialog MyPrintDg = new PrintDialog();
            MyPrintDg.Document = PrintDoc;
            if (MyPrintDg.ShowDialog() == DialogResult.OK)
            {
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
    }
}
