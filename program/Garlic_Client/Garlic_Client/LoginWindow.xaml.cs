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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            mw_model.loginwindow = this;
            InitializeComponent();
        }

        private void login_click (Object sender, RoutedEventArgs e)
        {
            mw_model mw = new mw_model();
            string user = username.Text;
            string pw = password.Password;
            Console.WriteLine(user +" "+pw);

            // TODO doesn't really work
            if (user == null || pw == null)
            {
                MessageBox.Show("Please enter a username and password", "OK");
            }

            mw_model.Username = user;
            mw_model.Password = pw;

            if (mw.UserExists)
            {
                MainWindow m = new MainWindow();
                m.Show();
                m.Topmost = true;
                this.Close();
            }
            else
            {
                // TODO register new user
            }
        }

        private void register_click (Object sender, RoutedEventArgs e)
        {

        }
    }
}
