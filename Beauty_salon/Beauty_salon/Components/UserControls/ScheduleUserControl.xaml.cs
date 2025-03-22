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
    /// Логика взаимодействия для ScheduleUserControl.xaml
    /// </summary>
    public partial class ScheduleUserControl : UserControl
    {
        public ScheduleUserControl(Schedule schedule)
        {
            InitializeComponent();
            DateTb.Text = schedule.DateSchedule.ToString().Remove(schedule.DateSchedule.ToString().Count() - 8);
            EmployeeTb.Text = $"{schedule.Employee.User.Surname} {schedule.Employee.User.Surname} {schedule.Employee.User.Surname}";
            TimeStartTb.Text = schedule.TimeStart.ToString();
            TimeEndTb.Text = schedule.TimeEnd.ToString();
            if (App.thisUser.Employee.First().SpecializationId > 1)
            {
                EmpSp.Visibility = Visibility.Collapsed;
            }
        }
    }
}
