using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Cactus.Db;

namespace Cactus.Pages
{
    public partial class CollectionPage : Page
    {
        private Collection current;
        public CollectionPage(Collection collection)
        {

            InitializeComponent();
            current = collection;
            CommentsLV.ItemsSource = current.Comment.ToList();
            PrizeLV.ItemsSource = current.Prize.ToList();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Utils.Db.Comment.Add(new Comment
                { Author = NameTB.Text, Text = CommentTB.Text, CollectionId = current.Id });
            Utils.Db.SaveChanges();
            NameTB.Text = string.Empty;
            CommentTB.Text = string.Empty;
            
            CommentsLV.ItemsSource = current.Comment.ToList();
        }

        private void Prize_OnClick(object sender, RoutedEventArgs e)
        {
            Utils.Db.Prize.Add(new Prize()
                {Name = PrizeTB.Text, CollectionId = current.Id });
            Utils.Db.SaveChanges();
            PrizeTB.Text = string.Empty;
            
            PrizeLV.ItemsSource = current.Prize.ToList();
        }
    }
}