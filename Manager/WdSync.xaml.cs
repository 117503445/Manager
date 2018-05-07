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
    /// WdSync.xaml 的交互逻辑
    /// </summary>
    public partial class WdSync : Window
    {
        public WdSync()
        {
            InitializeComponent();
        }

        private void Window_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var msg = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
                Console.WriteLine(msg);
            }
        }

        private void TbDirDest_Drop(object sender, DragEventArgs e)
        {

        }

        private void TbDirSource_Drop(object sender, DragEventArgs e)
        {

        }
    }
}
