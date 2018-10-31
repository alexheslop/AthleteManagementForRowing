using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AthleteManagementTools.Annotations;
using AthleteManagementTools.Model;

namespace AthleteManagementTools.ViewModel
{
    public class CrewSelectionViewModel :INotifyPropertyChanged
    {
        private ObservableCollection<Boat> _boatList;
        private ObservableCollection<Rower> _crewList;
        private ObservableCollection<Crew> _crews;
        public CrewSelectionViewModel()
        {
            _boatList = new ObservableCollection<Boat>();
            UpdateBoatList();
        }

        public ObservableCollection<Boat> BoatList
        {
            get => _boatList;
            set
            {
                _boatList = value;
                OnPropertyChanged(nameof(BoatList));
            }

        }
        public ObservableCollection<Rower> CrewList
        {
            get => _crewList;
            set
            {
                _crewList = value;
                OnPropertyChanged(nameof(CrewList));
            }

        }
        public ObservableCollection<Crew> Crews
        {
            get => _crews;
            set
            {
                _crews = value;
                OnPropertyChanged(nameof(Crews));
            }

        }

        public void UpdateCrewList()
        {
            //CrewList = AccessDatabaseComms.ReadDatabase();
        }

        public void UpdateBoatList()
        {
            BoatList = AccessDatabaseComms.ReadBoatFromDatabase();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddCrewPanel(object crew)
        {
            var newCrew = (Crew) crew;
            
        }
    }
}