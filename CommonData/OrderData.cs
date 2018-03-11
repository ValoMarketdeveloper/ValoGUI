using CommonTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Globalization;

namespace CommonData
{
    public enum OrderStates:int { Open, Export, Archive, ShipReady, Shipped, Service, OnHold, ASAP, Cancelled, Reorders }

    public class OrderState : NotificationObject
    {
        public OrderState(OrderStates state)
        {
            this.state = state;
        }

        private OrderStates state;
        public OrderStates State
        {
            get { return state; }
        }

        public string StateName
        {
            get { return state.ToString(); }
        }
    }

    public class OrderDetails : NotificationObject
    {
        private int qty;
        public int Qty
        {
            get { return qty; }
            set { SetField<int>(ref qty, value); }
        }

        public Brush QtyColor
        {
            get
            {

                Brush rt = null;
                var bc = new BrushConverter();

                if (Qty > 1)
                {
                    rt = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Pink"));
                }
                else
                {
                    rt = new SolidColorBrush((Color)ColorConverter.ConvertFromString("White"));
                }

                return rt;
            }
        }

        private string picture;
        public string Picture
        {
            get { return picture; }
            set { SetField<string>(ref picture, value); }
        }
        private string title;
        public string Title
        {
            get { return title; }
            set { SetField<string>(ref title, value); }
        }

        private string upc;
        public string UPC
        {
            get { return upc; }
            set { SetField<string>(ref upc, value); }
        }

        private string sku;
        public string SKU
        {
            get { return sku; }
            set { SetField<string>(ref sku, value); }
        }

        private string asin;
        public string ASIN
        {
            get { return asin; }
            set { SetField<string>(ref asin, value); }
        }

        private List<DistributorOrderData> listDistributors;
        public List<DistributorOrderData> ListDistributors
        {
            get { return listDistributors; }
            set { SetField<List<DistributorOrderData>>(ref listDistributors, value); }
        }

        public bool SKUVerified { get; set; }

        public Brush IDColor
        {
            get
            {
                if (SKUVerified)
                    return Brushes.LightGreen;

                return Brushes.LightSteelBlue;
            }
        }

        public FontWeight IDFontWeight
        {
            get
            {
                if (SKUVerified)
                    return FontWeights.Bold;

                return FontWeights.Black;
            }
        }

        public void ChangeDistributor(object sender, PropertyChangedEventArgs e)
        {
            ListDistributors.ForEach(d =>
            {
                if (d.Name != ((DistributorOrderData)sender).Name)
                {
                    d.IsSelected = false;
                }
            });
        }

        private RelayCommand<object> cmdProductDetails;
        public RelayCommand<object> CmdProductDetails
        {
            get
            {
                if (cmdProductDetails == null)
                {
                    cmdProductDetails = new RelayCommand<object>((o) =>
                    {
                        System.Diagnostics.Process.Start("https://www.amazon.com/dp/" + ASIN);
                    });
                }
                return cmdProductDetails;
            }
        }
    }

    public class DistributorOrderData : NotificationObject
    {
        public event Action DataUpdated;

        public DistributorOrderData()
        {
            this.PropertyChanged += DistributorOrderData_PropertyChanged;
        }

        private void DistributorOrderData_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

            Updated = true;
            if (DataUpdated != null && e.PropertyName == "IsSelected")
                DataUpdated();
        }

        public bool Updated { get; set; }

