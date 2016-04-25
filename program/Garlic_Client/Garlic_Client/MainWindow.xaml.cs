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
using System.Configuration;
using System.Data.SqlClient;
using Garlic_Client.models;

namespace Garlic_Client {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow () {
            mw_model.mainwindow = this;
            InitializeComponent();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string article = ((TextBlock)sender).Text;
            mw_model.ArticleTitle = article;
            ReadWindow read = new ReadWindow(); 
            read.Show();
            read.Topmost = true;
        }

        private void admin_click (object sender, RoutedEventArgs e)
        {
            
        }

        private void newclove_click (object sender, RoutedEventArgs e)
        {
            NewCloveWIndow cw = new NewCloveWIndow();
            cw.Show();
        }

        private void delete_click(object sender, RoutedEventArgs e)
        {
            DeleteWindow delete = new DeleteWindow();
            delete.Show();
        }

        private void settings_click (object sender, RoutedEventArgs e)
        {
            SettingsWindow set = new SettingsWindow();
            set.Show();
            set.Topmost = true;
        }
    }
}
