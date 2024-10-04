using System.Windows;
using System.Windows.Controls;

namespace Cactus.Pages
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Cactus_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CactusesPage());
        }

        private void Exh_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ExhibitionsPage());
        }

        private void Coll_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegPage());

        }
    }
}