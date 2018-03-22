﻿using System;
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
        public static List<SyncDirBinding> syncDirBindings=new List<SyncDirBinding>();
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
        //public static WdBackGround WdBackGround;


    }
}
