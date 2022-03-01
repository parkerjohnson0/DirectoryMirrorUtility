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
        public List<string> Paths { get; set; }
    }
}
