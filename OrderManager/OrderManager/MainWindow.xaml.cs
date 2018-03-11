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
using OrderManager.VM;
using OrderManager.Views;

namespace OrderManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private OrderManagerModel model;

        private MainWindow() {}

        public MainWindow(OrderManagerModel model)
        {
            this.model = model;
            InitializeComponent();
            var orders = new Orders();
            orders.DataContext = new OrdersVM(model);
            orders.Show();
            
        }
    }
}
