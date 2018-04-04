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
            //Application.WdBackGround.Show();
            //Visibility = Visibility.Hidden;

            //tmrWatcher = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1), IsEnabled = true };
            //tmrWatcher.Tick += TmrWatcher_Tick;



            HotKey hotKey_Window = new HotKey(ModifierKeys.Control, Keys.Y, this);
            hotKey_Window.HotKeyPressed += HotKey_Window_HotKeyPressed;
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
    }
}
