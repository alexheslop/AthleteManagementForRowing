using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AthleteManagementTools.Annotations;
using AthleteManagementTools.Model;

namespace AthleteManagementTools.ViewModel
{
    public class ErgSplitProfilingViewModel :INotifyPropertyChanged
    {
        private string _target5K;
        public string Target5K {
            get => _target5K;
            set
            {
                _target5K = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged(nameof(Target5K));
            }
        }
        private string _target30R20;
        public string Target30R20 {
            get => _target30R20;
            set
            {
                _target30R20 = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged(nameof(Target30R20));
            }
        }
        private string _target2K;
        public string Target2K
        {
            get => _target2K;
            set
            {
                _target2K = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged(nameof(Target2K));
            }
        }
        private string _target2KTime;
        public string Target2KTime
        {
            get => _target2KTime;
            set
            {
                _target2KTime = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged(nameof(Target2KTime));
            }
        }
        private string _target5KTime;
        public string Target5KTime
        {
            get => _target5KTime;
            set
            {
                _target5KTime = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged(nameof(Target5KTime));
            }
        }
        private ObservableCollection<TrainingZone> _trainingZones;
        public ObservableCollection<TrainingZone> TrainingZones
        {
            get => _trainingZones;
            set
            {
                _trainingZones = value;
                OnPropertyChanged(nameof(TrainingZones));
            }
        }

        public ErgSplitProfilingViewModel()
        {
            TrainingZones = new ObservableCollection<TrainingZone>();
            var splitCalc = new SplitCalculator(210, 55, "2:00.0");
            TrainingZones = splitCalc.TrainingZoneList;
            Target2K = splitCalc.Get2K();
            Target5K = splitCalc.Get5K();
            Target30R20 = splitCalc.Get30R20();
            Target2KTime = splitCalc.Get2KTime();
            Target5KTime = splitCalc.Get5KTime();

        }

        public ErgSplitProfilingViewModel(double hrmax, double hrmin, string split)
        {
            TrainingZones = new ObservableCollection<TrainingZone>();
            var splitCalc = new SplitCalculator(hrmax, hrmin, split);
            TrainingZones = splitCalc.TrainingZoneList;
            Target2K = splitCalc.Get2K();
            Target5K = splitCalc.Get5K();
            Target30R20 = splitCalc.Get30R20();
            Target2KTime = splitCalc.Get2KTime();
            Target5KTime = splitCalc.Get5KTime();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}