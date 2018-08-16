using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GeneralGrid.Focus();
        }

    }
}
