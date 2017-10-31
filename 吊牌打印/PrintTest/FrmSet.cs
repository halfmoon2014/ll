using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PrintTest
{
    public partial class FrmSet : Form
    {
        public FrmSet()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1) 
            {
                Form1.printType = printType.SelectedIndex;
                this.Close();
            }              
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSet_Load(object sender, EventArgs e)
        {
            printType.SelectedIndex = Form1.printType;
        }
    }
}
