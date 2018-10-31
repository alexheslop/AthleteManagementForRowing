using System.Windows;
using AthleteManagementTools.ViewModel;

namespace AthleteManagementTools.View
{
    public partial class CrewSelectionView
    {
        public CrewSelectionView()
        {
            InitializeComponent();
            DataContext = new CrewSelectionViewModel();
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
    }
}
