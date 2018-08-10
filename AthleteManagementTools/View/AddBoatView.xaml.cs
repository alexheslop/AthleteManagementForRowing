using System.Windows;
using System.Windows.Data;
using AthleteManagementTools.ViewModel;

namespace AthleteManagementTools.View
{
    public partial class AddBoatView
    {
        public AddBoatView()
        {
            InitializeComponent();
            DataContext = new AddBoatViewModel();
            ContentPanel.ContentTemplate = (DataTemplate)FindResource("BoatPane");
            var newBinding = new Binding
            {
                Source = (AddBoatViewModel)DataContext,
                Path = new PropertyPath("NewBoat"),
                Mode = BindingMode.TwoWay
            };
            BindingOperations.SetBinding(ContentPanel, ContentProperty, newBinding);
        }

        private void AddBoatBtn_OnClick(object sender, RoutedEventArgs e)
        {
            ((AddBoatViewModel) DataContext).AddBoatToCollection();
        }

        private void FinishBtn_OnClickBtn_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
