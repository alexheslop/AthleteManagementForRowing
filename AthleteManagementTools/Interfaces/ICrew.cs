using System.Collections.ObjectModel;
using AthleteManagementTools.Model;

namespace AthleteManagementTools.Interfaces
{
    public interface ICrew
    {
        int NumberOfMembers { get; set; }
        ObservableCollection<Rower> CrewList { get; set; }
        Coxswain Cox { get; set; }

    }
}