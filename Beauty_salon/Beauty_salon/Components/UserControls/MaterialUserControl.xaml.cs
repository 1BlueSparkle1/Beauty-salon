using Beauty_salon.Pages;
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
    /// Логика взаимодействия для MaterialUserControl.xaml
    /// </summary>
    public partial class MaterialUserControl : UserControl
    {
        private Material material;
        public MaterialUserControl(Material _material)
        {
            InitializeComponent();
            material = _material;
            TitleTb.Text = material.Title;
            QuantityTb.Text = material.Quantity.ToString();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (material.MaterialService.Count() > 0)
            {
                MessageBox.Show("Материал используется для услуги, его нельзя удалить!");
            }
            else
            {
                App.db.Material.Remove(material);
                App.db.SaveChanges();
                MessageBox.Show("Материал удален!");
                Navigations.NextCenterPage(new ListMaterialPage());
            }
        }
    }
}
