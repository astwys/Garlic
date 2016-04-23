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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Garlic_Client
{
    /// <summary>
    /// Interaction logic for LoginUC.xaml
    /// </summary>
    public partial class LoginUC : UserControl
    {

        public LoginUC()
        {
            InitializeComponent();
        }

        private void login_click(Object sender, RoutedEventArgs e)
        {
            var curWindow = Window.GetWindow(this);
            mw_model mw = new mw_model();
            string user = username.Text;
            string pw = password.Password;

            if (user == "" || pw == "")
            {
                MessageBox.Show("Please enter a username and password");
                return;
            }

            mw_model.Username = user;
            mw_model.Password = pw;


            if (mw.UserExists)
            {
                MainWindow m = new MainWindow();
                m.Show();
                m.Topmost = true;
                curWindow.Close();
            }
            else
            {
                // TODO register new user

                if (MessageBox.Show("This user does not exist. Do you want to create an account?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    Content = null;
                    Content = new RegisterUC();
                }
                else
                {

                }
            }
        }

        private void register_click(Object sender, RoutedEventArgs e)
        {
            mw_model.Username = username.Text;

            Content = null;
            Content = new RegisterUC();
        }

        private void EnterKey(Object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                login_click(sender, e);
            }
        }
    }
}
