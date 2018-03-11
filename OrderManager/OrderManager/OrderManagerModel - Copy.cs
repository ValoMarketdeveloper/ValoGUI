using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonData;
using CommonTools;
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Configuration;

namespace OrderManager
{
    public class OrderManagerModel
    {
        private UpdaterModel updaterModel = null;

        private MySqlConnection conn;
        private OrderManagerModel() { }


        public event EventHandler<string> OrderUpdateSuccess;
        public event EventHandler<string> OrderUpdateFailed;

        public OrderManagerModel(string server, string uid, string pwd, string db)
        {
            StringBuilder sb = new StringBuilder("server=");
            sb.Append(server);
            sb.Append(";uid=");
            sb.Append(uid);
            sb.Append(";pwd=");
            sb.Append(pwd);
            sb.Append(";database=");
            sb.Append(db);
            sb.Append(";");

            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ProjectConfigSection configSection = config.GetSection("ShippingCarriers") as ProjectConfigSection;

            if (configSection == null)
            {
                StaticLogger.LogError("Failed to load ConfigSection.");
            }
            else
            {
                foreach (ProjectConfigElement elem in configSection.Configs)
                {
                    ShipCarriers.Add(new CarrierInfo() { Name = elem.Name, Display = elem.Display });
                }
            }

            try
            {
                StaticLogger.LogInfo("Connectig to the database, connection string: " + sb.ToString());
                conn = new MySqlConnection(sb.ToString());
                conn.Open();
                updaterModel = new UpdaterModel(conn);
                LoadDistributors();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                switch (ex.Number)
                {
                    case 0:
                        StaticLogger.LogError("Cannot connect to server.  Contact administrator");
                        break;
                    case 1045:
                        StaticLogger.LogError("Invalid username/password, please try again");
                        break;
                }
            }
        }

        public string[] StringStates = { "Open", "Export", "Archive", "ShipReady", "Shipped", "Service", "OnHold", "ASAP", "Cancelled",
            "Reorders" };

        //public string[] ShipCarriers = { "FedEx", "USPS" };
        public List<CarrierInfo> ShipCarriers = new List<CarrierInfo>();

        System.Configuration.Configuration config = null;

        public ObservableCollection<DistributorData> DistributorList { get; set; }

        public UpdaterModel UpdaterModel
        {
            get { return updaterModel; }
        }

        void LoadDistributors()
        {
            MySqlDataReader reader = null;
            DistributorList = new ObservableCollection<DistributorData>();
            try
            {
              //  StaticLogger.LogInfo("GetOrderByState");
                string query = "select Name,DistributorID from distributors where Active = 1 order by DistributorID";
                DistributorData d = new DistributorData() { DistributorName = string.Empty, DistributorID = 0 };
                DistributorList.Add(d);
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DistributorData dd = new DistributorData();
                            dd.DistributorName = reader.GetString(0);
                            dd.DistributorID = reader.GetInt32(1);
                            DistributorList.Add(dd);
                        }
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                StaticLogger.LogException(ex);
            }
            catch (Exception e)
            {
                StaticLogger.LogException(e);
            }
        }

            OrderInfo CreateOrderInfo(MySqlDataReader reader)
        {
            OrderInfo rt = new OrderInfo()
            {
                Currency = reader.GetString(15),
                DistributorID = reader.GetInt16(16),
                MarketPlaceProdID = reader.GetString(17),
                Notes = reader.IsDBNull(18) ? string.Empty : reader.GetString(18),
                OrderItemID = reader.GetString(19),
                OrderStatus = reader.GetInt16(20),
                OrderTime = reader.GetDateTime(21).ToShortDateString(),
                Price = reader.GetDouble(22),
                PromissedDay = reader.GetDateTime(23).ToShortDateString(),
                Qty = reader.GetInt16(24),
                ShipPrice = reader.GetDouble(25),
                ShipTax = reader.GetDouble(26),
                SKU = reader.GetString(27),
                TrackingNumber = reader.IsDBNull(28) ? string.Empty : reader.GetString(28),
                ASIN = reader.GetString(29),
                MarketPlaceID = reader.GetInt16(9),
                Title = reader.IsDBNull(30) ? string.Empty : reader.GetString(30),
                UPC = reader.GetString(33),
                DistProdID = reader.IsDBNull(34) ? "" : reader.GetString(34),
                DistPrice = reader.IsDBNull(35) ? 0 : reader.GetDouble(35),
                DistUOM = reader.IsDBNull(36) ? 0 : reader.GetInt32(36),
                MPUOM = reader.IsDBNull(37) ? 0 : reader.GetInt32(37),
                ProcessingTime = reader.IsDBNull(38) ? DateTime.Now.ToString("MM/dd") : reader.GetDateTime(38).ToString("MM/dd"),
                MPNotes = reader.IsDBNull(39) ? string.Empty : reader.GetString(39),
                MasterQty = reader.IsDBNull(40) ? 0 : reader.GetInt32(40),
                OrderItems = reader.IsDBNull(41) ? 0 : reader.GetInt32(41),
                SKUVerified = reader.IsDBNull(43) ? false : reader.GetInt32(43) == 0 ? false : true,
                IsFood = reader.IsDBNull(45) ? false : reader.GetInt32(45) == 0 ? false : true
            };
            if (string.IsNullOrEmpty(rt.Title))
            {
                rt.Title = reader.IsDBNull(44) ? string.Empty : reader.GetString(44);
            }
            return rt;
        }

