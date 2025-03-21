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
    /// Логика взаимодействия для EmployeeUserControl.xaml
    /// </summary>
    public partial class EmployeeUserControl : UserControl
    {
        private User user;
        public EmployeeUserControl(User _user)
        {
            InitializeComponent();
            user = _user;
            FioTb.Text = $"{user.Surname} {user.Name} {user.Patronymic}";
            int age = DateTime.Now.Year - user.Birth.Value.Year;
            AgeTb.Text = age.ToString();
            PriceTb.Text = user.Employee.First().SalaryRate.ToString() + "руб.";
            SpecTb.Text = user.Employee.First().Specialization.Title;
            IEnumerable<Course> courses = user.Employee.First().Course;
            foreach (Course course in courses)
            {
                CourseTb.Text += course.Name + ", ";
            }
            if (courses.Count() > 0)
            {
                string text = CourseTb.Text.Remove(CourseTb.Text.Count() - 2);
                CourseTb.Text = text + ".";
            }
            else
            {
                CourseTb.Text = "-";
            }
        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
