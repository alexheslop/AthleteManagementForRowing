using System.Collections.ObjectModel;
using AthleteManagementTools.Model;

namespace AthleteManagementTools.Interfaces
{
    public interface ICrew
    {
        int NumberOfMembers { get; set; }
        ObservableCollection<Rower> CrewList { get; set; }
        bool Coxed { get; set; }
        Boat BoatUsed { get; set; }
        string CrewName { get; set; }
        bool Scull { get; set; }

    }
}