        private int id;
        public int ID
        {
            get { return id; }
            set { SetField<int>(ref id, value); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { SetField<string>(ref name, value);  }
        }

        private string sku;
        public string SKU
        {
            get { return sku; }
            set { SetField<string>(ref sku, value); }
        }

        private double price;
        public double Price
        {
            get { return price; }
            set { SetField<double>(ref price, value); }
        }

        private int qty;
        public int Qty
        {
            get { return qty; }
            set { SetField<int>(ref qty, value); }
        }

        private string upc;
        public string UPC
        {
            get { return upc; }
            set { SetField<string>(ref upc, value); }
        }

        private string distributorProductID;
        public string DistributorProductID
        {
            get { return distributorProductID; }
            set { SetField<string>(ref distributorProductID, value); }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { SetField<string>(ref title, value); }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { SetField<string>(ref description, value); }
        }

        private int uom;
        public int UOM
        {
            get { return uom; }
            set { SetField<int>(ref uom, value); }
        }

        private double weight;
        public double Weight
        {
            get { return weight; }
            set { SetField<double>(ref weight, value); }
        }

        private string size;
        public String Size
        {
            get { return size; }
            set { SetField<string>(ref size, value); }
        }

        private string brand;
        public string Brand
        {
            get { return brand; }
            set { SetField<string>(ref brand, value); }
        }

        private int mpUOM;
        public int MPUOM
        {
            get { return mpUOM; }
            set { SetField<int>(ref mpUOM, value); }
        }

        private string mpNotes;
        public string MPNotes
        {
            get { return mpNotes; }
            set { SetField<string>(ref mpNotes, value); }
        }

        private bool isSelected = false;
        public bool IsSelected
        {
            get { return isSelected; }
            set { SetField<bool>(ref isSelected, value); }
        }

        public string ProductInfo
        {
            get
            {
                return Name + " - $" + Price + " (" + Qty + ")";
            }
        }

        public string Vendor
        {
            get
            {
                return "Vendor Name: " + Brand;
            }
        }

        public string ProdID
        {
            get
            {
                return /*"Distributor Product ID: " + */ DistributorProductID;
            }
        }

        public string WeightDesc
        {
            get { return "Weight: " + weight; }
        }

        public string UOMDesc
        {
            get { return "UOM: " + UOM; }
        }

        public string SizeDesc
        {
            get { return "Size: " + size; }
        }
    }

    public class OrderData : NotificationObject
    {
        public event Action<object, string> DataUpdated;
        private Dictionary<int, Uri> marketPlaceImage;

        private void OrderData_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (DataUpdated != null && e.PropertyName == "Updated")
                DataUpdated(this, Updated);
        }

        public OrderData()
        {
            marketPlaceImage = new Dictionary<int, Uri>();
            marketPlaceImage[1] = new Uri("pack://application:,,,/OrderManager;component/Images/AmazonUS.jpg");
            marketPlaceImage[2] = new Uri("pack://application:,,,/OrderManager;component/Images/AmazonCA.jpg");
            marketPlaceImage[3] = new Uri("pack://application:,,,/OrderManager;component/Images/AmazonDE.jpg");
            marketPlaceImage[4] = new Uri("pack://application:,,,/OrderManager;component/Images/AmazonUK.jpg");
            marketPlaceImage[5] = new Uri("pack://application:,,,/OrderManager;component/Images/Ebay.jpg");
            marketPlaceImage[6] = new Uri("pack://application:,,,/OrderManager;component/images/Website.jpg");
            

            DetailsDataColumns = new ObservableCollection<DataGridColumn>()
                {
                    new DataGridTextColumn() { Header = "Qty", Binding = new Binding("Qty"), IsReadOnly = true },
                    new DataGridTextColumn() { Header = "Title", Binding = new Binding("Title"), IsReadOnly = true }
            };

            this.PropertyChanged += OrderData_PropertyChanged;
        }

        private ObservableCollection<DataGridColumn> detailsDataColumns = new ObservableCollection<DataGridColumn>();
        public ObservableCollection<DataGridColumn> DetailsDataColumns
        {
            get { return detailsDataColumns; }
            set { SetField<ObservableCollection<DataGridColumn>>(ref detailsDataColumns, value); }
        }

        private CustomerInfo custInfo;
        public CustomerInfo CustInfo
        {
            get { return custInfo; }
            set { SetField<CustomerInfo>(ref custInfo, value); }
        }

        private OrderInfo ordInfo;
        public OrderInfo OrdInfo
        {
            get { return ordInfo; }
            set { SetField<OrderInfo>(ref ordInfo, value); }
        }

        private OrderDetails details;
        public OrderDetails Details
        {
            get { return details; }
            set { SetField<OrderDetails>(ref details, value); }
        }

