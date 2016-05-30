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

        public MainWindow () {
            InitializeComponent();
        }

        private void list_Loaded (object sender, RoutedEventArgs e) {
            try {
                list.ItemsSource = (from c in db.c_clove
                                    select c).Distinct().ToList();
            } catch (Exception) {
                MessageBox.Show("An error occured while trying to connect to the database. Please try again.");
                throw;
            }
        }

        private int selectedClove;
        public int SelectedClove {
            get {
                return selectedClove;
            }
            set {
                selectedClove = value;
                PropertyChanged(this, new PropertyChangedEventArgs("articles_Loaded"));
            }
        }

        private void articles_Loaded (object sender, RoutedEventArgs e) {
            try {
                articles.ItemsSource = (from a in db.a_articles
                                        where a.c_clove.c_id == this.selectedClove
                                        select a).Distinct().ToList();
                var i = articles.ItemsSource;
            } catch (Exception) {
                MessageBox.Show("An error occured while loading the articles. Please try again");
                throw;
            }
        }
    }
}
