using DimaUrsova.EF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DimaUrsova
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static EF._123Context Context
        { get; set; } = new EF._123Context();
        public static EF.Login CurrentUser = null;
        public static Page WorkPages = new Pages.Pages_table.workersPage();
        public static Page CustomerPages = new Pages.Pages_table.CustomerPage();
        public static Page DetailsPages = new Pages.Pages_table.DetailsPage();
        public static Page PolzavatelPages = new Pages.Pages_table.PolzavatelPage();
        public static Page OrdersPages = new Pages.Pages_table.OrdersPageForProduct();
        public static void PreLoadBD() 
        
        {
            _ = App.Context.Customers.ToList();
            _ = App.Context.Workers.ToList();
            _ = App.Context.Orderssses.ToList();
            _ = App.Context.Details.ToList();
            _ = App.Context.Logins.ToList();
            _ = App.Context.Positionnns.ToList();
            _ = App.Context.Stocks.ToList();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            PreLoadBD();
        }
    }
}
