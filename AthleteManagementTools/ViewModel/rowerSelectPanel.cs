using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using AthleteManagementTools.Model;

namespace AthleteManagementTools.ViewModel
{
    public class RowerSelectPanel
    {
        private ObservableCollection<Rower> _crewPanelCrewList;
        private Rower _selectedAthlete;
        public ObservableCollection<Rower> CrewPanelCrewList
        {
            get => _crewPanelCrewList;
            set
            {
                if (value == _crewPanelCrewList) return;
                _crewPanelCrewList = value;
                NotifyPropertyChanged();
            }
        }
        public Rower SelectedAthlete
        {
            get => _selectedAthlete;
            set
            {
                if (value == _selectedAthlete) return;
                _selectedAthlete = value;
                NotifyPropertyChanged();
            }
        }
       
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
