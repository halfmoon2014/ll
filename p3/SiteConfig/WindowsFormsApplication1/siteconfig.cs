using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Text.RegularExpressions;
namespace WindowsFormsApplication1
{
    public partial class mysiteconfig : Form
    {
        public mysiteconfig()
        {
            
            InitializeComponent();
        }
        public bool isExists(string str)
        {
            //字母验证
            return Regex.Matches(str, "[a-zA-Z]").Count > 0;
        }
        public bool IPCheck2(string IP)
        {//IP验证
            string num = "(25[0-5]|2[0-4]//d|[0-1]//d{2}|[1-9]?//d)";
            return Regex.IsMatch(IP, ("^" + num + "//." + num + "//." + num + "//." + num + "$"));
        }
        public static bool IPCheck(string ip)
        {

            if (string.IsNullOrEmpty(ip) || ip.Length < 7 || ip.Length > 15) return false;

            string regformat = @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$";

            Regex regex = new Regex(regformat, RegexOptions.IgnoreCase);

            return regex.IsMatch(ip);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            string siteName = sitename.Text;
            if (siteName.StartsWith("http://", true, null))
            {
                //MessageBox.Show("前缀http://不用输入");
                //return;
                siteName=siteName.Substring(7, siteName.Length - 7);
            }
            string httpTag = "http";//http or https
            if (httpcheck.Checked)
            {
                httpTag = "https";
            }
            
            RegistryKey hkml = Registry.CurrentUser;//读取HKEY_CURRENT_USER            
            if (isExists(siteName))
            {//域名
  
                //if (siteName.StartsWith("www.", true, null))
                //{//分解掉www.
                //    siteName = siteName.Substring(4, siteName.Length - 4);
                //}
                if (siteName.IndexOf(".") == -1)
                {
                    MessageBox.Show("域名输入有误");
                    return;
                }
                string fontTag= siteName.Substring(0, siteName.IndexOf(".") );
                siteName = siteName.Substring(siteName.IndexOf(".") + 1, siteName.Length - (siteName.IndexOf(".") + 1));
                string address = @"SOFTWARE\MICROSOFT\WINDOWS\CURRENTVERSION\INTERNET SETTINGS\ZONEMAP\Domains";
                RegistryKey key1 = hkml.OpenSubKey(address, true);
                RegistryKey newPo = key1.CreateSubKey(siteName);//新建项   
                RegistryKey ww = newPo.CreateSubKey(fontTag);//新建子项   
                ww.SetValue(httpTag, 0x2, RegistryValueKind.DWord);//赋值
            }
            else if (IPCheck(siteName))
            {
                string address = @"SOFTWARE\MICROSOFT\WINDOWS\CURRENTVERSION\INTERNET SETTINGS\ZONEMAP\RANGES";
                RegistryKey key1 = hkml.OpenSubKey(address, true);

                RegistryKey Name1 = key1.CreateSubKey("Range" + (key1.SubKeyCount + 1).ToString());//新建项   
                Name1.SetValue(":Range", siteName, RegistryValueKind.String);//赋值  
                Name1.SetValue(httpTag, 0x2, RegistryValueKind.DWord);//赋值
            }
            else
            {
                MessageBox.Show("无效地址");
            }

        }



    }
}
