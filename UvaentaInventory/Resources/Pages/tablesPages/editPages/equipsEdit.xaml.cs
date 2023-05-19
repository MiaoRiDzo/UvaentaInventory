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
    /// Логика взаимодействия для equipsEdit.xaml
    /// </summary>
    public partial class equipsEdit : Page
    {
        Equipment _current = new Equipment();
        bool newIns = true;
        MainWindow win;
        public equipsEdit(Equipment current, MainWindow _win)
        {
            InitializeComponent();
            cbModels.ItemsSource = EquipmentUventaEntities.getContext().EquipmentModel.ToList();
            cbCabinets.ItemsSource = EquipmentUventaEntities.getContext().Cabinet.ToList();
            cbResponsible.ItemsSource = EquipmentUventaEntities.getContext().Responsible.ToList();
            cbType.ItemsSource = EquipmentUventaEntities.getContext().EquipmentType.ToList();
            win = _win;
            if (current != null)
            {
                _current = current;
                newIns = false;
                dpDatePurchase.Text = _current.DatePurchase.ToString();
            }
            DataContext = _current;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            //проверка вводиммых данных
            if(tbSN.Text.Length != 8 ) { errors.AppendLine("Введён не верный серийный номер;"); }
            if(string.IsNullOrEmpty(tbName.Text)) { errors.AppendLine("Отсутсвует наименование оборудования;"); }
            if (cbCabinets.SelectedItem == null) { errors.AppendLine("Не выбран кабинет;"); }
            if (cbModels.SelectedItem == null) { errors.AppendLine("Не выбрана моедль;"); }
            if (cbResponsible.SelectedItem == null) { errors.AppendLine("Не выбран ответственный;"); }
            if (cbType.SelectedItem == null) { errors.AppendLine("Не выбран тип оборудования"); }
            if(dpDatePurchase.DisplayDate == null) { errors.AppendLine("Не указана дата поступления"); }
            //Отображение ошибок
            if(errors.Length > 0) { 
                MessageBox.Show(errors.ToString(), "Ошибка" ,MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }



            if (newIns)
            {
                //Добавление данных в обьект
                EquipmentModel model = cbModels.SelectedItem as EquipmentModel;
                Cabinet cabinet = cbCabinets.SelectedItem as Cabinet;
                Responsible responsible = cbResponsible.SelectedItem as Responsible;
                EquipmentType type = cbType.SelectedItem as EquipmentType;
                _current.EquipmentModelID = model.EquipmentModelID;
                _current.CabinetID = cabinet.CabinetID;
                _current.ResponsibleID = responsible.ResponsibleID;
                _current.EquipmentTypeID = type.EquipmentTypeID;
            }
            DateTime date = DateTime.Parse(dpDatePurchase.Text);
            _current.DatePurchase = date;
            EquipmentUventaEntities.getContext().Equipment.AddOrUpdate(_current);
            try
            {
                EquipmentUventaEntities.getContext().SaveChanges();
                MessageBox.Show("Данные сохранены.");
                win.mFrame.GoBack();
            }catch(Exception ex)
            {
                MessageBox.Show("Ошибка\n" + ex.Message);
            }
        }
    }
}
