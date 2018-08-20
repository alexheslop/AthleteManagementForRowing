using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AthleteManagementTools.Annotations;
using AthleteManagementTools.Model;

namespace AthleteManagementTools.ViewModel
{
    public class MainViewModel :INotifyPropertyChanged
    {
        private ObservableCollection<Rower> _squadList;
        public ObservableCollection<Rower> SquadList
        {
            get => _squadList;
            set
            {
                _squadList = value;
                OnPropertyChanged(nameof(SquadList));
            }
    }

        public MainViewModel()
        {
            _squadList = new ObservableCollection<Rower>();
            RetrieveSquadUpdate("All");
        }

        public void RetrieveSquadUpdate(string squad)
        {
            SquadList = AccessDatabaseComms.SelectSquad(squad);
        }

        public void RemoveRower(object rower)
        {
            var removedRower = (Rower) rower;
            AccessDatabaseComms.RemoveRowerFromDatabase(removedRower.FirstName, removedRower.LastName);
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}