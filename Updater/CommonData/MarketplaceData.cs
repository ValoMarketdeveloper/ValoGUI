using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonTools;

namespace CommonData
{
    public class MarketplaceData : NotificationObject
    {
        public event Action DataUpdated;

        public MarketplaceData()
        {
            this.PropertyChanged += MarketplaceData_PropertyChanged;
        }

        private void MarketplaceData_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
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

        private string marketPlaceName;
        public string MarketPlaceName
        {
            get { return marketPlaceName; }
            set { SetField<string>(ref marketPlaceName, value); }
        }

        private string sku;
        public string SKU
        {
            get { return sku; }
            set { SetField<string>(ref sku, value);  }
        }

        private double weight;
        public double Weight
        {
            get { return weight; }
            set { SetField<double>(ref weight, value); }
        }

        private int uom;
        public int UOM
        {
            get { return uom; }
            set { SetField<int>(ref uom, value); }
        }

        private bool unpublish;
        public bool Unpublish
        {
            get { return unpublish; }
            set { SetField<bool>(ref unpublish, value); }
        }

        private double map;
        public double MAP
        {
            get { return map; }
            set { SetField<double>(ref map, value); }
        }

        private bool verified;
        public bool Verified
        {
            get { return verified; }
            set { SetField<bool>(ref verified, value); }
        }

        private bool isFood;
        public bool IsFood
        {
            get { return isFood; }
            set { SetField<bool>(ref isFood, value); }
        }
    }
}

//MarketPlaceID smallint NOT NULL,
//SKU  varchar(20) NOT NULL,
//Weight  decimal(6,2) NOT NULL,
//UOM  int(11) NOT NULL,
//Unpublish  tinyint NOT NULL,
//MAP numeric(7,2) NOT NULL,
//PRIMARY KEY(SKU )
