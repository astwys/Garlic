using Garlic_Client.models;
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

namespace Garlic_Client
{
    /// <summary>
    /// Interaction logic for DeleteWindow.xaml
    /// </summary>
    public partial class DeleteWindow : Window
    {
        public DeleteWindow()
        {
            InitializeComponent();
        }

        private void articledelete_click(object sender, RoutedEventArgs e)
        {
            mw_model mw = new mw_model();
            Console.WriteLine(((TextBlock)sender).Text);
            string title = ((TextBlock)sender).Text;

            if (MessageBox.Show("Do you want to delete this article.", "Qeustion", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return;
            }

            mw.DeleteArticle(title);

            posts.Items.Refresh();
        }
    }
}
