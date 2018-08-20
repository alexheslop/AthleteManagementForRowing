using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AthleteManagementTools.Annotations;
using AthleteManagementTools.Model;

namespace AthleteManagementTools.ViewModel
{
    public class ErgSplitProfilingViewModel :INotifyPropertyChanged
    {
        private string _rowerFirstName;
        private string _rowerLastName;
        public Rower NewRower { get; set; }
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

        private string _pb2K;
        private string _pb5K;
        private string _pb30R20;

        public string Pb2K
        {
            get => _pb2K;
            set
            {
                _pb2K = value;
                OnPropertyChanged(nameof(Pb2K));
            }
        }
        public string Pb5K
        {
            get => _pb5K;
            set
            {
                _pb5K = value;
                OnPropertyChanged(nameof(Pb5K));
            }
        }
        public string Pb30R20
        {
            get => _pb30R20;
            set
            {
                _pb30R20 = value;
                OnPropertyChanged(nameof(Pb30R20));
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

        public ErgSplitProfilingViewModel(object chosenRower)
        {
            NewRower = (Rower) chosenRower;
            TrainingZones = new ObservableCollection<TrainingZone>();
            var splitCalc = new SplitCalculator(200, 55, NewRower.Ut2Split, true);
            TrainingZones = splitCalc.TrainingZoneList;
            Predicted2K = splitCalc.Get2K();
            Predicted5K = splitCalc.Get5K();
            Predicted30R20 = splitCalc.Get30R20();
            Predicted2KTime = splitCalc.Get2KTime();
            Predicted5KTime = splitCalc.Get5KTime();
            Pb2K = NewRower.Pb2K;
            Pb5K = NewRower.Pb5K;
            Pb30R20 = NewRower.Pb30R20;
            _rowerFirstName = NewRower.FirstName;
            _rowerLastName = NewRower.LastName;
        }

        public ErgSplitProfilingViewModel(double hrmax, double hrmin, string split, string pb2K, string pb5K, string pb30R20)
        {
            TrainingZones = new ObservableCollection<TrainingZone>();
            var splitCalc = new SplitCalculator(hrmax, hrmin, split, true);
            TrainingZones = splitCalc.TrainingZoneList;
            Predicted2K = splitCalc.Get2K();
            Predicted5K = splitCalc.Get5K();
            Predicted30R20 = splitCalc.Get30R20();
            Predicted2KTime = splitCalc.Get2KTime();
            Predicted5KTime = splitCalc.Get5KTime();
            NewRower = new Rower {FirstName = _rowerFirstName, LastName = _rowerLastName, Ut2Split = split, Pb2K = pb2K, Pb30R20 = pb30R20, Pb5K = pb5K, MaxHr = (int)Math.Round(hrmax), MinHr = (int)Math.Round(hrmin) };
            Pb2K = NewRower.Pb2K;
            Pb5K = NewRower.Pb5K;
            Pb30R20 = NewRower.Pb30R20;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void UpdateRowerDetails(string firstName, string lastName, string splitBoxText, string pb2K, string pb5K, string pb30R20, int maxHR, int minHR)
        {
            AccessDatabaseComms.UpdateRowerFromErgProfile(firstName, lastName, pb2K,
                pb5K, pb30R20, splitBoxText, maxHR, minHR);
        }
    }
}