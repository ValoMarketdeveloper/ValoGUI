using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonTools;

namespace CommonData
{
    public class DistributorData : NotificationObject
    {
        public event Action DataUpdated;

        public DistributorData()
        {
            this.PropertyChanged += DistributorData_PropertyChanged;
        }

        private void DistributorData_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Updated = true;
            if (DataUpdated != null)
                DataUpdated();
        }

        public bool Updated { get; set; }

        private string upc;
        public string UPC
        {
            get { return upc; }
            set
            {
                SetField<string>(ref upc, value);
            }
        }

        private int distributorID;
        public int DistributorID
        {
            get { return distributorID; }
            set { SetField<int>(ref distributorID, value);  }
        }

        private string distributorName;
        public string DistributorName
        {
            get { return distributorName; }
            set { SetField<string>(ref distributorName, value); }
        }

        private string distributorProductID;
        public string DistributorProductID
        {
            get { return distributorProductID;  }
            set { SetField<string>(ref distributorProductID, value);  }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { SetField<string>(ref title, value);  }
        }

        private string brand;
        public string Brand
        {
            get { return brand; }
            set { SetField<string>(ref brand, value);  }
        }

        private string description;
        public string Description
        {
            get { return description;  }
            set { SetField<string>(ref description, value);  }
        }

        private string ingridients;
        public string Ingridients
        {
            get { return ingridients; }
            set { SetField<string>(ref ingridients, value);  }
        }

        private string features;
        public string Features
        {
            get { return features; }
            set { SetField<string>(ref features, value); }
        }

        private double weight;
        public double Weight
        {
            get { return weight; }
            set { SetField<double>(ref weight, value);  }
        }

        private string size;
        public string Size
        {
            get { return size; }
            set { SetField<string>(ref size, value);  }
        }

        private int uom;
        public int UOM
        {
            get { return uom; }
            set { SetField<int>(ref uom, value);  }
        }

        private bool unpublish;
        public bool Unpublish
        {
            get { return unpublish; }
            set { SetField<bool>(ref unpublish, value);  }
        }
    }
}

//UPC varchar(20) NOT NULL,
//DistributorID  smallint NOT NULL,
//DistributorProductID varchar(20) DEFAULT NULL,
//Title  varchar(300) DEFAULT NULL,
//Brand  varchar(300) DEFAULT NULL,
//Description  varchar(1000) DEFAULT NULL,
//Ingredients  varchar(500) DEFAULT NULL,
//Features  varchar(500) DEFAULT NULL,
//Weight  decimal(6,2) DEFAULT NULL,
//Size  varchar(45) DEFAULT NULL,
//UOM  int(11) NOT NULL,
//Unpublish  tinyint NOT NULL,
//unique key(UPC, DistributorID )

