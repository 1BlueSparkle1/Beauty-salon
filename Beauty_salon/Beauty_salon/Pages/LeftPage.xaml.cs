using Beauty_salon.Components;
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
    /// Логика взаимодействия для LeftPage.xaml
    /// </summary>
    public partial class LeftPage : Page
    {
        public LeftPage()
        {
            InitializeComponent();
            if (App.thisUser.Client.Count() > 0)
            {

            }
            else
            {
                if (App.thisUser.Employee.First().Specialization.Title == "Админ")
                {
                    ClientSp.Visibility = Visibility.Collapsed;
                }
                else
                {
                    ClientSp.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void MessageBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FeedbackBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            App.thisUser = new User();
            Navigations.NextMainPage(new AutharizationPage());
        }

        private void ServiceBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigations.NextCenterPage(new ListServicePage());
        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
