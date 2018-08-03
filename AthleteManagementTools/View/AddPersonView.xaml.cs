using System.Windows;
using System.Windows.Data;
using AthleteManagementTools.ViewModel;

namespace AthleteManagementTools.View
{
    public partial class AddPersonView
    {
        private readonly AddPersonViewModel _viewModel;
        public AddPersonView()
        {
            _viewModel = new AddPersonViewModel();
            InitializeComponent();
            DisplayRower();
        }

        private void DisplayRower()
        {
            ContentPanel.ContentTemplate = (DataTemplate)FindResource("RowerPane");
            
            var newBinding = new Binding
            {
                Source = _viewModel,
                Path = new PropertyPath("NewRower"),
                Mode = BindingMode.TwoWay
            };
            BindingOperations.SetBinding(ContentPanel, ContentProperty, newBinding);
        }

        private void RowerBtn_OnClick(object sender, RoutedEventArgs e)
        {
            DisplayRower();
        }

        private void CoxswainBtn_OnClick(object sender, RoutedEventArgs e)
        {
            ContentPanel.ContentTemplate = (DataTemplate)FindResource("CoxswainPane");
            var newBinding = new Binding
            {
                Source = _viewModel,
                Path = new PropertyPath("NewCoxswain"),
                Mode = BindingMode.TwoWay
            };
            BindingOperations.SetBinding(ContentPanel, ContentProperty, newBinding);
        }

        private void AddPersonBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (_viewModel.AddPersonToDatabase())
            {
                MessageBox.Show("Person successfully added!");
            }
            
        }

        private void FinishBtn_OnClickBtn_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
