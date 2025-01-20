using Accounting.ApplicationData;
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

namespace Accounting.Windows
{
    /// <summary>
    /// Логика взаимодействия для Add_and_Edit.xaml
    /// </summary>
    public partial class Add_and_Edit_devices : Window
    {
        Computer computer;
        bool red;
        public Add_and_Edit_devices(Computer currentComputer)
        {
            InitializeComponent();

            computer = currentComputer;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (computer != null)
            {
                txbNetwork_name.Text = computer.Network_name;
                txbIpAddress.Text = computer.IpAddress;
                txbLocation.Text = computer.Location;
                txbSystem_unit.Text = computer.System_unit;
                txbSystem_board.Text = computer.System_board;
                txbProcessor.Text = computer.Processor;
                txbRAM.Text = computer.RAM;
                txbVideo_card.Text= computer.Video_card;
                txbVideo_memory.Text = computer.Video_memory;
                txbHDD.Text = computer.HDD;
                txbHDD_capacity.Text = computer.HDD_capacity;
                txbCD_ROM.Text = computer.CD_ROM;
                txbMonitor.Text = computer.Monitor;
                txbMonitor_2.Text = computer.Monitor_2;
                txbKeyboard.Text = computer.Keyboard;
                txbMouse.Text = computer.Mouse;
                txbPrinter.Text = computer.Printer;
                txbScanner.Text = computer.Scanner;
                txbPrice_all.Text = computer.Price_all.ToString();
                txbPurchase_date.Text = computer.Purchase_date.ToString();
                txbOS.Text = computer.OS;
                txbNotes.Text = computer.Notes;
                red = true;
            }
            else computer = new Computer();
        }

        private void OK(object sender, RoutedEventArgs e)
        {
            try
            {
                computer.Network_name = txbNetwork_name.Text;
                computer.IpAddress = txbIpAddress.Text;
                computer.Location = txbLocation.Text;
                computer.System_unit = txbSystem_unit.Text;
                computer.System_board = txbSystem_board.Text;
                computer.Processor = txbProcessor.Text;
                computer.RAM = txbRAM.Text.ToString();
                computer.Video_card = txbVideo_card.Text;
                computer.Video_memory = txbVideo_memory.Text.ToString();
                computer.HDD = txbHDD.Text;
                computer.HDD_capacity = txbHDD_capacity.Text.ToString();
                computer.CD_ROM = txbCD_ROM.Text;
                computer.Monitor = txbMonitor.Text;
                computer.Monitor_2 = txbMonitor_2.Text;
                computer.Keyboard = txbKeyboard.Text;
                computer.Mouse = txbMouse.Text;
                computer.Printer = txbPrinter.Text;
                computer.Scanner = txbScanner.Text;
                computer.Price_all = Convert.ToDecimal(txbPrice_all.Text);
                computer.Purchase_date = Convert.ToDateTime(txbPurchase_date.Text);
                computer.OS = txbOS.Text;
                computer.Notes = txbNotes.Text;

                if (computer.Network_name == "" || computer.IpAddress == "" || computer.Location == "" || computer.System_unit == "" || computer.System_board == ""
                    || computer.Processor == "" || computer.Video_card == "" || computer.HDD == "" || computer.Monitor == "" || computer.Keyboard == ""
                    || computer.Mouse == "" || computer.Price_all <= 0 || computer.OS == "")
                {
                    MessageBox.Show("Вы не доконца заполнили запись", "Ошибка");
                }
                else
                {
                    if (!red)
                    {
                        AppConnect.db.Computer.Add(computer);
                    }
                    AppConnect.db.SaveChanges();
                    MainWindow main = new MainWindow();
                    main.DataGrid.ItemsSource = AppConnect.db.Computer.ToList();
                    Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
    }
}