        public void PrepareForShipping(OrderData ord)
        {
            try
            {
                if(ord != null && ord.OrdInfo != null && !string.IsNullOrEmpty(ord.OrdInfo.UPC))
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = string.Format("delete from ship_order where UPC = '{0}'",
                        ord.OrdInfo.UPC);
                    int numRowsUpdated = cmd.ExecuteNonQuery();
                }
                var orders = GetOrdersByState((int)OrderStates.Archive, string.Empty).ToList();
                orders.AddRange(GetOrdersByState((int)OrderStates.ShipReady, string.Empty).ToList());
                if (ord.OrdInfo.OrderStatus == (int)OrderStates.Archive || ord.OrdInfo.OrderStatus == (int)OrderStates.ShipReady)
                {
                    if (orders.Where(o => o.OrdInfo.OrderID == ord.OrdInfo.OrderID && o.OrdInfo.UPC == o.OrdInfo.UPC).FirstOrDefault() 
                        == null)
                    {
                        orders.Add(ord);
                    }
                }

                var upcList = orders.Where(o => o.OrdInfo.UPC == ord.OrdInfo.UPC).OrderBy(o => Convert.ToDateTime(o.OrdInfo.PromissedDay))
                    .ThenBy(o => Convert.ToDateTime(o.OrdInfo.OrderTime)).ThenBy(o => o.OrdInfo.Qty).ToList();


                using (MySqlCommand cmd = new MySqlCommand())
                {
                    int count = 0;
                    cmd.Connection = conn;
                    cmd.CommandText = "insert into ship_order (UPC, OrderID, ShipOrder, ShippingService) values (@upc, @id, @order, @service)";
                    cmd.Parameters.Add("@upc", MySqlDbType.VarChar);
                    cmd.Parameters.Add("@id", MySqlDbType.VarChar);
                    cmd.Parameters.Add("@order", MySqlDbType.UInt32);
                    cmd.Parameters.Add("@service", MySqlDbType.VarChar);
                    foreach (var order in upcList)
                    {
                        string service = "International";
                        int len = 13;
                        if (order.CustInfo.Country.Length < 13)
                            len = order.CustInfo.Country.Length;

                        if (order.CustInfo.Country.ToUpper().Substring(0,len).Equals(("UNITED STATES")))
                            service = "Standard";

                        if (order.CustInfo.Country.Length > 1)
                        {
                            if (order.CustInfo.Country.ToUpper().Substring(0, 2).Equals(("US")))
                                service = "Standard";
                        }
                        if (order.CustInfo.Country.Length > 2)
                        {
                            if (order.CustInfo.Country.ToUpper().Substring(0, 3).Equals(("U.S")))
                                service = "Standard";
                        }

                        cmd.Parameters[0].Value = order.OrdInfo.UPC;
                        cmd.Parameters[1].Value = order.OrdInfo.OrderID;
                        cmd.Parameters[2].Value = count++;
                        cmd.Parameters[3].Value = service;
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                StaticLogger.LogException(ex);
            }
            catch (Exception e)
            {
                StaticLogger.LogException(e);
            }
        }

        int records_per_page = 50;
        //public ObservableCollection<OrderData> GetOrdersByState(int orderState, string search)
        public ObservableCollection<OrderData>[] GetOrdersByState(int orderState, string search)
        {
            //StaticLogger.LogInfo("Started: " + DateTime.Now.ToString());
            Dictionary<string, List<OrderData>> SkuOrder = new Dictionary<string, List<OrderData>>();

            ObservableCollection<OrderData> data = new ObservableCollection<OrderData>();
            Dictionary<string, List<OrderInfo>> orderItems = new Dictionary<string, List<OrderInfo>>();

            MySqlDataReader reader = null;
            try
            {
                StringBuilder sb = new StringBuilder("select c.OrderID, c.Address1, c.Address2, c.Address3, c.BuyerPhone, c.City, c.Country, c.Email, c.InsertionTime, ");
                sb.Append("c.MarketPlaceID, c.Name, c.ShipPhone, c.ShipServiceLevel, c.State, c.ZipCode, ");
                sb.Append("o.Currency, o.DistributorID, o.MarketPlaceProdID, o.Notes, o.OrderItemID, o.OrderStatus, ");
                sb.Append("o.OrderTime, o.Price, o.PromissedDay, o.Qty, o.ShipPrice, o.ShipTax, o.SKU, o.TrackingNumber, p.ASIN, o.Title, ");
                sb.Append("p.ImageURL, m.Name, p.UPC, o.DistributorProductID, o.DistributorPrice, o.DistributorUOM, o.MPUOM, ");
                sb.Append("o.ProcessingTime, o.MPNotes, o.MasterQty, o.OrderItems, o.ShippingCarrier, md.Verified, p.Title as PTitle, md.IsFood ");
                sb.Append("from customer_info c, order_info o, products p, marketplaces m, marketplace_data md ");
                sb.Append("where c.OrderID = o.OrderID and c.MarketPlaceID = o.MarketPlaceID and ");
                sb.Append("o.SKU = p.SKU and c.MarketPlaceID = m.MarketPlaceID and md.MarketPlaceID = c.MarketPlaceID and md.SKU = o.SKU and ");
                if(!string.IsNullOrEmpty(search))
                {
                    sb.Append(search);
                }
                else
                {
                    sb.Append("o.OrderStatus = @ostatus ");
                }
                sb.Append("order by o.OrderTime desc, o.PromissedDay, o.OrderID, o.MarketPlaceID");
                string query = sb.ToString();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (string.IsNullOrEmpty(search))
                    {
                        cmd.Parameters.Add("@ostatus", MySqlDbType.Int32);
                        cmd.Parameters[0].Value = orderState;
                    }
                    using (reader = cmd.ExecuteReader())
                    {
                        string currentOrderID = string.Empty;
                        CustomerInfo custInfo = null;
                        OrderData orderData = null;

                        List<OrderInfo> tmp = null;
                      //  StaticLogger.LogInfo("Command Executed: " + DateTime.Now.ToString());
                        while (reader.Read())
                        {
                            string OrderID = reader.GetString(0);
                            if (currentOrderID != OrderID)
                            {
                                currentOrderID = OrderID;
                                custInfo = new CustomerInfo()
                                {
                                    OrderID = OrderID,
                                    Address1 = reader.GetString(1),
                                    Address2 = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                    Address3 = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                    BuyerPhone = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                    City = reader.GetString(5),
                                    Country = reader.GetString(6),
                                    Email = reader.GetString(7),
                                    InsertionTime = reader.GetDateTime(8).ToShortDateString(),
                                    MarketPlaceID = reader.GetInt16(9),
                                    Name = reader.GetString(10),
                                    ShipPhone = reader.IsDBNull(11) ? "" : reader.GetString(11),
                                    ShipServiceLevel = reader.GetString(12),
                                    State = reader.IsDBNull(13) ? "" : reader.GetString(13),
                                    ZipCode = reader.IsDBNull(14) ? "" : reader.GetString(14)
                                };
                                orderData = new OrderData() { CustInfo = custInfo };
                                data.Add(orderData);
                                var oi = CreateOrderInfo(reader);
                                oi.OrderID = OrderID;
                                oi.DBOrderItems = oi.OrderItems > 1;

                                var carrier = reader.IsDBNull(42) ? string.Empty : reader.GetString(42);
                                var ci = ShipCarriers.Where(c => c.Name.Equals(carrier)).FirstOrDefault();
                                if (ci != null)
                                    oi.ShippingCarrier = ci;

                                if (oi.DBOrderItems == false)
                                {
                                    if (!orderItems.TryGetValue(OrderID, out tmp))
                                    {
                                        tmp = new List<OrderInfo>();
                                        orderItems.Add(OrderID, tmp);
                                    }
                                    oi.OrderItems = tmp.Count;
                                    tmp.Add(oi);
                                }

                                orderData.OrdInfo = oi;
                                oi.DistributorName = DistributorList.Where(d => d.DistributorID == oi.DistributorID).First().DistributorName;
                                orderData.Ordered = oi.OrderTime;
                                orderData.ShipBy = oi.PromissedDay;
                                orderData.MarketPlaceName = reader.GetString(32);
                                orderData.Details =  new OrderDetails() { Qty = oi.Qty,
                                    Title = reader.IsDBNull(30) ? string.Empty : reader.GetString(30), Picture = reader.IsDBNull(31) ? string.Empty : reader.GetString(31), SKU = oi.SKU, ASIN = reader.GetString(29),
                                UPC = reader.GetString(33), SKUVerified = oi.SKUVerified };
                                if(string.IsNullOrEmpty(orderData.Details.Title))
                                {
                                    orderData.Details.Title = reader.IsDBNull(44) ? string.Empty : reader.GetString(44);
                                }
                            }
                            else
                            {
                                orderData = new OrderData() { CustInfo = custInfo };
                                orderData.MultipleItems = true;
                                data.Add(orderData);
                                var oi = CreateOrderInfo(reader);
                                oi.OrderID = OrderID;
                                oi.DBOrderItems = oi.OrderItems > 1;

                                var carrier = reader.IsDBNull(42) ? string.Empty : reader.GetString(42);
                                var ci = ShipCarriers.Where(c => c.Name.Equals(carrier)).FirstOrDefault();
                                if (ci != null)
                                    oi.ShippingCarrier = ci;

                                if (oi.DBOrderItems == false)
                                {
                                    if (!orderItems.TryGetValue(OrderID, out tmp))
                                    {
                                        tmp = new List<OrderInfo>();
                                    }
                                    tmp.Add(oi);
                                    int ct = tmp.Count;
                                    
                                    tmp.ForEach(o =>
                                    {
                                        o.OrderItems = ct;
                                    });
                                }

                                oi.DistributorName = DistributorList.Where(d => d.DistributorID == oi.DistributorID).First().DistributorName;
                                orderData.OrdInfo = oi;
                                orderData.Ordered = oi.OrderTime;
                                orderData.ShipBy = oi.PromissedDay;
                                orderData.MarketPlaceName = reader.GetString(32);
                                orderData.Details = new OrderDetails() { Qty = oi.Qty,
                                    Title = reader.IsDBNull(30) ? string.Empty : reader.GetString(30), Picture = reader.GetString(31), SKU = oi.SKU, ASIN = reader.GetString(29),
                                UPC = reader.GetString(33), SKUVerified = oi.SKUVerified };
                                if (string.IsNullOrEmpty(orderData.Details.Title))
                                {
                                    orderData.Details.Title = reader.IsDBNull(44) ? string.Empty : reader.GetString(44);
                                }
                            }
                        }
                    }
                }
            }
            catch(System.Data.SqlTypes.SqlNullValueException en)
            {
                StaticLogger.LogException(en);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                StaticLogger.LogException(ex);
            }
            catch(Exception e)
            {
                StaticLogger.LogException(e);
            }

            Dictionary<string, List<DistributorOrderData>> ddo = new Dictionary<string, List<DistributorOrderData>>();
            if (!string.IsNullOrEmpty(search))
            {
                foreach (var ood in data)
                {
                    StaticLogger.LogInfo("Getting distributors: " + DateTime.Now.ToString());
                    var d = GetDistributorsOrders(orderState, ood.OrdInfo.SKU);
                    d.Keys.ToList().ForEach(l =>
                    {
                        if (!ddo.ContainsKey(l))
                        {
                            ddo.Add(l, d[l]);
                        }
                    });
                }
            }
            else
            {
                ddo = GetDistributorsOrders(orderState, string.Empty);
            }

            //StaticLogger.LogInfo("Processing distributors: " + DateTime.Now.ToString());
            foreach (var od in data)
            {
                List<DistributorOrderData> dodList = null;
                if(ddo.TryGetValue(od.OrdInfo.SKU, out dodList))
                {
                    dodList.ForEach(d => d.PropertyChanged += od.Details.ChangeDistributor);
                    od.Details.ListDistributors = new List<DistributorOrderData>(dodList);
                    dodList.ForEach(dd =>
                    {
                        if(od.OrdInfo.DistPrice == 0)
                        {
                            od.OrdInfo.DistPrice = dd.Price;
                        }
                        else if(orderState == (int)OrderStates.Open)
                        {
                            if (od.OrdInfo.DistPrice > dd.Price && dd.Qty > 0)
                                od.OrdInfo.DistPrice = dd.Price;
                        }
                    });
                }
            }

            //StaticLogger.LogInfo("Finished: " + DateTime.Now.ToString());

            int num_pages = data.Count / records_per_page;
            int rm = data.Count % records_per_page;
            if (num_pages == 0 || rm > 0)
                num_pages += 1;

            ObservableCollection<OrderData>[] rt = new ObservableCollection<OrderData>[num_pages];
            int count = 0;
            int page_index = -1;
            foreach(var record in data)
            {
                if (count == 0 || count == records_per_page)
                {
                    page_index++;
                    rt[page_index] = new ObservableCollection<OrderData>();
                    count = (count == records_per_page) ? 0 : count;
                }
                count++;
                rt[page_index].Add(record);
            }
            
            return rt;
        }

