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
    }
}