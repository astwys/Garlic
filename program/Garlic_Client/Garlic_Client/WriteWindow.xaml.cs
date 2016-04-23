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
using Garlic_Client.models;

namespace Garlic_Client {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class WriteWindow : Window {
        public WriteWindow () {
            // TODO up to now only allows one window to be open - change to have multiple > see TODO in model
            mw_model.writewindow = this;
            InitializeComponent();
        }

        private void writecancle_Click (object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void Window_Closed (object sender, EventArgs e) {
            mw_model.OnWriteWindowClosed();
        }
    }
}
