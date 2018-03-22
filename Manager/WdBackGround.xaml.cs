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
using System.Xml.Linq;
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

#if !DEBUG
            App.copyer = new UsbCopyer(Setting.UsbBackupPath, false, false);

            App.hook = new KeyboardHook(true);
            App.hook.SetHook();

            App.hotKey = new HotKey(ModifierKeys.Control, Keys.T, this);
            App.hotKey.HotKeyPressed += HotKey_HotKeyPressed;

            ProcessWatcher processWatcher = new ProcessWatcher();
            processWatcher.AppLaunch += (s, e) => { System.IO.File.AppendAllText("KeyLog.txt", $"APPNAME=QQ,TIME={DateTime.Now}\r\n"); };

            LoadDirBinding();
#endif
            //SyncDirBinding binding = new SyncDirBinding("D:/temp/source","D:/temp/dest");

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

        private void LoadDirBinding()
        {
            XElement element = XElement.Load("Binds.xml");
            foreach (var item in element.Elements())
            {
                List<string> i = new List<string>();
                foreach (var w in item.Attributes())
                {
                    i.Add(w.Value);
                }
                App.syncDirBindings.Add(new SyncDirBinding(i[0], i[1], i[2]));
            }
        }
        private void SaveDirBindings()
        {
            var i = from x in App.syncDirBindings
                    select
new XElement("Bind",
new XAttribute("SourceStr", x.SourceStr),
new XAttribute("DestStr", x.DestStr),
new XAttribute("BackupStr", x.BackupStr));
            XElement root = new XElement("Binds", i);

            root.Save("Binds.xml");
        }
    }
}
