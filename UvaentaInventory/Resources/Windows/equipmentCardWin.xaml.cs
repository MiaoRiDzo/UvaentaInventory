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
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;

namespace UvaentaInventory.Resources.Windows
{
    /// <summary>
    /// Логика взаимодействия для equipmentCardWin.xaml
    /// </summary>
    public partial class equipmentCardWin : Window
    {
        Equipment equipment;
        public equipmentCardWin(Equipment _equipment)
        {
            InitializeComponent();
            equipment = _equipment;
            DataContext = equipment;
            tbDate.Text = equipment.DatePurchase.ToString().Substring(0, 10);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void reportBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
