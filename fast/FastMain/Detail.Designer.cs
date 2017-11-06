namespace FastMain
{
    partial class Detail
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.details = new System.Windows.Forms.RichTextBox();
            this.starttime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.creator = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.handler = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(821, 12);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 0;
            this.save.Text = "保存";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "任务名称";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(93, 48);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(259, 21);
            this.name.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "任务详情";
            // 
            // details
            // 
            this.details.Location = new System.Drawing.Point(93, 189);
            this.details.Name = "details";
            this.details.Size = new System.Drawing.Size(784, 382);
            this.details.TabIndex = 4;
            this.details.Text = "";
            // 
            // starttime
            // 
            this.starttime.Location = new System.Drawing.Point(93, 79);
            this.starttime.Name = "starttime";
            this.starttime.Size = new System.Drawing.Size(117, 21);
            this.starttime.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "开始时间";
            // 
            // creator
            // 
            this.creator.Location = new System.Drawing.Point(93, 113);
            this.creator.Name = "creator";
            this.creator.Size = new System.Drawing.Size(117, 21);
            this.creator.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "相关业务人员";
            // 
            // handler
            // 
            this.handler.Location = new System.Drawing.Point(93, 144);
            this.handler.Name = "handler";
            this.handler.Size = new System.Drawing.Size(117, 21);
            this.handler.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "对接人";
            // 
            // Detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 605);
            this.Controls.Add(this.handler);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.creator);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.starttime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.details);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.save);
            this.Name = "Detail";
            this.Text = "Add";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox details;
        private System.Windows.Forms.TextBox starttime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox creator;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox handler;
        private System.Windows.Forms.Label label5;
    }
}

