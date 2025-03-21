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
                EmployeeSp.Visibility = Visibility.Collapsed;
                AdminSp.Visibility = Visibility.Collapsed;
            }
            else
            {
                if (App.thisUser.Employee.First().Specialization.Title == "Админ")
                {
                    ClientSp.Visibility = Visibility.Collapsed;
                    EmployeeSp.Visibility = Visibility.Collapsed;
                }
                else
                {
                    ClientSp.Visibility = Visibility.Collapsed;
                    AdminSp.Visibility = Visibility.Collapsed;
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



        private void ScheduleBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MessageEmpBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OrderEmpBtn_Click(object sender, RoutedEventArgs e)
        {

        }



        private void ServiceAdmBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigations.NextCenterPage(new ListServicePage());
        }

        private void FeedbackAdmBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ScheduleAdmBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CourseBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigations.NextCenterPage(new ListEmployeePage());
        }

        private void ReportBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MessageAdmBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MaterialBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigations.NextCenterPage(new ListMaterialPage());
        }
    }
}
