using System.Windows;

namespace AthleteManagementTools.View
{
    public partial class AthleteZoneView
    {
        private readonly object _chosenRower;
        public AthleteZoneView()
        {
            InitializeComponent();
        }

        public AthleteZoneView(object chosenRower)
        {
            InitializeComponent();
            _chosenRower = chosenRower;
        }

        private void ErgSplitBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var ergoSplitProfileDlg = new ErgSplitProfilingView(_chosenRower){ Owner = this, WindowStartupLocation = WindowStartupLocation.CenterOwner };
            ergoSplitProfileDlg.ShowDialog();
            if (ergoSplitProfileDlg.DialogResult.HasValue && ergoSplitProfileDlg.DialogResult.Value)
            {

            }
        }

        private void WeightsBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var weightProfileDlg = new WeightsProfilingView(){ Owner = this, WindowStartupLocation = WindowStartupLocation.CenterOwner };
            weightProfileDlg.ShowDialog();

            if (weightProfileDlg.DialogResult.HasValue && weightProfileDlg.DialogResult.Value)
            {

            }
        }
    }
}
