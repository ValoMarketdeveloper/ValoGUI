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
    /// Interaction logic for CCInventory.xaml
    /// </summary>
    public partial class CCInventory : Window
    {
        public CCInventory()
        {
            InitializeComponent();
        }

        public void UPC_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if(tb.Text.Length == 0)
            {
                tb.Text = "Insert Product UPC";
                tb.GotFocus += UPC_GotFocus;
            }
        }

        public void UPC_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.Text = string.Empty;
            tb.GotFocus -= UPC_GotFocus;
        }

        public void Price_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.Text = string.Empty;
            tb.GotFocus -= Price_GotFocus;
        }

        private void Price_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Text.Length == 0)
            {
                tb.Text = "Price";
                tb.GotFocus += Price_GotFocus;
            }
        }

        public void Qty_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.Text = string.Empty;
            tb.GotFocus -= Qty_GotFocus;
        }

        private void Qty_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Text.Length == 0)
            {
                tb.Text = "Qty";
                tb.GotFocus += Qty_GotFocus;
            }
        }

        public void UOM_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.Text = string.Empty;
            tb.GotFocus -= UOM_GotFocus;
        }

        private void UOM_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Text.Length == 0)
            {
                tb.Text = "UOM";
                tb.GotFocus += UOM_GotFocus;
            }
        }
    }
}
