using System.Windows;
using System.Windows.Controls;
using AthleteManagementTools.ViewModel;

namespace AthleteManagementTools.View
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            var mainViewModel = new MainViewModel();
            DataContext = mainViewModel;
            InitializeComponent();
            SideSelect.Text = "All";
            SquadSelect.Text = "All";
            SortBy.Text = "Squad";
            ScullRankCBI.Visibility = Visibility.Hidden;
            SweepRankCBI.Visibility = Visibility.Hidden;
        }

        private void TrainingProgramBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var newTrainingProgramView = new TrainingProgramView() { Owner = this, WindowStartupLocation = WindowStartupLocation.CenterOwner };
            newTrainingProgramView.ShowDialog();
            if (newTrainingProgramView.DialogResult.HasValue && newTrainingProgramView.DialogResult.Value)
            {
                
            }
        }

        private void CrewSelectionBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var crewSelectionDlg = new CrewSelectionView();
            crewSelectionDlg.ShowDialog();
            if (crewSelectionDlg.DialogResult.HasValue && crewSelectionDlg.DialogResult.Value)
            {

            }
        }

        private void SeatRacingBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void AddPersonBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var newAddPersonView = new AddPersonView{ Owner = this, WindowStartupLocation = WindowStartupLocation.CenterOwner };
            newAddPersonView.ShowDialog();
            if (newAddPersonView.DialogResult.HasValue && newAddPersonView.DialogResult.Value)
            {
                RefreshTable(SquadSelect.Text, SideSelect.Text, SortBy.Text);
            }
        }

        private void AthleteZoneBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var newSelectAthleteView = new SelectAthleteView {Owner = this, WindowStartupLocation = WindowStartupLocation.CenterOwner};
            newSelectAthleteView.ShowDialog();
            if (!newSelectAthleteView.DialogResult.HasValue || !newSelectAthleteView.DialogResult.Value) return;
            var chosenRower = newSelectAthleteView.AthleteComboBox.SelectedItem;
            var newAthleteZoneView = new AthleteZoneView(chosenRower) { Owner = this, WindowStartupLocation = WindowStartupLocation.CenterOwner };
            newAthleteZoneView.ShowDialog();
        }

        private void SquadSelect_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var squadString = ((ComboBoxItem) e.AddedItems[0]).Content.ToString();

            RefreshTable(squadString, SideSelect.Text, SortBy.Text);
        }
        
        private void EditPersonBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var mi = sender as MenuItem;
            var cm = mi?.CommandParameter as ContextMenu;
            if (!(cm?.PlacementTarget is ListViewItem lvi)) return;
            var source = lvi.Content;
            var newEditRowerView = new EditRowerView(source){ Owner = this, WindowStartupLocation = WindowStartupLocation.CenterOwner };
            newEditRowerView.ShowDialog();
            if (newEditRowerView.DialogResult.HasValue && newEditRowerView.DialogResult.Value)
            {
                RefreshTable(SquadSelect.Text, SideSelect.Text, SortBy.Text);
            }
        }

        private void DeleteRower_OnClick(object sender, RoutedEventArgs e)
        {
            var mi = sender as MenuItem;
            var cm = mi?.CommandParameter as ContextMenu;
            if (!(cm?.PlacementTarget is ListViewItem lvi)) return;
            var source = lvi.Content;
            var messageBoxResult = MessageBox.Show($"Would you like to retire this rower from the squad?", "Delete Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                ((MainViewModel) DataContext).RemoveRower(source);
                RefreshTable(SquadSelect.Text, SideSelect.Text, SortBy.Text);
            }
        }

        private void RefreshTable(string squad, string side, string sort)
        {
            ((MainViewModel)DataContext).RetrieveAthletes(squad, side, sort);
        }

        private void SortBy_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var sortString = ((ComboBoxItem)e.AddedItems[0]).Content.ToString();
            RefreshTable(SquadSelect.Text, SideSelect.Text, sortString);
        }

        private void SideSelect_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var sideString = ((ComboBoxItem)e.AddedItems[0]).Content.ToString();
            
            switch (sideString)
            {
                case "Bowside":
                case "Strokeside":
                    SweepRankCBI.Visibility = Visibility.Visible;
                    ScullRankCBI.Visibility = Visibility.Hidden;
                    break;
                case "Scullers":
                    ScullRankCBI.Visibility = Visibility.Visible;
                    SweepRankCBI.Visibility = Visibility.Hidden;
                    break;
                default:
                    SweepRankCBI.Visibility = Visibility.Hidden;
                    ScullRankCBI.Visibility = Visibility.Hidden;
                    break;
            }
            RefreshTable(SquadSelect.Text, sideString, SortBy.Text);
        }
    }
}
