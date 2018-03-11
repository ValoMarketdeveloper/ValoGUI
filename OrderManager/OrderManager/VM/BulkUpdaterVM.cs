using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using CommonTools;
using System.IO;
using System.Windows;

namespace OrderManager.VM
{
    public class BulkUpdaterVM : NotificationObject
    {
        private UpdaterModel model = null;
        private List<string> skuList = new List<string>();

        private BulkUpdaterVM() { }

        public BulkUpdaterVM(UpdaterModel model)
        {
            this.model = model;
            bulkUpdateFields = new List<string> { string.Empty, "MAP", "UOM", "Unpublish", "Weight" };
        }

        #region Properties

        private List<string> bulkUpdateFields;
        public List<string> BulkUpdateFields
        {
            get { return bulkUpdateFields; }
        }

        private string bulkUpdateSelection;
        public string BulkUpdateSelection
        {
            get { return bulkUpdateSelection; }
            set { SetField<string>(ref bulkUpdateSelection, value); }
        }

        private string newValue;
        public string NewValue
        {
            get { return newValue; }
            set { SetField<string>(ref newValue, value); }
        }

        #endregion Properties

        #region Commands

        private RelayCommand<object> cmdSKUs;
        public RelayCommand<object> CmdSKUs
        {
            get
            {
                if (cmdSKUs == null)
                {
                    cmdSKUs = new RelayCommand<object>(o =>
                    {
                        skuList.Clear();
                        OpenFileDialog dlg = new OpenFileDialog();
                        dlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                        var result = dlg.ShowDialog();
                        if (result == true)
                        {
                            using (StreamReader sr = new StreamReader(dlg.FileName))
                            {
                                string line = string.Empty;
                                while ((line = sr.ReadLine()) != null)
                                    skuList.Add(line);
                            }
                        }
                    });
                }
                return cmdSKUs;
            }
        }

        private RelayCommand<object> cmdUpdate;
        public RelayCommand<object> CmdUpdate
        {
            get
            {
                if (cmdUpdate == null)
                {
                    cmdUpdate = new RelayCommand<object>(o =>
                    {
                        if (!string.IsNullOrEmpty(BulkUpdateSelection) && !string.IsNullOrEmpty(NewValue))
                        {
                            int result = model.bulkUpdateMarketplaceData(skuList, this.BulkUpdateSelection, NewValue);
                            MessageBoxResult messageBoxResult = MessageBox.Show("Updated " + result + " Rows. Dow you want to clear SKUs",
                                "Update Result", MessageBoxButton.YesNo);
                            if (messageBoxResult == MessageBoxResult.Yes)
                            {
                                skuList.Clear();
                                BulkUpdateSelection = string.Empty;
                                NewValue = string.Empty;
                            }
                        }
                    }, (o => {
                        return skuList.Count > 0 && !string.IsNullOrEmpty(BulkUpdateSelection)
                  && !string.IsNullOrEmpty(NewValue);
                    }));
                }

                return cmdUpdate;
            }
        }

        #endregion Commands
    }
}
