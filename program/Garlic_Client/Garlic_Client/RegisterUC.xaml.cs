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
