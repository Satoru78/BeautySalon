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

namespace BeautySalon.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ClientDataBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientAddPage(new Model.Client()));
        }

        private void ServiceAddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ActionServicePage(new Model.Service()));

        }

        private void ServiceListBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ServiceListPage(new Model.Service()/*, new Model.Masters() , new Model.ServiceType() , new Model.Client()*/)); 

        }
    }
}
