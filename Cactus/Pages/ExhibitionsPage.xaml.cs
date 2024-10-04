using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Cactus.Pages
{
    public partial class ExhibitionsPage : Page
    {
        public ExhibitionsPage()
        {
            InitializeComponent();
            ExhLV.ItemsSource = Utils.Db.Exhibition.ToList();

        }
        private Db.Exhibition current;

        private void CactusLV_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            current = ExhLV.SelectedItem as Db.Exhibition;
            CactusView.DataContext = ExhLV.SelectedItem;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {

            current.Name = NameTB.Text;
            current.Location = LocTB.Text;
            current.Date = DateDP.SelectedDate;
            if (current.Id == 0)
            {
                Utils.Db.Exhibition.Add(current);

            }
            Utils.Db.SaveChanges();
            ExhLV.ItemsSource = Utils.Db.Exhibition.ToList();
        }

        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            current = new Db.Exhibition();
            CactusView.DataContext = ExhLV.SelectedItem;
            
        }

        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            Utils.Db.Exhibition.Remove(current);
            Utils.Db.SaveChanges();
            ExhLV.ItemsSource = Utils.Db.Exhibition.ToList();
        }
    }
}