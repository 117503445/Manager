using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Manager
{
    public class ProcessWatcher
    {
        public event EventHandler AppLaunch;
        private bool isEnabled;
        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                isEnabled = value;
                timer.IsEnabled = value;
            }
        }
        private string strWatch;
        private List<string> lastList;

        private DispatcherTimer timer;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strWatch">被监控的字符串</param>
        public ProcessWatcher(string strWatch = "QQ")
        {
            this.strWatch = strWatch;
            timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1), IsEnabled = true };
            timer.Tick += Timer_Tick;
            //lastList = Process.GetProcesses().ToList();
            lastList = (from x in Process.GetProcesses() select x.ProcessName).ToList();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //foreach (var item in lastList)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("***!!!!***");
            List<string> newList = (from x in Process.GetProcesses() select x.ProcessName).ToList();
            if (newList.Except(lastList).Contains(strWatch))
            {
                AppLaunch(this, e);
            }
            //foreach (var item in i)
            //{
            //    Console.WriteLine(item);
            //}
            lastList = newList;
        }
    }
}
