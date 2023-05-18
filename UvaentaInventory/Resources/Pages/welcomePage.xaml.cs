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

namespace UvaentaInventory.Resources.Pages
{
    /// <summary>
    /// Логика взаимодействия для welcomePage.xaml
    /// </summary>
    public partial class welcomePage : Page
    {
        CurrentUser currentUser;
        public welcomePage(CurrentUser currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
            welcomeCard.Content = currentUser.UserName;
        }
    }
}
