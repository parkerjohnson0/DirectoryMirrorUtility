using DirectoryWatcher.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DirectoryWatcher
{
    public class WatcherService
    {
        private readonly ILogger<WatcherService> _logger;
        //private List<string> folderPaths;
        private List<Folder> Folders = new List<Folder>();
        private readonly FolderPathsOptions _options;
        private List<FileSystemWatcher> watchers;
        //private readonly IConfiguration Configuration;
        public WatcherService(IOptions<FolderPathsOptions> options, ILogger<WatcherService> logger)
        {
            _logger = logger;
            _options = options.Value;
            Folders = GetFoldersFromConfig();
            watchers = WatcherFactory.CreateWatchers(Folders);
        }

        private List<Folder> GetFoldersFromConfig()
        {
            List<Folder> list = new List<Folder>();
            foreach (var item in _options.Paths)
            {
                list.Add(new Folder()
                {
                    Path = item
                });
            }
            return list;
        }

        public void Run()
        {

        }
    }
}
