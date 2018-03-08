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

namespace Manager
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Application.WdBackGround.Show();
            Visibility = Visibility.Hidden;
            DispatcherTimer tmrWatcher = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1), IsEnabled = true };
            tmrWatcher.Tick += TmrWatcher_Tick;
            App.WdBackGround = new WdBackGround();
        }

        private void TmrWatcher_Tick(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string pathShow = path + "/show";
            string pathStop = path + "/stop";
            if (File.Exists(pathShow))
            {
                Visibility = Visibility.Visible;
            }
            else
            {
                Visibility = Visibility.Hidden;
            }
            if (File.Exists(pathStop))
            {
                File.AppendAllText(pathStop, DateTime.Now.ToString());
                App.Current.Shutdown();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //
        }
    }
}
