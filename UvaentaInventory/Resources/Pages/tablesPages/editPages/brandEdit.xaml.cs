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
    /// Логика взаимодействия для brandEdit.xaml
    /// </summary>
    public partial class brandEdit : Page
    {
        private Brand _current = new Brand();
        MainWindow win;
        bool newIns = true;
        public brandEdit(Brand current, MainWindow _win)
        {
            InitializeComponent();
            win = _win;
            if (current != null) { _current = current; newIns = false; }
            DataContext = _current;
        }
        private static int getNextId(Brand current)
        {
            try
            {
                int id = EquipmentUventaEntities.getContext().Brand.ToList().Last().BrandID;
                return id + 1;
            }
            catch { return 0; }
        }
        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text)) { MessageBox.Show("Наименование пустое"); }

            if (_current.BrandID >= 0)
            {
                if (newIns)
                {
                    _current.BrandID = getNextId(_current);
                }
                EquipmentUventaEntities.getContext().Brand.AddOrUpdate(_current);
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
