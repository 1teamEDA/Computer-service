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

namespace DimaUrsova.Pages
{
    /// <summary>
    /// Логика взаимодействия для login.xaml
    /// </summary>
    public partial class login : Page
    {
        public login()
        {
            InitializeComponent();
        
    }
        
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            
        var currentUser = App.Context.Logins.FirstOrDefault(p => p.Login1 == TBoxLogin.Text && p.Password == PBoxPassword.Password);

            if (currentUser != null)
            {
                App.CurrentUser = currentUser;
                NavigationService.Navigate(new Pages.Ordersmain(currentUser));
                NavigationService.RemoveBackEntry();
            }
            else
            {
                ErrorBlock.Text = "Не має такого користувача";
            }

            //FrameMain1.Navigate(new Pages.login());

            //if (FrameMain.CanGoBack)
            //{
            //    FrameMain.GoBack();

            //}
            
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BtnLogin_Click(Btnlogin, null);
            }
        }
    }

}
