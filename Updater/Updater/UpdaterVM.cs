using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonTools;
using System.Collections.ObjectModel;
using CommonData;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows;

namespace Updater
{
    public class UpdaterVM : NotificationObject
    {
        public class DisplayData : NotificationObject
        {
            public DisplayData()
            {
                DistributorDataColumns = new ObservableCollection<DataGridColumn>()
                {
                    new DataGridTextColumn() { Header = "Distr", Binding = new Binding("DistributorName"), IsReadOnly = true  },
                    new DataGridTextColumn() { Header = "Distr ID", Binding = new Binding("DistributorProductID"), IsReadOnly = true },
                    new DataGridTextColumn() { Header = "Title", Binding = new Binding("Title"), IsReadOnly = true },
                    new DataGridTextColumn() { Header = "Brand", Binding = new Binding("Brand"), IsReadOnly = true },
                    new DataGridTextColumn() { Header = "Description", Binding = new Binding("Description"), IsReadOnly = true },
                    new DataGridTextColumn() { Header = "Weight", Binding = new Binding { Path = new PropertyPath("Weight"),
                        UpdateSourceTrigger = UpdateSourceTrigger.LostFocus } },
                    new DataGridTextColumn() { Header = "Size", Binding = new Binding { Path = new PropertyPath("Size"),
                        UpdateSourceTrigger = UpdateSourceTrigger.LostFocus } },
                    new DataGridTextColumn() { Header = "UOM", Binding = new Binding { Path = new PropertyPath("UOM"),
                        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged } },
                    new DataGridCheckBoxColumn() { Header = "Unpublish", Binding = new Binding { Path = new PropertyPath("Unpublish"),
                        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged } }
                };

                MarketplaceDataColumns = new ObservableCollection<DataGridColumn>()
                {
                    new DataGridTextColumn() { Header = "Market", Binding = new Binding("MarketPlaceName"), IsReadOnly = true },
                    new DataGridTextColumn() { Header = "SKU", Binding = new Binding("SKU"), IsReadOnly = true },
                    new DataGridTextColumn() { Header = "Weight", Binding = new Binding { Path = new PropertyPath("Weight"),
                        UpdateSourceTrigger = UpdateSourceTrigger.LostFocus } },
                    new DataGridTextColumn() { Header = "UOM", Binding = new Binding { Path = new PropertyPath("UOM"),
                        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged } },
                    new DataGridCheckBoxColumn() { Header = "Unpublish", Binding = new Binding { Path = new PropertyPath("Unpublish"),
                        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged } },
                    new DataGridTextColumn() { Header = "MAP", Binding = new Binding { Path = new PropertyPath("MAP"),
                        UpdateSourceTrigger = UpdateSourceTrigger.LostFocus } },
                     new DataGridCheckBoxColumn() { Header = "Verified", Binding = new Binding { Path = new PropertyPath("Verified"),
                        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged } },
                      new DataGridCheckBoxColumn() { Header = "IsFood", Binding = new Binding { Path = new PropertyPath("IsFood"),
                        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged } }
                };
            }

            private ObservableCollection<DataGridColumn> distributorDataColumns = new ObservableCollection<DataGridColumn>();
            public ObservableCollection<DataGridColumn> DistributorDataColumns
            {
                get { return distributorDataColumns; }
                set { SetField<ObservableCollection<DataGridColumn>>(ref distributorDataColumns, value); }
            }

            private ObservableCollection<DataGridColumn> marketplaceDataColumns = new ObservableCollection<DataGridColumn>();
            public ObservableCollection<DataGridColumn> MarketplaceDataColumns
            {
                get { return marketplaceDataColumns; }
                set { SetField<ObservableCollection<DataGridColumn>>(ref marketplaceDataColumns, value); }
            }

            private string upc;
            public string UPC
            {
                get { return upc; }
                set { SetField<string>(ref upc, value); }
            }

            private ObservableCollection<DistributorData> distData = new ObservableCollection<DistributorData>();
            public ObservableCollection<DistributorData> DistData
            {
                get { return distData; }
                set { SetField<ObservableCollection<DistributorData>>(ref distData, value); }
            }

            private ObservableCollection<MarketplaceData> mpData = new ObservableCollection<MarketplaceData>();
            public ObservableCollection<MarketplaceData> MarketplaceData
            {
                get { return mpData; }
                set { SetField<ObservableCollection<MarketplaceData>>(ref mpData, value); }
            }

            public event Action Updated;

            public void DataUpdated()
            {
                if (Updated != null)
                    Updated();
            }
        }

        private bool updated = false;
        private RelayCommand<object> cmdSave;
        public RelayCommand<object> CmdSave
        {
            get
            {
                if(cmdSave == null)
                {
                    cmdSave = new RelayCommand<object>(o =>
                    {
                        DistributorDataList.ToList().ForEach(dd =>
                        {
                            dd.DistData.ToList().ForEach(d =>
                            {
                                if (d.Updated == true)
                                    model.SaveDistributorData(d);
                            });

                            dd.MarketplaceData.ToList().ForEach(mp =>
                                {
                                    if (mp.Updated == true)
                                        model.SaveMarketplaceData(mp);
                                });
                            updated = false;
                            CommandManager.InvalidateRequerySuggested();
                        });
                    }, o => { return updated; });
                }

                return cmdSave;
            }
        }

