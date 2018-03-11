using CommonTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonData
{
    public class CustomerInfo : NotificationObject
    {
        public event Action DataUpdated;

        public CustomerInfo()
        {
            this.PropertyChanged += CustomerInfo_PropertyChanged;
        }

        private void CustomerInfo_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
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

        private string email;
        public string Email
        {
            get { return email; }
            set { SetField<string>(ref email, value); }
        }

        private string buyerPhone;
        public string BuyerPhone
        {
            get { return buyerPhone; }
            set { SetField<string>(ref buyerPhone, value); }
        }

        private string shipServiceLevel;
        public string ShipServiceLevel
        {
            get { return shipServiceLevel; }
            set { SetField<string>(ref shipServiceLevel, value); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { SetField<string>(ref name, value); }
        }

        private string address1;
        public string Address1
        {
            get { return address1; }
            set { SetField<string>(ref address1, value); }
        }

        private string address2;
        public string Address2
        {
            get { return address2; }
            set { SetField<string>(ref address2, value); }
        }

        private string address3;
        public string Address3
        {
            get { return address3; }
            set { SetField<string>(ref address3, value); }
        }

        private string city;
        public string City
        {
            get { return city; }
            set { SetField<string>(ref city, value); }
        }

        private string state;
        public string State
        {
            get { return state; }
            set { SetField<string>(ref state, value); }
        }

        private string zipCode;
        public string ZipCode
        {
            get { return zipCode; }
            set { SetField<string>(ref zipCode, value); }
        }

        private string country;
        public string Country
        {
            get { return country; }
            set { SetField<string>(ref country, value); }
        }

        private string shipPhone;
        public string ShipPhone
        {
            get { return shipPhone; }
            set { SetField<string>(ref shipPhone, value); }
        }

        private string insertionTime;
        public string InsertionTime
        {
            get { return insertionTime; }
            set { SetField<string>(ref insertionTime, value); }
        }

        public string Address4
        {
            get { return City + ", " + State + ", " + ZipCode; }
        }

        private string phone;
        public string Phone
        {
            get
            {
                if (!string.IsNullOrEmpty(phone))
                    return phone;
                if (!string.IsNullOrEmpty(ShipPhone))
                    return ShipPhone;
                return BuyerPhone;
            }
            set { SetField<string>(ref phone, value); }
        }

        public bool International
        {
            get
            {
                bool rt = true;
                int len = 13;
                if (Country.Length < 13)
                    len = Country.Length;

                if (Country.ToUpper().Substring(0, len).Equals(("UNITED STATES")))
                    rt = false;

                if (Country.Length > 1)
                {
                    if (Country.ToUpper().Substring(0, 2).Equals(("US")))
                        rt = false;
                }
                if (Country.Length > 2)
                {
                    if (Country.ToUpper().Substring(0, 3).Equals(("U.S")))
                        rt = false;
                }
                return rt;
            }
        }
    }
}

