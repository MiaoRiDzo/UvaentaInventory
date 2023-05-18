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
    /// Логика взаимодействия для cabinetsPage.xaml
    /// </summary>
    public partial class cabinetsPage : Page
    {
        MainWindow win;
        public cabinetsPage(MainWindow _win)
        {
            InitializeComponent();
            win = _win;
            cabinetsGrid.ItemsSource = EquipmentUventaEntities.getContext().Cabinet.ToList();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbSearch.Text))
            {
                // Предположим, что у вас есть DataGridView с именем dgUsers
                List<Cabinet> list = cabinetsGrid.ItemsSource as List<Cabinet>; // Получаем List<User> из DataSource
                if (list != null) // Проверяем, что он не null
                {
                    string filter = tbSearch.Text; // Получаем текст из TextBox
                    List<Cabinet> filteredList = list.FindAll(cabinet => cabinet.CabinetName.Contains(filter)); // Создаем отфильтрованный список по лямбда-выражению
                    cabinetsGrid.ItemsSource = filteredList; // Привязываем отфильтрованный список к DataGridView
                }
            }
            else
            {
                cabinetsGrid.ItemsSource = EquipmentUventaEntities.getContext().Cabinet.ToList();
            }
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            win.mFrame.Navigate(new Pages.tablesPages.editPages.cabinetEdit(null, win));
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            var removes = cabinetsGrid.SelectedItems.Cast<Cabinet>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {removes.Count()} элементы?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    EquipmentUventaEntities.getContext().Cabinet.RemoveRange(removes);
                    EquipmentUventaEntities.getContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    cabinetsGrid.ItemsSource = EquipmentUventaEntities.getContext().Cabinet.ToList();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            EquipmentUventaEntities.getContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            cabinetsGrid.ItemsSource = EquipmentUventaEntities.getContext().Cabinet.ToList();
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            win.mFrame.Navigate(new Pages.tablesPages.editPages.cabinetEdit((sender as Button).DataContext as Cabinet, win));
        }
    }
}
