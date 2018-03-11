using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Microsoft.Practices.Prism.Logging;
using CommonTools;

namespace OrderManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Log4NetLogger log;
        public Log4NetLogger Log
        {
            get { return log; }
        }

        public string DBServer { get; set; }
        public string DBUser { get; set; }
        public string DBPwd { get; set; }
        public string DBName { get; set; }

        public OrderManagerModel Model { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
            
            log = new Log4NetLogger();

            DBServer = ConfigurationManager.AppSettings["DBServer"];
            DBName = ConfigurationManager.AppSettings["DBName"];
            DBUser = ConfigurationManager.AppSettings["DBUser"];
            DBPwd = ConfigurationManager.AppSettings["DBPwd"];

            log.Log("Starting Application", Category.Info, Priority.Low);
            StaticLogger.Logger = log;
            Model = new OrderManagerModel(DBServer, DBUser, DBPwd, DBName);

            //MainWindow main = new MainWindow(Model);
            //main.Show();

            var orders = new Views.Orders();
            orders.DataContext = new VM.OrdersVM(Model);
            orders.Show();

        }

        private void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs args)
        {
            if (args != null)
            {
                StaticLogger.LogException(args.Exception);
                args.Handled = true;
            }
        }

    }
}
