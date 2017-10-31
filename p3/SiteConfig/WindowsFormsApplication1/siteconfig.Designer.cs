namespace WindowsFormsApplication1
{
    partial class mysiteconfig
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
            this.button1 = new System.Windows.Forms.Button();
            this.sitename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.httpcheck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(179, 210);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "加入信任站点";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // sitename
            // 
            this.sitename.Location = new System.Drawing.Point(27, 64);
            this.sitename.Multiline = true;
            this.sitename.Name = "sitename";
            this.sitename.Size = new System.Drawing.Size(227, 93);
            this.sitename.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "网站地址,可输入IP地址或域名\r\n如:192.168.1.204\r\n    www.baidu.com";
            // 
            // httpcheck
            // 
            this.httpcheck.AutoSize = true;
            this.httpcheck.Location = new System.Drawing.Point(29, 164);
            this.httpcheck.Name = "httpcheck";
            this.httpcheck.Size = new System.Drawing.Size(78, 16);
            this.httpcheck.TabIndex = 3;
            this.httpcheck.Text = "使用https";
            this.httpcheck.UseVisualStyleBackColor = true;
            // 
            // mysiteconfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.httpcheck);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sitename);
            this.Controls.Add(this.button1);
            this.Name = "mysiteconfig";
            this.Text = "信任站点配置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox sitename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox httpcheck;
    }
}

