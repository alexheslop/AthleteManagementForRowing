using System.Windows;
using AthleteManagementTools.ViewModel;

namespace AthleteManagementTools.View
{
    public partial class WeightsProfilingView
    {
        public WeightsProfilingView()
        {
            InitializeComponent();
            var viewModel = new WeightsProfilingViewModel();
            DataContext = viewModel;
            StandardsData.Visibility = Visibility.Hidden;
            StandardsCharting.Visibility = Visibility.Hidden;
        }

        private void UpdateScoreGraphBtn_OnClick(object sender, RoutedEventArgs e)
        {
            ComparisonGraph.Series.Clear();
            var seriesList = ((WeightsProfilingViewModel) DataContext).UpdateActualForRadarComparisonGraph();
            foreach (var series in seriesList)
            {
                ComparisonGraph.Series.Add(series);
            }
        }

        private void CalcStandardsBtn_OnClick(object sender, RoutedEventArgs e)
        {
            StandardsData.Visibility = Visibility.Visible;
            StandardsCharting.Visibility = Visibility.Visible;
            ComparisonGraph.Series.Clear();
            var seriesList = ((WeightsProfilingViewModel)DataContext).UpdateActualForRadarComparisonGraph();
            foreach (var series in seriesList)
            {
                ComparisonGraph.Series.Add(series);
            }
        }
    }
}
