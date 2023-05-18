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
using System.Windows.Shapes;

namespace UvaentaInventory.Resources.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CurrentUser currentUser;
        public MainWindow(CurrentUser _currentUser)
        {
            InitializeComponent();
            currentUser = _currentUser;
            mFrame.Navigate(new Pages.welcomePage(currentUser));
        }

        private void closeClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Сменить пользователя?", currentUser.UserName, MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                this.Close();
            }
        }
        private void equipClick(object sender, RoutedEventArgs e)
        {
            mFrame.NavigationService.Navigate(new Pages.tablesPages.equipsPage(this));
        }
        private void respClick(object sender, RoutedEventArgs e)
        {
            mFrame.NavigationService.Navigate(new Pages.tablesPages.responsiblesPage(this));
        }
        private void cabinetClick(object sender, RoutedEventArgs e)
        {
            mFrame.NavigationService.Navigate(new Pages.tablesPages.cabinetsPage(this));
        }

        private void backClick(object sender, RoutedEventArgs e)
        {
            try
            {
                mFrame.NavigationService.GoBack();
            }
            catch { }
        }

    }
}
