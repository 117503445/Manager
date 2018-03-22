using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TLib;

namespace Manager
{
    public class SyncDirBinding
    {
        private string sourceStr;
        private string destStr;
        private string backupStr;

        private bool isWatching;

        public string SourceStr { get => sourceStr; set => sourceStr = value; }
        public string DestStr { get => destStr; set => destStr = value; }
        public string BackupStr { get => backupStr; set => backupStr = value; }
        /// <summary>
        /// 是否监视源文件夹
        /// </summary>
        public bool IsWatching
        {
            get => isWatching; set
            {
                isWatching = value;
                sourceDirWatcher.EnableRaisingEvents = value;
                destDirWatcher.EnableRaisingEvents = value;
            }
        }

        private FileSystemWatcher sourceDirWatcher;
        private FileSystemWatcher destDirWatcher;
        public SyncDirBinding(string sourceStr, string destStr, string backupStr = "")
        {
            if (!Directory.Exists(sourceStr))
            {
                throw new ArgumentException("原路径不存在");
            }
            if (!Directory.Exists(destStr))
            {
                throw new ArgumentException("目标路径不存在");
            }
            if (backupStr != "" && !Directory.Exists(backupStr))
            {
                throw new ArgumentException("备份路径不存在");
            }
            this.sourceStr = sourceStr;
            this.destStr = destStr;
            this.backupStr = backupStr;
            sourceDirWatcher = new FileSystemWatcher()
            {
                Path = sourceStr,
                IncludeSubdirectories = true,
                EnableRaisingEvents = true,
            };
            destDirWatcher = new FileSystemWatcher()
            {
                Path = destStr,
                IncludeSubdirectories = true,
                EnableRaisingEvents = true,
            };
            WatcherBindingMethod(sourceDirWatcher, DestDirWatcher_Changed, DestDirWatcher_Changed);
            WatcherBindingMethod(destDirWatcher, DestDirWatcher_Changed, DestDirWatcher_Changed);
            DestDirWatcher_Changed(this, null);
        }

        private void DestDirWatcher_Changed(object sender, EventArgs e)
        {

            WatcherUnBindingMethod(sourceDirWatcher, DestDirWatcher_Changed, DestDirWatcher_Changed);
            WatcherUnBindingMethod(destDirWatcher, DestDirWatcher_Changed, DestDirWatcher_Changed);
            SyncDir.Sync(sourceStr, destStr, backupStr);
            WatcherBindingMethod(sourceDirWatcher, DestDirWatcher_Changed, DestDirWatcher_Changed);
            WatcherBindingMethod(destDirWatcher, DestDirWatcher_Changed, DestDirWatcher_Changed);
        }

        private static void WatcherBindingMethod(FileSystemWatcher watcher, FileSystemEventHandler fileSystemEventHandler, RenamedEventHandler renamedEventHandler)
        {
            watcher.Changed += fileSystemEventHandler;
            watcher.Created += fileSystemEventHandler;
            watcher.Deleted += fileSystemEventHandler;
            watcher.Renamed += renamedEventHandler;
        }
        private static void WatcherUnBindingMethod(FileSystemWatcher watcher, FileSystemEventHandler fileSystemEventHandler, RenamedEventHandler renamedEventHandler)
        {
            watcher.Changed -= fileSystemEventHandler;
            watcher.Created -= fileSystemEventHandler;
            watcher.Deleted -= fileSystemEventHandler;
            watcher.Renamed -= renamedEventHandler;
        }
    }

}
