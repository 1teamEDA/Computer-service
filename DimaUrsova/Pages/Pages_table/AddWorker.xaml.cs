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
    /// Логика взаимодействия для AddWorker.xaml
    /// </summary>
     public partial class AddWorker : Page
    {
        public AddWorker(EF.Worker worker)
        {
            InitializeComponent();
            ComboBPositionCode.ItemsSource = App.Context.Positionnns.ToList();
  
            exampleGrid.DataContext = worker;
            if (worker != null )
            {

                ComboBPositionCode.SelectedItem = worker.PositionCodeNavigation ;
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
        private void OnlyLetters_KeyUp(object sender, KeyEventArgs e)
        {
            int count = -1;
            if (((e.Key >= Key.D0 && e.Key <= Key.D9) ||
                (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) ||
                e.Key == Key.Back || e.Key == Key.Delete))
            {
                e.Handled = true;
            }
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (exampleGrid.DataContext as EF.Worker == null)
            {
                var workers = new EF.Worker
                {
                WorkerPib = TextBWorkerPib.Text,
                WorkerNumber = TextbWorkerNumber.Text,
                WorkerDocument = TextBWorkerDocument.Text,
                PositionCodeNavigation = ComboBPositionCode.SelectedItem as EF.Positionnn,
            };



                //EF.Worker workers = new Worker();
                //workers.WorkerPib = TextBWorkerPib.Text;
                //workers.WorkerNumber = TextbWorkerNumber.Text;
                //workers.WorkerDocument = TextBWorkerDocument.Text;
                //workers.PositionCodeNavigation = ComboBPositionCode.SelectedItem as Positionnn;

                App.Context.Workers.Add(workers);
                App.Context.SaveChanges();
                NavigationService.GoBack();
            }
            else
            {

                App.Context.SaveChanges();

                NavigationService.GoBack();

            }

           
        }
    }
}
