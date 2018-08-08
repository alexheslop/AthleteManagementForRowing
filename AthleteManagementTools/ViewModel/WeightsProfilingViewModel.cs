using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using AthleteManagementTools.Annotations;
using AthleteManagementTools.Model;
using DevExpress.Xpf.Charts;

namespace AthleteManagementTools.ViewModel
{
    public class WeightsProfilingViewModel : INotifyPropertyChanged
    {
        private double _bodyweight;
        public double BodyWeight
        {
            get => _bodyweight;
            set
            {
                _bodyweight = value;
                WeightStandards = WeightProfilingCommonMethods.AddStandardClasses(_bodyweight);
                OnPropertyChanged(nameof(BodyWeight));
            }
        }
        private ObservableCollection<WeightClass> _weightStandards;
        public ObservableCollection<WeightClass> WeightStandards
        {
            get => _weightStandards;
            set
            {
                _weightStandards = value;
                OnPropertyChanged(nameof(WeightStandards));
            }
        }
        private ObservableCollection<WeightClass> _weightActual;
        public ObservableCollection<WeightClass> WeightActual
        {
            get => _weightActual;
            set
            {
                _weightActual = value;
                OnPropertyChanged(nameof(WeightActual));
            }
        }
        
        public WeightsProfilingViewModel()
        {
            WeightStandards = WeightProfilingCommonMethods.AddStandardClasses(BodyWeight);
            WeightActual = WeightProfilingCommonMethods.AddStandardClasses(0);
        }

        public IEnumerable<RadarAreaSeries2D> UpdateActualForRadarComparisonGraph()
        {
            var seriesList = new List<RadarAreaSeries2D>();
            var targetSeries = new RadarAreaSeries2D {Transparency = 0.5, Background = Brushes.DarkBlue};
            foreach (var weightClass in WeightStandards)
            {
                targetSeries.Points.Add(new SeriesPoint(weightClass.Name, weightClass.OneRepMax));
            }
            seriesList.Add(targetSeries);

            var actualSeries = new RadarAreaSeries2D { Transparency = 0.8, Background = Brushes.AliceBlue };
            foreach (var weightClass in WeightActual)
            {
                actualSeries.Points.Add(new SeriesPoint(weightClass.Name, weightClass.OneRepMax));
            }
            seriesList.Add(actualSeries);

            return seriesList;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}