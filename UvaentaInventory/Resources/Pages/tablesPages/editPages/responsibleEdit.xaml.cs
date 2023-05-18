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
    /// Логика взаимодействия для responsibleEdit.xaml
    /// </summary>
    public partial class responsibleEdit : Page
    {
        private Responsible _current = new Responsible();
        MainWindow win;
        bool newIns = true;
        public responsibleEdit(Responsible current, MainWindow _win)
        {
            InitializeComponent();
            win = _win;
            if(current != null)
            {
                _current = current;
                newIns = false;
            }
            cbPosition.ItemsSource = EquipmentUventaEntities.getContext().Position.ToList();
            DataContext = _current;
        }
        //Полученгие ID последней записи
        private static int getNextId(Responsible current)
        {
            try
            {
                int id = EquipmentUventaEntities.getContext().Responsible.ToList().Last().ResponsibleID;
                return id + 1;
            }
            catch { return 0; }
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            // Создаем объект StringBuilder для хранения сообщений об ошибках
            StringBuilder errors = new StringBuilder();
            // Проверяем, что поля имени и фамилии не пустые
            if (String.IsNullOrEmpty(tbFName.Text) && String.IsNullOrEmpty(tbLName.Text)) errors.AppendFormat("Введите имя и/или фамилию{0}", Environment.NewLine);
            // Проверяем, что выбрана должность
            if (cbPosition.SelectedItem == null) errors.AppendFormat("Выберите должность{0}", Environment.NewLine);
            // Если есть ошибки, показываем их в окне сообщения и выходим из функции
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_current.ResponsibleID >= 0)
            {
                if (newIns)
                {
                    _current.ResponsibleID = getNextId(_current);
                     Position pos = cbPosition.SelectedItem as Position;
                    _current.IDPosition = pos.PositionID;
                }
                EquipmentUventaEntities.getContext().Responsible.AddOrUpdate(_current);
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
