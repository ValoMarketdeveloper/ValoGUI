using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonData;
using System.Collections.ObjectModel;
using MySql.Data.MySqlClient;
using System.Data;
using CommonTools;

namespace Updater
{
    public class UpdaterModel
    {

        private MySqlConnection conn;

        private UpdaterModel() { }

        public UpdaterModel(string server, string uid, string pwd, string db)
        {
            // var myConnectionString = "server=127.0.0.1;uid=user1;pwd=user123;database=valo_db;";

            StaticLogger.LogInfo("Connecting");
            StringBuilder sb = new StringBuilder("server=");
            sb.Append(server);
            sb.Append(";uid=");
            sb.Append(uid);
            sb.Append(";pwd=");
            sb.Append(pwd);
            sb.Append(";database=");
            sb.Append(db);
            sb.Append(";");

            try
            {
                conn = new MySqlConnection(sb.ToString());
                conn.Open();
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

        public ObservableCollection<DistributorData> GetDistributorDataByUPC(string upc)
        {
            ObservableCollection<DistributorData> data = new ObservableCollection<DistributorData>();

            MySqlDataReader reader = null;
            try
            {
                string query = "select d.Name, dd.* from distributor_data dd, distributors d where d.DistributorID=dd.DistributorID and UPC=@upc;";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@upc", MySqlDbType.VarChar);
                    cmd.Parameters[0].Value = upc;
                    using (reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DistributorData dd = new DistributorData()
                            {
                                DistributorName = reader.GetString(0),
                                UPC = reader.GetString(1),
                                DistributorID = reader.GetInt32(2),
                                DistributorProductID = reader.GetString(3),
                                Title = reader.GetString(4),
                                Brand = reader.GetString(5),
                                Description = reader.GetString(6),
                                Ingridients = reader.GetString(7),
                                Features = reader.GetString(8),
                                Weight = reader.GetDouble(9),
                                Size = reader.GetString(10),
                                UOM = reader.GetInt32(11),
                                Unpublish = reader.GetBoolean(12)
                            };
                            data.Add(dd);
                        }
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                StaticLogger.LogException(ex);
            }
          
            return data;
        }

        
        public ObservableCollection<MarketplaceData> GetMarketDataByUPC(string upc)
        {
            ObservableCollection<MarketplaceData> data = new ObservableCollection<MarketplaceData>();

            MySqlDataReader reader = null;
            try
            {
                string query = "select m.Name, mp.MarketPlaceID, mp.SKU, mp.Weight, mp.UOM, mp.Unpublish, mp.MAP, mp.Verified, mp.IsFood from products p, marketplace_data mp, marketplaces m where mp.SKU = p.SKU and ";
                query += "m.MarketPlaceID = mp.MarketPlaceID and p.UPC=@upc;";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@upc", MySqlDbType.VarChar);
                    cmd.Parameters[0].Value = upc;
                    using (reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MarketplaceData mp = new MarketplaceData()
                            {
                                MarketPlaceName = reader.GetString(0),
                                MarketPlaceID = reader.GetInt32(1),
                                SKU = reader.GetString(2),
                                Weight = reader.GetDouble(3),
                                UOM = reader.GetInt32(4),
                                Unpublish = reader.GetBoolean(5),
                                MAP = reader.GetDouble(6),
                                Verified = reader.IsDBNull(7) ? false : reader.GetBoolean(7),
                                IsFood = reader.IsDBNull(8) ? false : reader.GetBoolean(8)
                            };
                            data.Add(mp);
                        }
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                StaticLogger.LogException(ex);
            }

            return data;

        }

        public ObservableCollection<MarketplaceData> GetMarketDataByASIN(string asin, out string upc)
        {
            upc = string.Empty;
            ObservableCollection<MarketplaceData> data = new ObservableCollection<MarketplaceData>();

            MySqlDataReader reader = null;
            try
            {
                string query = "select m.Name, mp.MarketPlaceID, mp.SKU, mp.Weight, mp.UOM, mp.Unpublish, mp.MAP, p.UPC, mp.Verified, mp.IsFood from products p, marketplace_data mp, marketplaces m where mp.SKU = p.SKU and ";
                query += "m.MarketPlaceID = mp.MarketPlaceID and p.ASIN=@asin;";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@asin", MySqlDbType.VarChar);
                    cmd.Parameters[0].Value = asin;
                    using (reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MarketplaceData mp = new MarketplaceData()
                            {
                                MarketPlaceName = reader.GetString(0),
                                MarketPlaceID = reader.GetInt32(1),
                                SKU = reader.GetString(2),
                                Weight = reader.GetDouble(3),
                                UOM = reader.GetInt32(4),
                                Unpublish = reader.GetBoolean(5),
                                MAP = reader.GetDouble(6),
                                Verified = reader.IsDBNull(8) ? false : reader.GetBoolean(8),
                                IsFood = reader.IsDBNull(9) ? false : reader.GetBoolean(9)
                            };
                            data.Add(mp);
                            upc = reader.GetString(7);
                        }
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                StaticLogger.LogException(ex);
            }

            return data;

        }

        public ObservableCollection<MarketplaceData> GetMarketDataBySKU(string sku, out string upc)
        {
            upc = string.Empty;
            ObservableCollection<MarketplaceData> data = new ObservableCollection<MarketplaceData>();

            MySqlDataReader reader = null;
            try
            {
                string query = "select m.Name, mp.MarketPlaceID, mp.SKU, mp.Weight, mp.UOM, mp.Unpublish, mp.MAP, p.UPC, mp.Verified, mp.IsFood from products p, marketplace_data mp, marketplaces m where mp.SKU = p.SKU and ";
                query += "m.MarketPlaceID = mp.MarketPlaceID and p.SKU=@sku;";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@sku", MySqlDbType.VarChar);
                    cmd.Parameters[0].Value = sku;
                    using (reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MarketplaceData mp = new MarketplaceData()
                            {
                                MarketPlaceName = reader.GetString(0),
                                MarketPlaceID = reader.GetInt32(1),
                                SKU = reader.GetString(2),
                                Weight = reader.GetDouble(3),
                                UOM = reader.GetInt32(4),
                                Unpublish = reader.GetBoolean(5),
                                MAP = reader.GetDouble(6),
                                Verified = reader.IsDBNull(8) ? false : reader.GetBoolean(8),
                                IsFood = reader.IsDBNull(9) ? false : reader.GetBoolean(9)
                            };
                            data.Add(mp);
                            upc = reader.GetString(7);
                        }
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                StaticLogger.LogException(ex);
            }
            return data;
        }

        public int bulkUpdateMarketplaceData(List<string> skus, string columnName, string updateValue)
        {
            int rt = 0;

            foreach (var sku in skus)
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = conn;

                        cmd.CommandText = string.Format("UPDATE marketplace_data SET {0}={1} Where SKU='{2}' and MarketPlaceID={3}",
                            columnName, updateValue, sku, 1);
                        int numRowsUpdated = cmd.ExecuteNonQuery();
                        rt += numRowsUpdated;
                    }
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    StaticLogger.LogException(ex);
                }
            }

            return rt;
        }

        public void SaveMarketplaceData(MarketplaceData mp)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.CommandText = string.Format("UPDATE marketplace_data SET Weight={0}, UOM={1}, Unpublish={2}, MAP={3}, IsFood={6} Where SKU='{4}' and MarketPlaceID={5}",
                        mp.Weight, mp.UOM, mp.Unpublish == true ? 1 : 0, mp.MAP, mp.SKU, mp.MarketPlaceID, mp.IsFood == true ? 1: 0);
                    int numRowsUpdated = cmd.ExecuteNonQuery();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                StaticLogger.LogException(ex);
            }
        }

        public void SaveDistributorData(DistributorData dd)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.CommandText = string.Format("UPDATE distributor_data SET Weight={0}, Size='{1}', UOM={2}, Unpublish={3} Where UPC='{4}' and DistributorID={5}",
                        dd.Weight, dd.Size, dd.UOM, dd.Unpublish == true ? 1 : 0, dd.UPC, dd.DistributorID);
                    int numRowsUpdated = cmd.ExecuteNonQuery();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                StaticLogger.LogException(ex);
            }
        }
    }
}