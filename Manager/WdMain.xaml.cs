using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using User.Windows;
using st = Manager.Properties.Settings;
using User.SoftWare;

namespace Manager
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class WdMain : Window
    {
        private int numExpection = 0;
        public int NumExpection
        {
            get => numExpection; set
            {
                numExpection = value;
                TxtNumExpection.Text = "当前异常数:" + NumExpection.ToString();
            }
        }

        public WdMain()
        {
            App.WdMain = this;
            InitializeComponent();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var i = System.Windows.MessageBox.Show("Close?", ":<", MessageBoxButton.OKCancel);
            if (i == MessageBoxResult.OK)
            {
                App.Current.Shutdown();
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                HotKey hotKey_Window = new HotKey(ModifierKeys.Control, Keys.Y, this);
                hotKey_Window.HotKeyPressed += HotKey_Window_HotKeyPressed;
            }
            catch (Exception ex)
            {
#if DEBUG
                System.Windows.MessageBox.Show("绑定唤醒热键失败,程序将退出:<");
#endif
                ULogger.WriteException(ex);
                App.Current.Shutdown();
            }

            App.backGround = new BackGround(this);
            TbUsbBackupPath.Text = st.Default.UsbBackupPath;
        }
        private void HotKey_Window_HotKeyPressed(HotKey obj)
        {
            Visibility = (Visibility == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
            Topmost = true;
            Topmost = false;
        }
        private void TbUsbBackupPath_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsLoaded)
            {
                if (Directory.Exists(TbUsbBackupPath.Text))
                {
                    TbUsbBackupPath.Background = Brushes.White;
                    st.Default.UsbBackupPath = TbUsbBackupPath.Text;
                }
                else
                {
                    TbUsbBackupPath.Background = Brushes.Red;
                }
            }
        }


    }
}