        private string ordered;
        public string Ordered
        {
            get { return ordered; }
            set { SetField<string>(ref ordered, value); }
        }

        private string shipBy;
        public string ShipBy
        {
            get { return shipBy; }
            set { SetField<string>(ref shipBy, value); }
        }

        private string marketPlaceName;
        public string MarketPlaceName
        {
            get { return marketPlaceName; }
            set { SetField<string>(ref marketPlaceName, value); }
        }

        public Uri MarketPlaceImage
        {
            get { return marketPlaceImage[OrdInfo.MarketPlaceID]; }
        }

        private bool multipleItems;
        public bool MultipleItems
        {
            get { return multipleItems; }
            set { SetField<bool>(ref multipleItems, value); }
        }

       
        public Brush StatusColor
        {
            get
            {

                Brush rt = null;
                var bc = new BrushConverter();

                if (OrdInfo.OrderStatus == (int)OrderStates.Open)
                {
                    rt = new SolidColorBrush((Color)ColorConverter.ConvertFromString("White"));
                }
                if (OrdInfo.OrderStatus == (int)OrderStates.Export)
                {
                    rt = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Pink"));
                }
                if (OrdInfo.OrderStatus == (int)OrderStates.Archive)
                {
                    rt = (Brush)bc.ConvertFrom("#0857df");
                }
                if (OrdInfo.OrderStatus == (int)OrderStates.ShipReady)
                {
                    rt = (Brush)bc.ConvertFrom("#1cdbd9");
                }
                if (OrdInfo.OrderStatus == (int)OrderStates.Shipped)
                {
                    rt = (Brush)bc.ConvertFrom("#19ff19");
                }
                if (OrdInfo.OrderStatus == (int)OrderStates.Service)
                {
                    rt = (Brush)bc.ConvertFrom("#adadad");
                }
                if (OrdInfo.OrderStatus == (int)OrderStates.OnHold)
                {
                    rt = (Brush)bc.ConvertFrom("#f4f41e");
                }
                if (OrdInfo.OrderStatus == (int)OrderStates.ASAP)
                {
                    rt = (Brush)bc.ConvertFrom("#9e1616");
                }
                if (OrdInfo.OrderStatus == (int)OrderStates.Cancelled)
                {
                    rt = (Brush)bc.ConvertFrom("#ff0606");
                }
                if (OrdInfo.OrderStatus == (int)OrderStates.Reorders)
                {
                    rt = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Orange"));
                }
                return rt;
            }
        }

        private DistributorOrderData selected;
        public DistributorOrderData Selected
        {
            get { return selected; }
            set { SetField<DistributorOrderData>(ref selected, value); }
        }

        
        private ObservableCollection<OrderState> states;
        public ObservableCollection<OrderState> States
        {
            get { return states; }
            set { SetField<ObservableCollection<OrderState>>(ref states, value); }
        }

        public bool SuppressEvent { get; set; }

        private string selectedStatus;
        public string SelectedStatus
        {
            get { return selectedStatus; }
            set
            {
                if (value != null)
                {
                    SetField<string>(ref selectedStatus, value);
                    Updated = "SelectedStatus";
                    OrderData_PropertyChanged(this, new PropertyChangedEventArgs("Updated"));
                }
            }
        }

        private string updated;
        public string Updated
        {
            get { return updated; }
            set { SetField<string>(ref updated, value); }
        }

        private RelayCommand<string> cmdEmail;
        public RelayCommand<string> CmdEmail
        {
            get
            {
                if (cmdEmail == null)
                {
                    cmdEmail = new RelayCommand<string>(o =>
                    {
                        Clipboard.SetText(o);
                    }, o => !string.IsNullOrEmpty(o));
                }
                return cmdEmail;
            }
        }

        private RelayCommand<object> cmdIsFood;
        public RelayCommand<object> CmdIsFood
        {
            get
            {
                if(cmdIsFood == null)
                {
                    cmdIsFood = new RelayCommand<object>(o =>
                   {
                       OrdInfo.IsFoodChanged = true;
                   });
                }
                return cmdIsFood;
            }
        }
    }
}
