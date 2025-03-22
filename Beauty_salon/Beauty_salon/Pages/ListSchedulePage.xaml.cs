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
    /// Логика взаимодействия для ListSchedulePage.xaml
    /// </summary>
    public partial class ListSchedulePage : Page
    {
        public ListSchedulePage()
        {
            InitializeComponent();
            if (App.thisUser.Employee.First().SpecializationId == 1)
            {
                AddBtn.Visibility = Visibility.Collapsed;
                IEnumerable<Schedule> schedules = App.db.Schedule.Where(x => x.DateSchedule >= DateTime.Now);
                foreach(var schedule in schedules)
                {
                    ScheduleWp.Children.Add(new ScheduleUserControl(schedule));
                }
            }
            else
            {
                SortSp.Visibility = Visibility.Collapsed;
                int id = App.thisUser.Employee.First().Id;
                IEnumerable<Schedule> schedules = App.db.Schedule.Where(x => x.DateSchedule >= DateTime.Now && x.EmployeeId == id);
                foreach (Schedule schedule in schedules)
                {
                    ScheduleWp.Children.Add(new ScheduleUserControl(schedule));
                }
            }
            EmployeeCb.ItemsSource = App.db.User.Where(x => x.Employee.Count() > 0).ToList();
            EmployeeCb.DisplayMemberPath = "Surname";
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigations.NextCenterPage(new AddSchedulePage());
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            User employee = (User)EmployeeCb.SelectedItem;
            IEnumerable<Schedule> schedules  = App.db.Schedule.Where(x => x.DateSchedule == DateDp.SelectedDate);
            if (EmployeeCb.SelectedIndex != 0)
            {
                schedules = App.db.Schedule.Where(x => x.DateSchedule == DateDp.SelectedDate && x.Employee.UserId == employee.Id);
            }
            ScheduleWp.Children.Clear();
            foreach (var schedule in schedules)
            {
                ScheduleWp.Children.Add(new ScheduleUserControl(schedule));
            }

        }
    }
}
