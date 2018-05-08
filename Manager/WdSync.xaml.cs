using System;
using System.IO;
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
        #region TbDrag的拖放事件
        private void TbDrag_PreviewDragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Copy;
            e.Handled = true;
        }
        private void TbDrag_PreviewDrop(object sender, DragEventArgs e)
        {
            var s = GetMsg(e);
            if (Directory.Exists(s))
            {
                ((TextBox)sender).Text = s;
            }
        }
        #endregion
        private void BtnRunSync_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
        /// <summary>
        /// 获取字符串,出现问题时返回string.Empty
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private static string GetMsg(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var msg = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
                return msg;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
