using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AthleteManagementTools.ViewModel;

namespace AthleteManagementTools.View
{
    /// <summary>
    /// Interaction logic for AddPersonView.xaml
    /// </summary>
    public partial class AddPersonView : Window
    {
        private AddPersonViewModel viewModel;
        public AddPersonView()
        {
            viewModel = new AddPersonViewModel();
            InitializeComponent();
            DisplayRower();
        }

        private void DisplayRower()
        {
            ContentPanel.ContentTemplate = (DataTemplate)FindResource("RowerPane");
            //ContentPanel.Content = viewModel.newRower;

            var newBinding = new Binding
            {
                Source = viewModel,
                Path = new PropertyPath("newRower"),
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
            ContentPanel.Content = viewModel.newCoxswain;
        }
    }
}
