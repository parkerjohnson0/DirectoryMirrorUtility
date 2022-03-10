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
        internal static void CreateAndAssignWatchers(List<Folder> folders)
        {
            List<FileSystemWatcher> watchers = new List<FileSystemWatcher>();
            foreach (var folder in folders)
            {
                FileSystemWatcher watcher = new FileSystemWatcher(folder.Path);
                watcher.EnableRaisingEvents = true;
                watcher.IncludeSubdirectories = true;
                watcher.Filter = "";
                watcher.Created += (sender, e) => OnChange(sender, e, folder);
                watcher.Deleted += (sender, e) => OnChange(sender, e, folder);
                watcher.Changed += (sender, e) => OnChange(sender, e, folder);
                watcher.Renamed += (sender, e) => OnChange(sender, e, folder);
                folder.FileWatcher = watcher;
            }
        }
        private static void OnChange(object sender, EventArgs e, Folder folder)
        {
            folder.ChangesMade = true;
        }
    }
}


