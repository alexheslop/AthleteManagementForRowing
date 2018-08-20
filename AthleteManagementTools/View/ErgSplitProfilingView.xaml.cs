using System;
using System.Windows;
using System.Windows.Input;
using AthleteManagementTools.ViewModel;

namespace AthleteManagementTools.View
{
    public partial class ErgSplitProfilingView
    {
        private string _rowerFirstName;
        private string _rowerLastName;
        public ErgSplitProfilingView()
        {
            InitializeComponent();
            var viewModel = new ErgSplitProfilingViewModel();
            DataContext = viewModel;
        }
        public ErgSplitProfilingView(object chosenRower)
        {
            InitializeComponent();
            var viewModel = new ErgSplitProfilingViewModel(chosenRower);
            _rowerFirstName = viewModel.NewRower.FirstName;
            _rowerLastName = viewModel.NewRower.LastName;
            DataContext = viewModel;
        }

        private void GenerateResultsBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var  ergSplitProfilingViewModel = new ErgSplitProfilingViewModel(Convert.ToDouble(MaxHrBox.Text), Convert.ToDouble(MinHrBox.Text), SplitBox.Text, Pb2kBox.Text, Pb5kBox.Text, Pb30r20Box.Text);
            DataContext = ergSplitProfilingViewModel;
            ((ErgSplitProfilingViewModel) DataContext).UpdateRowerDetails(_rowerFirstName, _rowerLastName, SplitBox.Text, Pb2kBox.Text, Pb5kBox.Text,
                Pb30r20Box.Text, Convert.ToInt32(MaxHrBox.Text), Convert.ToInt32(MinHrBox.Text));
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GeneralGrid.Focus();
        }

    }
}
