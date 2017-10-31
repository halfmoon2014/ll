using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace UILogin
{
    public partial class Login : Form
    {
        private TextBox textBox2;
        private GroupBox groupBox1;
        private TextBox textBox1;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox1;
        private Button BtnLogin;
        private Button BtnClose;
        private Label msg;
        static public String UserName = "";

        public Login()
        {     
            InitializeComponent();      
        }

        private void InitializeComponent()
        {
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnClose = new System.Windows.Forms.Button();
            this.msg = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(72, 67);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(170, 21);
            this.textBox2.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(114, 148);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 111);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户信息";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(72, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(170, 21);
            this.textBox1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "密    码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用 户 名：";
            // 
            // BtnLogin
            // 
            this.BtnLogin.Location = new System.Drawing.Point(287, 276);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(69, 30);
            this.BtnLogin.TabIndex = 5;
            this.BtnLogin.Text = "登录";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Location = new System.Drawing.Point(-3, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(592, 135);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(208, 276);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(73, 30);
            this.BtnClose.TabIndex = 7;
            this.BtnClose.Text = "退出";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // msg
            // 
            this.msg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.msg.Location = new System.Drawing.Point(114, 323);
            this.msg.Name = "msg";
            this.msg.Padding = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.msg.Size = new System.Drawing.Size(287, 23);
            this.msg.TabIndex = 8;
            // 
            // Login
            // 
            this.ClientSize = new System.Drawing.Size(537, 364);
            this.ControlBox = false;
            this.Controls.Add(this.msg);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnLogin);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Login_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private void Login_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;

            this.FormBorderStyle = FormBorderStyle.None;
            pictureBox1.ImageLocation = "";
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            BtnLogin.Text = "登录中...";
            BtnLogin.Enabled = false;

            Thread login = new Thread(logining);
            login.IsBackground = true;
            login.Start();
        }

        private void logining() 
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SrvSysBace.Service1 BaseSvr = new SrvSysBace.Service1();
                string username = BaseSvr.LoginIn(textBox1.Text, textBox2.Text);

                if (username != "")
                {
                    UserName = username;
                    this.Close();
                }
                else
                {
                    msg.Text = "用户名或密码有误";
                    BtnLogin.Text = "登录";
                    BtnLogin.Enabled = true;
                }
            }
            else
            {
                BtnLogin.Text = "登录";
                BtnLogin.Enabled = true;
            }
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
