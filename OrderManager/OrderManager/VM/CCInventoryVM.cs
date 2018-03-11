using CommonData;
using CommonTools;
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

namespace OrderManager.VM
{
    public class CCInventoryVM : NotificationObject
    {
        private OrderManagerModel model;
        private UpdaterVM updaterVM;

        private CCInventoryVM() { }

        public CCInventoryVM(OrderManagerModel model)
        {
            try
            {
                this.model = model;
                updaterVM = new UpdaterVM(model.UpdaterModel);
                PopulateInventory();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void PopulateInventory()
        {
            if(CCInventoryList != null)
            {
                CCInventoryList.ToList().ForEach(i =>
                {
                    i.InventoryUpdated -= InventoryUpdated;
                    i.OpenUpdater -= OpenUpdater;
                });
            }
            CCInventoryList = model.GetCCInventory();
            CCInventoryList.ToList().ForEach(i =>
            {
                i.InventoryUpdated += InventoryUpdated;
                i.OpenUpdater += OpenUpdater;
            });
        }

        private void OpenUpdater(object obj)
        {
            var search = new Views.Updater();
            updaterVM.Search = ((DistributorData)obj).UPC;
            updaterVM.SearchOption = "UPC";
            updaterVM.PerformSearch();
            search.DataContext = updaterVM;
            search.Show();
        }

        private void InventoryUpdated(object arg1, string arg2)
        {
            if(arg2.Equals("Delete"))
            {
                CCInventoryList.Remove((DistributorData)arg1);
            }
            if(arg2.Equals("Qty") || arg2.Equals("Price") || arg2.Equals("Delete"))
                model.UpdateDeleteCCInventory((DistributorData)arg1, arg2);
        }

        private string upc = "Insert Product UPC";
        public string UPC
        {
            get { return upc; }
            set { SetField<string>(ref upc, value); }
        }

        private string price = "Price";
        public string Price
        {
            get { return price; }
            set { SetField<string>(ref price, value); }
        }

        private string qty = "Qty";
        public string Qty
        {
            get { return qty; }
            set { SetField<string>(ref qty, value); }
        }

        private bool add = true;
        private string uom = "UOM";
        public string UOM
        {
            get { return uom; }
            set { SetField<string>(ref uom, value); }
        }

        private string title = "Some Title";
        public string Title
        {
            get { return title; }
            set { SetField<string>(ref title, value); }
        }

        private ObservableCollection<DistributorData> ccInventoryList;
        public ObservableCollection<DistributorData> CCInventoryList
        {
            get { return ccInventoryList; }
            set { SetField<ObservableCollection<DistributorData>>(ref ccInventoryList, value); }
        }

        private RelayCommand<object> cmdSearch;
        public RelayCommand<object> CmdSearch
        {
            get
            {
                if(cmdSearch == null)
                {
                    cmdSearch = new RelayCommand<object>(o =>
                    {
                        if(string.IsNullOrEmpty(UPC))
                        {
                            PopulateInventory();
                            return;
                        }
                        //local search
                        var upc = CCInventoryList.Where(l => l.UPC == UPC).FirstOrDefault();
                        if(upc != null)
                        {
                            CCInventoryList.ToList().ForEach(i =>
                            {
                                i.InventoryUpdated -= InventoryUpdated;
                                i.OpenUpdater -= OpenUpdater;
                            });
                            CCInventoryList.Clear();
                            upc.InventoryUpdated += InventoryUpdated;
                            upc.OpenUpdater += OpenUpdater;
                            CCInventoryList.Add(upc);
                            return;
                        }
                        string ttl = string.Empty;
                        string uom = string.Empty;
                        add = model.SearchProduct(UPC, out ttl, out uom);
                        Title = ttl;
                        if(!add)
                        {
                            UOM = uom;
                        }
                    });
                }
                return cmdSearch;
            }
        }

        private RelayCommand<object> cmdAdd;
        public RelayCommand<object> CmdAdd
        {
            get
            {
                if(cmdAdd == null)
                {
                    cmdAdd = new RelayCommand<object>(o =>
                    {
                        if(o != null)
                        {
                            model.AddToCCInventory(UPC, Qty, Price, add ? UOM : string.Empty);
                            PopulateInventory();
                            UPC = "Insert Product UPC";
                            Price = "Price";
                            Qty = "Qty";
                            UOM = "UOM";
                            Title = string.Empty;
                            var win = o as Views.CCInventory;
                            if(win != null)
                            {
                                win.UPC.GotFocus += win.UPC_GotFocus;
                                win.Price.GotFocus += win.Price_GotFocus;
                                win.Qty.GotFocus += win.Qty_GotFocus;
                                win.UOM.GotFocus += win.UOM_GotFocus;
                            }
                        }
                    });
                }
                return cmdAdd;
            }
        }
    }
}
