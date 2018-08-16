using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AthleteManagementTools.Annotations;
using AthleteManagementTools.Model;

namespace AthleteManagementTools.ViewModel
{
    public class ErgSplitProfilingViewModel :INotifyPropertyChanged
    {
        public string Ut2Split { get; set; }
        private string _predicted5K;
        public string Predicted5K {
            get => _predicted5K;
            set
            {
                _predicted5K = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged(nameof(Predicted5K));
            }
        }
        private string _predicted30R20;
        public string Predicted30R20 {
            get => _predicted30R20;
            set
            {
                _predicted30R20 = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged(nameof(Predicted30R20));
            }
        }
        private string _predicted2K;
        public string Predicted2K
        {
            get => _predicted2K;
            set
            {
                _predicted2K = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged(nameof(Predicted2K));
            }
        }
        private string _predicted2KTime;
        public string Predicted2KTime
        {
            get => _predicted2KTime;
            set
            {
                _predicted2KTime = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged(nameof(Predicted2KTime));
            }
        }
        private string _predicted5KTime;
        public string Predicted5KTime
        {
            get => _predicted5KTime;
            set
            {
                _predicted5KTime = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged(nameof(Predicted5KTime));
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
        private string _targetSplit;
        public string TargetSplit
        {
            get => _targetSplit;
            set
            {
                _targetSplit = value;
                var splitCalc = new SplitCalculator(210, 55, _targetSplit, false);
                //Find value of combo box and calculate TargetUT2
                switch (SplitType)
                {
                    case "2000m":
                        TargetUt2 = splitCalc.UT2From2k;
                        break;
                    case "5000m":
                        TargetUt2 = splitCalc.UT2From5k;
                        break;
                    default:
                        TargetUt2 = splitCalc.UT2From3020;
                        break;
                }
                OnPropertyChanged(nameof(TargetSplit));
            }
        }
        private string _targetUt2;
        public string TargetUt2
        {
            get => _targetUt2;
            set
            {
                _targetUt2 = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged(nameof(TargetUt2));
            }
        }
        private string _splitType;
        public string SplitType
        {
            get => _splitType;
            set
            {
                _splitType = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged(nameof(SplitType));
            }
        }





        public ErgSplitProfilingViewModel()
        {
            TrainingZones = new ObservableCollection<TrainingZone>();
            var splitCalc = new SplitCalculator(200, 55, "2:00.0", true);
            TrainingZones = splitCalc.TrainingZoneList;
            Predicted2K = splitCalc.Get2K();
            Predicted5K = splitCalc.Get5K();
            Predicted30R20 = splitCalc.Get30R20();
            Predicted2KTime = splitCalc.Get2KTime();
            Predicted5KTime = splitCalc.Get5KTime();
        }

        public ErgSplitProfilingViewModel(double hrmax, double hrmin, string split)
        {
            TrainingZones = new ObservableCollection<TrainingZone>();
            var splitCalc = new SplitCalculator(hrmax, hrmin, split, true);
            TrainingZones = splitCalc.TrainingZoneList;
            Predicted2K = splitCalc.Get2K();
            Predicted5K = splitCalc.Get5K();
            Predicted30R20 = splitCalc.Get30R20();
            Predicted2KTime = splitCalc.Get2KTime();
            Predicted5KTime = splitCalc.Get5KTime();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}