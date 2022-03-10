using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryWatcher
{
    public class Folder
    {
        public bool ChangesMade { get; set; }
        public string Path { get; set; }
        public FileSystemWatcher FileWatcher { get; set; }

        internal void HandleChange()
        {
            ChangesMade = false;
        }
    }
}
