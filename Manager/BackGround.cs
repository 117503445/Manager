﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Xml.Linq;

namespace Manager
{
    public class BackGround : IDisposable
    {
        public BackGround(Window window)
        {

#if !DEBUG
            App.copyer = new UsbCopyer(Setting.UsbBackupPath, false, false);

            App.hook = new KeyboardHook(true);
            App.hook.SetHook();

            App.hotKey = new HotKey(ModifierKeys.Control, Keys.T, window);
            App.hotKey.HotKeyPressed += (hotkey) => { App.copyer.CopyUSB(); };

            ProcessWatcher processWatcher = new ProcessWatcher();
            processWatcher.AppLaunch += (s, e) => { System.IO.File.AppendAllText("KeyLog.txt", $"APPNAME=QQ,TIME={DateTime.Now}\r\n"); };

            LoadDirBinding();
#endif
            //SyncDirBinding binding = new SyncDirBinding("D:/temp/source","D:/temp/dest");
        }
        public void Dispose()
        {
            App.Current.Shutdown();
        }
        private void LoadDirBinding()
        {
            XElement element = XElement.Load("Binds.xml");
            foreach (var item in element.Elements())
            {
                List<string> i = (from x in item.Attributes() select x.Value).ToList();
                App.syncDirBindings.Add(new SyncDirBinding(i[0], i[1], i[2]));
            }
        }
    }
}
