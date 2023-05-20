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
    /// Логика взаимодействия для usersPage.xaml
    /// </summary>
    public partial class usersPage : Page
    {
        MainWindow win;
        public usersPage(MainWindow _win)
        {
            InitializeComponent();
            win = _win;
            userGrid.ItemsSource = EquipmentUventaEntities.getContext().User.ToList();
            cbRoles.ItemsSource = EquipmentUventaEntities.getContext().Role.ToList();
        }

        private void roleBtn_Click(object sender, RoutedEventArgs e)
        {
            win.mFrame.NavigationService.Navigate(new Pages.tablesPages.rolesPage(win));
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            win.mFrame.Navigate(new Pages.tablesPages.editPages.userEdit(null, win));
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            var removes = userGrid.SelectedItems.Cast<User>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {removes.Count()} элементы?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    EquipmentUventaEntities.getContext().User.RemoveRange(removes);
                    EquipmentUventaEntities.getContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    userGrid.ItemsSource = EquipmentUventaEntities.getContext().User.ToList();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            }
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            win.mFrame.Navigate(new Pages.tablesPages.editPages.userEdit((sender as Button).DataContext as User, win));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            EquipmentUventaEntities.getContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            userGrid.ItemsSource = EquipmentUventaEntities.getContext().User.ToList();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbSearch.Text))
            {
                // Предположим, что у вас есть DataGridView с именем dgUsers
                List<User> list = userGrid.ItemsSource as List<User>; // Получаем List<User> из DataSource
                if (list != null) // Проверяем, что он не null
                {
                    string filter = tbSearch.Text; // Получаем текст из TextBox
                    List<User> filteredList = list.FindAll(user => user.UserName.Contains(filter)); // Создаем отфильтрованный список по лямбда-выражению
                    userGrid.ItemsSource = filteredList; // Привязываем отфильтрованный список к DataGridView
                }
            }
            else
            {
                userGrid.ItemsSource = EquipmentUventaEntities.getContext().User.ToList();
            }
        }

        private void cbRoles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbRoles.SelectedIndex != -1)
            {
                List<User> userList = EquipmentUventaEntities.getContext().User.ToList();
                Role role = cbRoles.SelectedItem as Role;
                userList = userList.FindAll(x => x.Role.RoleName == role.RoleName);
                userGrid.ItemsSource = userList;
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            cbRoles.SelectedIndex = -1;
            tbSearch.Text = string.Empty;
            userGrid.ItemsSource = EquipmentUventaEntities.getContext().User.ToList();
        }
    }
}
