using Beauty_salon.Components;
using Beauty_salon.Components.UserControls;
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

namespace Beauty_salon.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListServicePage.xaml
    /// </summary>
    public partial class ListServicePage : Page
    {
        public ListServicePage()
        {
            InitializeComponent();
            if (App.thisUser.Employee.Count > 0)
            {
                AddBtn.Visibility = Visibility.Visible;
            }
            else
            {
                AddBtn.Visibility = Visibility.Collapsed;
            }
            IEnumerable<Service> services = App.db.Service.ToList();
            foreach (var service in services)
            {
                ServiceWp.Children.Add(new ServiceUserControl(service));
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
