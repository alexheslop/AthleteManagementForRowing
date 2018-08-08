using System;
using System.Windows;
using AthleteManagementTools.ViewModel;

namespace AthleteManagementTools.View
{
    public partial class ErgSplitProfilingView
    {
        public ErgSplitProfilingView()
        {
            InitializeComponent();
            var viewModel = new ErgSplitProfilingViewModel();
            DataContext = viewModel;
        }

        private void GenerateResultsBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var  ergSplitProfilingViewModel = new ErgSplitProfilingViewModel(Convert.ToDouble(MaxHrBox.Text), Convert.ToDouble(MinHrBox.Text), SplitBox.Text);
            DataContext = ergSplitProfilingViewModel;
        }
    }
}
