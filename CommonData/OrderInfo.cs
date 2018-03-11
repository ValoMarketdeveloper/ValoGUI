using CommonTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonData
{
    public class CarrierInfo
    {
        public string Name { get; set; }
        public string Display { get; set; }
    }

    public class OrderInfo : NotificationObject
    {
        public event Action DataUpdated;

        public OrderInfo()
        {
            this.PropertyChanged += OrderInfo_PropertyChanged;
        }

        private void OrderInfo_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Updated = true;
            if (DataUpdated != null)
                DataUpdated();
        }

        public bool Updated { get; set; }

        private int marketPlaceID;
        public int MarketPlaceID
        {
            get { return marketPlaceID; }
            set { SetField<int>(ref marketPlaceID, value); }
        }

        private string orderID;
        public string OrderID
        {
            get { return orderID; }
            set { SetField<string>(ref orderID, value); }
        }

        private string orderItemID;
        public string OrderItemID
        {
            get { return orderItemID; }
            set { SetField<string>(ref orderItemID, value); }
        }

        private string marketPlaceProdID;
        public string MarketPlaceProdID
        {
            get { return marketPlaceProdID; }
            set { SetField<string>(ref marketPlaceProdID, value); }
        }

        private int distributorID;
        public int DistributorID
        {
            get { return distributorID; }
            set { SetField<int>(ref distributorID, value); }
        }

        private string distributorName;
        public string DistributorName
        {
            get { return distributorName; }
            set { SetField<string>(ref distributorName, value); }
        }

        private string sku;
        public string SKU
        {
            get { return sku; }
            set { SetField<string>(ref sku, value); }
        }

        private string orderTime;
        public string OrderTime
        {
            get { return orderTime; }
            set { SetField<string>(ref orderTime, value); }
        }

        private string insertionTime;
        public string InsertionTime
        {
            get { return insertionTime; }
            set { SetField<string>(ref insertionTime, value); }
        }

        private string promissedDay;
        public string PromissedDay
        {
            get { return promissedDay; }
            set { SetField<string>(ref promissedDay, value); }
        }

        private int orderStatus;
        public int OrderStatus
        {
            get { return orderStatus; }
            set { SetField<int>(ref orderStatus, value); }
        }

        private int qty;
        public int Qty
        {
            get { return qty; }
            set { SetField<int>(ref qty, value); }
        }

        private int masterQty;
        public int MasterQty
        {
            get { return masterQty; }
            set { SetField<int>(ref masterQty, value); }
        }

        private string currency;
        public string Currency
        {
            get { return currency; }
            set { SetField<string>(ref currency, value); }
        }

        private double price;
        public double Price
        {
            get { return price; }
            set { SetField<double>(ref price, value); }
        }

        private double tax;
        public double Tax
        {
            get { return tax; }
            set { SetField<double>(ref tax, value); }
        }

        private double shipPrice;
        public double ShipPrice
        {
            get { return shipPrice; }
            set { SetField<double>(ref shipPrice, value); }
        }

        private double shipTax;
        public double ShipTax
        {
            get { return shipTax; }
            set { SetField<double>(ref shipTax, value); }
        }

        private string notes;
        public string Notes
        {
            get { return notes; }
            set { SetField<string>(ref notes, value); }
        }

        private string trackingNumber;
        public string TrackingNumber
        {
            get { return trackingNumber; }
            set { SetField<string>(ref trackingNumber, value); }
        }

        private CarrierInfo shippingCarrier;
        public CarrierInfo ShippingCarrier
        {
            get { return shippingCarrier; }
            set { SetField<CarrierInfo>(ref shippingCarrier, value); }
        }

        private string shipTime;
        public string ShipTime
        {
            get { return shipTime; }
            set { SetField<string>(ref shipTime, value); }
        }

        private string upc;
        public string UPC
        {
            get { return upc; }
            set { SetField<string>(ref upc, value); }
        }

        private string asin;
        public string ASIN
        {
            get { return asin; }
            set { SetField<string>(ref asin, value); }
        }

        private string distProdID;
        public string DistProdID
        {
            get { return distProdID; }
            set { SetField<string>(ref distProdID, value); }
        }

        private double distPrice;
        public double DistPrice
        {
            get { return distPrice; }
            set { SetField<double>(ref distPrice, value); }
        }

        public string DistPriceDisplay
        {
            get { return DistPrice.ToString("C"); }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { SetField<string>(ref title, value); }
        }

        private int distUOM;
        public int DistUOM
        {
            get { return distUOM; }
            set { SetField<int>(ref distUOM, value); }
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

        private string processingTime;
        public string ProcessingTime
        {
            get { return processingTime; }
            set { SetField<string>(ref processingTime, value); }
        }

        public bool ShowDistributor
        {
            get
            {
                return OrderStatus > 0;
            }
        }

        private int orderItems;
        public int OrderItems
        {
            get { return orderItems; }
            set { SetField<int>(ref orderItems, value); }
        }

        public string OrderItemsTitle
        {
            get { return OrderItems.ToString() + " Items"; }
        }

        public bool ShowOrderItems
        {
            get { return OrderItems > 1; }
        }

        public bool DBOrderItems { get; set; }

        public double ProfitNumber
        {
            get
            {
                var totalPrice = (Price * Qty) + ShipPrice;
                return Math.Round((totalPrice - (totalPrice * 0.15 + DistPrice * Qty)),2);
            }
        }

        public bool Profit
        {
            get
            {
                return ProfitNumber > 0;
            }
        }

        public double TotalPrice
        {
            get { return Qty * Price; }
        }

        public bool SKUVerified { get; set; }

        private bool isFood;
        public bool IsFood
        {
            get { return isFood; }
            set { SetField<bool>(ref isFood, value); }
        }

        public bool IsFoodChanged { get; set; }
    }
}

