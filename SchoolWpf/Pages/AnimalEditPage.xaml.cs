using SchoolWpf.Components.Model;
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

namespace SchoolWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для AnimalEditPage.xaml
    /// </summary>
    public partial class AnimalEditPage : Page
    {
        Animal animal;
        public AnimalEditPage(Animal animal)
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if(TbCountry == null & TbHabitat == null & TbLifeTimeInYear == null & TbName == null & TbNutrition == null)
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }
            else
            {
                App.Db.SaveChanges();
            }
            App.Db.SaveChanges();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
