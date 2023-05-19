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
    /// Логика взаимодействия для responsiblesPage.xaml
    /// </summary>
    public partial class responsiblesPage : Page
    {
        MainWindow win;
        public responsiblesPage(MainWindow _win)
        {
            InitializeComponent();
            win = _win;
            respGrid.ItemsSource = EquipmentUventaEntities.getContext().Responsible.ToList();
           cbPositions.ItemsSource = EquipmentUventaEntities.getContext().Position.ToList();
        }



        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbSearch.Text))
            {
                // Предположим, что у вас есть DataGridView с именем dgUsers
                List<Responsible> list = respGrid.ItemsSource as List<Responsible>; // Получаем List<User> из DataSource
                if (list != null) // Проверяем, что он не null
                {
                    string filter = tbSearch.Text; // Получаем текст из TextBox
                    List<Responsible> filteredList = list.FindAll(responsible => responsible.ResponsibleSecondName.Contains(filter)); // Создаем отфильтрованный список по лямбда-выражению
                    respGrid.ItemsSource = filteredList; // Привязываем отфильтрованный список к DataGridView
                }
            }
            else
            {
                respGrid.ItemsSource = EquipmentUventaEntities.getContext().Responsible.ToList();
            }
        }

        private void posBtn_Click(object sender, RoutedEventArgs e)
        {
            win.mFrame.Navigate(new Pages.tablesPages.positionsPage(win));
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            win.mFrame.Navigate(new Pages.tablesPages.editPages.responsibleEdit(null, win));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            EquipmentUventaEntities.getContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            respGrid.ItemsSource = EquipmentUventaEntities.getContext().Responsible.ToList();
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            var removes = respGrid.SelectedItems.Cast<Responsible>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {removes.Count()} элементы?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    EquipmentUventaEntities.getContext().Responsible.RemoveRange(removes);
                    EquipmentUventaEntities.getContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    respGrid.ItemsSource = EquipmentUventaEntities.getContext().Responsible.ToList();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            }
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            win.mFrame.Navigate(new Pages.tablesPages.editPages.responsibleEdit((sender as Button).DataContext as Responsible, win));
        }

        private void cbPositions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbPositions.SelectedIndex != -1)
            {
                List<Responsible> responsiblesList = EquipmentUventaEntities.getContext().Responsible.ToList();
                Position position = cbPositions.SelectedItem as Position;
                responsiblesList = responsiblesList.FindAll(x => x.Position.PositionName == position.PositionName);
                respGrid.ItemsSource = responsiblesList;
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            cbPositions.SelectedIndex = -1;
            tbSearch.Text = string.Empty;
            respGrid.ItemsSource = EquipmentUventaEntities.getContext().Responsible.ToList();
        }

        private void listBtn_Click(object sender, RoutedEventArgs e)
        {
            EquipListWin listWin = new EquipListWin((sender as Button).DataContext as Responsible);
            listWin.ShowDialog();
        }
    }
}
