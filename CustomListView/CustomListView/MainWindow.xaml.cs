using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CustomListView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ObservableCollection<Manufacturer> ManufacturerList = new ObservableCollection<Manufacturer>();

            ManufacturerList.Add(new Manufacturer()
            {
                Company = "DEll",
                Models = new List<Model>(){new Model(){CPU = "T7250", Name = "Inspiron1525", price =234434 , Ram= "2048 MB" },
                                       new Model(){CPU = "T5750", Name = "Studio 1535", price =234443 , Ram= "2048 MB" },
                                       new Model(){CPU = "T5780", Name = "Vastro 1510", price =234434 , Ram= "2048 MB" },}
            });

            ManufacturerList.Add(new Manufacturer()
            {
                Company = "Lenovo",
                Models = new List<Model>(){new Model(){CPU = "T1230", Name = "l123", price =23546454 , Ram= "1024 MB" },
                                      new Model(){CPU = "T1230", Name = "l1423", price =2346456 , Ram= "1024 MB" },
                                      new Model(){CPU = "T1230", Name = "ldf123", price =2344646 , Ram= "1024 MB" },}
            });

            //ManufacturerListBox.ItemsSource = ManufacturerList;
        }
    }
}
