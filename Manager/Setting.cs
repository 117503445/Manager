using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.SoftWare;

namespace Manager
{
    public static class Setting
    {
        public static USettings uSettings = new USettings(AppDomain.CurrentDomain.BaseDirectory, "Settings");
        private static USettingsProperty<bool> WdBackgroundVisibilityProperty = uSettings.Register("WdBackgroundVisibility", false);
        public static bool WdBackgroundVisibility { get => WdBackgroundVisibilityProperty.Value; set => WdBackgroundVisibilityProperty.Value = value; }

        private static USettingsProperty<bool> WdMainVisibilityProperty = uSettings.Register("WdMainVisibility", false);
        public static bool WdMainVisibility { get => WdMainVisibilityProperty.Value; set => WdMainVisibilityProperty.Value = value; }

        private static USettingsProperty<string> UsbBackupPathProperty = uSettings.Register("UsbBackupPath",@"D:/temp/");
        public static string UsbBackupPath { get => UsbBackupPathProperty.Value; set => UsbBackupPathProperty.Value = value; }
    }
}
