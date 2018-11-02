using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AthleteManagementTools.Annotations;
using AthleteManagementTools.Interfaces;

namespace AthleteManagementTools.Model
{
    public class Crew : ICrew
    {
        public Crew()
        {
            _crewList = new ObservableCollection<Rower>();
        }

        public int NumberOfMembers { get; set; }
        private ObservableCollection<Rower> _crewList;
        public ObservableCollection<Rower> CrewList
        {
            get => _crewList;
            set
            {
                _crewList = value;
                OnPropertyChanged(nameof(CrewList));
            }

        }
        public bool Coxed { get; set; }
        public Boat BoatUsed { get; set; }
        public string CrewName { get; set; }
        public bool Scull { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}