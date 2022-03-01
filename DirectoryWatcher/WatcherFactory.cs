using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryWatcher
{
    public static class WatcherFactory
    {
        internal static List<FileSystemWatcher> CreateWatchers(List<Folder> folders)
        {
            List<FileSystemWatcher> watchers = new List<FileSystemWatcher>();
            foreach (var folder in folders)
            {
                FileSystemWatcher watcher = new FileSystemWatcher(folder.Path);
                watcher.EnableRaisingEvents = true;
                watcher.IncludeSubdirectories = true;
                watcher.Filter = "";
                watcher.Changed += OnChanged;
                watcher.Created += OnCreated;
                watchers.Add(watcher);
            }
            return watchers;
        }
        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            //_logger.LogInformation("Directory " + e.FullPath + " has changed.");
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            //_logger.LogInformation("Directory " + e.FullPath + " has changed.");
        }
    }
}
