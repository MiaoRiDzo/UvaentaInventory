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
    /// Логика взаимодействия для rolesPage.xaml
    /// </summary>
    public partial class rolesPage : Page
    {
        MainWindow win;
        public rolesPage(MainWindow _win)
        {
            InitializeComponent();
            win = _win;
            rolesGrid.ItemsSource = EquipmentUventaEntities.getContext().Role.ToList();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            EquipmentUventaEntities.getContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            rolesGrid.ItemsSource = EquipmentUventaEntities.getContext().Role.ToList();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            win.mFrame.Navigate(new Pages.tablesPages.editPages.roleEdit(null, win));
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            var removes = rolesGrid.SelectedItems.Cast<Role>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {removes.Count()} элементы?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    EquipmentUventaEntities.getContext().Role.RemoveRange(removes);
                    EquipmentUventaEntities.getContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    rolesGrid.ItemsSource = EquipmentUventaEntities.getContext().Role.ToList();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            }
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            win.mFrame.Navigate(new Pages.tablesPages.editPages.roleEdit((sender as Button).DataContext as Role, win));
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbSearch.Text))
            {
                // Предположим, что у вас есть DataGridView с именем dgUsers
                List<Role> list = rolesGrid.ItemsSource as List<Role>; // Получаем List<User> из DataSource
                if (list != null) // Проверяем, что он не null
                {
                    string filter = tbSearch.Text; // Получаем текст из TextBox
                    List<Role> filteredList = list.FindAll(role => role.RoleName.Contains(filter)); // Создаем отфильтрованный список по лямбда-выражению
                    rolesGrid.ItemsSource = filteredList; // Привязываем отфильтрованный список к DataGridView
                }
            }
            else
            {
                rolesGrid.ItemsSource = EquipmentUventaEntities.getContext().Role.ToList();
            }
        }
    }
}
