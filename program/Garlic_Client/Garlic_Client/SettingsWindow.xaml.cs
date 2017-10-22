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
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void update_click (object sender, RoutedEventArgs e)
        {
            mw_model mw = new mw_model();
            if (pw.Text == "" || email.Text == "" )
            {
                MessageBox.Show("Please fill in all the required fields.");
                return;
            }

            mw_model.Password = pw.Text;
            mw.Email = email.Text;

            mw.UpdateSettings("add");

            MessageBox.Show("Settings updated. Please relogin to apply.");
            this.Close();
        } 
    }
}
