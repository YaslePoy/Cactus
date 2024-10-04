using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Cactus.Db;

namespace Cactus.Pages
{
    public partial class RegPage : Page
    {
        private List<Db.Cactus> totalCact = new List<Db.Cactus>();
        
        public RegPage()
        {
            InitializeComponent();
            ExhLV.ItemsSource = Utils.Db.Exhibition.ToList();
            totalCact = Utils.Db.Cactus.ToList();
        }

        private void CactusLV_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = ExhLV.SelectedItem as Exhibition;
            var cactuses = selected.Collection.Select(i => i.Cactus).ToList();
            ExhContextSP.DataContext = selected;
            RegedCactusesLB.ItemsSource = cactuses;
            var avalible = new List<Db.Cactus>(totalCact);
            avalible.RemoveAll(i => cactuses.Any(j => j.Id == i.Id));
            CactusLV.ItemsSource = avalible;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var currExh = ExhContextSP.DataContext as Exhibition;
            var currCact = (sender as Button).DataContext as Db.Cactus;
            Utils.Db.Collection.Add(new Collection { CactusId = currCact.Id, ExhibitionId = currExh.Id});
            Utils.Db.SaveChanges();
            
            var cactuses = currExh.Collection.Select(i => i.Cactus).ToList();
            RegedCactusesLB.ItemsSource = cactuses;
            var avalible = new List<Db.Cactus>(totalCact);
            avalible.RemoveAll(i => cactuses.Any(j => j.Id == i.Id));
            CactusLV.ItemsSource = avalible;
        }

        private void Remove_OnClick(object sender, RoutedEventArgs e)
        {
            var currExh = ExhContextSP.DataContext as Exhibition;
            var currCact = (sender as Button).DataContext as Db.Cactus;
            Utils.Db.Collection.Remove(Utils.Db.Collection.FirstOrDefault(i => i.CactusId == currCact.Id && i.ExhibitionId == currExh.Id));
            Utils.Db.SaveChanges();
            
            var cactuses = currExh.Collection.Select(i => i.Cactus).ToList();
            RegedCactusesLB.ItemsSource = cactuses;
            var avalible = new List<Db.Cactus>(totalCact);
            avalible.RemoveAll(i => cactuses.Any(j => j.Id == i.Id));
            CactusLV.ItemsSource = avalible;
        }

        private void RegedCactusesLB_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var currExh = ExhContextSP.DataContext as Exhibition;
            var cactus = (RegedCactusesLB.SelectedItem as Db.Cactus).Id;
            var coll = Utils.Db.Collection.FirstOrDefault(i =>
                i.CactusId == cactus &&
                currExh.Id == i.ExhibitionId);
            NavigationService.Navigate(new CollectionPage(coll));
        }
    }
}