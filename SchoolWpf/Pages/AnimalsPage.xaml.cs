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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для AnimalsPage.xaml
    /// </summary>
    public partial class AnimalsPage : Page
    {
        public AnimalsPage()
        {
            InitializeComponent();
            LvList.ItemsSource = App.Db.Animal.Where(x => x.IsDelete != true).ToList();
        }
        public void Refresh()
        {
            IEnumerable<Animal> filterService = App.Db.Animal.Where(x => x.IsDelete != true).ToList();
            if (SortCb.SelectedIndex == 1)
                filterService = filterService.OrderBy(x => x.LifeTimeInYear);
            else if (SortCb.SelectedIndex == 2)
                filterService = filterService.OrderByDescending(x => x.LifeTimeInYear);
            if (DiscountSortCb.SelectedIndex > 0)
            {
                if (DiscountSortCb.SelectedIndex == 1)
                    filterService = filterService.Where(x => x.Habitat == "Лес").ToList();
                else if (DiscountSortCb.SelectedIndex == 2)
                    filterService = filterService.Where(x => x.Habitat == "Тропический лес").ToList();

            }
            LvList.ItemsSource = filterService.ToList();
        }
        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void DiscountSortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var editAnimal = (sender as Button).DataContext as Animal;
            NavigationService.Navigate(new AnimalEditPage(editAnimal));
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selService = (sender as Button).DataContext as Animal;
            selService.IsDelete = true;
            App.Db.SaveChanges();
            LvList.ItemsSource = App.Db.Animal.Where(x => x.IsDelete != true).ToList();
        }

        private void ZooCompButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ZooCompany());
        }
    }
}
