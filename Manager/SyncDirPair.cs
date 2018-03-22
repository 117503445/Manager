using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Manager
{
    public class SyncDirPair:INotifyPropertyChanged
    {
        string sourceDir;
        string destDir;
        string backupDir;

        public string SourceDir
        {
            get => sourceDir;
            set
            {
                sourceDir = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SourceDir)));

            }
        }

        public string DestDir
        {
            get => destDir; set
            {
                destDir = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DestDir)));
            }
        }
        public string BackupDir
        {
            get => backupDir; set
            {
                backupDir = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BackupDir)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
