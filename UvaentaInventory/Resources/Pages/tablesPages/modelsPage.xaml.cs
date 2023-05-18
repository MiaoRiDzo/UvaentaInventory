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
    /// Логика взаимодействия для modelsPage.xaml
    /// </summary>
    public partial class modelsPage : Page
    {
        MainWindow win;
        public modelsPage(MainWindow _win)
        {
            InitializeComponent();
            win = _win;
            modelsGrid.ItemsSource = EquipmentUventaEntities.getContext().EquipmentModel.ToList();
            cbBrands.ItemsSource = EquipmentUventaEntities.getContext().Brand.ToList();
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            win.mFrame.Navigate(new Pages.tablesPages.editPages.modelsEdit((sender as Button).DataContext as EquipmentModel, win));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            EquipmentUventaEntities.getContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            modelsGrid.ItemsSource = EquipmentUventaEntities.getContext().EquipmentModel.ToList();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            win.mFrame.Navigate(new Pages.tablesPages.editPages.modelsEdit(null, win));
        }

        private void brandBtn_Click(object sender, RoutedEventArgs e)
        {
            win.mFrame.Navigate(new Pages.tablesPages.brandsPage(win));
        }

        private void typesBtn_Click(object sender, RoutedEventArgs e)
        {
            win.mFrame.Navigate(new Pages.tablesPages.typesPage(win));

        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            var removes = modelsGrid.SelectedItems.Cast<EquipmentModel>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {removes.Count()} элементы?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    EquipmentUventaEntities.getContext().EquipmentModel.RemoveRange(removes);
                    EquipmentUventaEntities.getContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    modelsGrid.ItemsSource = EquipmentUventaEntities.getContext().EquipmentModel.ToList();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            }
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbSearch.Text))
            {
                // Предположим, что у вас есть DataGridView с именем dgUsers
                List<EquipmentModel> list = modelsGrid.ItemsSource as List<EquipmentModel>; // Получаем List<User> из DataSource
                if (list != null) // Проверяем, что он не null
                {
                    string filter = tbSearch.Text; // Получаем текст из TextBox
                    List<EquipmentModel> filteredList = list.FindAll(model => model.EquipmentModelName.Contains(filter)); // Создаем отфильтрованный список по лямбда-выражению
                    modelsGrid.ItemsSource = filteredList; // Привязываем отфильтрованный список к DataGridView
                }
            }
            else
            {
                modelsGrid.ItemsSource = EquipmentUventaEntities.getContext().EquipmentModel.ToList();
            }
        }

        private void cbBrands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbBrands.SelectedIndex != -1)
            {
                List<EquipmentModel> modelLis= EquipmentUventaEntities.getContext().EquipmentModel.ToList();
                Brand brand= cbBrands.SelectedItem as Brand;
                modelLis = modelLis.FindAll(x => x.Brand.BrandName == brand.BrandName);
                modelsGrid.ItemsSource = modelLis;
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            cbBrands.SelectedIndex = -1;
            tbSearch.Text = string.Empty;
            modelsGrid.ItemsSource = EquipmentUventaEntities.getContext().EquipmentModel.ToList();
        }
    }
}
