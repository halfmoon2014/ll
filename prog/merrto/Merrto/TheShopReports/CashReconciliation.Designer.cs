﻿namespace Merrto.TheShopReports
{
    partial class CashReconciliation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WPHbROWDGV = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DTStop = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.RBALLcADE = new System.Windows.Forms.RadioButton();
            this.RBzfb = new System.Windows.Forms.RadioButton();
            this.RBerp = new System.Windows.Forms.RadioButton();
            this.RBall = new System.Windows.Forms.RadioButton();
            this.DTPOrderDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtCade = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnupEXcel = new System.Windows.Forms.Button();
            this.CmdShop = new System.Windows.Forms.ComboBox();
            this.BTNbROW = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.WPHbROWDGV)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // WPHbROWDGV
            // 
            this.WPHbROWDGV.AllowUserToAddRows = false;
            this.WPHbROWDGV.AllowUserToDeleteRows = false;
            this.WPHbROWDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WPHbROWDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WPHbROWDGV.Location = new System.Drawing.Point(0, 126);
            this.WPHbROWDGV.Name = "WPHbROWDGV";
            this.WPHbROWDGV.RowTemplate.Height = 23;
            this.WPHbROWDGV.Size = new System.Drawing.Size(989, 304);
            this.WPHbROWDGV.TabIndex = 14;
            this.WPHbROWDGV.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.WPHbROWDGV_CellToolTipTextNeeded);
            this.WPHbROWDGV.SelectionChanged += new System.EventHandler(this.WPHbROWDGV_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DTStop);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.RBALLcADE);
            this.groupBox1.Controls.Add(this.RBzfb);
            this.groupBox1.Controls.Add(this.RBerp);
            this.groupBox1.Controls.Add(this.RBall);
            this.groupBox1.Controls.Add(this.DTPOrderDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TxtCade);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnupEXcel);
            this.groupBox1.Controls.Add(this.CmdShop);
            this.groupBox1.Controls.Add(this.BTNbROW);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(989, 73);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // DTStop
            // 
            this.DTStop.Location = new System.Drawing.Point(275, 44);
            this.DTStop.Name = "DTStop";
            this.DTStop.Size = new System.Drawing.Size(134, 21);
            this.DTStop.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 26;
            this.label2.Text = "终止时间：";
            // 
            // RBALLcADE
            // 
            this.RBALLcADE.AutoSize = true;
            this.RBALLcADE.Location = new System.Drawing.Point(439, 45);
            this.RBALLcADE.Name = "RBALLcADE";
            this.RBALLcADE.Size = new System.Drawing.Size(71, 16);
            this.RBALLcADE.TabIndex = 25;
            this.RBALLcADE.Text = "所有单据";
            this.RBALLcADE.UseVisualStyleBackColor = true;
            // 
            // RBzfb
            // 
            this.RBzfb.AutoSize = true;
            this.RBzfb.Location = new System.Drawing.Point(512, 18);
            this.RBzfb.Name = "RBzfb";
            this.RBzfb.Size = new System.Drawing.Size(77, 16);
            this.RBzfb.TabIndex = 24;
            this.RBzfb.Text = "无ERP单据";
            this.RBzfb.UseVisualStyleBackColor = true;
            // 
            // RBerp
            // 
            this.RBerp.AutoSize = true;
            this.RBerp.Location = new System.Drawing.Point(512, 45);
            this.RBerp.Name = "RBerp";
            this.RBerp.Size = new System.Drawing.Size(95, 16);
            this.RBerp.TabIndex = 23;
            this.RBerp.Text = "无支付单单据";
            this.RBerp.UseVisualStyleBackColor = true;
            // 
            // RBall
            // 
            this.RBall.AutoSize = true;
            this.RBall.Checked = true;
            this.RBall.Location = new System.Drawing.Point(439, 18);
            this.RBall.Name = "RBall";
            this.RBall.Size = new System.Drawing.Size(47, 16);
            this.RBall.TabIndex = 22;
            this.RBall.TabStop = true;
            this.RBall.Text = "全部";
            this.RBall.UseVisualStyleBackColor = true;
            // 
            // DTPOrderDate
            // 
            this.DTPOrderDate.Location = new System.Drawing.Point(73, 44);
            this.DTPOrderDate.Name = "DTPOrderDate";
            this.DTPOrderDate.Size = new System.Drawing.Size(134, 21);
            this.DTPOrderDate.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "起始时间：";
            // 
            // TxtCade
            // 
            this.TxtCade.Location = new System.Drawing.Point(61, 14);
            this.TxtCade.Name = "TxtCade";
            this.TxtCade.Size = new System.Drawing.Size(146, 21);
            this.TxtCade.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "单据号：";
            // 
            // btnupEXcel
            // 
            this.btnupEXcel.Location = new System.Drawing.Point(696, 14);
            this.btnupEXcel.Name = "btnupEXcel";
            this.btnupEXcel.Size = new System.Drawing.Size(88, 51);
            this.btnupEXcel.TabIndex = 16;
            this.btnupEXcel.Text = "导出EXCEL";
            this.btnupEXcel.UseVisualStyleBackColor = true;
            this.btnupEXcel.Click += new System.EventHandler(this.btnupEXcel_Click);
            // 
            // CmdShop
            // 
            this.CmdShop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmdShop.FormattingEnabled = true;
            this.CmdShop.Location = new System.Drawing.Point(275, 14);
            this.CmdShop.Name = "CmdShop";
            this.CmdShop.Size = new System.Drawing.Size(134, 20);
            this.CmdShop.TabIndex = 8;
            // 
            // BTNbROW
            // 
            this.BTNbROW.Location = new System.Drawing.Point(619, 14);
            this.BTNbROW.Name = "BTNbROW";
            this.BTNbROW.Size = new System.Drawing.Size(75, 51);
            this.BTNbROW.TabIndex = 12;
            this.BTNbROW.Text = "查询";
            this.BTNbROW.UseVisualStyleBackColor = true;
            this.BTNbROW.Click += new System.EventHandler(this.BTNbROW_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(238, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "店铺：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnSave);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(989, 53);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(10, 14);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(113, 32);
            this.BtnSave.TabIndex = 12;
            this.BtnSave.Text = "保存";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // CashReconciliation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 430);
            this.Controls.Add(this.WPHbROWDGV);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CashReconciliation";
            this.Text = "CashReconciliation";
            this.Load += new System.EventHandler(this.CashReconciliation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WPHbROWDGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView WPHbROWDGV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker DTStop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton RBALLcADE;
        private System.Windows.Forms.RadioButton RBzfb;
        private System.Windows.Forms.RadioButton RBerp;
        private System.Windows.Forms.RadioButton RBall;
        private System.Windows.Forms.DateTimePicker DTPOrderDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtCade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnupEXcel;
        private System.Windows.Forms.ComboBox CmdShop;
        private System.Windows.Forms.Button BTNbROW;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnSave;
    }
}