using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FastMain
{
    public partial class Detail : Form
    {
        public Detail()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.V)
            {                
                try
                {
                    IDataObject iData = Clipboard.GetDataObject();
                    if (iData.GetDataPresent(DataFormats.Text))
                    {
                        //MessageBox.Show((string)iData.GetData(DataFormats.Text));  
                     //   details.Text = (string)iData.GetData(DataFormats.UnicodeText);
                    }else if (iData.GetDataPresent(typeof(Bitmap)))
                    {
                        //Image photo = (Image)iData.GetData(typeof(Bitmap));
                        //Panel imgPanel = new Panel();
                        //pictureBox1.Image = photo;                        
                    }
                    else
                    {
                        MessageBox.Show("目前剪贴板中数据不可转换为文本", "错误");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            
        }
    }
}
