using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Manager
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class Application : System.Windows.Application
    {
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            //WdBackGround.copyer.Dispose();      
        }

        public static WdBackGround WdBackGround = new WdBackGround();
    }
}
