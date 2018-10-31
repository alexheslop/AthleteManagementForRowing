using System.Windows;
using System.Windows.Data;
using AthleteManagementTools.ViewModel;

namespace AthleteManagementTools.View
{
    /// <summary>
    /// Interaction logic for AddCrewView.xaml
    /// </summary>
    public partial class AddCrewView
    {
        public object NewCrew { get; set; }
        public AddCrewView()
        {
            InitializeComponent();
            DataContext = new AddCrewViewModel();
            BoatComboBox.ItemsSource = ((AddCrewViewModel) DataContext).BoatList;
        }


        private void AddCrewBtn_OnClick(object sender, RoutedEventArgs e)
        {
            ((AddCrewViewModel)DataContext).AddCrewToDatabase();
            throw new System.NotImplementedException();
        }

        private void FinishBtn_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
