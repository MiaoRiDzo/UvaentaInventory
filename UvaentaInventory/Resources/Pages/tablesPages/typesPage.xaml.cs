﻿using System;
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
    /// Логика взаимодействия для typesPage.xaml
    /// </summary>
    public partial class typesPage : Page
    {
        MainWindow win;
        public typesPage(MainWindow _win)
        {
            InitializeComponent();
            win = _win;
            typesGrid.ItemsSource = EquipmentUventaEntities.getContext().EquipmentType.ToList();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            win.mFrame.Navigate(new Pages.tablesPages.editPages.typeEdit(null, win));
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            var removes = typesGrid.SelectedItems.Cast<EquipmentType>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {removes.Count()} элементы?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    EquipmentUventaEntities.getContext().EquipmentType.RemoveRange(removes);
                    EquipmentUventaEntities.getContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    typesGrid.ItemsSource = EquipmentUventaEntities.getContext().EquipmentType.ToList();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            }
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            win.mFrame.Navigate(new Pages.tablesPages.editPages.typeEdit((sender as Button).DataContext as EquipmentType, win));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            EquipmentUventaEntities.getContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            typesGrid.ItemsSource = EquipmentUventaEntities.getContext().EquipmentType.ToList();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbSearch.Text))
            {
                // Предположим, что у вас есть DataGridView с именем dgUsers
                List<EquipmentType> list = typesGrid.ItemsSource as List<EquipmentType>; // Получаем List<User> из DataSource
                if (list != null) // Проверяем, что он не null
                {
                    string filter = tbSearch.Text; // Получаем текст из TextBox
                    List<EquipmentType> filteredList = list.FindAll(type => type.EquipmentTypeName.Contains(filter)); // Создаем отфильтрованный список по лямбда-выражению
                    typesGrid.ItemsSource = filteredList; // Привязываем отфильтрованный список к DataGridView
                }
            }
            else
            {
                typesGrid.ItemsSource = EquipmentUventaEntities.getContext().EquipmentType.ToList();
            }
        }
    }
}
