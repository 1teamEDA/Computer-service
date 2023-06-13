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
    /// Логика взаимодействия для Details.xaml
    /// </summary>
    public partial class Details : Page
    {
        public double AllPrice = 0;
        Pages.Addinfo parentPage = null;
        public Details(Pages.Addinfo page)
        {
            InitializeComponent();
            
            if (page._currentstock == null) {
                page._currentstock = new List<Stock>() { };
                
            }
            else if (page._currentstock != null && page._currentstock.Count>0)
            {

                var i = 0;

                foreach (var stock in page._currentstock)
                {


                    Label newInfoTextBlock = new Label();
                    newInfoTextBlock.Content = $"Назва деталі: {stock.DetailsCodeNavigation.NameDetails}";
                    newInfoTextBlock.Foreground = new SolidColorBrush(Colors.White);

                    Label newInfoTextBlockForQuantity = new Label();
                    newInfoTextBlockForQuantity.Content = $"Кількість детелей: {stock.Quantity}";
                    newInfoTextBlockForQuantity.Foreground = new SolidColorBrush(Colors.White);

                    StackPanelForInfoDet.Children.Add(newInfoTextBlock);
                    StackPanelForInfoDet.Children.Add(newInfoTextBlockForQuantity);

                
            }
                //MessageBox.Show("А это значит, что у тебя передаваемый список не пустой, и по хорошему ты должен его вот тут,где этот текст, вывести в тот самый стакпанель)");
            }
            parentPage = page;
            ComboboxForAddDet.ItemsSource = App.Context.Details.ToList();
            ComboboxForAddDet.DisplayMemberPath = "NameDetails";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //TextBlock InfoForDet = new TextBlock();
            //EF.Detail _infocombo = ComboboxForAddDet.SelectedItem as EF.Detail ;
            
       
            string textBoxText = TextBoxForQuan.Text;
            double? cost = 0;
            if (!string.IsNullOrEmpty(textBoxText) && long.TryParse(textBoxText, out _))
            {
                EF.Detail selectedDetail = ComboboxForAddDet.SelectedItem as EF.Detail;
                EF.Stock stock = new Stock();
                stock.DetailsCodeNavigation = selectedDetail;
                parentPage._currentstock.Add(stock);
                
                stock.Quantity = long.Parse(textBoxText);
              

                Label newInfoTextBlock = new Label();
                newInfoTextBlock.DataContext = stock;
                newInfoTextBlock.Content = $"Назва деталі: {stock.DetailsCodeNavigation.NameDetails}" ;
                newInfoTextBlock.Foreground = new SolidColorBrush(Colors.White);
              

                Label newInfoTextBlockForQuantity = new Label();
                //newInfoTextBlockForQuantity.DataContext = textBoxText;
                newInfoTextBlockForQuantity.Content = $"Кількість детелей: {textBoxText}";
                newInfoTextBlockForQuantity.Foreground = new SolidColorBrush(Colors.White);

                stock.Quantity = long.Parse(textBoxText);
                StackPanelForInfoDet.Children.Add(newInfoTextBlock);
                StackPanelForInfoDet.Children.Add(newInfoTextBlockForQuantity);

                //selectedDetail.NameDetails = parentPage._currentstock.ToString();
                //textBoxText = parentPage._currentstock.ToString();
                //parentPage._currentstock.Add(stock);
                //parentPage._currentstock.Add(selectedDetail.NameDetails);

            }
            else
            {
                InfoForDet.Text = "Не обрана деталь чи не задана кількість.";
            }
            
            //Details detel = new Details(selectedDetail.NameDetails);
            //parentPage._currentstock.Add(selectedDetail.NameDetails);

            //Stock stock = new Stock(textBoxText); 
            //parentPage._currentstock.Add(stock);
        }

        private void SaveDet_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
