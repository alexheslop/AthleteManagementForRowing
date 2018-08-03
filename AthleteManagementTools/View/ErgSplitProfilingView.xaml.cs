using System.Windows;
using AthleteManagementTools.ViewModel;

namespace AthleteManagementTools.View
{
    public partial class ErgSplitProfilingView
    {
        public ErgSplitProfilingView()
        {
            InitializeComponent();
            var viewModel = new ErgSplitProfilingViewModel();
            DataContext = viewModel;
        }
    }
}
