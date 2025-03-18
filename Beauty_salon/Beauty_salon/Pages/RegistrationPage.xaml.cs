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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        private User user = new User();
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SurnameTb.Text) && !string.IsNullOrEmpty(FirstnameTb.Text) && !string.IsNullOrEmpty(PatronymicTb.Text) && 
                !string.IsNullOrEmpty(BirthDp.Text) && !string.IsNullOrEmpty(PhoneTb.Text) && !string.IsNullOrEmpty(LoginTb.Text) && !string.IsNullOrEmpty(PasswordPb.Password))
            {
                user.Surname = SurnameTb.Text;
                user.Name = FirstnameTb.Text;
                user.Patronymic = PatronymicTb.Text;
                user.Birth = BirthDp.SelectedDate;
                user.Phone = PhoneTb.Text;
                user.Login = LoginTb.Text;
                user.Password = PasswordPb.Password;
                App.db.User.Add(user);
                App.db.SaveChanges();
                Client client = new Client();
                client.DateStart = DateTime.Now;
                client.DiscountPercentage = 0;
                client.Scores = 0;
                client.UserId = App.db.User.ToList().Last().Id;
                App.db.Client.Add(client);
                App.db.SaveChanges();
                MessageBox.Show("Вы зарегистрированы!");
                Navigations.NextMainPage(new AutharizationPage());
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены!");
            }
        }

        private void EntryBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigations.NextMainPage(new AutharizationPage());
        }
    }
}
