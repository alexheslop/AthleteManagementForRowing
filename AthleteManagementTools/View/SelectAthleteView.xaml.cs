using System.Collections.Generic;
using System.Windows;
using AthleteManagementTools.Model;
using AthleteManagementTools.ViewModel;

namespace AthleteManagementTools.View
{
    public partial class SelectAthleteView
    {
        public SelectAthleteView()
        {
            InitializeComponent();
            DataContext = new SelectAthleteViewModel();
            AthleteComboBox.ItemsSource = ((SelectAthleteViewModel) DataContext).RowerList;
        }

        private void OKBtn_OnClickMethod(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
