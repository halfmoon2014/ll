using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
namespace WindowsServiceTest
{
    public partial class ServiceTest : ServiceBase
    {
        public ServiceTest()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("C:\\log.txt", true))
            {
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "Start.");
            }
            StartDoSomething();
        }

        protected override void OnStop()
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("C:\\log.txt", true))
            {
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "Stop.");
            }
        }
        private void StartDoSomething()
        {
            System.Timers.Timer timer = new System.Timers.Timer(2000); //间隔10秒
            timer.AutoReset = true;
            timer.Enabled = false;  //执行一次
            timer.Elapsed += new ElapsedEventHandler(ExecutionCode);
            timer.Start();
        }

        private void ExecutionCode(object source, System.Timers.ElapsedEventArgs e)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("C:\\log.txt", true))
            {
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "服务执行了一次任务t.");
            }

        }
    }
}
