using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PrintTest
{
    class LoadFace
    {
        private Panel PanelLoad = new Panel();
        private Label label2;
        public LoadFace(Form frm)
        {           
            PanelLoad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //PanelLoad.Controls.Add(this.groupBox2);
            PanelLoad.Location = new System.Drawing.Point(210, 200);
            PanelLoad.Name = "PanelLoad";
            PanelLoad.Size = new System.Drawing.Size(256, 76);
            //PanelLoad.TabIndex = 100;
            
            //PanelLoad.Visible = false;

            label2 = new Label();
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(44, 21);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(107, 12);
            label2.TabIndex = 0;
            label2.Text = "数据加载中... ...";
            PanelLoad.Controls.Add(label2);

            frm.Controls.Add(PanelLoad);            
        }
        public void show()
        {           
            PanelLoad.Visible = true;
            PanelLoad.BringToFront();
        }
        public void hide()
        {
            PanelLoad.Visible = false;
            
        }
    }
}
