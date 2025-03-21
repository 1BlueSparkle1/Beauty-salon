using Beauty_salon.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        private User user;
        public ProfilePage(User _user)
        {
            InitializeComponent();
            user = _user;
            if (user.Client.Count() > 0)
            {
                EmployeeSp.Visibility = Visibility.Collapsed;
                ScoreTb.Text = user.Client.First().Scores.ToString();
                DiscountTb.Text = user.Client.First().DiscountPercentage.ToString() + "%";
            }
            else
            {
                ClientSp.Visibility = Visibility.Collapsed;
                PriceTb.Text = user.Employee.First().SalaryRate.ToString() + "руб.";
                IEnumerable<Course> courses = user.Employee.First().Course.ToList();
                foreach (Course course in courses)
                {
                    CourseTb.Text += course.Name + ", ";
                }
                if (courses.Count()> 0)
                {
                    string text = CourseTb.Text.Remove(CourseTb.Text.Count() - 2);
                    CourseTb.Text = text + ".";
                }
                else
                {
                    CourseTb.Text = "-";
                }
            }
            SaveBtn.Visibility = Visibility.Collapsed;
            SurnameTb.Text = user.Surname;
            NameTb.Text = user.Name;
            PatronymicTb.Text = user.Patronymic;
            BirthDp.SelectedDate = user.Birth;
            PhoneTb.Text = user.Phone;
            LoginTb.Text = user.Login;
            PasswordTb.Text = user.Password;


        }

        private void PhoneTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[^0-9]"))
            {
                e.Handled = true;
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            SurnameTb.IsEnabled = true;
            NameTb.IsEnabled = true;
            PatronymicTb.IsEnabled = true;
            BirthDp.IsEnabled = true;
            PhoneTb.IsEnabled = true;
            LoginTb.IsEnabled = true;
            PasswordTb.IsEnabled = true;
            EditBtn.Visibility = Visibility.Collapsed;
            SaveBtn.Visibility = Visibility.Visible;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            user.Surname = SurnameTb.Text;
            user.Name = NameTb.Text;
            user.Patronymic = PatronymicTb.Text;
            user.Birth = BirthDp.SelectedDate;
            user.Phone = PhoneTb.Text;
            user.Login = LoginTb.Text;
            user.Password = PasswordTb.Text;
            App.db.SaveChanges();
            MessageBox.Show("Изменения сохранены!");

            SurnameTb.IsEnabled = false;
            NameTb.IsEnabled = false;
            PatronymicTb.IsEnabled = false;
            BirthDp.IsEnabled = false;
            PhoneTb.IsEnabled = false;
            LoginTb.IsEnabled = false;
            PasswordTb.IsEnabled = false;
            EditBtn.Visibility = Visibility.Visible;
            SaveBtn.Visibility = Visibility.Collapsed;
        }
    }
}
