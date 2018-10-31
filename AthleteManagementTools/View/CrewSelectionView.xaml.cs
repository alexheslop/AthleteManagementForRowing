using System.Collections.ObjectModel;
using System.Windows;
using AthleteManagementTools.ViewModel;

namespace AthleteManagementTools.View
{
    public partial class CrewSelectionView
    {
        private ObservableCollection<MyPanel> panels = new ObservableCollection<MyPanel>();
        public CrewSelectionView()
        {
            InitializeComponent();
            DataContext = new CrewSelectionViewModel();
            ((CrewSelectionViewModel) DataContext).UpdateCrewList();
            LstPanels.ItemsSource = panels;
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
        private void AddPanel(string buttonId)
        {
            
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
            MyPanel p = new MyPanel();
            panels.Add(p);
        }
    }
}
