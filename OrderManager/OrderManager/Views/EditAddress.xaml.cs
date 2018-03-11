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

namespace OrderManager.Views
{
    /// <summary>
    /// Interaction logic for EditAddress.xaml
    /// </summary>
    public partial class EditAddress : Window
    {
        public bool SaveData { get; set; }
        public EditAddress()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveData = true;
            Close();
        }
    }
}
