using DimaUrsova.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DimaUrsova.Pages.Pages_table
{
    /// <summary>
    /// Логика взаимодействия для AddOrders.xaml
    /// </summary>
    public partial class AddOrders : Page
    {
        EF.Ordersss? context = null;
        EF.Customer? ContextCust = null;
        public AddOrders(EF.Ordersss? orders)
        {
            InitializeComponent();
            CBstatus.Items.Clear();
            CBstatus.ItemsSource = new List<string> { "Виконано", "Виконується", "Активні", "На діагностиці" };
            if (CBstatus.Items.Count > 0)
            {
                CBstatus.SelectedIndex = 0;
            }
            CBmaster.ItemsSource = App.Context.Workers.Where(p => p.PositionCode == 1).ToList(); ;
            if (CBmaster.Items.Count > 0)
            {
                CBmaster.SelectedIndex = 0;
            }
            CBmanag.ItemsSource = App.Context.Workers.Where(p => p.PositionCode == 2).ToList(); ;
            if (CBmanag.Items.Count > 0)
            {
                CBmanag.SelectedIndex = 0;
            }
            CBnamedet.ItemsSource = App.Context.Details.ToList();
            if (CBnamedet.Items.Count > 0)
            {
                CBnamedet.SelectedIndex = 0;
            }
         
            var Date = DateTime.Now;
            DateOrdersDP.SelectedDate = Date;
            AllPriceBox.Content = (double)0;
            if (orders!=null)
            {
                context = orders;
                CBstatus.SelectedItem = orders.Status;
                CBmaster.SelectedItem = orders.WorkerCodeMas;
                CBmanag.SelectedItem = orders.WorkerCodeMen;
                CBnamedet.SelectedItem = orders.NameDevice;
               TBname.Text = orders.NameDevice.ToString();
                TBcause.Text = orders.Breaking.ToString();
                TBappearence.Text = orders.Appearance.ToString();
                Date = DateTime.ParseExact(orders.DateOrder, "dd.MM.yyyy", null);
                DateOrdersDP.SelectedDate = Date;
                TBPIB.Text = orders.CustomerCodeNavigation.CustomerPib.ToString();
                TBphone.Text = orders.CustomerCodeNavigation.CustomerNomer.ToString();
                TBaddress.Text = orders.CustomerCodeNavigation.CustomerAddress.ToString();
                TBdocument.Text = orders.CustomerCodeNavigation.CustomerDocument.ToString();

                foreach (EF.Stock item1 in orders.StockNavigation().ToArray())
                {
                    AddsProducts.Items.Add(item1);
                }
                AllPriceBox.Content = ReCount(orders.Stocks.ToList());
            }
           
        }
        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext as EF.Stock;
            AddsProducts.Items.Remove(item);
            AllPriceBox.Content = ReCount(AddsProducts.Items.Cast<EF.Stock>().ToList());
            if (context != null)
            {
                App.Context.Stocks.Remove(item);
            }
        }
        private double ReCount(List<EF.Stock> ls)
        {
            return ls.Sum(p => (p.DetailsCodeNavigation.CostDetails * p.Quantity) + p.DetailsCodeNavigation.CostService);
        }
        private void Product_Click(object sender, RoutedEventArgs e)
        {
            var Stock = new EF.Stock
            {
                DetailsCodeNavigation = CBnamedet.SelectedItem as EF.Detail

                //NameDetails = (CBnamedet.SelectedItem as EF.Detail)?.ToString()
            };
            try
            {
                Stock.Quantity = long.Parse(TBquantity.Text);
            }
            catch
            {
                return;
            }
            //if (int.Parse(TBquantity.Text) == 0)
            //{
            //    return;
            //}
            var det = CBnamedet.SelectedItem as EF.Detail;
            var item = AddsProducts.Items.Cast<EF.Stock>().Where(p => p.DetailsCodeNavigation == det).FirstOrDefault();
            if (item!=null)
            {
                AddsProducts.Items.Remove(item);
                item.Quantity += long.Parse(TBquantity.Text);

                AddsProducts.Items.Add(item);
                Stock = item;

            }
            else
            {
                AddsProducts.Items.Add(Stock);
            }
            AllPriceBox.Content = ReCount(AddsProducts.Items.Cast<EF.Stock>().ToList());


        }
        private void OnlyDigits_KeyUp(object sender, KeyEventArgs e)
        {
            int count = -1;
            if (!((e.Key >= Key.D0 && e.Key <= Key.D9) ||
                (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) ||
                e.Key == Key.Back || e.Key == Key.Delete))
            {
                e.Handled = true;
            }
        }
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void OnlyLettersAndSpecialChars_KeyDown(object sender, KeyEventArgs e)
        {
            if (((e.Key >= Key.D0 && e.Key <= Key.D9) ||
                (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) ||
                e.Key == Key.Back || e.Key == Key.Delete))
            {
                e.Handled = true;
            }
        }








        private void AdditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (context == null)
            {
                EF.Customer cust = new Customer();
                cust.CustomerPib = TBPIB.Text;
                cust.CustomerNomer = TBphone.Text;
                cust.CustomerAddress = TBaddress.Text;
                cust.CustomerDocument = TBdocument.Text;
                App.Context.Customers.Add(cust);

                ContextCust = cust;


                
                EF.Ordersss order = new Ordersss();
                order.NameDevice = TBname.Text;
                order.Breaking =TBcause.Text;
                order.Appearance = TBappearence.Text;
                order.DateOrder = DateOrdersDP.Text;
                order.Status = CBstatus.Text;
                order.WorkerCodeMenNavigation = CBmanag.SelectedItem as EF.Worker;
                order.WorkerCodeMasNavigation = CBmaster.SelectedItem as EF.Worker;  
                order.CustomerCodeNavigation = cust;
                order.AllSum = (double)AllPriceBox.Content;

                foreach (EF.Stock item in AddsProducts.Items)
                {
                    item.OrdersssCodeNavigation = order;
                    if (item.StockCode == 0)
                    {
                        App.Context.Stocks.Add(item);
                    }
                }
                App.Context.SaveChanges();

            }
            else
            {
                         
                context.AllSum = (double)AllPriceBox.Content;
                context.DateOrder = ((DateTime)DateOrdersDP.SelectedDate).ToString("dd.MM.yyyy");
                context.Status = CBstatus.Text;
                foreach (EF.Stock item in AddsProducts.Items)
                {
                    item.OrdersssCodeNavigation = context;
                    if (item.StockCode == 0)
                    {
                        App.Context.Stocks.Add(item);
                    }

                }
                App.Context.SaveChanges();

            }
            NavigationService.GoBack();
        }
     
        
    }
}
