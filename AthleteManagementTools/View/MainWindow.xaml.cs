using System.Runtime.InteropServices;
using System.Windows;
using AthleteManagementTools.ViewModel;

namespace AthleteManagementTools.View
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var mainViewModel = new MainViewModel();
            DataContext = mainViewModel;


        }

        private void TrainingProgramBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void CrewSelectionBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void ErgoSplitProfileBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var ergoSplitProfileDlg = new ErgSplitProfilingView();
            ergoSplitProfileDlg.ShowDialog();
            if (ergoSplitProfileDlg.DialogResult.HasValue && ergoSplitProfileDlg.DialogResult.Value)
            {

            }
        }

        private void WeightProfileBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void SeatRacingBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void AddPersonBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var newAddPersonView = new AddPersonView();
            newAddPersonView.ShowDialog();
            if (newAddPersonView.DialogResult.HasValue && newAddPersonView.DialogResult.Value)
            {
               ((MainViewModel) DataContext).RetrieveSquadUpdate();
            }
        }
    }
}
