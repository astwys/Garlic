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
    public partial class RegisterUC : UserControl
    {
        public RegisterUC()
        {
            InitializeComponent();
        }

        private void register_click(Object sender, RoutedEventArgs e)
        {
            var curWindow = Window.GetWindow(this);

            string user = username.Text;
            string pw = password.Password;
            string em = email.Text;

            if (user == "" || pw == "" || em == "")
            {
                MessageBox.Show("Please enter a username, password and email address.");
                return;
            }

            mw_model mw = new mw_model();
            mw.NewUser(user, pw, em);

            if (mw.UserExists(user, pw))
            {
                mw_model.Username = user;
                mw_model.Password = pw;
                MainWindow m = new MainWindow();
                m.Show();
                curWindow.Close();
            }
            else
            {
                MessageBox.Show("Something went wrong while creating a new user account.");
            }
        }

        private void EnterKey(Object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                register_click(sender, e);
            }
        }
    }
}
