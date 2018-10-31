using System.Collections.ObjectModel;
using AthleteManagementTools.Interfaces;

namespace AthleteManagementTools.Model
{
    public class Crew : ICrew
    {
        public int NumberOfMembers { get; set; }
        public ObservableCollection<Rower> CrewList { get; set; }
        public bool Coxed { get; set; }
        public Boat BoatUsed { get; set; }
        public string CrewName { get; set; }
        public bool Scull { get; set; }
    }
}