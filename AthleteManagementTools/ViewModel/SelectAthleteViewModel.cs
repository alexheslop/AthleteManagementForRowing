using System.Collections.ObjectModel;
using AthleteManagementTools.Model;

namespace AthleteManagementTools.ViewModel
{
    public class SelectAthleteViewModel
    {
        public ObservableCollection<Rower> RowerList { get; private set; }
        public SelectAthleteViewModel()
        {
            RowerList = AccessDatabaseComms.SelectSquad("All");
        }
    }
}