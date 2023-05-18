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
    /// Логика взаимодействия для positionsPage.xaml
    /// </summary>
    public partial class positionsPage : Page
    {
        MainWindow win;
        public positionsPage(MainWindow _win)
        {
            InitializeComponent();
            win = _win;
            positionsGrid.ItemsSource = EquipmentUventaEntities.getContext().Position.ToList();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbSearch.Text))
            {
                // Предположим, что у вас есть DataGridView с именем dgUsers
                List<Position> list = positionsGrid.ItemsSource as List<Position>; // Получаем List<Position> из DataSource
                if (list != null) // Проверяем, что он не null
                {
                    string filter = tbSearch.Text; // Получаем текст из TextBox
                    List<Position> filteredList = list.FindAll(position => position.PositionName.Contains(filter)); // Создаем отфильтрованный список по лямбда-выражению
                    positionsGrid.ItemsSource = filteredList; // Привязываем отфильтрованный список к DataGridView
                }
            }
            else
            {
                positionsGrid.ItemsSource = EquipmentUventaEntities.getContext().Position.ToList();
            }
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            win.mFrame.Navigate(new Pages.tablesPages.editPages.positionEdit(null, win));
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            win.mFrame.Navigate(new Pages.tablesPages.editPages.positionEdit((sender as Button).DataContext as Position, win));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            EquipmentUventaEntities.getContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            positionsGrid.ItemsSource = EquipmentUventaEntities.getContext().Position.ToList();
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            var removes = positionsGrid.SelectedItems.Cast<Position>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {removes.Count()} элементы?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    EquipmentUventaEntities.getContext().Position.RemoveRange(removes);
                    EquipmentUventaEntities.getContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    positionsGrid.ItemsSource = EquipmentUventaEntities.getContext().Position.ToList();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            }
        }
    }
}
