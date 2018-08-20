using System.Windows;
using AthleteManagementTools.ViewModel;

namespace AthleteManagementTools.View
{
    public partial class EditRowerView
    {
        public EditRowerView(object rower)
        {
            InitializeComponent();
            DataContext = new EditRowerViewModel(rower);
        }

        private void OkBtn_OnClick(object sender, RoutedEventArgs e)
        {
            ((EditRowerViewModel) DataContext).UpdatePersonInDatabase();
            DialogResult = true;
        }
    }
}
