using BeautySalon.Context;
using BeautySalon.Model;
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
    /// Логика взаимодействия для ServiceListPage.xaml
    /// </summary>
    public partial class ServiceListPage : Page
    {
        public Client Client { get; set; }
        //public List<Client> Clients { get; set; }
        public Service Service { get; set; }

        public Masters Masters { get; set; }
        //public List<Masters> Masterss { get; set; }
        //public List<ServiceType> ServiceTypes { get; set; }
        public ServiceType ServiceType { get; set; }

        public List<Service> Services { get; set; }
        public ServiceListPage(Service service/*, Masters masters, ServiceType serviceType , Client client*/)
        {
            InitializeComponent();
            Service = service;
            //Masters = masters;
            //ServiceType = serviceType;
            //Client = client;
            this.DataContext = this;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Services = Data.db.Service.ToList();
            //Clients = Data.db.Client.ToList();
            //ServiceTypes = Data.db.ServiceType.ToList();
            //Masterss = Data.db.Masters.ToList();
            //ServiceDataGtid.ItemsSource = Masterss;
            //ServiceDataGtid.ItemsSource = ServiceTypes;
            //ServiceDataGtid.ItemsSource = Clients;
            ServiceListView.ItemsSource = Services;
        }
        private List<Service> CheckDateObject(List<Service> collection)
        {
            List<Service> list = new List<Service>();
            foreach (Service item in collection)
            {
                if (item.DateOfRecording < DateTime.Now)
                {
                    list.Add(item);
                }
            }
            if (list.Count > 0)
            {
                return list;
            }
            else
            {
                return null;
            }
            }
            private void CheckDate_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckDateObject(Data.db.Service.ToList()) != null)
            {
                ServiceListView.ItemsSource = CheckDateObject(Data.db.Service.ToList());
            }
            else
            {
                MessageBox.Show("Записей на услугу нп ближайшее время нет", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                CheckDate.IsChecked = false;
            }
        }

        private void CheckDate_Unchecked(object sender, RoutedEventArgs e)
        {
            Page_Loaded(null, null);

        }
    }
}
