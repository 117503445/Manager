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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Manager_Server_Admin.Server_Message;
namespace Manager_Server_Admin
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnPushUTask_Click(object sender, RoutedEventArgs e)
        {
            MessageSvcClient client = new MessageSvcClient();
            client.PushUTask(new UTask { Id = client.GetTimeStamp(), Sender = "admin", Receiver = "test" });
        }
    }
}
