using Dark.Net;
using DimaUrsova.Pages.LiveChart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DimaUrsova
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            const Theme windowTheme = Theme.Dark;
            DarkNet.Instance.SetWindowThemeWpf(this, windowTheme);
            InitializeComponent();
            FrameMain.Navigate(new Pages.login());
            //var a = App.Context.Orderssses.FirstOrDefault().StockNavigation();
            //foreach (var item in a)
            //{
            //    MessageBox.Show($"для первого заказа: {item.Quantity} {item.DetailsCodeNavigation.NameDetails}");
            //}
        }

       
        
    }
}
