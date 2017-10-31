namespace eSignage
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.panelbody = new System.Windows.Forms.FlowLayoutPanel();
            this.TimerShow = new System.Windows.Forms.Timer(this.components);
            this.labelShowTimer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panelbody
            // 
            this.panelbody.BackColor = System.Drawing.Color.Transparent;
            this.panelbody.Location = new System.Drawing.Point(1, 232);
            this.panelbody.Name = "panelbody";
            this.panelbody.Size = new System.Drawing.Size(1901, 797);
            this.panelbody.TabIndex = 0;
            // 
            // TimerShow
            // 
            this.TimerShow.Enabled = true;
            this.TimerShow.Tick += new System.EventHandler(this.TimerShow_Tick);
            // 
            // labelShowTimer
            // 
            this.labelShowTimer.AutoSize = true;
            this.labelShowTimer.BackColor = System.Drawing.Color.Transparent;
            this.labelShowTimer.Font = new System.Drawing.Font("微软雅黑 Light", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelShowTimer.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelShowTimer.Location = new System.Drawing.Point(1475, 35);
            this.labelShowTimer.Name = "labelShowTimer";
            this.labelShowTimer.Size = new System.Drawing.Size(384, 52);
            this.labelShowTimer.TabIndex = 1;
            this.labelShowTimer.Text = "2017-05-02 13:40:00";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = global::eSignage.Properties.Resources.bg1;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.labelShowTimer);
            this.Controls.Add(this.panelbody);
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.Text = "电子看板";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panelbody;
        private System.Windows.Forms.Timer TimerShow;
        private System.Windows.Forms.Label labelShowTimer;


    }
}

