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

namespace UvaentaInventory.Resources.Pages.tablesPages.editPages
{
    /// <summary>
    /// Логика взаимодействия для equipsEdit.xaml
    /// </summary>
    public partial class equipsEdit : Page
    {
        public equipsEdit()
        {
            InitializeComponent();
            cbModels.ItemsSource = EquipmentUventaEntities.getContext().EquipmentModel.ToList();
            cbCabinets.ItemsSource = EquipmentUventaEntities.getContext().Cabinet.ToList();
            cbResponsible.ItemsSource = EquipmentUventaEntities.getContext().Responsible.ToList();
            cbType.ItemsSource = EquipmentUventaEntities.getContext().EquipmentType.ToList();
            
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
