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
        // Создаем новый объект класса Equipment
        Equipment _current = new Equipment();
        // Создаем переменную для проверки, является ли запись новой
        bool newIns = true;
        // Создаем переменную для хранения ссылки на главное окно
        MainWindow win;
        // Создаем конструктор класса equipsEdit с двумя параметрами: current и _win
        public equipsEdit(Equipment current, MainWindow _win)
        {
            // Вызываем метод InitializeComponent для инициализации компонентов окна
            InitializeComponent();
            // Задаем источник данных для выпадающего списка cbModels из таблицы EquipmentModel
            cbModels.ItemsSource = EquipmentUventaEntities.getContext().EquipmentModel.ToList();
            // Задаем источник данных для выпадающего списка cbCabinets из таблицы Cabinet
            cbCabinets.ItemsSource = EquipmentUventaEntities.getContext().Cabinet.ToList();
            // Задаем источник данных для выпадающего списка cbResponsible из таблицы Responsible
            cbResponsible.ItemsSource = EquipmentUventaEntities.getContext().Responsible.ToList();
            // Задаем источник данных для выпадающего списка cbType из таблицы EquipmentType
            cbType.ItemsSource = EquipmentUventaEntities.getContext().EquipmentType.ToList();
            // Присваиваем переменной win значение параметра _win
            win = _win;
            // Проверяем, не равен ли параметр current null
            if (current != null)
            {
                // Присваиваем переменной _current значение параметра current
                _current = current;
                // Устанавливаем переменную newIns в false, так как запись не новая
                newIns = false;
                // Устанавливаем текстовое значение элемента dpDatePurchase из свойства DatePurchase объекта _current
                dpDatePurchase.Text = _current.DatePurchase.ToString();
            }
            // Устанавливаем контекст данных для окна из объекта _current
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
                //Попытка добавления сохранения данных в базе
                EquipmentUventaEntities.getContext().SaveChanges();
                //Выводим сообщение о сохранении, если успешно
                MessageBox.Show("Данные сохранены.");
                win.mFrame.GoBack();
            }catch(Exception ex)
            {
                //В случае ошибки, выводим сообщение об ошибке
                MessageBox.Show("Ошибка\n" + ex.Message);
            }
        }
    }
}
