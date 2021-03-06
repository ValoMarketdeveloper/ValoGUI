﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonTools;
using CommonData;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows;
using GUITools;

namespace OrderManager.VM
{
    public class OrdersVM : NotificationObject
    {
        private OrderManagerModel model;

        private UpdaterVM updaterVM;

        private OrdersVM() { }

        public OrdersVM(OrderManagerModel model)
        {
            this.model = model;
            model.OrderUpdateSuccess += this.UpdateResultsSuccess;
            model.OrderUpdateFailed += this.UpdateResultsFailed;
            updaterVM = new UpdaterVM(model.UpdaterModel);


            States = new ObservableCollection<OrderState>()
            {
                new OrderState(OrderStates.Open),
                new OrderState(OrderStates.Export),
                new OrderState(OrderStates.Archive),
                new OrderState(OrderStates.ShipReady),
                new OrderState(OrderStates.Shipped),
                new OrderState(OrderStates.Service),
                new OrderState(OrderStates.OnHold),
                new OrderState(OrderStates.ASAP),
                new OrderState(OrderStates.Cancelled),
                new OrderState(OrderStates.Reorders)
            };

            StatesList = new ObservableCollection<string>(model.StringStates);

            MarketList.Add("Amazon US");
            MarketList.Add("Amazon CA");
            MarketList.Add("Amazon UK");
            MarketList.Add("Website");
            MarketList.Add("eBay");

            SelectedState = States[(int)OrderStates.Open];
            this.PropertyChanged += OrdersVM_PropertyChanged;
        }

        private void UpdateResultsSuccess(object sender, string field)
        {
            SelectedMessageType = MessageType.Success;
            FlashMessage = "Updated " + field;
        }

        private void UpdateResultsFailed(object sender, string field)
        {
            SelectedMessageType = MessageType.Error;
            FlashMessage = "Unable to Update " + field;
        }
       
