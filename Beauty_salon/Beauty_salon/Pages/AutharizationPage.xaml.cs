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
    /// Логика взаимодействия для AutharizationPage.xaml
    /// </summary>
    public partial class AutharizationPage : Page
    {
        public AutharizationPage()
        {
            InitializeComponent();
        }

        private void EntryBtn_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<User> users = App.db.User.ToList();
            foreach(var user in users)
            {
                if (user.Login == LoginTb.Text)
                {
                    if (user.Password == PasswordPb.Password)
                    {
                        App.thisUser = user;
                    }
                }
            }
            if (App.thisUser.Id == 0)
            {
                MessageBox.Show("Пользователь не найден!");
            }
            else
            {
                IEnumerable<Client> clients = App.thisUser.Client.ToList();
                IEnumerable<Employee> employees = App.thisUser.Employee.ToList();
                if (employees.Count() > 0)
                {
                    Navigations.NextMainPage(new EmptyPage());
                    Navigations.NextLeftPage(new LeftPage());
                    Navigations.NextTopPage(new TopPage());
                    Navigations.NextCenterPage(new EmptyPage());
                    if (employees.First().SpecializationId == 1)
                    {
                        Navigations.NextCenterPage(new ListServicePage());
                    }
                }
                else if (clients.Count() > 0)
                {
                    int date = DateTime.Now.Year - clients.First().DateStart.Value.Year;
                    if ((int)(date/2)*5 > 40)
                    {
                        clients.First().DiscountPercentage = 40;
                    }
                    else
                    {
                        clients.First().DiscountPercentage = (int)(date / 2) * 5;
                    }
                    App.db.SaveChanges();
                    Navigations.NextMainPage(new EmptyPage());
                    Navigations.NextLeftPage(new LeftPage());
                    Navigations.NextTopPage(new TopPage());
                    Navigations.NextCenterPage(new ListServicePage());
                }
                else
                {
                    MessageBox.Show("Что-то пошло не так. Пожалуйста, обратитесь к администратору!");
                }
            }
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigations.NextMainPage(new RegistrationPage());
        }
    }
}
