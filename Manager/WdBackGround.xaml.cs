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
using System.Windows.Shapes;

namespace Manager
{
    /// <summary>
    /// WdBackGround.xaml 的交互逻辑
    /// </summary>
    public partial class WdBackGround : Window
    {
        public UsbCopyer copyer = new UsbCopyer("D:/temp/",true);
        public WdBackGround()
        {
            InitializeComponent();
            //Visibility = Visibility.Hidden;

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
