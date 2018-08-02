using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AthleteManagementTools.View
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
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
            throw new System.NotImplementedException();
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
        }
    }
}