        private Dictionary<string, List<DistributorOrderData>> GetDistributorsOrders(int orderState, string osku)
        {
            Dictionary<string, List<DistributorOrderData>> rt = new Dictionary<string, List<DistributorOrderData>>();

            MySqlDataReader reader = null;
            try
            {
                StringBuilder sb = new StringBuilder("select o.OrderID, o.SKU, d.DistributorID, d.Name, a.Price, a.Qty, dd.UPC, ");
                sb.Append("dd.DistributorProductID, dd.Title, dd.Description, dd.UOM, dd.Weight, dd.Size, dd.Brand, md.UOM, md.Notes ");
                sb.Append("from order_info o, products p, available_products a, distributors d, distributor_data dd, marketplace_data md ");
                sb.Append("where o.SKU = p.SKU and p.UPC = a.UPC and d.DistributorID = a.DistributorID and ");
                sb.Append("dd.UPC = p.UPC and dd.DistributorID = d.DistributorID and o.SKU = md.SKU and ");
                if(string.IsNullOrEmpty(osku))
                {
                    sb.Append("o.OrderStatus = @ostatus ");
                }
                else
                {
                    sb.Append("o.SKU = @sku ");
                }
                sb.Append("order by o.SKU, a.Price, a.Qty");
                string query = sb.ToString();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    string currentOrderID = string.Empty;
                    string currentSKU = string.Empty;
                    List<DistributorOrderData> list = null;
                    if (string.IsNullOrEmpty(osku))
                    {
                        cmd.Parameters.Add("@ostatus", MySqlDbType.Int32);
                        cmd.Parameters[0].Value = orderState;
                    }
                    else
                    {
                        cmd.Parameters.Add("@sku", MySqlDbType.VarChar);
                        cmd.Parameters[0].Value = osku;
                    }
                    using (reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string orderID = reader.GetString(0);
                            string sku = reader.GetString(1);
                            int id = reader.GetInt32(2);
                            if (currentSKU != sku)
                            {
                                currentOrderID = orderID;
                                currentSKU = sku;
                                
                                if (!rt.ContainsKey(sku))
                                {
                                    list = new List<DistributorOrderData>();
                                    rt.Add(sku, list);
                                }
                                else
                                {
                                    list = rt[sku];
                                }
                                bool existed = false;
                                foreach (var d in list)
                                {
                                    if (d.ID == id)
                                    {
                                        existed = true;
                                        break;
                                    }
                                }
                                if (existed == true)
                                    continue;
                                DistributorOrderData dd = new DistributorOrderData()
                                {
                                    SKU = sku,
                                    ID = id,
                                    Name = reader.GetString(3),
                                    Price = reader.GetDouble(4),
                                    Qty = reader.GetInt32(5),
                                    UPC = reader.GetString(6),
                                    DistributorProductID = reader.GetString(7),
                                    Title = reader.GetString(8),
                                    Description = reader.GetString(9),
                                    UOM = reader.GetInt32(10),
                                    Weight = reader.GetDouble(11),
                                    Size = reader.GetString(12),
                                    Brand = reader.GetString(13),
                                    MPUOM = reader.GetInt32(14),
                                    MPNotes = reader.IsDBNull(15) ? string.Empty : reader.GetString(15)
                                };
                                list.Add(dd);
                            }
                            else
                            {
                                list = rt[sku];
                                id = reader.GetInt32(2);
                                bool existed = false;
                                foreach(var d in list)
                                {
                                    if (d.ID == id)
                                    {
                                        existed = true;
                                        break;
                                    }
                                }
                                if (existed == true)
                                    continue;
                                DistributorOrderData dd = new DistributorOrderData()
                                {
                                    SKU = sku,
                                    ID = id,
                                    Name = reader.GetString(3),
                                    Price = reader.GetDouble(4),
                                    Qty = reader.GetInt32(5),
                                    UPC = reader.GetString(6),
                                    DistributorProductID = reader.GetString(7),
                                    Title = reader.GetString(8),
                                    Description = reader.GetString(9),
                                    UOM = reader.GetInt32(10),
                                    Weight = reader.GetDouble(11),
                                    Size = reader.GetString(12),
                                    Brand = reader.GetString(13),
                                    MPUOM = reader.GetInt32(14),
                                    MPNotes = reader.IsDBNull(15) ? string.Empty : reader.GetString(15)
                                };
                                if (!list.Contains(dd))
                                {
                                    list.Add(dd);
                                }
                            }
                        }
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                StaticLogger.LogException(ex);
            }
            catch(Exception e)
            {
                StaticLogger.LogError("Exception GetDistributorsOrders");
                StaticLogger.LogException(e);
            }

            return rt;
        }

