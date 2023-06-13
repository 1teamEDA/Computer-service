using DimaUrsova.Pages.Pages_table;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DimaUrsova.Pages
{
    /// <summary>
    /// Логика взаимодействия для Ordersmain.xaml
    /// </summary>
    public partial class Ordersmain : Page
    {
        public Ordersmain(EF.Login user)
        {
            InitializeComponent();
            //textblock.Text = $"{user.Login1} {user.PositionWorker}";
            GridContext.DataContext = this;
            UserRole.Text = user.PositionWorker;
            UserName.Text = user.Login1;
            FrameMain11.Navigate(App.OrdersPages);
        
        }

       

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {

            //FrameMain1.Navigate(new Pages.login());
            NavigationService.Navigate(new Pages.login());
            //if (FrameMain.CanGoBack)
            //{
            //    FrameMain.GoBack();

            //}

        }
         

        private void Button_orders(object sender, RoutedEventArgs e)
        {
            FrameMain11.NavigationService.Navigate(App.WorkPages);
            
        }

        private void Button_workers(object sender, RoutedEventArgs e)
        {
            FrameMain11.NavigationService.Navigate(App.OrdersPages);
        }
        private void Button_customers(object sender, RoutedEventArgs e)
        {
            FrameMain11.NavigationService.Navigate(App.CustomerPages);
        }

        private void Button_details(object sender, RoutedEventArgs e)
        {
            FrameMain11.NavigationService.Navigate(App.DetailsPages);
        }

        private void Button_addinfo(object sender, RoutedEventArgs e)
        {
           
            FrameMain11.NavigationService.Navigate(new Pages.LiveChart.LiveChatPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameMain11.NavigationService.Navigate(App.PolzavatelPages);
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void WorkersNavBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            if (FrameMain11.Content.Equals(App.OrdersPages))
            {
                (sender as Button).ToolTip = null;
                return;
            }
            (sender as Button).ToolTip = EFextend.TooltipTemplate.Template(App.OrdersPages, "Закази");
        }

        private void GroupsNavBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            if (FrameMain11.Content.Equals(App.WorkPages))
            {
                (sender as Button).ToolTip = null;
                return;
            }
            (sender as Button).ToolTip = EFextend.TooltipTemplate.Template(App.WorkPages, "Співробітники");
        }

        private void BuyersNavBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            if (FrameMain11.Content.Equals(App.CustomerPages))
            {
                (sender as Button).ToolTip = null;
                return;
            }
            (sender as Button).ToolTip = EFextend.TooltipTemplate.Template(App.CustomerPages, "Клієнти");
        }

        private void CostNavBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            if (FrameMain11.Content.Equals(App.DetailsPages))
            {
                (sender as Button).ToolTip = null;
                return;
            }
            (sender as Button).ToolTip = EFextend.TooltipTemplate.Template(App.DetailsPages, "Деталі");
        }

 
        private void ProfileMenu_Click(object sender, RoutedEventArgs e)
        {
            Storyboard appearAnimation = (Storyboard)FindResource("VisibleMenu");
            Storyboard disappearAnimation = (Storyboard)FindResource("HiddenMenu");
            if (UserMenu.Visibility == Visibility.Visible) {
                //ProfileMenu.Content = CopyButton.Content ;
                disappearAnimation.Begin();
            } 
            else
            {
                appearAnimation.Begin();
                //CopyButton.Content = ProfileMenu.Content;
            }
           
        }

        private void UserMenu_MouseLeave(object sender, MouseEventArgs e)
        {
            Task.Delay(5000);
            Storyboard disappearAnimation = (Storyboard)FindResource("HiddenMenu");
            disappearAnimation.Begin();
        }

        private void CopyButton_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ProfileMenu_Click(sender, e);
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.login());
        }
        public string AdminControlsVisibility
        {
            get
            {
                return App.CurrentUser.PositionWorker == "Адміністратор" ? "Visible" : "Collapsed";
            }

        }
    }
   

}
