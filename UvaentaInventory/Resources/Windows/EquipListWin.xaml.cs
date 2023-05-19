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
using System.Windows.Shapes;
using UvaentaInventory.Resources.Classes;

namespace UvaentaInventory.Resources.Windows
{
    /// <summary>
    /// Логика взаимодействия для EquipListWin.xaml
    /// </summary>
    public partial class EquipListWin : Window
    {
        Responsible responsible = new Responsible();
        public EquipListWin(Responsible _responsible)
        {
            InitializeComponent();
            responsible = _responsible;
            DataContext = responsible;

            List<Equipment> equipmentList = EquipmentUventaEntities.getContext().Equipment.ToList();
            List<Equipment> respEqList = new List<Equipment>();

            foreach (Equipment equ in equipmentList)
            {
                if (equ.ResponsibleID == responsible.ResponsibleID)
                {
                    respEqList.Add(equ);
                }
            }
           dgList.ItemsSource = respEqList;
        }

        private void cardBtn_Click(object sender, RoutedEventArgs e)
        {
            equipmentCardWin cardWin = new equipmentCardWin((sender as Button).DataContext as Equipment);
            cardWin.ShowDialog();
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgList_Initialized(object sender, EventArgs e)
        {
            List<Equipment> equipmentList = EquipmentUventaEntities.getContext().Equipment.ToList();
            List<Equipment> respEqList = new List<Equipment>();

            foreach(Equipment equ in equipmentList) { 
                if(equ.ResponsibleID == responsible.ResponsibleID)
                {
                    respEqList.Add(equ);
                }
            }
            (sender as DataGrid).ItemsSource = respEqList;
        }
    }
}
