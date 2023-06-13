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
    /// Логика взаимодействия для AddDetal.xaml
    /// </summary>
    public partial class AddDetal : Page
    {
        public AddDetal(EF.Detail det)
        {
            InitializeComponent();
            exampleGrid.DataContext = det;
            if (det !=null)
            {
                
                TextBNameDetails.Text = det.NameDetails;
                TextbQuantityInstock.Text = det.QuantityInstock.ToString();
                TextBCostDetails.Text = det.CostDetails.ToString();
                TextBCostService.Text = det.CostService.ToString();
            }

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
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (exampleGrid.DataContext as Details == null)
            {
                EF.Detail detail = new Detail();
                detail.NameDetails = TextBNameDetails.Text;
                detail.QuantityInstock = long.Parse(TextbQuantityInstock.Text);
                detail.CostDetails = long.Parse(TextBCostDetails.Text);
                detail.CostService = long.Parse(TextBCostService.Text);
                App.Context.Details.Add(detail);
                App.Context.SaveChanges();

            }
            else
            {
                App.Context.SaveChanges();

            }
            NavigationService.GoBack();
        }
    }
}
