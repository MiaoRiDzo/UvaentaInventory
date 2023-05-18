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
using UvaentaInventory.Resources.Classes;
using UvaentaInventory.Resources.Windows;

namespace UvaentaInventory.Resources.Pages.tablesPages.editPages
{
    /// <summary>
    /// Логика взаимодействия для typeEdit.xaml
    /// </summary>
    public partial class typeEdit : Page
    {
        private EquipmentType _current = new EquipmentType();
        MainWindow win;
        bool newIns = true;
        public typeEdit(EquipmentType current, MainWindow _win)
        {
            InitializeComponent();
            win = _win;
            if (current != null) { _current = current; newIns = false; }
            DataContext = _current;
        }
        private static int getNextId(EquipmentType current)
        {
            try
            {
                int id = EquipmentUventaEntities.getContext().EquipmentType.ToList().Last().EquipmentTypeID;
                return id + 1;
            }
            catch { return 0; }
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text)) { MessageBox.Show("Наименование пустое"); }

            if (_current.EquipmentTypeID >= 0)
            {
                if (newIns)
                {
                    _current.EquipmentTypeID = getNextId(_current);
                }
                EquipmentUventaEntities.getContext().EquipmentType.AddOrUpdate(_current);
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
