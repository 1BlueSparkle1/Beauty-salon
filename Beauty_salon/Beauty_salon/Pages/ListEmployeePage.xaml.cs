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
    /// Логика взаимодействия для ListEmployeePage.xaml
    /// </summary>
    public partial class ListEmployeePage : Page
    {
        public ListEmployeePage()
        {
            InitializeComponent();
            IEnumerable<User> users = App.db.User.Where(x => x.Employee.Count() > 0);
            foreach (User user in users)
            {
                EmployeeWp.Children.Add(new EmployeeUserControl(user));
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
