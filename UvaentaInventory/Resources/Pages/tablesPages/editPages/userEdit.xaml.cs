using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
using System.Xml.Linq;
using UvaentaInventory.Resources.Classes;
using UvaentaInventory.Resources.Windows;

namespace UvaentaInventory.Resources.Pages.tablesPages.editPages
{
    /// <summary>
    /// Логика взаимодействия для userEdit.xaml
    /// </summary>
    public partial class userEdit : Page
    {
        MainWindow win;
        private User _current = new User();
        bool newIns = true;
        public userEdit(User current , MainWindow _win)
        {
            InitializeComponent();
            win = _win;
            if(current != null ) { 
                _current = current;
                newIns = false;
            }
            DataContext = _current;
            cbRole.ItemsSource = EquipmentUventaEntities.getContext().Role.ToList();
        }

        private static int getNextId(User current)
        {
            try
            {
                int id = EquipmentUventaEntities.getContext().User.ToList().Last().UserID;
                return id + 1;
            }
            catch { return 0; }
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder err = new StringBuilder();
            if (string.IsNullOrEmpty(tbUserName.Text)) { err.AppendLine("Имя пользователся пустое"); }
            if (string.IsNullOrEmpty(tbLogin.Text)) { err.AppendLine("Логин пустой"); }
            if(string.IsNullOrEmpty(tbPass.Text)) { err.AppendLine("Пароль пустой"); }
            if(cbRole.SelectedItem == null) { err.AppendLine("Не выбрана роль пользователя"); }
            if(err.Length > 0) { MessageBox.Show(err.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }

            if (_current.UserID >= 0)
            {
                if (newIns)
                {
                    _current.UserID = getNextId(_current);
                    Role role = cbRole.SelectedItem as Role;
                    _current.RoleID = role.RoleID;
                }
                EquipmentUventaEntities.getContext().User.AddOrUpdate(_current);
                try
                {
                    EquipmentUventaEntities.getContext().SaveChanges();
                    MessageBox.Show("Данные сохранены.");
                    win.mFrame.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка\n" + ex.Message);
                }
            }
        }
    }

}
