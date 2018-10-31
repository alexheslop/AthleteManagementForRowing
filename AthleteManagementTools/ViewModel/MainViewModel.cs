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
            RetrieveAthletes("All", "All", "Squad");
        }

        public void RetrieveAthletes(string squad, string side, string sort)
        {
            SquadList = SqlServerDbComms.SelectSquad(squad, side, sort);
        }

        public void RemoveRower(object rower)
        {
            var removedRower = (Rower) rower;
            SqlServerDbComms.RemoveRowerFromDatabase(removedRower.FirstName, removedRower.LastName);
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}