        public void AssignDistribtors(List<OrderData> orders, int status, DistributorData distData = null)
        {
            if (status < 0)
                return;
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = conn;
                orders.ForEach(o =>
                {
                    if (!(o.Selected == null && distData == null))
                    {
                        string sql = string.Format("Update order_info set OrderStatus={0}, DistributorID={1}, " +
                            "DistributorProductID='{2}', DistributorPrice={3}, DistributorUOM={4}, MPUOM={5}, ProcessingTime='{6}', " +
                            "MPNotes='{10}' where MarketPlaceID={7} and OrderID='{8}' and SKU='{9}'",
                            status, o.Selected != null ? o.Selected.ID : distData.DistributorID, o.Selected != null ? 
                            o.Selected.DistributorProductID : o.OrdInfo.DistProdID, o.Selected != null ? o.Selected.Price : 
                            o.OrdInfo.DistPrice, status == (int)OrderStates.Archive ? o.OrdInfo.DistUOM : o.Selected.UOM, 
                            status == (int)OrderStates.Archive ? o.OrdInfo.MPUOM : o.Selected.MPUOM, 
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), o.CustInfo.MarketPlaceID, o.CustInfo.OrderID, o.Details.SKU,
                            status == (int)OrderStates.Archive ? o.OrdInfo.Notes : o.Selected.MPNotes);
                        try
                        {
                            StaticLogger.LogInfo("AssignDistributor: " + sql);
                            cmd.CommandText = sql;
                            int numRowsUpdated = cmd.ExecuteNonQuery();

                            if(o.OrdInfo.DBOrderItems == false && o.OrdInfo.OrderItems > 1)
                            {
                                cmd.CommandText = string.Format("Update order_info set OrderItems={0} where OrderID='{1}' and MarketPlaceID={2}",
                                    o.OrdInfo.OrderItems, o.OrdInfo.OrderID, o.OrdInfo.MarketPlaceID);
                                numRowsUpdated = cmd.ExecuteNonQuery();
                            }

                            if(o.OrdInfo.IsFoodChanged == true)
                            {
                                cmd.CommandText = string.Format("Update marketplace_data md, products p set IsFood={0} where p.SKU = md.SKU and p.UPC='{1}'",
                                    o.OrdInfo.IsFood == true ? 1 : 0, o.OrdInfo.UPC);
                                numRowsUpdated = cmd.ExecuteNonQuery();
                            }
                        }
                        catch (MySql.Data.MySqlClient.MySqlException ex)
                        {
                            StaticLogger.LogException(ex);
                        }
                    }
                });
            }
        }

        public void UpdateOrder(OrderData order, string field)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = conn;
                StringBuilder toSet = new StringBuilder();
                switch(field)
                {
                    case "TrackingNumber":
                        toSet.Append("TrackingNumber='").Append(order.OrdInfo.TrackingNumber).Append("', ");
                        toSet.Append("ShippingCarrier='").Append(order.OrdInfo.ShippingCarrier.Name).Append("', ");
                        toSet.Append("OrderStatus=4").Append(", UploadState=null");
                        break;

                    case "Notes":
                        toSet.Append("Notes='").Append(order.OrdInfo.Notes).Append("'");
                        break;

                    case "SelectedStatus":
                        int num = 0;
                        for(int i = 0; i < StringStates.Length; i++)
                        {
                            if(StringStates[i].Equals(order.SelectedStatus))
                            {
                                num = i;
                                order.OrdInfo.OrderStatus = num;
                                break;
                            }
                        }
                        
                        toSet.Append("OrderStatus=").Append(num);
                        break;

                    case "MasterQty":
                        toSet.Append("MasterQty=").Append(order.OrdInfo.MasterQty);
                        toSet.Append(", ShipQty=").Append(order.OrdInfo.MasterQty == 0 ? order.OrdInfo.Qty : order.OrdInfo.MasterQty);
                        break;
                    case "Title":
                        toSet.Append("Title='").Append(order.OrdInfo.Title).Append("' ");
                        break;
                    default:
                        return;
                }
                string sql = string.Format("Update order_info set {0} where MarketPlaceID={1} and OrderID='{2}' and SKU='{3}'",
                    toSet, order.OrdInfo.MarketPlaceID, order.OrdInfo.OrderID, order.OrdInfo.SKU);
                try
                {
                    cmd.CommandText = sql;
                    int numRowsUpdated = cmd.ExecuteNonQuery();
                    if (OrderUpdateSuccess != null && OrderUpdateFailed != null)
                    {
                        if (numRowsUpdated > 0)
                        {
                            OrderUpdateSuccess(this, field);
                        }
                        else
                        {
                            OrderUpdateFailed(this, field);
                        }
                    }
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    StaticLogger.LogException(ex);
                    if (OrderUpdateFailed != null)
                        OrderUpdateFailed(this, field);
                    return;
                }
                catch (Exception e)
                {
                    StaticLogger.LogException(e);
                    if (OrderUpdateFailed != null)
                        OrderUpdateFailed(this, field);
                    return;
                }
            }
            
            PrepareForShipping(order);
        }

        public void UpdateShippingAddress(CustomerInfo info)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = conn;
                StringBuilder sb = new StringBuilder(string.Empty);
                if (!string.IsNullOrEmpty(info.Phone))
                    sb.Append(", ShipPhone='").Append(info.Phone).Append("'");
                string sql = string.Format("update customer_info set Name='{0}', Address1='{1}', Address2='{2}', Address3='{3}', " +
                    "City='{4}', State='{5}', Country='{6}', ZipCode='{7}'{8} where MarketPlaceID='{9}' and OrderID='{10}'",
                    info.Name, info.Address1, info.Address2, info.Address3, info.City, info.State, info.Country, info.ZipCode, sb,
                    info.MarketPlaceID, info.OrderID);

                try
                {
                    cmd.CommandText = sql;
                    int numRowsUpdated = cmd.ExecuteNonQuery();
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    StaticLogger.LogException(ex);
                }
            }
        }

        public void DownlaodDistributorData(ObservableCollection<OrderData> orders, string distributorName)
        {
            try
            {
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                string today = DateTime.Now.ToString("MM.dd.yyyy");
                string baseName = distributorName + "-" + today;
                dlg.FileName = baseName; // Default file name
                dlg.DefaultExt = ".txt"; // Default file extension
                dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

                // Show save file dialog box
                Nullable<bool> result = dlg.ShowDialog();

                // Process save file dialog box results
                string filename = string.Empty;
                if (result == true)
                {
                    // Save document
                    filename = dlg.FileName;
                }

                if (string.IsNullOrEmpty(filename))
                {
                    string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                    string pathDownload = Path.Combine(pathUser, "Downloads");
                    baseName += ".txt";
                    filename = Path.Combine(pathDownload, baseName);
                }
                

                var delimiter = "\t";
                StringBuilder header = new StringBuilder("upc").Append(delimiter).Append("distr_prod_id").Append(delimiter);
                header.Append("title").Append(delimiter).Append("quantity").Append(delimiter).Append("price").Append(delimiter);
                header.Append("dist_UOM").Append(delimiter).Append("mp_UOM").Append(delimiter).Append("Notes").Append(delimiter).Append("Reorder");

                var reorders = orders.Where(od => od.OrdInfo.OrderStatus == (int)OrderStates.Reorders)
                    .ToDictionary(o => o.OrdInfo.UPC, o => o.OrdInfo.OrderID);

                var lst = orders
                    .GroupBy(o => o.OrdInfo.UPC)
                    .Select(og => new 
                    {
                        UPC = og.First().OrdInfo.UPC,
                        DistProdID = og.First().OrdInfo.DistProdID,
                        Title = og.First().OrdInfo.Title,
                        Qty = og.Sum(g => g.OrdInfo.MasterQty > 0 ? g.OrdInfo.MasterQty : g.OrdInfo.Qty),
                        Price = og.Min( g => g.OrdInfo.DistPrice),
                        DistUOM = og.First().OrdInfo.DistUOM,
                        MPUOM = og.First().OrdInfo.MPUOM,
                        MPNotes = og.First().OrdInfo.MPNotes
                    }).ToList();
                using (var sw = new StreamWriter(filename))
                {
                    sw.WriteLine(header);
                    foreach(var od in lst)
                    {
                        string rd = null;
                        reorders.TryGetValue(od.UPC, out rd);
                        string line = string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}", od.UPC, od.DistProdID, od.Title,
                            od.Qty, od.Price, od.DistUOM, od.MPUOM, od.MPNotes, string.IsNullOrEmpty(rd) ? string.Empty : rd);
                        sw.WriteLine(line);
                    }
                }
            }
            catch(Exception e)
            {
                StaticLogger.LogException(e);
            }
        }

        public bool SearchProduct(string upc, out string title, out string uom)
        {
            title = "Product with the UPC: " + upc + " wasn't found in the database";
            uom = "0";
            bool addDD = true;

            MySqlDataReader reader = null;
            MySqlDataReader ddReader = null;
            try
            {
                string query = "select Title from products where UPC=@upc";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@upc", MySqlDbType.String);
                    cmd.Parameters[0].Value = upc;

                    bool found = false;
                    using (reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            title = reader.GetString(0);
                            found = true;
                        }
                    }

                    if (found)
                    {
                        string sql = "select UOM from distributor_data where DistributorID = 1 and UPC=@upc";
                        using (MySqlCommand ddCmd = new MySqlCommand(sql, conn))
                        {
                            ddCmd.Parameters.Add("@upc", MySqlDbType.String);
                            ddCmd.Parameters[0].Value = upc;
                            using (ddReader = ddCmd.ExecuteReader())
                            {
                                if (ddReader.Read())
                                {
                                    uom = ddReader.GetString(0);
                                    addDD = false;
                                }
                            }
                        }
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                StaticLogger.LogException(ex);
            }

            
            return addDD;
        }

        public void AddToCCInventory(string upc, string qty, string price, string uom)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = conn;

                string sql = string.Format("insert into available_products (UPC, DistributorID, Price, Qty) values (" +
                    "'{0}', 1, {1}, {2})", upc, price, qty);

                try
                {
                    cmd.CommandText = sql;
                    int numRowsUpdated = cmd.ExecuteNonQuery();

                    if (!string.IsNullOrEmpty(uom))
                    {
                        sql = string.Format("insert into distributor_data (UPC, DistributorID, UOM, Unpublish) values (" +
                            "'{0}', 1, {1}, 0)", upc, uom);
                        cmd.CommandText = sql;
                        numRowsUpdated = cmd.ExecuteNonQuery();
                    }
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    StaticLogger.LogException(ex);
                }
            }
        }

        public ObservableCollection<DistributorData> GetCCInventory()
        {
            ObservableCollection<DistributorData> rt = new ObservableCollection<DistributorData>();

            string query = "select p.Title, p.ImageURL, p.UPC, a.Qty, a.Price from available_products a, products p where a.UPC = p.UPC and a.DistributorID = 1";
            MySqlDataReader reader = null;

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DistributorData dd = new DistributorData();
                            dd.Title = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                            dd.URL = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                            dd.UPC = reader.GetString(2);
                            dd.Qty = reader.GetInt32(3);
                            dd.Price = reader.GetDouble(4);
                            rt.Add(dd);
                        }
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                StaticLogger.LogException(ex);
            }

            return rt;
        }

        public void UpdateDeleteCCInventory(DistributorData dd, string field)
        {
            string sql = string.Empty;
            switch (field)
            {
                case "Price":
                case "Qty":
                    sql = string.Format("update available_products set {0}={1} where UPC='{2}' and DistributorID=1",
                        field, dd.Price, dd.UPC);
                    break;
                case "Delete":
                    sql = "delete from available_products where DistributorID=1 and UPC='" + dd.UPC + "'";
                    break;
            }

            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    int numRowsUpdated = cmd.ExecuteNonQuery();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                StaticLogger.LogException(ex);
            }
        }

        public void CreateTrackingReport(DateTime from, DateTime to, int marketPlace)
        {
            string query = string.Format("select o.OrderID, o.OrderItemID, o.Qty, o.PromissedDay, o.ShipTime, o.ShippingCarrier, " +
                " o.TrackingNumber, p.UPC, o.OrderStatus, o.UploadState, o.Notes " +
                "from order_info o, products p " +
                "where o.SKU = p.SKU and PromissedDay between '{0}' and '{1}' and MarketPlaceID = {2} " +
                "order by o.PromissedDay, o.ShipTime", 
                from.ToString("s"), to.ToString("s"), marketPlace);

            MySqlDataReader reader = null;
            var delimiter = "\t";
            StringBuilder header = new StringBuilder("OrderID").Append(delimiter).Append("OrderItemID").Append(delimiter);
            header.Append("Qty").Append(delimiter).Append("PromissedDay").Append(delimiter).Append("ShipTime").Append(delimiter);
            header.Append("Carrier").Append(delimiter).Append("TrackingNumber").Append(delimiter).Append("UPC").Append(delimiter);
            header.Append("OrderStatus").Append(delimiter).Append("UploadState").Append(delimiter).Append("OrderNotes");

            string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string pathDownload = Path.Combine(pathUser, "Downloads");
            string fileName = "trackgin_confirmation_report" + ".txt";
            fileName = Path.Combine(pathDownload, fileName);

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            using (var sw = new StreamWriter(fileName))
                            {
                                sw.WriteLine(header.ToString());
                                while (reader.Read())
                                {
                                    string line = string.Format("{0}\t{1}\t" +
                                        "{2}\t{3}\t{4}\t" +
                                        "{5}\t{6}\t{7}\t" +
                                        "{8}\t{9}\t{10}",
                                        reader.GetString(0), reader.GetString(1),
                                        reader.GetInt32(2), reader.GetDateTime(3).ToShortDateString(), reader.IsDBNull(4) ? string.Empty : reader.GetDateTime(4).ToString(),
                                        reader.IsDBNull(5) ? string.Empty : reader.GetString(5), reader.IsDBNull(6) ? string.Empty : reader.GetString(6), reader.GetString(7),
                                        StringStates[reader.GetInt32(8)], reader.IsDBNull(9) ? "Didn't Upload" : "Uploaded", reader.IsDBNull(10) ? string.Empty : reader.GetString(10));

                                    sw.WriteLine(line);
                                }
                            }
                        }
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                StaticLogger.LogException(ex);
            }
        }
    }
}
