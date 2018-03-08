using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TLib;
namespace Manager
{
    /// <summary>
    /// WdBackGround.xaml 的交互逻辑
    /// </summary>
    public partial class WdBackGround : Window
    {


        public WdBackGround()
        {
            InitializeComponent();

            App.copyer = new UsbCopyer("D:/temp/", false);
            App.hook = new KeyboardHook(true);
            App.hook.SetHook();

            Visibility = Visibility.Hidden;

            App.hotKey = new HotKey(ModifierKeys.Control, Keys.T, this);
            App.hotKey.HotKeyPressed += HotKey_HotKeyPressed;
            //ProcessWatcher processWatcher = new ProcessWatcher();
            //processWatcher.AppLaunch += ProcessWatcher_AppLaunch;
        }

        private void ProcessWatcher_AppLaunch(object sender, EventArgs e)
        {
            Logger.Write(DateTime.Now.ToString());
        }

        private void HotKey_HotKeyPressed(HotKey obj)
        {
            App.copyer.CopyUSB();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            App.Current.Shutdown();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
