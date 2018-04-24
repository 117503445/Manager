using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Manager_Server_Admin.Server_Message;
namespace Manager_Server_Admin
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

        private void BtnPushUTask_Click(object sender, RoutedEventArgs e)
        {
            MessageSvcClient client = new MessageSvcClient();
            client.PushUTask(new UTask { Id = client.GetTimeStamp(), Sender = "admin", Receiver = "test", IsHandled = false, MethodName = "CallCMD",MethodParameters = new string[]{ @"ping 192.168.2.233" } });

        }

        private async void BtnDebug_Click(object sender, RoutedEventArgs e)
        {
            string s = await MethodCollection.CallCMD("ping 192.168.2.233");
            Console.WriteLine(s);
        }
        static class MethodCollection
        {
            public static string GetClientMethod()
            {
                Type type = typeof(MethodCollection);
                var m = type.GetMethods();
                string s = "";
                foreach (var item in m)
                {
                    s += item.Name + ";";
                }
                return s;
            }
            public static async Task<string> CallCMD(string s)
            {
                string output = "";
                await Task.Run(() =>
                {
                    System.Diagnostics.Process p = new System.Diagnostics.Process();
                    p.StartInfo.FileName = "cmd.exe";
                    p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
                    p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
                    p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
                    p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
                    p.StartInfo.CreateNoWindow = true;//不显示程序窗口
                    p.Start();//启动程序
                              //向cmd窗口发送输入信息
                    p.StandardInput.WriteLine(s + "&exit");
                    p.StandardInput.AutoFlush = true;
                    //获取cmd窗口的输出信息
                    output = p.StandardOutput.ReadToEnd();
                    p.WaitForExit();//等待程序执行完退出进程
                    p.Close();

                });
                return output;
            }
        }
    }
}
