using Beauty_salon.Pages;
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

namespace Beauty_salon.Components.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ServiceUserControl.xaml
    /// </summary>
    public partial class ServiceUserControl : UserControl
    {
        private Service service;
        public ServiceUserControl(Service _service)
        {
            InitializeComponent();
            service = _service;
            TitleTb.Text = service.Title;
            TimeTb.Text = service.TimeService.ToString();
            IEnumerable<Stock> stocks = App.db.Stock.Where(x => x.ServiceId == service.Id && x.DateStart <= DateTime.Now && x.DateEnd > DateTime.Now).ToList();
            if (stocks.Count() > 0)
            {
                SaleTb.Text = "Скидка до  " + stocks.Last().DateEnd + " составляет " + stocks.Last().PercentStock + "%";
                PriceDoTb.Text = service.Price.ToString();
                PricePoTb.Text = (service.Price - (service.Price / 100 * stocks.Last().PercentStock)).ToString();
            }
            else if (App.thisUser.Client.Count > 0)
            {
                if (App.thisUser.Client.ToList().First().DiscountPercentage > 0)
                {
                    SaleTb.Text = "Ваша персональная скидка " + App.thisUser.Client.ToList().First().DiscountPercentage + "%";
                    PriceDoTb.Text = service.Price.ToString();
                    PricePoTb.Text = (service.Price - (service.Price / 100 * App.thisUser.Client.ToList().First().DiscountPercentage)).ToString();
                }
            }
            else
            {
                SaleTb.Visibility = Visibility.Collapsed;
                PriceDoTb.Visibility = Visibility.Collapsed;
                PricePoTb.Foreground = Brushes.Black;
                PricePoTb.Text = service.Price.ToString();
            }
            IEnumerable<MaterialService> materials = service.MaterialService.ToList();
            foreach(var material in materials)
            {
                MaterialsTb.Text += material.Material.Title + " - " + material.QuantityMaterial + ", ";
            }
            string text = MaterialsTb.Text.Remove(MaterialsTb.Text.Length - 2);
            MaterialsTb.Text = text + ".";

            if (App.thisUser.Client.Count > 0)
            {
                EditBtn.Visibility = Visibility.Collapsed;
                DeleteBtn.Visibility = Visibility.Collapsed;
            }
            else
            {
                OrderBtn.Visibility = Visibility.Collapsed;
            }

        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (service.Order.Count() > 0)
            {
                MessageBox.Show("На эту услугу есть записи, ее нельзя удалить!");
            }
            else
            {
                App.db.Service.Remove(service);
                App.db.SaveChanges();
                MessageBox.Show("Услуга удалена!");
                Navigations.NextCenterPage(new ListServicePage());
            }
        }
    }
}
