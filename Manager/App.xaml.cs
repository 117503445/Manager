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
        public static List<SyncDirBinding> syncDirBindings = new List<SyncDirBinding>();
        public static WdMain wdMain;
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            try
            {
                copyer.Dispose();
                hook.UnHook();
                hotKey.UnregisterHotKey();
                hotKey.Dispose();
            }
            catch (Exception)
            {

            }

        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            ULogger.WriteException(e.Exception);
#if !DEBUG
            e.Handled = true;
#endif
            wdMain.NumExpection += 1;
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //Application myAp = new Application();
            //myAp.Run(wdMain);
            //new Application().Run(wdMain);
            //wdMain.Show();
            // App.Current.Run(wdMain);
        }
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            wdMain = new WdMain();
            //Console.WriteLine("OnStart");
        }
        //public static WdBackGround WdBackGround;


    }
}
