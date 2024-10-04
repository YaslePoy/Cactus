using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Cactus.Pages
{
    public partial class CactusesPage : Page
    {
        private Db.Cactus current;
        public CactusesPage()
        {
            InitializeComponent();
            CactusLV.ItemsSource = Utils.Db.Cactus.ToList();
            KindCB.ItemsSource = Utils.Db.CactusKind.Select(i => i.Name).ToList();
        }

        private void CactusLV_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            current = null;
            if(CactusLV.SelectedItem  == null)
                return;
            current = CactusLV.SelectedItem as Db.Cactus;
            CactusView.DataContext = CactusLV.SelectedItem;
            KindCB.SelectedIndex = (int)((current).KindId - 1);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {

            try
            {
                current.KindId = KindCB.SelectedIndex + 1;
                current.Age = int.Parse(AgeTB.Text);
                current.Cost = decimal.Parse(CostTB.Text, CultureInfo.InvariantCulture);
                current.Country = CountryTB.Text;
                current.Manual = ManTB.Text;
                if (current.Id == 0)
                {
                    Utils.Db.Cactus.Add(current);

                }
                Utils.Db.SaveChanges();
                CactusLV.ItemsSource = Utils.Db.Cactus.ToList();
            }
            catch (Exception exception)
            {
                MessageBox.Show("ошибка ввода данных. перепроверьте правиьлность данных");
            }


        }

        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            current = new Db.Cactus();
            CactusView.DataContext = CactusLV.SelectedItem;
            KindCB.SelectedIndex = 0;
            
        }
        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            Utils.Db.Cactus.Remove(current);
            Utils.Db.SaveChanges();
            CactusLV.ItemsSource = Utils.Db.Cactus.ToList();

        }
    }
}