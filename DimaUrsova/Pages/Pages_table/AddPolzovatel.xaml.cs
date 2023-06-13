using DimaUrsova.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
    /// Логика взаимодействия для AddPolzovatel.xaml
    /// </summary>
    public partial class AddPolzovatel : Page
    {
        public AddPolzovatel(EF.Login polzov )
        {
            InitializeComponent();
            exampleGrid.DataContext = polzov;
            ComboBCPositionWorker.Items.Clear();
            ComboBCPositionWorker.ItemsSource = new List<string> { "Адміністратор", "Менеджер"  };
            if (polzov !=null)
            {
             
                ComboBCPositionWorker.SelectedItem = polzov.PositionWorker;
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (exampleGrid.DataContext as EF.Login == null)
            {
                EF.Login polzov1 = new EF.Login();
                polzov1.Login1 = TextBLogin1.Text;
                polzov1.Password = TextbPassword.Text;
                polzov1.PositionWorker = ComboBCPositionWorker.Text;
                App.Context.Add(polzov1);
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
