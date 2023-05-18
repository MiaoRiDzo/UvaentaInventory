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
    /// Логика взаимодействия для modelsEdit.xaml
    /// </summary>
    public partial class modelsEdit : Page
    {
        private EquipmentModel _current = new EquipmentModel();
        MainWindow win;
        bool newIns = true;
        public modelsEdit(EquipmentModel current, MainWindow _win)
        {
            InitializeComponent();
            win = _win;
            if (current != null)
            {
                _current = current;
                newIns = false;
            }
            cbBrands.ItemsSource = EquipmentUventaEntities.getContext().Brand.ToList();
            DataContext = _current;
        }
        private static int getNextId(EquipmentModel current)
        {
            try
            {
                int id = EquipmentUventaEntities.getContext().EquipmentModel.ToList().Last().EquipmentModelID;
                return id + 1;
            }
            catch { return 0; }
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (String.IsNullOrEmpty(tbName.Text)) errors.AppendFormat("Введите наименование{0}", Environment.NewLine);
            if (cbBrands.SelectedItem == null) errors.AppendFormat("Выберите должность{0}", Environment.NewLine);
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_current.EquipmentModelID >= 0)
            {
                if (newIns)
                {
                    _current.EquipmentModelID = getNextId(_current);
                    Brand brand = cbBrands.SelectedItem as Brand;
                    _current.BrandID= brand.BrandID;
                }
                EquipmentUventaEntities.getContext().EquipmentModel.AddOrUpdate(_current);
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
