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
    /// Логика взаимодействия для AddSchedulePage.xaml
    /// </summary>
    public partial class AddSchedulePage : Page
    {
        public AddSchedulePage()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TimeSpan.Parse(StartTb.Text) > TimeSpan.Parse(EndTb.Text))
            {
                MessageBox.Show("Нельзя, чтобы время начала было больше завершения!");
            }
            else
            {
                Schedule schedule = new Schedule();
                schedule.DateSchedule = DateDp.SelectedDate;
                schedule.EmployeeId = App.thisUser.Employee.First().Id;
                schedule.TimeStart = TimeSpan.Parse(StartTb.Text);
                schedule.TimeEnd = TimeSpan.Parse(EndTb.Text);
                App.db.Schedule.Add(schedule);
                App.db.SaveChanges();
                MessageBox.Show("Рабочий день записан!");
                Navigations.NextCenterPage(new ListSchedulePage());
            }

        }
    }
}
