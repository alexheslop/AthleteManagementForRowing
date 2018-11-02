using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using AthleteManagementTools.ViewModel;

namespace AthleteManagementTools.View
{
    public partial class CrewSelectionView
    {
        private object _boatUsed;

        private ObservableCollection<RowerSelectPanel> panels = new ObservableCollection<RowerSelectPanel>();
        public CrewSelectionView()
        {
            InitializeComponent();
            DataContext = new CrewSelectionViewModel();
            LstPanels.ItemsSource = panels;
            CbxBoatName.Visibility = Visibility.Hidden;
            LblBoatName.Visibility = Visibility.Hidden;

        }

        private void AddBoatBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var addNewBoat = new AddBoatView();
            addNewBoat.ShowDialog();
            if (addNewBoat.DialogResult.HasValue && addNewBoat.DialogResult.Value)
            {
                ((CrewSelectionViewModel)DataContext).UpdateBoatList();
            }
        }

        private void AddCrewBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var addNewCrew = new AddCrewView();
            addNewCrew.ShowDialog();
            if (addNewCrew.DialogResult.HasValue && addNewCrew.DialogResult.Value)
            {
                ((CrewSelectionViewModel)DataContext).AddCrewPanel(addNewCrew.NewCrew);
            }
        }

        private void MyButton_OnClick(object sender, RoutedEventArgs e)
        {
            ((CrewSelectionViewModel) DataContext).CreateNewCrew(panels, _boatUsed);
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            panels.Clear();
            var seats = ((CrewSelectionViewModel)DataContext).GetSeatNumber(e.AddedItems);
            _boatUsed = e.AddedItems[0];
            for (int i = 0; i < seats; i++)
            {
                RowerSelectPanel p = new RowerSelectPanel
                {
                    CrewPanelCrewList = ((CrewSelectionViewModel) DataContext).CrewList
                };

                panels.Add(p);
            }
            
        }

        private void SquadSelector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var squad = ((ComboBoxItem) e.AddedItems[0]).Content.ToString();
            ((CrewSelectionViewModel)DataContext).UpdateCrewList(squad);
            CbxBoatName.Visibility = Visibility.Visible;
            LblBoatName.Visibility = Visibility.Visible;
        }
    }
}