        private RelayCommand<object> cmdBulkUpdte;
        public RelayCommand<object> CmdBulkUpdate
        {
            get
            {
                if(cmdBulkUpdte == null)
                {
                    cmdBulkUpdte = new RelayCommand<object>(o =>
                   {
                       Window w = new BulkUpaterView(this.model);
                       w.ShowDialog();
                   });
                }

                return cmdBulkUpdte;
            }
        }

        private UpdaterModel model = null;

        private UpdaterVM() { }

        public UpdaterVM(UpdaterModel model)
        {
            this.model = model;
            SearchOption = "SKU";
        }

     

        private List<string> searchOptions = new List<string>() { "ASIN", "SKU", "UPC" };
        public List<string> SearchOptions
        {
            get { return searchOptions; }
        }

        private string searchOption;
        public string SearchOption
        {
            get { return searchOption; }
            set { SetField<string>(ref searchOption, value); }
        }

        private string search;
        public string Search
        {
            get { return search; }
            set { SetField<string>(ref search, value); }
        }

        private ObservableCollection<DisplayData> distributorDataList = new ObservableCollection<DisplayData>();
        public ObservableCollection<DisplayData> DistributorDataList
        {
            get { return distributorDataList; }
            set { SetField<ObservableCollection<DisplayData>>(ref distributorDataList, value); }
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
                        PerformSearch();
                    });
                }
                return cmdSearch;
            }
        }

        public void PerformSearch()
        {
            updated = false;
            DistributorDataList.Clear();
            if (SearchOption == "UPC")
            {
                if (SearchByUPC() == false)
                    if (SearchBySKU() == false)
                        SearchByASIN();
            }
            else if (SearchOption == "ASIN")
            {
                if (SearchByASIN() == false)
                    if (SearchBySKU() == false)
                        SearchByUPC();
            }
            else if (searchOption == "SKU")
            {
                if (SearchBySKU() == false)
                    if (SearchByUPC() == false)
                        SearchByASIN();
            }
        }

        private bool SearchByASIN()
        {
            string upc = string.Empty;
            var mList = model.GetMarketDataByASIN(Search, out upc);

            if (mList == null || mList.Count == 0)
                return false;

            DisplayData dd = new DisplayData();
            dd.UPC = upc;
            mList.ToList().ForEach(m =>
            {
                m.Updated = false;
                dd.MarketplaceData.Add(m);
                m.DataUpdated += dd.DataUpdated;
            });

            var dList = model.GetDistributorDataByUPC(upc);
            if (dList != null && dList.Count > 0)
            {

                dList.ToList().ForEach(d =>
                {
                    d.Updated = false;
                    dd.DistData.Add(d);
                    d.DataUpdated += dd.DataUpdated;
                });
            }
            
            dd.Updated += () => 
            {
                updated = true;
                CommandManager.InvalidateRequerySuggested();
            };
            DistributorDataList.Add(dd);

            return true;
        }

        private void Dd_Updated()
        {
            throw new NotImplementedException();
        }

        private bool SearchBySKU()
        {
            string upc = string.Empty;
            var mList = model.GetMarketDataBySKU(Search, out upc);

            if (mList == null || mList.Count == 0)
                return false;
            
            DisplayData dd = new DisplayData();
            dd.UPC = upc;
            mList.ToList().ForEach(m =>
            {
                m.Updated = false;
                dd.MarketplaceData.Add(m);
                m.DataUpdated += dd.DataUpdated;
            });

            var dList = model.GetDistributorDataByUPC(upc);
            if (dList != null && dList.Count > 0)
            {
                dList.ToList().ForEach(d =>
                {
                    d.Updated = false;
                    dd.DistData.Add(d);
                    d.DataUpdated += dd.DataUpdated;
                });
            }
            dd.Updated += () =>
            {
                updated = true;
                CommandManager.InvalidateRequerySuggested();
            };
            DistributorDataList.Add(dd);
            
            return true;
        }

        private bool SearchByUPC()
        {
            var dList = model.GetDistributorDataByUPC(Search);
            if (dList == null || dList.Count == 0)
                return false;

            DisplayData dd = new DisplayData();
            dd.UPC = Search;
            dList.ToList().ForEach(d =>
            {
                d.Updated = false;
                dd.DistData.Add(d);
                d.DataUpdated += dd.DataUpdated;
            });

            var mpList = model.GetMarketDataByUPC(Search);
            if (mpList != null && mpList.Count > 0)
            {
                mpList.ToList().ForEach(m =>
                {
                    m.Updated = false;
                    dd.MarketplaceData.Add(m);
                    m.DataUpdated += dd.DataUpdated;
                });
            }
            dd.Updated += () =>
            {
                updated = true;
                CommandManager.InvalidateRequerySuggested();
            };
            DistributorDataList.Add(dd);

            return true;
        }
    }
}
