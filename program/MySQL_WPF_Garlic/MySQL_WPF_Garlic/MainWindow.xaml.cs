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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.ComponentModel;

namespace MySQL_WPF_Garlic {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;

        garlicEntities db = new garlicEntities();

        MainWindowController controller;

        public MainWindow () {
            this.controller = new MainWindowController(ref db);
            InitializeComponent();
        }

        private async void list_Loaded (object sender, RoutedEventArgs e) {
            try {
                list.IsEnabled = false;
                articles.IsEnabled = false;
                list.ItemsSource = await controller.Task_list_ItemsSource();
                list.DisplayMemberPath = "ci_cloveName";
                list.IsEnabled = true;
                articles.IsEnabled = true;
            } catch (Exception) {
                list.IsEnabled = true;
                articles.IsEnabled = true;
                MessageBox.Show("An error occured while trying to connect to the database. Please try again.");
                throw;
            }
        }

        private async void list_SelectionChanged (object sender, SelectionChangedEventArgs e) {
            var selecteditem = (vcloveinfo)list.SelectedItem;
            list.IsEnabled = false;
            articles.IsEnabled = false;
            articles.ItemsSource = await controller.Task_articles_ItemsSource(selecteditem);
            articles.DisplayMemberPath = "a_title";
            list.IsEnabled = true;
            articles.IsEnabled = true;
            builderCloveInfo(selecteditem.ci_articles, selecteditem.ci_subscribers, selecteditem.ci_admins);
            builderArticleInfo(null);
        }

        private void builderCloveInfo (long? numberOfArticles, long? numberOfSubscribers, long? numberOfAdmins) {
            articlestitle.Text = "Clove Information" + "\n" + "Articles: " + numberOfArticles + "\n" + "Subs: " + numberOfSubscribers + "\n" + "Admins: " + numberOfAdmins;
        }

        private void articles_SelectionChanged (object sender, SelectionChangedEventArgs e) {
            var selecteditem = (a_articles)articles.SelectedItem;
            builderArticleInfo(selecteditem);
        }

        private async void builderArticleInfo (a_articles article) {
            if(article == null) {
                articleid.Text = "-"; articledate.Text = "-"; articleauthor.Text = "-"; articletitle.Text = "-"; articlecontent.Text = "-";
            } else {
                //TODO change the view in MySQL so there is only the second view used
                list.IsEnabled = false;
                articles.IsEnabled = false;
                var info = await controller.Task_info_query(article);
                list.IsEnabled = true;
                articles.IsEnabled = true;
                articleid.Text = info.p_id.ToString();
                articledate.Text = article.p_posts.p_date.ToString();
                articleauthor.Text = article.p_posts.p_u_username;
                articletitle.Text = article.a_title.Length > 20 ? article.a_title.Substring(0, 20) + " ..." : article.a_title;
                articlecontent.Text = article.p_posts.p_content.Substring(0, 20)+" ...";
            }
        }

        

    }
}