        private void OrdersVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "SelectedState" && !(SelectedState.State == OrderStates.Export || 
                SelectedState.State == OrderStates.Archive))
            {
                if (SelectedDistributor != null && SelectedDistributor.DistributorID != 0)
                {
                    var dist = model.DistributorList.Where(d => d.DistributorID == 0).First();
                    SelectedDistributor = dist;
                }
            }
        }

        public ObservableCollection<DistributorData> DistributorList
        {
            get { return model.DistributorList; }
        }

        private DistributorData selectedDistributorShipBy;
        public DistributorData SelectedDistributorShipBy
        {
            get { return selectedDistributorShipBy; }
            set { SetField<DistributorData>(ref selectedDistributorShipBy, value); }
        }

        private DistributorData selectedDistributor;
        public DistributorData SelectedDistributor
        {
            get { return selectedDistributor; }
            set
            {
                SetField<DistributorData>(ref selectedDistributor, value);
                if (selectedDistributor.DistributorID == 0)
                    ShowDistButtons = false;
                else
                {
                    ShowDistButtons = true;
                    SelectedState = States[(int)OrderStates.Export];
                }
            }
        }

        private bool showDistButtons = false;
        public bool ShowDistButtons
        {
            get { return showDistButtons; }
            set { SetField<bool>(ref showDistButtons, value); }
        }

        private string selectedMarket;
        public string SelectedMarket
        {
            get { return selectedMarket; }
            set { SetField<string>(ref selectedMarket, value); }
        }
        private ObservableCollection<string> marketList = new ObservableCollection<string>();
        public ObservableCollection<string> MarketList
        {
            get { return marketList; }
            set { SetField<ObservableCollection<string>>(ref marketList, value); }
        }

        public List<CarrierInfo> CarrierList
        {
            get { return model.ShipCarriers; }
        }

        private ObservableCollection<string> statesList;
        public ObservableCollection<string> StatesList
        {
            get { return  statesList; }
            set { SetField<ObservableCollection<string>>(ref statesList, value); }
        }

        private ObservableCollection<OrderState> states;
        public ObservableCollection<OrderState> States
        {
            get { return states; }
            set { SetField<ObservableCollection<OrderState>>(ref states, value); }
        }

        private int numOrders;
        public int NumOrders
        {
            get { return numOrders; }
            set
            {
                numOrders = value;
                if (allOrdersArray == null)
                {
                    OrderCount = numOrders.ToString() + "/" + numOrders.ToString();
                }
                else
                {
                    if (CurrentPage == allOrdersArray.Length - 1)
                    {
                        OrderCount = numOrders.ToString() + "/" + numOrders.ToString();
                    }
                    else
                    {
                        OrderCount = ((CurrentPage + 1) * records_per_page).ToString() + "/" + numOrders.ToString();
                    }
                }
            }
        }
        private string orderCount;
        public string OrderCount
        {
            get { return orderCount; }
            set { SetField<string>(ref orderCount, value); }
        }

        private void SetOrderCount()
        {
            int count = 0;
            if (allOrdersArray != null)
            {
                allOrdersArray.ToList().ForEach(page =>
                {
                    if (page != null)
                    {
                        count += page.Count;
                    }
                });
            }
            NumOrders = count;
        }

        private int currentPage = 0;
        public int CurrentPage
        {
            get { return currentPage; }
            set { SetField<int>(ref currentPage, value); }
        }

        private OrderState selectedState;
        public OrderState SelectedState
        {
            get { return selectedState; }
            set
            {
                SetField<OrderState>(ref selectedState, value);
                Search = string.Empty;
                DtShipBy = DateTime.Now;
                SelectedDistributorShipBy = null;
                ShowAll = false;
                switch (selectedState.State)
                {
                    case OrderStates.Open:
                    case OrderStates.Archive:
                    case OrderStates.ShipReady:
                    case OrderStates.Shipped:
                    case OrderStates.Service:
                    case OrderStates.ASAP:
                    case OrderStates.OnHold:
                    case OrderStates.Reorders:
                    case OrderStates.Cancelled:
                        RemoveEvents();
                        PopulateOrders(SelectedDistributor == null ? 0 : SelectedDistributor.DistributorID);
                        break;
                    case OrderStates.Export:
                        
                        PopulateOrders(SelectedDistributor == null ? 0 : SelectedDistributor.DistributorID);
                        if (SelectedDistributor != null && SelectedDistributor.DistributorID != 0)
                        {
                            var tmpOrdersArray = model.GetOrdersByState((int)OrderStates.Reorders, string.Empty);
                            tmpOrdersArray.ToList().ForEach(page =>
                           {
                               if (page != null)
                               {
                                   page.ToList().ForEach(l =>
                                   {
                                       l.Details.ListDistributors.ForEach(d =>
                                       {
                                           if (d.ID == SelectedDistributor.DistributorID)
                                           {
                                               l.OrdInfo.DistPrice = d.Price;
                                               l.OrdInfo.DistProdID = d.ProdID;
                                               l.OrdInfo.DistUOM = d.UOM;
                                               l.OrdInfo.MPUOM = d.MPUOM;
                                               l.SelectedStatus = model.StringStates[l.OrdInfo.OrderStatus];
                                               l.DataUpdated += OrderData_DataUpdated;
                                           }
                                       });
                                   });
                               }
                           });

                            List<OrderData> tmpList = new List<OrderData>();
                            allOrdersArray.ToList().ForEach(page =>
                            {
                                if(page != null)
                                {
                                    page.ToList().ForEach(o =>
                                    {
                                        tmpList.Add(o);
                                    });
                                    page.Clear();
                                }
                            });
                            tmpOrdersArray.ToList().ForEach(page =>
                            {
                                if (page != null)
                                {
                                    page.ToList().ForEach(o =>
                                    {
                                        tmpList.Add(o);
                                    });
                                }
                            });
                            allOrdersArray = CreateAllOrders(tmpList);
                            CurrentPage = 0;
                            OrderDataList = allOrdersArray[CurrentPage];
                            SetOrderCount();
                        }
                        break;

                }
            }
        }

        private void PopulateOrders(int id, StringBuilder sb = null)
        {
            RemoveEvents();

            allOrdersArray = model.GetOrdersByState((int)SelectedState.State, sb == null ? string.Empty : sb.ToString());
           
            if (id == 0)
            {
                OrderDataList = allOrdersArray[CurrentPage];
            }
            else
            {
                List<OrderData> tmp = new List<OrderData>();
                allOrdersArray.ToList().ForEach(page =>
                {
                    if (page != null)
                    {
                        var lst = page.Where(od => od.OrdInfo.DistributorID == id).ToList();
                        if (lst != null && lst.Count > 0)
                        {
                            tmp.AddRange(lst);
                        }
                        page.Clear();
                    }
                });
                allOrdersArray = CreateAllOrders(tmp);
                OrderDataList = allOrdersArray[CurrentPage];
            }

            AddEvents();
        }

        private void RemoveEvents()
        {
            if (allOrdersArray != null)
            {
                allOrdersArray.ToList().ForEach(page =>
                {
                    if (page != null)
                    {
                        page.ToList().ForEach(o =>
                        {
                            o.DataUpdated -= OrderData_DataUpdated;
                        });
                        page.Clear();
                    }
                });
            }
            CurrentPage = 0;
            NumOrders = 0;
        }

        private void AddEvents()
        {
            int count = 0;
            if (allOrdersArray != null)
            {
                allOrdersArray.ToList().ForEach(page =>
                {
                    if (page != null)
                        page.ToList().ForEach(o =>
                        {
                            o.SelectedStatus = model.StringStates[o.OrdInfo.OrderStatus];
                            o.DataUpdated += OrderData_DataUpdated;
                            count++;
                        });
                });
            }
            NumOrders = count;
        }

        private void OrderData_DataUpdated(object sender, string property)
        {
            var data = sender as OrderData;
            if (data.SuppressEvent == false)
            {
                model.UpdateOrder(data, property);
            }
            else
            {
                data.SuppressEvent = false;
            }
            if (shibBySearch == false)
            {
                if (!string.IsNullOrEmpty(Search) && SelectedState == States[(int)OrderStates.Open])
                    return;
            }
            var removals = OrderDataList.Where(od => od.SelectedStatus != SelectedState.StateName).ToList();
            if(removals != null)
            {
                var list = OrdersToList(allOrdersArray);
                removals.ForEach(r => {
                        r.DataUpdated -= OrderData_DataUpdated;
                        list.Remove(r);
                    });
                RemoveEvents();
                allOrdersArray = CreateAllOrders(list);
                AddEvents();
                SetOrderCount();
                OrderDataList = allOrdersArray[CurrentPage];
            }
        }

        private ObservableCollection<OrderData>[] allOrdersArray;
        private ObservableCollection<OrderData> orderDataList;
        public ObservableCollection<OrderData> OrderDataList
        {
            get { return orderDataList; }
            set
            {
                SetField<ObservableCollection<OrderData>>(ref orderDataList, value);
            }
        }

        private MessageType selectedMessageType;
        public MessageType SelectedMessageType
        {
            get { return selectedMessageType; }
            set
            {
                SetField<MessageType>(ref selectedMessageType, value);
            }
        }

        private string flashMessage;
        public string FlashMessage
        {
            get { return flashMessage; }
            set
            {
                SetField<string>(ref flashMessage, value);
            }
        }

        private RelayCommand<object> cmdSave;
        public RelayCommand<object> CmdSave
        {
            get
            {
                if(cmdSave == null)
                {
                    cmdSave = new RelayCommand<object>((o) =>
                    {
                        model.AssignDistribtors(OrderDataList.ToList(), 1 );
                        OrderDataList.Clear();
                        allOrdersArray = model.GetOrdersByState((int)SelectedState.State, string.Empty);
                        
                        if(SelectedDistributor != null && SelectedDistributor.DistributorID > 0)
                        {
                            List<OrderData> filtered = new List<OrderData>();
                            if(allOrdersArray != null)
                            {
                                allOrdersArray.ToList().ForEach(page =>
                                {
                                    if(page != null)
                                    {
                                        filtered.AddRange(page.Where(l => l.OrdInfo.DistributorID == SelectedDistributor.DistributorID).ToList());
                                    }
                                });
                            }
                            allOrdersArray = CreateAllOrders(filtered);
                            AddEvents();
                        }
                        else
                        {
                            OrderDataList = allOrdersArray[currentPage];
                            SetOrderCount();
                        }
                    });
                }
                return cmdSave;
            }
        }

        int records_per_page = 50;
        private ObservableCollection<OrderData>[] CreateAllOrders(List<OrderData> data)
        {
            int num_pages = data.Count / records_per_page;
            int rm = data.Count % records_per_page;
            if (num_pages == 0 || rm > 0)
                num_pages += 1;

            ObservableCollection<OrderData>[] rt = new ObservableCollection<OrderData>[num_pages];
            int count = 0;
            int page_index = -1;
            foreach (var record in data)
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

        private RelayCommand<object> cmdDistributors;
        public RelayCommand<object> CmdDistributors
        {
            get
            {
                if (cmdDistributors == null)
                {
                    cmdDistributors = new RelayCommand<object>(o =>
                    {
                        var window = new Views.DistributorsInfo();
                        window.DataContext = o;
                        window.ShowDialog();
                    });
                }
                return cmdDistributors;
            }
        }

        private RelayCommand<object> cmdTrackingNumber;
        public RelayCommand<object> CmdTrackingNumber
        {
            get
            {
                if(cmdTrackingNumber == null)
                {
                    cmdTrackingNumber = new RelayCommand<object>(oi =>
                    {
                        KeyEventArgs args = oi as KeyEventArgs;
                        if(args != null)
                        {
                            if (args.Key != Key.Enter)
                                return;
                            var ct = args.OriginalSource as Control;
                            var od = ((System.Windows.Controls.TextBox)args.OriginalSource).DataContext as OrderData;
                            if (ct.Name == "TrackingNumber")
                            {
                                
                                if (od.OrdInfo.ShippingCarrier == null)
                                {
                                    MessageBox.Show("Please select Shipping Carrier!", "Tracking Number", MessageBoxButton.OK, MessageBoxImage.Stop);
                                    return;
                                }
                                
                                od.Updated = ct.Name;
                                od.SuppressEvent = true;
                                od.SelectedStatus = "Shipped";
                                od.SuppressEvent = false;
                            }
                            else
                            {
                                od.Updated = ct.Name;
                            }
                        }
                    });
                }
                return cmdTrackingNumber;
            }
        }

        private RelayCommand<object> cmdSearchByID;
        public RelayCommand<object> CmdSearchByID
        {
            get
            {
                if (cmdSearchByID == null)
                {
                    cmdSearchByID = new RelayCommand<object>(oi =>
                    {
                        KeyEventArgs args = oi as KeyEventArgs;
                        if (args != null)
                        {
                            if (args.Key != Key.Enter)
                                return;

                            var ct = args.Source as TextBox;
                            var search = new Views.Updater();
                            updaterVM.Search = ct.Text;
                            updaterVM.SearchOption = ct.Tag as string;
                            updaterVM.PerformSearch();
                            search.DataContext = updaterVM;
                            search.Show();
                        }
                    });
                
                }
                return cmdSearchByID;
            }

        }

        private RelayCommand<object> cmdDownload;
        public RelayCommand<object> CmdDownload
        {
            get
            {
                if(cmdDownload == null)
                {
                    cmdDownload = new RelayCommand<object>(o =>
                    {
                        var ords = new ObservableCollection<OrderData>(OrdersToList(allOrdersArray));
                        model.DownlaodDistributorData(ords, SelectedDistributor.DistributorName);
                    });
                }
                return cmdDownload;
            }
        }

        private bool canArchive = true;
        public bool CanArchive
        {
            get { return canArchive; }
            set { SetField<bool>(ref canArchive, value); }
        }

        private RelayCommand<object> cmdArchive;
        public RelayCommand<object> CmdArchive
        {
            get
            {
                if(cmdArchive == null)
                {
                    cmdArchive = new RelayCommand<object>(o =>
                    {
                        StaticLogger.LogInfo("CmdArchive: Distributor: " + SelectedDistributor.DistributorName + "ID: " + SelectedDistributor.DistributorID);
                        CanArchive = false;
                        
                        allOrdersArray.ToList().ForEach(page =>
                        {
                            model.AssignDistribtors(page.ToList(), (int)States[(int)OrderStates.Archive].State, SelectedDistributor);
                        });

                        RemoveEvents();
                        SelectedState = States[(int)OrderStates.Archive];
        
                        CurrentPage = 0;
                        allOrdersArray = model.GetOrdersByState((int)SelectedState.State, string.Empty);
                        OrderDataList = allOrdersArray[CurrentPage];
                        AddEvents();
                        allOrdersArray.ToList().ForEach(page =>
                        {
                            if(page != null)
                            {
                                page.ToList().ForEach(od =>
                                {
                                    model.PrepareForShipping(od);
                                });
                            }
                        });
                      
                        CanArchive = true;
                    });
                }
                return cmdArchive;
            }
        }

        //private bool localSearch;
        //public bool LocalSearch
        //{
        //    get { return localSearch; }
        //    set { SetField<bool>(ref localSearch, value); }
        //}
        private string search;
        public string Search
        {
            get { return search; }
            set { SetField<string>(ref search, value); }
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
                        KeyEventArgs args = o as KeyEventArgs;
                        if (args != null)
                        {
                            if (args.Key != Key.Enter)
                                return;
                        }

                        ShowAll = false;
                        shibBySearch = false;
                        SelectedDistributorShipBy = null;
                        DtShipBy = DateTime.Now;
                        if (string.IsNullOrEmpty(Search))
                        {
                            PopulateOrders(0);
                            return;
                        }
                        if (SelectedState != States[(int)OrderStates.Open])
                        {
                            performLocalSearch(false);
                        }
                        else
                        {
                            performDBSearch();
                        }
                    });
                }
                return cmdSearch;
            }
        }

        private List<OrderData> OrdersToList(ObservableCollection<OrderData>[] source)
        {
            List<OrderData> rt = new List<OrderData>();
            source.ToList().ForEach(page =>
            {
                if (page != null)
                {
                    page.ToList().ForEach(o =>
                    {
                        rt.Add(o);
                    });
                }
            });
            return rt;
        }

        private void performLocalSearch(bool shipBy)
        {
            List<OrderData> list = null;
            if(shipBy == true)
            {              
                PopulateOrders(0);
                SetOrderCount();

                list = OrdersToList(allOrdersArray);
                var shp = list.Where(od => od.OrdInfo.PromissedDay.Equals(DtShipBy.ToShortDateString())).ToList();
                if(SelectedDistributorShipBy != null)
                {
                    shp = shp.Where(od => od.OrdInfo.DistributorID == SelectedDistributorShipBy.DistributorID).ToList();
                }
                RemoveEvents();

                allOrdersArray = CreateAllOrders(shp);
                CurrentPage = 0;
                OrderDataList = allOrdersArray[CurrentPage];
                AddEvents();
                
                return;
            }

            list = OrdersToList(allOrdersArray);
            if (list == null)
                return;
            var upc = list.Where(od => od.OrdInfo.UPC.Equals(Search)).ToList();
            if (upc != null && upc.Count() > 0)
            {
                RemoveEvents();
                allOrdersArray = CreateAllOrders(upc);
                CurrentPage = 0;
                OrderDataList = allOrdersArray[CurrentPage];
                AddEvents();
                return;
            }

            var sku = list.Where(od => od.OrdInfo.SKU.Equals(Search)).ToList();
            if (sku != null && sku.Count() > 0)
            {
                RemoveEvents();
                allOrdersArray = CreateAllOrders(sku);
                CurrentPage = 0;
                OrderDataList = allOrdersArray[CurrentPage];
                AddEvents();
                return;
            }

            var ordId = list.Where(od => od.OrdInfo.OrderID.Equals(Search)).ToList();
            if (ordId != null && ordId.Count() > 0)
            {
                RemoveEvents();
                allOrdersArray = CreateAllOrders(ordId);
                CurrentPage = 0;
                OrderDataList = allOrdersArray[CurrentPage];
                AddEvents();
                return;
            }

            var email = OrderDataList.Where(od => od.CustInfo.Email.Equals(Search)).ToList();
            if(email != null && email.Count() > 0)
            {
                RemoveEvents();
                allOrdersArray = CreateAllOrders(email);
                CurrentPage = 0;
                OrderDataList = allOrdersArray[CurrentPage];
                AddEvents();
                return;
            }

            var name = OrderDataList.Where(od => od.CustInfo.Name.ToUpper().Contains(Search.ToUpper())).ToList();
            if (name != null && name.Count() > 0)
            {
                RemoveEvents();
                allOrdersArray = CreateAllOrders(name);
                CurrentPage = 0;
                OrderDataList = allOrdersArray[CurrentPage];
                AddEvents();
                return;
            }

            var title = OrderDataList.Where(od => od.OrdInfo.Title.ToUpper().Contains(Search.ToUpper())).ToList();
            if (title != null && title.Count() > 0)
            {
                RemoveEvents();
                allOrdersArray = CreateAllOrders(title);
                CurrentPage = 0;
                OrderDataList = allOrdersArray[CurrentPage];
                AddEvents();
                return;
            }

            var asin = OrderDataList.Where(od => od.OrdInfo.ASIN.Equals(Search)).ToList();
            if (asin != null && asin.Count() > 0)
            {
                RemoveEvents();
                allOrdersArray = CreateAllOrders(asin);
                CurrentPage = 0;
                OrderDataList = allOrdersArray[CurrentPage];
                AddEvents();
                return;
            }

            var zipCD = OrderDataList.Where(od => od.CustInfo.ZipCode.ToUpper().Contains(Search.ToUpper())).ToList();
            if (zipCD != null && zipCD.Count() > 0)
            {
                RemoveEvents();
                allOrdersArray = CreateAllOrders(zipCD);
                CurrentPage = 0;
                OrderDataList = allOrdersArray[CurrentPage];
                AddEvents();
                return;
            }

        }

        private void performDBSearch()
        {

            StringBuilder sb = new StringBuilder("o.OrderID = '").Append(Search).Append("' ");
            PopulateOrders(0, sb);
            if (OrderDataList != null && OrderDataList.Count > 0)
                return;

            sb.Clear();
            sb.Append("c.Email = '").Append(Search).Append("' ");
            PopulateOrders(0, sb);
            if (OrderDataList != null && OrderDataList.Count > 0)
                return;

            sb.Clear();
            sb.Append("p.UPC = '").Append(Search).Append("' ");
            PopulateOrders(0, sb);
            if (OrderDataList != null && OrderDataList.Count > 0)
                return;

            sb.Clear();
            sb.Append("o.SKU = '").Append(Search).Append("' ");
            PopulateOrders(0, sb);
            if (OrderDataList != null && OrderDataList.Count > 0)
                return;

            sb.Clear();
            sb.Append("p.ASIN = '").Append(Search).Append("' ");
            PopulateOrders(0, sb);
            if (OrderDataList != null && OrderDataList.Count > 0)
                return;

            sb.Clear();
            sb.Append("c.ZipCode like '").Append(Search).Append("%' ");
            PopulateOrders(0, sb);
            if (OrderDataList != null && OrderDataList.Count > 0)
                return;

            sb.Clear();
            sb.Append("p.Title like '").Append(Search).Append("%' ");
            PopulateOrders(0, sb);
            if (OrderDataList != null && OrderDataList.Count > 0)
                return;

            sb.Clear();
            sb.Append("c.Name like '").Append(Search).Append("%' ");
            PopulateOrders(0, sb);
            if (OrderDataList != null && OrderDataList.Count > 0)
                return;

            sb.Clear();
            sb.Append("o.TrackingNumber = '").Append(Search).Append("' ");
            PopulateOrders(0, sb);
            if (OrderDataList != null && OrderDataList.Count > 0)
                return;
        }

        private RelayCommand<object> cmdCCInventory;
        public RelayCommand<object> CmdCCInventroy
        {
            get
            {
                if(cmdCCInventory == null)
                {
                    cmdCCInventory = new RelayCommand<object>(o =>
                    {
                        var cc = new Views.CCInventory();
                        cc.DataContext = new CCInventoryVM(model);
                        cc.Show();
                    });
                }
                return cmdCCInventory;
            }
        }

        private RelayCommand<CustomerInfo> cmdEditAddress;
        public RelayCommand<CustomerInfo> CmdEditAddress
        {
            get
            {
                if(cmdEditAddress == null)
                {
                    cmdEditAddress = new RelayCommand<CustomerInfo>(ci =>
                    {
                        var ea = new Views.EditAddress();
                        ea.DataContext = ci;
                        ea.ShowDialog();
                        if(ea.SaveData)
                        {
                            model.UpdateShippingAddress(ci);
                        }
                    });
                }
                return cmdEditAddress;
            }
        }

        private DateTime dtFrom = DateTime.Now;
        public DateTime DtFrom
        {
            get { return dtFrom; }
            set { SetField<DateTime>(ref dtFrom, value); }
        }

        private DateTime dtTo = DateTime.Now;
        public DateTime DtTo
        {
            get { return dtTo; }
            set { SetField<DateTime>(ref dtTo, value); }
        }

        private DateTime dtShipBy = DateTime.Now;
        public DateTime DtShipBy
        {
            get { return dtShipBy; }
            set
            {
                SetField<DateTime>(ref dtShipBy, value);          
            }
        }

        bool shibBySearch = false;
        private RelayCommand<object> cmdShipByMouseDn;
        public RelayCommand<object> CmdShipByMouseDn
        {
            get
            {
                if(cmdShipByMouseDn == null)
                {
                    cmdShipByMouseDn = new RelayCommand<object>(o =>
                    {
                        Search = dtShipBy.ToShortDateString();
                        shibBySearch = true;
                        performLocalSearch(true);
                    });
                }
                return cmdShipByMouseDn;
            }
        }

        private RelayCommand<object> cmdTrackingReport;
        public RelayCommand<object> CmdTrackingReport
        {
            get
            {
                if(cmdTrackingReport == null)
                {
                    cmdTrackingReport = new RelayCommand<object>(o =>
                    {
                        var diff = DtTo - DtFrom;
                        if (diff.Days < 0)
                            return;

                        if (string.IsNullOrEmpty(SelectedMarket))
                            return;

                        model.CreateTrackingReport(DtFrom, dtTo, MarketList.ToList().FindIndex(m => m.Equals(SelectedMarket)) + 1);
                    });
                }
                return cmdTrackingReport;
            }
        }

        private RelayCommand<object> cmdPrevPage;
        public RelayCommand<object> CmdPrevPage
        {
            get
            {
                if(cmdPrevPage == null)
                {
                    cmdPrevPage = new RelayCommand<object>(o =>
                    {
                        CurrentPage--;
                        NumOrders = numOrders;
                        OrderDataList = allOrdersArray[CurrentPage];
                    }, o => CurrentPage > 0);
                }
                return cmdPrevPage;
            }
        }

        private RelayCommand<object> cmdNextPage;
        public RelayCommand<object> CmdNextPage
        {
            get
            {
                if(cmdNextPage == null)
                {
                    cmdNextPage = new RelayCommand<object>(o =>
                    {
                        CurrentPage++;
                        NumOrders = numOrders;
                        OrderDataList = allOrdersArray[CurrentPage];
                    }, o => CurrentPage < allOrdersArray.Length - 1);
                }
                return cmdNextPage;
            }
        }

        private bool showAll = false;
        public bool ShowAll
        {
            get { return showAll; }
            set { SetField<bool>(ref showAll, value); }
        }

        private RelayCommand<object> cmdShowAll;
        public RelayCommand<object> CmdShowAll
        {
            get
            {
                if(cmdShowAll == null)
                {
                    cmdShowAll = new RelayCommand<object>(o =>
                    {
                        if (ShowAll == true)
                        {
                            for (int i = 0; i < allOrdersArray.Length; i++)
                            {
                                if (i == 0)
                                {
                                    OrderDataList = allOrdersArray[i];
                                }
                                else
                                {
                                    if (allOrdersArray[i] != null)
                                    {
                                        allOrdersArray[i].ToList().ForEach(or =>
                                        {
                                            OrderDataList.Add(or);
                                        });
                                    }
                                }
                            }
                            allOrdersArray = new ObservableCollection<OrderData>[1];
                            allOrdersArray[0] = OrderDataList;
                            SetOrderCount();
                        }
                        else
                        {
                            allOrdersArray = CreateAllOrders(OrderDataList.ToList());
                            CurrentPage = 0;
                            OrderDataList = allOrdersArray[CurrentPage];
                            SetOrderCount();
                        }
                    });
                }
                return cmdShowAll;
            }
        }
    }
}
