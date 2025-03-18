using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Beauty_salon.Components
{
    internal class Navigations
    {
        public static MainWindow mainWindow;
        public static void NextMainPage(Page page)
        {
            mainWindow.MainFrame.Navigate(page);
        }
        public static void NextTopPage(Page page)
        {
            mainWindow.TopFrame.Navigate(page);
        }
        public static void NextLeftPage(Page page)
        {
            mainWindow.LeftFrame.Navigate(page);
        }
        public static void NextCenterPage(Page page)
        {
            mainWindow.CenterFrame.Navigate(page);
        }
    }
}
