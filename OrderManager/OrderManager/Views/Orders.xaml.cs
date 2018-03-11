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
    /// Interaction logic for Orders.xaml
    /// </summary>
    public partial class Orders : Window
    {
        public Orders()
        {
            InitializeComponent();
        }

        private void CustomComboEdit_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;
            //MouseWheelEventArgs args = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
            //args.RoutedEvent = UIElement.MouseWheelEvent;
            //args.Source = sender;
            
        }
    }
}
