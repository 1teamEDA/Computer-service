using DimaUrsova.EF;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace DimaUrsova.Pages.Pages_table
{
    /// <summary>
    /// Логика взаимодействия для OrdersPageForProduct.xaml
    /// </summary>
    public partial class OrdersPageForProduct : Page
    {
        public OrdersPageForProduct()
        {
            InitializeComponent();
            OrdersPage1.Items.Clear();
            OrdersPage1.ItemsSource = Update(SearchBox.Text);
            //ComboboxPriceChar.ItemsSource = new List<string> { "Неділя", "Місяць","Рік" };

        }

        private List<EF.Ordersss> Update(string search) 
        {
            var source = App.Context.Orderssses.ToList();
            if (!String.IsNullOrWhiteSpace(search))
            {
                source = source.Where(p=>p.AllSearch.ToLower().Contains(search.ToLower())).ToList();
            }
            return source;
        }
        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var context = (sender as Button).DataContext as EF.Ordersss;
            App.Context.Orderssses.Remove(context);
           
            App.Context.SaveChanges();



            NavigationService.Navigate(new Pages.Pages_table.OrdersPageForProduct());
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var context = (sender as Button).DataContext as EF.Ordersss;
            NavigationService.Navigate(new Pages.Pages_table.AddOrders(context));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            OrdersPage1.ItemsSource = Update(SearchBox.Text);
            AllOrdersRadio.IsChecked = true;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;

           
            var allOrders = App.Context.Orderssses.ToList();

         
            OrdersPage1.ItemsSource = allOrders;
        }




        private void BtnOrders_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Pages_table.AddOrders(null));
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            var filteredData = App.Context.Orderssses.Where(p => p.Status == "Виконано").ToList();
            OrdersPage1.ItemsSource = filteredData;
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            
                   var radioButton = sender as RadioButton;
            var filteredData = App.Context.Orderssses.Where(p => p.Status == "Виконується").ToList();
            OrdersPage1.ItemsSource = filteredData;
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            var filteredData = App.Context.Orderssses.Where(p => p.Status == "Активні").ToList();
            OrdersPage1.ItemsSource = filteredData;
        }

        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            var filteredData = App.Context.Orderssses.Where(p => p.Status == "На діагностиці").ToList();
            OrdersPage1.ItemsSource = filteredData;

        }

        private void BtnOrdersSearch_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void OrdersPage1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            
            var block = (sender as TextBlock);
            if (block == null)
            {
                return;
            }
            //MessageBox.Show(block.Text);
            var datacontext = block.DataContext as EF.Ordersss;
            if (datacontext == null)
            {
                return;
            }
            if (block.ActualWidth<150)
            {
                block.Text = datacontext.ShortDetails.ToString();  
            }
            else
            {
                block.Text = datacontext.NameDevice.ToString();  
            }

        }
        
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SearchBox.Text))
            {
                // Если комбобокс содержит текст, скрываем текстовый блок
                SearchPlc.Visibility = Visibility.Collapsed;
            }
            else
            {
                // Если комбобокс пустой, отображаем текстовый блок
                SearchPlc.Visibility = Visibility.Visible;
            }
            OrdersPage1.ItemsSource = Update(SearchBox.Text);
        }

        //private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (ComboboxPriceChar.ItemsSource != null)
        //    {
        //        string selectedPeriod = ((ComboBoxItem)ComboboxPriceChar.SelectedItem).Content.ToString();
        //        DateTime startDate, endDate;

        //        // Определение начальной и конечной даты в соответствии с выбранным периодом
        //        if (selectedPeriod == "Неделя")
        //        {
        //            startDate = DateTime.Today.AddDays(-7);
        //            endDate = DateTime.Today;
        //        }
        //        else if (selectedPeriod == "Місяць")
        //        {
        //            startDate = DateTime.Today.AddMonths(-1);
        //            endDate = DateTime.Today;
        //        }
        //        else if (selectedPeriod == "Рік")
        //        {
        //            startDate = DateTime.Today.AddYears(-1);
        //            endDate = DateTime.Today;
        //        }
        //        else
        //        {
        //            return; // Если выбран неверный период, прекратить выполнение метода
        //        }

        //        decimal totalIncome = 0;

        //        List<decimal> filteredData = new List<decimal>();
        //        EF.Ordersss ordersss = new EF.Ordersss();
        //        foreach (decimal income in ordersss)
        //        {
        //            DateTime incomeDate = GetIncomeDate(income); // Здесь необходимо определить дату дохода
        //            if (incomeDate >= startDate && incomeDate <= endDate)
        //            {
        //                filteredData.Add(income);
        //            }
        //        }

        //        foreach (decimal income in filteredData)
        //        {
        //            totalIncome += income;
        //        }

        //        // Вывод суммы дохода в текстовом блоке
        //        incomeTextBlock.Text = $"Сумма дохода за {selectedPeriod.ToLower()}: {totalIncome}";
        //    }
        //}

        private DateTime GetIncomeDate(double income)
        {
            // Подключение к базе данных и запрос для получения даты дохода на основе значения income
            using (var context = new _123Context()) // Замените YourDbContext на свой собственный класс контекста
            {
                var ordersss = new Ordersss(); // Создание экземпляра Ordersss
                var incomeRecord = context.Orderssses.FirstOrDefault(i => i.AllSum == income);
                if (incomeRecord != null)
                {
                    DateTime incomeDate = DateTime.Parse(incomeRecord.DateOrder);
                    return incomeDate;
                }
            }

            return DateTime.Now;
        }
    }

}
