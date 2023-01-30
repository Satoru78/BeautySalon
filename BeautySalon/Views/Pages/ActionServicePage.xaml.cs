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
    /// Логика взаимодействия для ActionServicePage.xaml
    /// </summary>
    public partial class ActionServicePage : Page
    {
        public Service Service { get; set; }
        public List<Client> Clients { get; set; }
        public ActionServicePage(Service service)
        {
            InitializeComponent();
            Service = service;
            Clients = Data.db.Client.ToList();
            this.DataContext = this;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Service.ID == 0)
                {
                    Data.db.Service.Add(Service);
                }
                Data.db.SaveChanges();
                MessageBox.Show("Данные сохранены", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Произошла ошибка");
            }
        }
    }
}
