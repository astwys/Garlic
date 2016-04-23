﻿using Garlic_Client.models;
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

        private void LoginUC_OnLoaded (object sender, RoutedEventArgs e)
        {
            Grid.Children.Clear();
            Grid.Children.Add(new LoginUC());
        }

        private void register_click (Object sender, RoutedEventArgs e)
        {
            Grid.Children.Clear();
            Grid.Children.Add(new LoginUC());
        }

        private void EnterKey(Object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                //login_click(sender, e);
            }
        }
    }
}
