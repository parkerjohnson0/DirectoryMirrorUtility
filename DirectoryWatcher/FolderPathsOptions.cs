using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryWatcher
{
    public class FolderPathsOptions
    {
        public const string FolderPaths = "FolderPaths";
        public List<FolderPath> Paths { get; set; }
    }
    public class FolderPath
    {
        public string Directory { get; set; }
        public string Output { get; set; }
    }
}
