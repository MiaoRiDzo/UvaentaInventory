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
        public equipsPage(MainWindow _win)
        {
            InitializeComponent();
            win = _win;
            equipGrid.ItemsSource = EquipmentUventaEntities.getContext().Equipment.ToList();
            cbTypes.ItemsSource = EquipmentUventaEntities.getContext().EquipmentType.ToList();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void posBtn_Click(object sender, RoutedEventArgs e)
        {
            win.mFrame.Navigate(new Pages.tablesPages.modelsPage(win));
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cbTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
}
