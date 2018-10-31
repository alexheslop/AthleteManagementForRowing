using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AthleteManagementTools.Annotations;
using AthleteManagementTools.Model;

namespace AthleteManagementTools.ViewModel
{
    public class AddCrewViewModel
    {
        public Crew NewCrew { get; set; }
        public ObservableCollection<Boat> BoatList;
        public AddCrewViewModel()
        {
            NewCrew = new Crew();
            BoatList = SqlServerDbComms.ReadBoatFromDatabase();
        }

        public void AddCrewToDatabase()
        {
            
        }


    }
}