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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DimaUrsova.Pages.Pages_table
{
    /// <summary>
    /// Логика взаимодействия для DetailsPage.xaml
    /// </summary>
    public partial class DetailsPage : Page
    {
        public DetailsPage()
        {
            InitializeComponent();
            DetailsPage1.Items.Clear();
            DetailsPage1.ItemsSource = Update(SearchBox.Text);
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
            DetailsPage1.ItemsSource = Update(SearchBox.Text);
        }

        private void OrdersPage1_SizeChanged(object sender, SizeChangedEventArgs e)
        {

            var block = (sender as TextBlock);
            if (block == null)
            {
                return;
            }
            //MessageBox.Show(block.Text);
            var datacontext = block.DataContext as EF.Detail;
            if (datacontext == null)
            {
                return;
            }

        }

        private List<EF.Detail> Update(string search)
        {
            var source = App.Context.Details.ToList();
            if (!String.IsNullOrWhiteSpace(search))
            {
                source = source.Where(p => p.AllSearch.ToLower().Contains(search.ToLower())).ToList();
            }
            return source;
        }




    


    

        private void BtnOrders_Click(object sender, RoutedEventArgs e)
        {
            
            NavigationService.Navigate(new Pages.Pages_table.AddDetal(null));

        }
        
      
        private void Del_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var context = (sender as Button).DataContext as EF.Detail;
                App.Context.Details.Remove(context);

                App.Context.SaveChanges();

                NavigationService.Navigate(new Pages.Pages_table.DetailsPage());
            }
            catch (Exception)
            {
                MessageBox.Show("Помилка, cпочатку видалите заказ з цією послугою");

            }

        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var context = (sender as Button).DataContext as EF.Detail;
            NavigationService.Navigate(new Pages.Pages_table.AddDetal(context));

        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                App.Context.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DetailsPage1.ItemsSource = App.Context.Details.ToList();

            }
            catch
            {


            }

        }


    }
}
