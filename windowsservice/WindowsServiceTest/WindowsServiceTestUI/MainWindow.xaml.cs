using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ServiceProcess;
using System.Diagnostics;
namespace WindowsServiceTestUI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string CurrentDirectory = System.Environment.CurrentDirectory;
                System.Environment.CurrentDirectory = CurrentDirectory + "\\Service";
                Process process = new Process();
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.FileName = "Install.bat";
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                System.Environment.CurrentDirectory = CurrentDirectory;
                MessageBox.Show("安装成功");
            }
            catch (System.Exception me)
            {
                MessageBox.Show("安装失败," + me.Message.ToString());
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string CurrentDirectory = System.Environment.CurrentDirectory;
                System.Environment.CurrentDirectory = CurrentDirectory + "\\Service";
                Process process = new Process();
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.FileName = "Uninstall.bat";
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                System.Environment.CurrentDirectory = CurrentDirectory;
                MessageBox.Show("卸载成功");
            }
            catch (System.Exception me)
            {
                MessageBox.Show("卸载失败," + me.Message.ToString());
            }
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ServiceController serviceController = new ServiceController("ServiceTest");
                string Status = serviceController.Status.ToString();
                MessageBox.Show("检查状态成功," + Status);
            }
            catch (System.Exception me)
            {
                MessageBox.Show("检查状态," + me.Message.ToString());
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ServiceController serviceController = new ServiceController("ServiceTest");
                if (serviceController.CanPauseAndContinue)
                {
                    if (serviceController.Status == ServiceControllerStatus.Running)
                        serviceController.Pause();
                    else if (serviceController.Status == ServiceControllerStatus.Paused)
                        serviceController.Continue();
                }
                MessageBox.Show("暂停/继续成功");
            }
            catch (System.Exception me)
            {
                MessageBox.Show("暂停/继续," + me.Message.ToString());
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ServiceController serviceController = new ServiceController("ServiceTest");
                if (serviceController.CanStop)
                    serviceController.Stop();

                MessageBox.Show("停止成功");
            }
            catch (System.Exception me)
            {
                MessageBox.Show("停止," + me.Message.ToString());
            }
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ServiceController serviceController = new ServiceController("ServiceTest");
                serviceController.Start();
                MessageBox.Show("启动成功");
            }
            catch (System.Exception me)
            {
                MessageBox.Show("启动," + me.Message.ToString());
            }
        }
    }
}
