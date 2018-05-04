using System;
namespace Manager.Properties
{

    internal sealed partial class Settings
    {
        public Settings()
        {
            PropertyChanged += Settings_PropertyChanged;
        }

        private void Settings_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Save();
            switch (e.PropertyName)
            {
                case "IsDirBinding":
                    foreach (var item in App.syncDirBindings)
                    {
                        item.IsWatching = IsDirBinding;
                    }
                    break;
                case "IsUSBCopyer":
                    App.copyer.IsEnabled = IsUSBCopyer;
                    break;
                case "IsHookKeyBoard":
                    if (IsHookKeyBoard)
                    {
                        App.hook.SetHook();
                    }
                    else
                    {
                        App.hook.UnHook();
                    }
                    break;
                case "IsWatchingQQ":
                    App.processWatcher.IsEnabled = IsWatchingQQ;
                    break;
                default:
                    break;
            }
        }
    }
}
