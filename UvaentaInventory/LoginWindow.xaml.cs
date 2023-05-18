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
            CurrentUser currentUser = new CurrentUser();
            List<User> users = EquipmentUventaEntities.getContext().User.ToList();
            foreach (User user in users)
            {
                if (user.Login == txtLogin.Text) {
                    currentUser.UserName = user.UserName;
                    currentUser.Role = user.Role.RoleName;
                    currentUser.Password = user.Password;
                    break;
                }
            }
                if(currentUser.UserName == null) { MessageBox.Show("Не верный логин");  }
                if(currentUser.Password == txtPassword.Password)
                {
                    new MainWindow(currentUser).Show();
                    this.Close();
                }else if(currentUser.Password != txtPassword.Password) { MessageBox.Show("Не верный пароль!"); }
        }
    }
}
