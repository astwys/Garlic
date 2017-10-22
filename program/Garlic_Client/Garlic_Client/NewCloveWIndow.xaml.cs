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
    /// Interaction logic for NewCloveWIndow.xaml
    /// </summary>
    public partial class NewCloveWIndow : Window
    {
        public NewCloveWIndow()
        {
            InitializeComponent();
        }

        private void cancle_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void submit_click(object sender, RoutedEventArgs e)
        {
            mw_model mw = new mw_model();
            string name = title.Text;
            string desc = description.Text;

            if (name == "" || desc == "")
            {
                MessageBox.Show("Please enter a title as well as a description for the new clove");
                return;
            }
            mw.CreateClove(name, desc);
            this.Close();
            
        }
    }
}
