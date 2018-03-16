using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using User.SoftWare;
namespace Manager
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public static UsbCopyer copyer;
        public static KeyboardHook hook;
        public static HotKey hotKey;
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            copyer.Dispose();
            hook.UnHook();
            hotKey.UnregisterHotKey();
            hotKey.Dispose();
        }
        public static WdBackGround WdBackGround;

       
    }
}
