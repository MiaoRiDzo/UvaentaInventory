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

namespace UvaentaInventory
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void entered_Click(object sender, RoutedEventArgs e)
        {
            // Создаем новый объект типа CurrentUser
            CurrentUser currentUser = new CurrentUser();

            // Получаем список всех пользователей из базы данных
            List<User> users = EquipmentUventaEntities.getContext().User.ToList();

            // Итерируемся по каждому пользователю в списке
            foreach (User user in users)
            {
                // Проверяем, совпадает ли логин пользователя с введенным текстом в поле txtLogin
                if (user.Login == txtLogin.Text)
                {
                    // Если совпадение найдено, сохраняем информацию о пользователе в объекте currentUser
                    currentUser.UserName = user.UserName;
                    currentUser.Role = user.Role.RoleName;
                    currentUser.Password = user.Password;

                    // Прерываем цикл, так как нашли нужного пользователя
                    break;
                }
            }

            // Проверяем, был ли найден пользователь с таким логином
            if (currentUser.UserName == null)
            {
                // Если пользователь не найден, выводим сообщение об ошибке
                MessageBox.Show("Неверный логин");
            }

            // Проверяем, совпадает ли пароль пользователя с введенным текстом в поле txtPassword
            if (currentUser.Password == txtPassword.Password)
            {
                // Если пароль совпадает, открываем новое окно MainWindow и передаем в него объект currentUser
                new MainWindow(currentUser).Show();

                // Закрываем текущее окно
                this.Close();
            }
            else if (currentUser.Password != txtPassword.Password)
            {
                // Если пароль не совпадает, выводим сообщение об ошибке
                MessageBox.Show("Неверный пароль!");
            }
        }

    }
}
