using DimaUrsova.EF;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DimaUrsova.Pages
{
    /// <summary>
    /// Логика взаимодействия для Addinfo.xaml
    /// </summary>
    public partial class Addinfo : Page
    {
       
        private EF.Customer _currentcustomer = null;
        private EF.Ordersss _currentorders = null;
        private EF.Detail _currentdetail = null;
        //В
        //О
        //Т
        /*---->*/ public List<EF.Stock> _currentstock = null; /*<-------*/
        //Т
        //У
        //Т
        public Addinfo()
        {
            InitializeComponent();



            Combox2.ItemsSource = App.Context.Workers.Where(p => p.PositionCode == 1).ToList();
            Combox2.DisplayMemberPath = "WorkerPib";
            Combox3.ItemsSource = App.Context.Workers.Where(p => p.PositionCode == 2).ToList();
            Combox3.DisplayMemberPath = "WorkerPib";
            
            
            try
            {
                Combox1.SelectedIndex = 0;
                Combox2.SelectedIndex = 0;
                Combox3.SelectedIndex = 0;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ебать, а нет работников, ну вот нет, иди нахуй. Подрбности: "+ex.Message);
                NavigationService.GoBack();
            }

          



            //Combobox10.ItemsSource = App.Context.Details.Where();
        }

        //public Addinfo(EF.Stock servicestcok)
        //{
        //    _currentstock = servicestcok;
        //    TextboxQuntdet.Text = _currentstock.Quantity.ToString();
        //}

            public Addinfo(EF.Detail servicedetail)
        {

            _currentdetail = servicedetail;
       
            //TextboxQuntdet.Text = _currentstock.Quantity.ToString();



        }

        public Addinfo(EF.Ordersss serviceorder) 
        {
            InitializeComponent();
            
            Combox2.ItemsSource = App.Context.Workers.Where(p => p.PositionCode == 1).ToList();
            Combox2.DisplayMemberPath = "WorkerPib";
            Combox2.SelectedIndex = 0;

            Combox3.ItemsSource = App.Context.Workers.Where(p => p.PositionCode == 2).ToList();
            Combox3.DisplayMemberPath = "WorkerPib";
            Combox3.SelectedIndex = 0;

            _currentorders = serviceorder;
            _currentcustomer = serviceorder.CustomerCodeNavigation;
           

            Title = "Редагування послуги";
            TextBox1.Text = _currentcustomer.CustomerPib;
            TextBox2.Text = _currentcustomer.CustomerNomer;
            TextBox3.Text = _currentcustomer.CustomerAddress;
            TextBox4.Text = _currentcustomer.CustomerDocument;
            Textboxeorders1.Text = _currentorders.NameDevice;
            Textboxeorders2.Text = _currentorders.Breaking;
            Textboxeorders3.Text = _currentorders.Appearance;
            Textboxeorders4.Text = _currentorders.DateOrder;
            Combox1.SelectedItem = _currentorders.Status;
            Combox2.SelectedItem = _currentorders.WorkerCodeMenNavigation;
            Combox3.SelectedItem = _currentorders.WorkerCodeMasNavigation;
            _currentstock = _currentorders.StockNavigation();
           
            allsum.Text = AllPrice(_currentstock).ToString();
            CostService.Text = AllPrice(_currentstock).ToString();
            CostDet.Text = CostServiceFun(_currentstock).ToString();

            
        }




        private double CostServiceFun(List<EF.Stock>? stocks)
        {
            if (stocks == null)
            {
                return 0;
            }
            else
            {
                double price = 0;
                foreach (var item in stocks)
                {
                    price += item.DetailsCodeNavigation.CostService;
                }
                return price;
            }

        }
        private double CostPrice(List<EF.Stock>? stocks) 
        {
           
          
            if (stocks == null)
            {
                return 0;
            }
            else
            {
                double price = 0;
                foreach (var item in stocks)
                {
                    if (item.Quantity == 0)
                    {
                        return 0;
                    }
                    price += (item.DetailsCodeNavigation.CostDetails) * item.Quantity;
                    
                }
               
                return price;
            }
           
        }
	
        private double AllPrice(List<EF.Stock>? stocks)
        {
            if (stocks==null)
            {
                return 0;
            }
            else
            {
                double price = 0;
                foreach (var item in stocks)
                {
                    if (item.Quantity==0)
                    {
                        return item.DetailsCodeNavigation.CostService;
                    }
                    price += (item.DetailsCodeNavigation.CostDetails * item.Quantity) + item.DetailsCodeNavigation.CostService ;
                }
                return price;
            }
           
        }
 

    private string ChekErrors()
        {
            var errorBuild = new StringBuilder();
            if (string.IsNullOrEmpty(TextBox1.Text))
            {
                errorBuild.AppendLine("Заповнить поле будласко");
            }
            var serviceexistDB = App.Context.Orderssses.Where(p=>p.NameDevice.ToLower()== TextBox1.Text.ToLower()).FirstOrDefault();

            if (serviceexistDB!=null)
            {
                errorBuild.AppendLine("Така услуга вже є");
            }

            decimal cost = 0;
            if (decimal.TryParse(TextBox1.Text,out cost) == false || cost<=0)
            {
                errorBuild.AppendLine("Введіть додатні числа");
            }
            

            return errorBuild.ToString();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var errorMess = "";
            if (errorMess.Length>0)
            {
                MessageBox.Show(errorMess, "Помилка");
            }
            else
            {
                if (_currentorders == null)
                {
                    var customer1 = new EF.Customer
                    {
                        CustomerPib = TextBox1.Text,
                        CustomerNomer = TextBox2.Text,
                        CustomerAddress = TextBox3.Text,
                        CustomerDocument = TextBox4.Text,

                    };
                    App.Context.Customers.Add(customer1);

                    //string SelectedDetailName = (Combobox10.SelectedItem as EF.Detail).NameDetails;

                    //double detailprice = 0;
                    //var detail = App.Context.Details.FirstOrDefault(d => d.NameDetails == SelectedDetailName);
                    //if (detail != null)
                    //{
                    //    detailprice = detail.CostDetails;
                    //}

                     var orders21 = new EF.Ordersss
                    {
                        NameDevice = Textboxeorders1.Text,
                        Breaking = Textboxeorders2.Text,
                        Appearance = Textboxeorders3.Text,
                        DateOrder = Textboxeorders4.Text,
                        CustomerCodeNavigation = customer1,
                        AllSum = long.Parse(AllPrice(_currentstock).ToString()),
                        Status = (Combox1.SelectedItem as ComboBoxItem).Content.ToString(),
                        WorkerCodeMenNavigation = Combox2.SelectedItem as EF.Worker,
                        WorkerCodeMasNavigation = Combox3.SelectedItem as EF.Worker,
                     
                   
                    }; 
                    App.Context.Orderssses.Add(orders21);
                    App.Context.SaveChanges();
                    
                    foreach (var item in _currentstock) {
                        item.OrdersCode = orders21.OrdersCode;
                        App.Context.Stocks.Add(item);
                    }
                    App.Context.SaveChanges();




                    NavigationService.Navigate(new Pages.Pages_table.OrdersPageForProduct());


                }
                else
                {
                    _currentcustomer.CustomerPib = TextBox1.Text;
                         _currentcustomer.CustomerNomer = TextBox2.Text;
                    _currentcustomer.CustomerAddress = TextBox3.Text;
                    _currentcustomer.CustomerDocument = TextBox4.Text;

                    _currentorders.NameDevice = Textboxeorders1.Text;
                    _currentorders.Breaking = Textboxeorders2.Text;
                    _currentorders.Appearance = Textboxeorders3.Text;
                    _currentorders.DateOrder = Textboxeorders4.Text;
                    _currentorders.CustomerCodeNavigation = _currentcustomer;
                    
                    _currentorders.AllSum = long.Parse(AllPrice(_currentstock).ToString());

                    CostService.Text = AllPrice(_currentstock).ToString();
                    CostDet.Text = CostPrice(_currentstock).ToString();

                    try
                    {
                        _currentorders.Status = (Combox1.SelectedItem as ComboBoxItem).Content.ToString();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Введіть значення статусу");
                        return;
                    }
                    MessageBox.Show("skdfksdf");

                    _currentorders.WorkerCodeMenNavigation = Combox2.SelectedItem as EF.Worker;
                    _currentorders.WorkerCodeMasNavigation = Combox3.SelectedItem as EF.Worker;
                   
                    foreach (var item in _currentstock)
                    {
                        if (item.StockCode != 0)
                        {
                            continue;
                        }
                        item.OrdersCode = _currentorders.OrdersCode;
                        App.Context.Stocks.Add(item);
                    }
                    App.Context.SaveChanges();

                    //_currentstock.Quantity = long.Parse(TextboxQuntdet.Text);

                    NavigationService.Navigate(new Pages_table.OrdersPageForProduct());
                }
              
               

               
           

            }
        }

        private void editDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages_table.Details(this));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
          
            if(_currentstock != null && _currentstock.Count>0)
            {
               
                allsum.Text = AllPrice(_currentstock).ToString();
                CostDet.Text = CostPrice(_currentstock).ToString();
                CostService.Text = CostServiceFun(_currentstock).ToString();
            }
        }
    }
}
