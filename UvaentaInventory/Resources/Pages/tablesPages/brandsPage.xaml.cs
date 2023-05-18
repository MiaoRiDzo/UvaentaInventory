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
using UvaentaInventory.Resources.Classes;
using UvaentaInventory.Resources.Windows;

namespace UvaentaInventory.Resources.Pages.tablesPages
{
    /// <summary>
    /// Логика взаимодействия для brandsPage.xaml
    /// </summary>
    public partial class brandsPage : Page
    {
        MainWindow win;
        public brandsPage(MainWindow _win)
        {
            InitializeComponent();
            win = _win;
            brandsGrid.ItemsSource = EquipmentUventaEntities.getContext().Brand.ToList();
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            win.mFrame.Navigate(new Pages.tablesPages.editPages.brandEdit((sender as Button).DataContext as Brand, win));

        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            win.mFrame.Navigate(new Pages.tablesPages.editPages.brandEdit(null, win));
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            var removes = brandsGrid.SelectedItems.Cast<Brand>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {removes.Count()} элементы?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    EquipmentUventaEntities.getContext().Brand.RemoveRange(removes);
                    EquipmentUventaEntities.getContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    brandsGrid.ItemsSource = EquipmentUventaEntities.getContext().Brand.ToList();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            EquipmentUventaEntities.getContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            brandsGrid.ItemsSource = EquipmentUventaEntities.getContext().Brand.ToList();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbSearch.Text))
            {
                // Предположим, что у вас есть DataGridView с именем dgUsers
                List<Brand> list = brandsGrid.ItemsSource as List<Brand>; // Получаем List<User> из DataSource
                if (list != null) // Проверяем, что он не null
                {
                    string filter = tbSearch.Text; // Получаем текст из TextBox
                    List<Brand> filteredList = list.FindAll(brand => brand.BrandName.Contains(filter)); // Создаем отфильтрованный список по лямбда-выражению
                    brandsGrid.ItemsSource = filteredList; // Привязываем отфильтрованный список к DataGridView
                }
            }
            else
            {
                brandsGrid.ItemsSource = EquipmentUventaEntities.getContext().Brand.ToList();
            }
        }
    }
}
