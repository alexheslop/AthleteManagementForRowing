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
            RetrieveSquadUpdate();
        }

        public void RetrieveSquadUpdate()
        {
            SquadList = AccessDatabaseComms.ReadDatabase();
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}