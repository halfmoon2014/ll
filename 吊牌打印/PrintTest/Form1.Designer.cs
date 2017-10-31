namespace PrintTest
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnQuery = new System.Windows.Forms.ToolStripButton();
            this.btnOrderInfo = new System.Windows.Forms.ToolStripButton();
            this.BtnPrintLable = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnSet = new System.Windows.Forms.ToolStripButton();
            this.BtnRepair = new System.Windows.Forms.ToolStripButton();
            this.BtnAbout = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtBillSn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxStatus = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuerySubmit = new System.Windows.Forms.Button();
            this.txtdateEnd = new System.Windows.Forms.DateTimePicker();
            this.txtdateStart = new System.Windows.Forms.DateTimePicker();
            this.listViewDetail = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.PanelLoad = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelLoading = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewOrder = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.PanelLoad.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnQuery,
            this.btnOrderInfo,
            this.BtnPrintLable,
            this.toolStripSeparator1,
            this.BtnSet,
            this.BtnRepair,
            this.BtnAbout});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(706, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BtnQuery
            // 
            this.BtnQuery.Image = global::PrintTest.Properties.Resources.ooopic_1457510447;
            this.BtnQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnQuery.Name = "BtnQuery";
            this.BtnQuery.Size = new System.Drawing.Size(52, 22);
            this.BtnQuery.Text = "查询";
            this.BtnQuery.Click += new System.EventHandler(this.BtnQuery_Click);
            // 
            // btnOrderInfo
            // 
            this.btnOrderInfo.Image = global::PrintTest.Properties.Resources.ooopic_1457507938;
            this.btnOrderInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOrderInfo.Name = "btnOrderInfo";
            this.btnOrderInfo.Size = new System.Drawing.Size(100, 22);
            this.btnOrderInfo.Text = "打印订单信息";
            this.btnOrderInfo.Click += new System.EventHandler(this.btnOrderInfo_Click);
            // 
            // BtnPrintLable
            // 
            this.BtnPrintLable.Image = global::PrintTest.Properties.Resources.ooopic_1457510415;
            this.BtnPrintLable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnPrintLable.Name = "BtnPrintLable";
            this.BtnPrintLable.Size = new System.Drawing.Size(76, 22);
            this.BtnPrintLable.Text = "打印吊牌";
            this.BtnPrintLable.Click += new System.EventHandler(this.BtnPrintLable_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnSet
            // 
            this.BtnSet.Image = global::PrintTest.Properties.Resources.ooopic_1457507963;
            this.BtnSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSet.Name = "BtnSet";
            this.BtnSet.Size = new System.Drawing.Size(52, 22);
            this.BtnSet.Text = "设置";
            this.BtnSet.Click += new System.EventHandler(this.BtnSet_Click);
            // 
            // BtnRepair
            // 
            this.BtnRepair.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnRepair.Name = "BtnRepair";
            this.BtnRepair.Size = new System.Drawing.Size(36, 22);
            this.BtnRepair.Text = "补打";
            this.BtnRepair.Click += new System.EventHandler(this.BtnRepair_Click);
            // 
            // BtnAbout
            // 
            this.BtnAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAbout.Name = "BtnAbout";
            this.BtnAbout.Size = new System.Drawing.Size(36, 22);
            this.BtnAbout.Text = "关于";
            this.BtnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(211, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(282, 158);
            this.panel1.TabIndex = 6;
            this.panel1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtBillSn);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.checkBoxStatus);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnQuerySubmit);
            this.groupBox1.Controls.Add(this.txtdateEnd);
            this.groupBox1.Controls.Add(this.txtdateStart);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 147);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // TxtBillSn
            // 
            this.TxtBillSn.Location = new System.Drawing.Point(46, 63);
            this.TxtBillSn.Name = "TxtBillSn";
            this.TxtBillSn.Size = new System.Drawing.Size(100, 21);
            this.TxtBillSn.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "单号：";
            // 
            // checkBoxStatus
            // 
            this.checkBoxStatus.AutoSize = true;
            this.checkBoxStatus.Checked = true;
            this.checkBoxStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxStatus.Location = new System.Drawing.Point(8, 90);
            this.checkBoxStatus.Name = "checkBoxStatus";
            this.checkBoxStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBoxStatus.Size = new System.Drawing.Size(84, 16);
            this.checkBoxStatus.TabIndex = 4;
            this.checkBoxStatus.Text = "订单已签收";
            this.checkBoxStatus.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "至";
            // 
            // btnQuerySubmit
            // 
            this.btnQuerySubmit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuerySubmit.Location = new System.Drawing.Point(179, 116);
            this.btnQuerySubmit.Name = "btnQuerySubmit";
            this.btnQuerySubmit.Size = new System.Drawing.Size(71, 25);
            this.btnQuerySubmit.TabIndex = 2;
            this.btnQuerySubmit.Text = "提交";
            this.btnQuerySubmit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuerySubmit.UseVisualStyleBackColor = true;
            this.btnQuerySubmit.Click += new System.EventHandler(this.btnQuerySubmit_Click);
            // 
            // txtdateEnd
            // 
            this.txtdateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtdateEnd.Location = new System.Drawing.Point(140, 33);
            this.txtdateEnd.Name = "txtdateEnd";
            this.txtdateEnd.Size = new System.Drawing.Size(97, 21);
            this.txtdateEnd.TabIndex = 1;
            // 
            // txtdateStart
            // 
            this.txtdateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtdateStart.Location = new System.Drawing.Point(6, 33);
            this.txtdateStart.Name = "txtdateStart";
            this.txtdateStart.Size = new System.Drawing.Size(97, 21);
            this.txtdateStart.TabIndex = 0;
            this.txtdateStart.Value = new System.DateTime(2015, 10, 31, 0, 0, 0, 0);
            // 
            // listViewDetail
            // 
            this.listViewDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewDetail.CheckBoxes = true;
            this.listViewDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.listViewDetail.FullRowSelect = true;
            this.listViewDetail.GridLines = true;
            this.listViewDetail.Location = new System.Drawing.Point(0, 202);
            this.listViewDetail.Name = "listViewDetail";
            this.listViewDetail.Size = new System.Drawing.Size(706, 224);
            this.listViewDetail.TabIndex = 7;
            this.listViewDetail.UseCompatibleStateImageBehavior = false;
            this.listViewDetail.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "货号";
            this.columnHeader6.Width = 85;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "品名";
            this.columnHeader7.Width = 117;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "数量";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader8.Width = 63;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "模板";
            this.columnHeader9.Width = 142;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "交货日期";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 506);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(706, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.toolStripProgressBar1.ToolTipText = "loading";
            this.toolStripProgressBar1.Value = 5;
            this.toolStripProgressBar1.Visible = false;
            // 
            // PanelLoad
            // 
            this.PanelLoad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelLoad.Controls.Add(this.groupBox2);
            this.PanelLoad.Location = new System.Drawing.Point(211, 230);
            this.PanelLoad.Name = "PanelLoad";
            this.PanelLoad.Size = new System.Drawing.Size(278, 76);
            this.PanelLoad.TabIndex = 7;
            this.PanelLoad.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelLoading);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 66);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // labelLoading
            // 
            this.labelLoading.AutoSize = true;
            this.labelLoading.Location = new System.Drawing.Point(44, 21);
            this.labelLoading.Name = "labelLoading";
            this.labelLoading.Size = new System.Drawing.Size(107, 12);
            this.labelLoading.TabIndex = 0;
            this.labelLoading.Text = "数据加载中... ...";
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(0, 432);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(699, 71);
            this.txtLog.TabIndex = 9;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "日期";
            this.columnHeader1.Width = 85;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "单据号";
            this.columnHeader2.Width = 79;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "备注";
            this.columnHeader3.Width = 120;
            // 
            // col5
            // 
            this.col5.Text = "对应材料";
            this.col5.Width = 87;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "厂家签收";
            // 
            // listViewOrder
            // 
            this.listViewOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.col5,
            this.columnHeader5,
            this.columnHeader4});
            this.listViewOrder.FullRowSelect = true;
            this.listViewOrder.Location = new System.Drawing.Point(0, 28);
            this.listViewOrder.Name = "listViewOrder";
            this.listViewOrder.Size = new System.Drawing.Size(706, 174);
            this.listViewOrder.TabIndex = 4;
            this.listViewOrder.UseCompatibleStateImageBehavior = false;
            this.listViewOrder.View = System.Windows.Forms.View.Details;
            this.listViewOrder.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listViewOrder.Click += new System.EventHandler(this.listViewOrder_Click);
            this.listViewOrder.DoubleClick += new System.EventHandler(this.listViewOrder_DoubleClick);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "下单人";
            this.columnHeader4.Width = 73;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 528);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.PanelLoad);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listViewDetail);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.listViewOrder);
            this.Name = "Form1";
            this.Text = "打印";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.PanelLoad.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtnPrintLable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker txtdateEnd;
        private System.Windows.Forms.DateTimePicker txtdateStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQuerySubmit;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripButton BtnQuery;
        private System.Windows.Forms.ToolStripButton btnOrderInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BtnSet;
        private System.Windows.Forms.Panel PanelLoad;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelLoading;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.ListView listViewDetail;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader col5;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ListView listViewOrder;
        private System.Windows.Forms.ToolStripButton BtnRepair;
        private System.Windows.Forms.ToolStripButton BtnAbout;
        private System.Windows.Forms.CheckBox checkBoxStatus;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox TxtBillSn;
        private System.Windows.Forms.Label label2;
    }
}

