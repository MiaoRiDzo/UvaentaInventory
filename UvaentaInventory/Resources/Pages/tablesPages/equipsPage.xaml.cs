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
    /// Логика взаимодействия для equipsPage.xaml
    /// </summary>
    public partial class equipsPage : Page
    {
        MainWindow win;
        public equipsPage(MainWindow _win, CurrentUser currentUser)
        {
            InitializeComponent();
            win = _win;
            equipGrid.ItemsSource = EquipmentUventaEntities.getContext().Equipment.ToList();
            cbTypes.ItemsSource = EquipmentUventaEntities.getContext().EquipmentType.ToList();
            if (currentUser.Role == "Директор") { 
                editBtn.Visibility = Visibility.Collapsed;
                addBtn.Visibility = Visibility.Collapsed;
                delBtn.Visibility = Visibility.Collapsed;
                modelsBtn.Visibility = Visibility.Collapsed;
            }
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            win.mFrame.Navigate(new Pages.tablesPages.editPages.equipsEdit(null, win));
        }

        private void modelsBtn_Click(object sender, RoutedEventArgs e)
        {
            win.mFrame.Navigate(new Pages.tablesPages.modelsPage(win));
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            var removes = equipGrid.SelectedItems.Cast<Equipment>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {removes.Count()} элементы?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    EquipmentUventaEntities.getContext().Equipment.RemoveRange(removes);
                    EquipmentUventaEntities.getContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    equipGrid.ItemsSource = EquipmentUventaEntities.getContext().Equipment.ToList();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            }
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            win.mFrame.Navigate(new Pages.tablesPages.editPages.equipsEdit((sender as Button).DataContext as Equipment, win));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            EquipmentUventaEntities.getContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            equipGrid.ItemsSource = EquipmentUventaEntities.getContext().Equipment.ToList();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbSearch.Text))
            {
                // Предположим, что у вас есть DataGridView с именем dgUsers
                List<Equipment> list = equipGrid.ItemsSource as List<Equipment>; // Получаем List<User> из DataSource
                if (list != null) // Проверяем, что он не null
                {
                    string filter = tbSearch.Text; // Получаем текст из TextBox
                    List<Equipment> filteredList = list.FindAll(equipment => equipment.EquipmentName.Contains(filter)); // Создаем отфильтрованный список по лямбда-выражению
                    equipGrid.ItemsSource = filteredList; // Привязываем отфильтрованный список к DataGridView
                }
            }
            else
            {
                equipGrid.ItemsSource = EquipmentUventaEntities.getContext().Equipment.ToList();
            }
        }

        private void cbTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbTypes.SelectedIndex != -1)
            {
                // Получаем список всех оборудований из базы данных
                List<Equipment> equipments = EquipmentUventaEntities.getContext().Equipment.ToList();
                // Получаем выбранный тип оборудования из ComboBox
                EquipmentType type = cbTypes.SelectedItem as EquipmentType;
                // Используем LINQ для фильтрации списка оборудований по выбранному типу
                equipments = equipments.Where(eq => eq.EquipmentType.EquipmentTypeName == type.EquipmentTypeName).ToList();
            
            // Обновляем данные в таблице
            equipGrid.ItemsSource = equipments;
                }
        }

        private void cardBtn_Click(object sender, RoutedEventArgs e)
        {
            equipmentCardWin cardWin = new equipmentCardWin((sender as Button).DataContext as Equipment);
            cardWin.ShowDialog();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            cbTypes.SelectedIndex = -1;
            tbSearch.Text = string.Empty;
            equipGrid.ItemsSource = EquipmentUventaEntities.getContext().Equipment.ToList();
        }
    }
}
