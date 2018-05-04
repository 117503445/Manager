using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using User.SoftWare;
using User.Windows;

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
        public static BackGround backGround;
        private static WdMain wdMain;

        public static WdMain WdMain
        {
            get => wdMain; set
            {
                if (wdMain != null)
                {
                    throw new Exception("已经赋值了");
                }
                wdMain = value;
            }
        }

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

        protected override void OnStartup(StartupEventArgs e)
        {
            // Get Reference to the current Process
            Process thisProc = Process.GetCurrentProcess();
            // Check how many total processes have the same name as the current one
            if (Process.GetProcessesByName(thisProc.ProcessName).Length > 1)
            {
                // If ther is more than one, than it is already running.
                MessageBox.Show("Application is already running :(");
                Current.Shutdown();
                return;
            }
            base.OnStartup(e);
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Current.DispatcherUnhandledException += App_OnDispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }
        /// <summary>
        /// UI线程抛出全局异常事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            try
            {
                ULogger.WriteException(e.Exception);
#if !DEBUG
                e.Handled = true;
#endif
            }
            catch (Exception)
            {
                ULogger.WriteInfo("Error", "不可恢复的UI异常");
            }
            WdMain.NumExpection += 1;
        }

        /// <summary>
        /// 非UI线程抛出全局异常事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                if (e.ExceptionObject is Exception exception)
                {
                    ULogger.WriteException(exception);
                }
            }
            catch (Exception)
            {
                ULogger.WriteInfo("Error", "不可恢复的非UI异常");
            }
        }

    }
}
