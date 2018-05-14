using User.IO;
using System.Collections.ObjectModel;
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
        bool loaded = false;
        public WdSync()
        {
            InitializeComponent();
            CboSyncs.ItemsSource = App.Syncs;
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
            Sync sync = new Sync(TbDirSource.Text, TbDirDest.Text);
            App.Syncs.Add(sync);

            return;
            string path_Dir_Source = TbDirSource.Text;
            string path_Dir_Dest = TbDirDest.Text;
            if (Directory.Exists(path_Dir_Source) && Directory.Exists(path_Dir_Dest))
            {
                SyncDir.Sync(path_Dir_Source, path_Dir_Dest);
                MessageBox.Show("Finish");
            }
            else
            {
                MessageBox.Show("不存在/错误的路径");
            }
        }
        private void TbDrag_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tb = (TextBox)sender;
            if (tb.Text == "源路径" || tb.Text == "目标路径")
            {
                return;
            }
            if (Directory.Exists(tb.Text))
            {
                tb.Background = Brushes.White;
            }
            else
            {
                tb.Background = Brushes.Red;
            }
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loaded = true;
        }

        private void CboSyncs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (loaded)
            {
                var cbo = (ComboBox)e.Source;
                Console.WriteLine(cbo.SelectedIndex);
                var syncs = (ObservableCollection<Sync>)(cbo.ItemsSource);
                foreach (var item in syncs)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
            }

            //TbDirSource = e.Source;
        }
    }
}
