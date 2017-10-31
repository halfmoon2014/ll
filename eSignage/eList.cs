using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace eSignage
{
    public partial class eList : UserControl
    {
        /// <summary>
        /// 组名称
        /// </summary>
        public string Group = "";
        /// <summary>
        /// 跟踪单号
        /// </summary>
        public string GoodName = "";
        /// <summary>
        /// 需求数
        /// </summary>
        public string number = "";
        /// <summary>
        /// 实发数
        /// </summary>
        public string number2 = "";
        /// <summary>
        /// 床号
        /// </summary>
        public string CutSn = "";
        /// <summary>
        /// 材料类别
        /// </summary>
        public string CatName = "";
        /// <summary>
        /// 材料代码
        /// </summary>
        public string MaterialCode = "";
        /// <summary>
        /// 材料名称
        /// </summary>
        public string MaterialName = "";
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit = "";
        /// <summary>
        /// 
        /// </summary>
        public int status = 0;

        /// <summary>
        /// 仓储备料人
        /// </summary>
        public string ccblr = "";

        /// <summary>
        /// 裁剪领料人
        /// </summary>
        public string cjllr = "";

        public float ScreenWith = 1920f;
        public DateTime RequestTime = DateTime.Now;
        public string stocker = "";
        public eList()
        {
            InitializeComponent();
        }

        private void eList_Load(object sender, EventArgs e)
        
        {
            double scale = 1920f / ScreenWith;
            this.Height = (Int32)(this.Height / scale);
            groupBox1.Top = (Int32)(groupBox1.Top / scale);
            foreach (Control control in this.Controls)
            {
                if(control.GetType() == typeof(Label))
                {
                    control.Left = (Int32)(control.Left / scale);
                    control.Top = (Int32)(control.Top / scale);
                    control.Height = (Int32)(control.Height / scale);
                    control.Width = (Int32)(control.Width / scale);
                    float size = (float)(control.Font.Size / scale);
                    Font newfont = new System.Drawing.Font("微软雅黑", size, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    control.Font = newfont;
                }
            }
  
        }
        public void load_data()
        {
            ItemGood.Text = GoodName;
            ItemNumber.Text = number;
            ItemNumber2.Text = number2;
            ItemCutSn.Text = GoodName+"_"+ CutSn;
            ItemMaterial.Text = MaterialCode;
            ItemMaterialName.Text = CatName;
            itemUnit.Text = Unit;
            ItemGroup.Text = Group;
            /*switch(Group)
            {
                case "剪裁A组":
                    labelstock.Text = "001";
                    break;
                case "剪裁B组":
                    labelstock.Text = "002";
                    break;
                default:
                    labelstock.Text = "";
                    break;
            }*/
            labelstock.Text = ccblr;
            label2.Text = cjllr;
            DateTime now = DateTime.Now;
            TimeSpan ts = DateTime.Now - RequestTime;
            LabelTimer.Text = String.Format("{0:00}:{1:00}",ts.Hours, ts.Minutes);
            foreach (Control control in this.Controls)
            {
                if (control.GetType() == typeof(Label))
                {
                    if (status == 1)
                        control.ForeColor = Color.Red;//字体颜色
                }
            }
        }
    }
}
