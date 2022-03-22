using DirectoryWatcher;
using GUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.ViewModel
{
    public class MainViewModel
    {
        public ObservableCollection<MirrorListItem> MirrorListItems { get; set; }
        public MainViewModel()
        {

        }
        public MainViewModel(WatcherService service)
        {

        }
    }
}
