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

namespace CommonData
{
    public enum OrderStates { All = -1, Open, Export, Archive, ShipReady, Shipped, Service, OnHold, ASAP, Cancelled, Reorders }

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

        private int selected = -1;
        public int Selected
        {
            get { return selected; }
            set { SetField<int>(ref selected, value); }
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

        private bool isSelected = false;
        public bool IsSelected
        {
            get { return isSelected; }
            set { SetField<bool>(ref isSelected, value); }
        }
    }

    public class OrderData : NotificationObject
    {
        public OrderData()
        {
            DetailsDataColumns = new ObservableCollection<DataGridColumn>()
                {
                    new DataGridTextColumn() { Header = "Qty", Binding = new Binding("Qty"), IsReadOnly = true },
                    new DataGridTextColumn() { Header = "Title", Binding = new Binding("Title"), IsReadOnly = true }
            };
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

        private List<OrderInfo> itemsList;
        public List<OrderInfo> ItemsList
        {
            get { return itemsList; }
            set { SetField<List<OrderInfo>>(ref itemsList, value); }
        }

        private List<OrderDetails> detailsList;
        public List<OrderDetails> DetailsList
        {
            get { return detailsList; }
            set { SetField<List<OrderDetails>>(ref detailsList, value); }
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

        private bool multipleItems;
        public bool MultipleItems
        {
            get { return multipleItems; }
            set { SetField<bool>(ref multipleItems, value); }
        }
    }
}
