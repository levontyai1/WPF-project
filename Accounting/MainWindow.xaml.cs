using Accounting.ApplicationData;
using Accounting.Windows;
using DevExpress.Data.ODataLinq.Helpers;
using DevExpress.Data.Utils;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace Accounting
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        Add_and_Edit_devices aaeD = new Add_and_Edit_devices(null);
        Add_and_Edit_staff aaeS = new Add_and_Edit_staff(null);
        Authorization authorization = new Authorization();
        Add_and_Edit_program aaeP = new Add_and_Edit_program(null, null);
        Add_and_Edit_repair aaeR = new Add_and_Edit_repair(null, null);
        
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataGrid.ItemsSource = AppConnect.db.Computer.ToList();
            DataGrid2.ItemsSource = AppConnect.db.User.ToList();
        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            authorization.Show();
            Close();
        }
        private void CSV(object sender, RoutedEventArgs e)
        {
            var excelApp = new Excel.Application();
            excelApp.Visible = true;
            Workbooks books = excelApp.Workbooks;

            Excel.Application app = new Excel.Application();
            Workbook mWorkBook = app.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet mWSheet1 = (Worksheet)mWorkBook.Worksheets.get_Item(1);

            mWSheet1.Cells[1, 1] = "ID"; // row, coloum
            mWSheet1.Cells[1, 1].Font.Bold = true; //bold font

            mWSheet1.Cells[1, 2] = "Имя в сети"; //row, coloum
            mWSheet1.Cells[1, 2].Font.Bold = true; //bold font

            mWSheet1.Cells[1, 3] = "IP Адрес"; //row, coloumn
            mWSheet1.Cells[1, 3].Font.Bold = true; //bold font
                                                   
            mWSheet1.Cells[1, 4] = "Место расположения"; //row, coloumn
            mWSheet1.Cells[1, 4].Font.Bold = true; //bold font

            mWSheet1.Cells[1, 5] = "Сист. блок"; //row, coloumn
            mWSheet1.Cells[1, 5].Font.Bold = true; //bold font

            mWSheet1.Cells[1, 6] = "Мат. плата"; //row, coloumn
            mWSheet1.Cells[1, 6].Font.Bold = true; //bold font

            mWSheet1.Cells[1, 7] = "Процессор"; //row, coloumn
            mWSheet1.Cells[1, 7].Font.Bold = true; //bold font

            mWSheet1.Cells[1, 8] = "Оперативная память"; //row, coloumn
            mWSheet1.Cells[1, 8].Font.Bold = true; //bold font

            mWSheet1.Cells[1, 9] = "Видео карта"; //row, coloumn
            mWSheet1.Cells[1, 9].Font.Bold = true; //bold font

            mWSheet1.Cells[1, 10] = "Видео память"; //row, coloumn
            mWSheet1.Cells[1, 10].Font.Bold = true; //bold font

            mWSheet1.Cells[1, 11] = "HDD"; //row, coloumn
            mWSheet1.Cells[1, 11].Font.Bold = true; //bold font

            mWSheet1.Cells[1, 12] = "Объем HDD"; //row, coloumn
            mWSheet1.Cells[1, 12].Font.Bold = true; //bold font

            mWSheet1.Cells[1, 13] = "CD-ROM"; //row, coloumn
            mWSheet1.Cells[1, 13].Font.Bold = true; //bold font

            mWSheet1.Cells[1, 14] = "Монитор"; //row, coloumn
            mWSheet1.Cells[1, 14].Font.Bold = true; //bold font

            mWSheet1.Cells[1, 15] = "Монитор 2"; //row, coloumn
            mWSheet1.Cells[1, 15].Font.Bold = true; //bold font

            mWSheet1.Cells[1, 16] = "Клавиатура"; //row, coloumn
            mWSheet1.Cells[1, 16].Font.Bold = true; //bold font

            mWSheet1.Cells[1, 17] = "Мышь"; //row, coloumn
            mWSheet1.Cells[1, 17].Font.Bold = true; //bold font

            mWSheet1.Cells[1, 18] = "Принтер"; //row, coloumn
            mWSheet1.Cells[1, 18].Font.Bold = true; //bold font

            mWSheet1.Cells[1, 19] = "Сканер"; //row, coloumn
            mWSheet1.Cells[1, 19].Font.Bold = true; //bold font

            mWSheet1.Cells[1, 20] = "Цена за всё"; //row, coloumn
            mWSheet1.Cells[1, 20].Font.Bold = true; //bold font

            mWSheet1.Cells[1, 21] = "Дата покупки"; //row, coloumn
            mWSheet1.Cells[1, 21].Font.Bold = true; //bold font

            mWSheet1.Cells[1, 22] = "ОС"; //row, coloumn
            mWSheet1.Cells[1, 22].Font.Bold = true; //bold font

            mWSheet1.Cells[1, 23] = "Notes"; //row, coloumn
            mWSheet1.Cells[1, 23].Font.Bold = true; //bold font


            foreach (Computer computer in AppConnect.db.Computer)
            {
                mWSheet1.Cells[2, 1] = computer.IDComputer;
                mWSheet1.Cells[2, 2] = computer.Network_name;
                mWSheet1.Cells[2, 3] = computer.IpAddress; ;
                mWSheet1.Cells[2, 4] = computer.Location;
                mWSheet1.Cells[2, 5] = computer.System_unit;
                mWSheet1.Cells[2, 6] = computer.System_board;
                mWSheet1.Cells[2, 7] = computer.Processor;
                mWSheet1.Cells[2, 8] = computer.RAM;
                mWSheet1.Cells[2, 9] = computer.Video_card;
                mWSheet1.Cells[2, 10] = computer.Video_memory;
                mWSheet1.Cells[2, 11] = computer.HDD;
                mWSheet1.Cells[2, 12] = computer.HDD_capacity;
                mWSheet1.Cells[2, 13] = computer.CD_ROM;
                mWSheet1.Cells[2, 14] = computer.Monitor;
                mWSheet1.Cells[2, 15] = computer.Monitor_2;
                mWSheet1.Cells[2, 16] = computer.Keyboard;
                mWSheet1.Cells[2, 17] = computer.Mouse;
                mWSheet1.Cells[2, 18] = computer.Printer;
                mWSheet1.Cells[2, 19] = computer.Scanner;
                mWSheet1.Cells[2, 20] = computer.Price_all;
                mWSheet1.Cells[2, 21] = computer.Purchase_date;
                mWSheet1.Cells[2, 22] = computer.OS;
                mWSheet1.Cells[2, 23] = computer.Notes;
            }
            mWorkBook.SaveAs(System.IO.Path.Combine(Environment.CurrentDirectory, "Export", "data.csv"));
            mWorkBook.Close(true);
        }
        private void Prog(object sender, RoutedEventArgs e)
        {
            Prog prog = new Prog();
            prog.ShowDialog();
        }
        private void Add_devices(object sender, RoutedEventArgs e)
        {
            if (Title == "Учет компьютерной техники - Гость")
            {
                MessageBox.Show("У вас недостаточно прав", "Ошибка");
            }
            else
            {
                aaeD = new Add_and_Edit_devices(null);
                aaeD.ShowDialog();
            }
        }
        private void Edit_devices(object sender, RoutedEventArgs e)
        {
            if (Title == "Учет компьютерной техники - Гость")
            {
                MessageBox.Show("У вас недостаточно прав", "Ошибка");
            }
            else
            {
                var currentComputer = DataGrid.SelectedItem as Computer;
                aaeD = new Add_and_Edit_devices(currentComputer);
                aaeD.ShowDialog();
            }
        }
        private void Delete_devices(object sender, RoutedEventArgs e)
        {
            if (Title == "Учет компьютерной техники - Гость")
            {
                MessageBox.Show("У вас недостаточно прав", "Ошибка");
            }
            else
            {
                if (MessageBox.Show("Вы уверены что хотите удалить запись?", "Подтверждение удаления данных",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    try
                    {
                        var currentComputer = DataGrid.SelectedItem as Computer;
                        AppConnect.db.Computer.Remove(currentComputer);
                        AppConnect.db.SaveChanges();
                        DataGrid.ItemsSource = AppConnect.db.Computer.ToList();
                        MessageBox.Show("Выполнено", "Выполнено", MessageBoxButton.OK);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка");
                    }
                }
            }
        }
        private void Update_devices(object sender, RoutedEventArgs e)
        {
            DataGrid.ItemsSource = AppConnect.db.Computer.ToList();
        }
        private void Add_staff(object sender, RoutedEventArgs e)
        {
            if (Title == "Учет компьютерной техники - Гость")
            {
                MessageBox.Show("У вас недостаточно прав", "Ошибка");
            }
            else
            {
                aaeS = new Add_and_Edit_staff(null);
                aaeS.ShowDialog();
            }
        }
        private void Edit_staff(object sender, RoutedEventArgs e)
        {
            if (Title == "Учет компьютерной техники - Гость")
            {
                MessageBox.Show("У вас недостаточно прав", "Ошибка");
            }
            else
            {
                var currentUser = DataGrid2.SelectedItem as User;
                aaeS = new Add_and_Edit_staff(currentUser);
                aaeS.ShowDialog();
            }
        }
        private void Delete_staff(object sender, RoutedEventArgs e)
        {
            if (Title == "Учет компьютерной техники - Гость")
            {
                MessageBox.Show("У вас недостаточно прав", "Ошибка");
            }
            else
            {
                if (MessageBox.Show("Вы уверены что хотите удалить запись?", "Подтверждение удаления данных",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    try
                    {
                        var currentUser = DataGrid2.SelectedItem as User;
                        AppConnect.db.User.Remove(currentUser);
                        AppConnect.db.SaveChanges();
                        DataGrid2.ItemsSource = AppConnect.db.Computer.ToList();
                        MessageBox.Show("Выполнено", "Выполнено", MessageBoxButton.OK);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка");
                    }
                }
            }
        }
        private void Update_staff(object sender, RoutedEventArgs e)
        {
            DataGrid2.ItemsSource = AppConnect.db.User.ToList();
        }
        //ddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd
        private void Add_program(object sender, RoutedEventArgs e)
        {
            if (Title == "Учет компьютерной техники - Гость")
            {
                MessageBox.Show("У вас недостаточно прав", "Ошибка");
            }
            else
            {
                var currentComputer = DataGrid.SelectedItem as Computer;
                aaeP = new Add_and_Edit_program(null, currentComputer);
                aaeP.ShowDialog();
            }
        }
        private void Edit_program(object sender, RoutedEventArgs e)
        {
            if (Title == "Учет компьютерной техники - Гость")
            {
                MessageBox.Show("У вас недостаточно прав", "Ошибка");
            }
            else
            {
                var currentProgram = DataGrid1.SelectedItem as Program;
                aaeP = new Add_and_Edit_program(currentProgram, null);
                aaeP.ShowDialog();
            }
        }
        private void Delete_program(object sender, RoutedEventArgs e)
        {
            if (Title == "Учет компьютерной техники - Гость")
            {
                MessageBox.Show("У вас недостаточно прав", "Ошибка");
            }
            else
            {
                if (MessageBox.Show("Вы уверены что хотите удалить запись?", "Подтверждение удаления данных",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    try
                    {
                        foreach (var PC in AppConnect.db.Program_Computer.ToList())
                        {
                            AppConnect.db.Program_Computer.Remove(PC);
                        }
                        var currentProgram = DataGrid1.SelectedItem as Program;
                        AppConnect.db.Program.Remove(currentProgram);
                        AppConnect.db.SaveChanges();
                        DataGrid1.ItemsSource = AppConnect.db.Program.ToList();
                        MessageBox.Show("Выполнено", "Выполнено", MessageBoxButton.OK);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка");
                    }
                }
            }
        }
        private void Update_program(object sender, RoutedEventArgs e)
        {
            DataGrid1.ItemsSource = AppConnect.db.Program.ToList();
            /*var currentComputer = DataGrid.SelectedItem as Computer;
            foreach (var PC in AppConnect.db.Program_Computer.ToList())
            {
                for (int i = 0; AppConnect.db.Program_Computer.Local.Count() > i ;i++)
                {
                    PC.IDComputer = AppConnect.db.Program_Computer.Local[i].IDComputer;
                    if(currentComputer.IDComputer == PC.IDComputer)
                        DataGrid1.ItemsSource = AppConnect.db.Program.Where(p => currentComputer.IDComputer == PC.IDComputer).ToList();
                }
            }*/
        }
        private void Add_repair(object sender, RoutedEventArgs e)
        {
            if (Title == "Учет компьютерной техники - Гость")
            {
                MessageBox.Show("У вас недостаточно прав", "Ошибка");
            }
            else
            {
                var currentComputer = DataGrid.SelectedItem as Computer;
                aaeR = new Add_and_Edit_repair(null, currentComputer);
                aaeR.ShowDialog();
            }
        }
        private void Edit_repair(object sender, RoutedEventArgs e)
        {
            if (Title == "Учет компьютерной техники - Гость")
            {
                MessageBox.Show("У вас недостаточно прав", "Ошибка");
            }
            else
            {
                var currentRaM = DataGrid3.SelectedItem as RaM;
                aaeR = new Add_and_Edit_repair(currentRaM, null);
                aaeR.ShowDialog();
            }
        }
        private void Delete_repair(object sender, RoutedEventArgs e)
        {
            if (Title == "Учет компьютерной техники - Гость")
            {
                MessageBox.Show("У вас недостаточно прав", "Ошибка");
            }
            else
            {
                if (MessageBox.Show("Вы уверены что хотите удалить запись?", "Подтверждение удаления данных",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    try
                    {
                        foreach (var RC in AppConnect.db.RaM_Computer.ToList())
                        {
                            AppConnect.db.RaM_Computer.Remove(RC);
                        }
                        var currentRaM = DataGrid3.SelectedItem as RaM;
                        AppConnect.db.RaM.Remove(currentRaM);
                        AppConnect.db.SaveChanges();
                        DataGrid3.ItemsSource = AppConnect.db.RaM.ToList();
                        MessageBox.Show("Выполнено", "Выполнено", MessageBoxButton.OK);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка");
                    }
                }
            }
        }
        private void Update_repair(object sender, RoutedEventArgs e)
        {
            DataGrid2.ItemsSource = AppConnect.db.RaM.ToList();
        }
        //ddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd
        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Title == "Учет компьютерной техники - Гость")
            {
                MessageBox.Show("У вас недостаточно прав", "Ошибка");
            }
            else
            {
                var currentComputer = DataGrid.SelectedItem as Computer;
                aaeD = new Add_and_Edit_devices(currentComputer);
                aaeD.ShowDialog();
            }
        }
        private void DataGrid2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Title == "Учет компьютерной техники - Гость")
            {
                MessageBox.Show("У вас недостаточно прав", "Ошибка");
            }
            else
            {
                var currentUser = DataGrid2.SelectedItem as User;
                aaeS = new Add_and_Edit_staff(currentUser);
                aaeS.ShowDialog();
            }
        }

        private void DataGrid1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Title == "Учет компьютерной техники - Гость")
            {
                MessageBox.Show("У вас недостаточно прав", "Ошибка");
            }
            else
            {
                var currentProgram = DataGrid1.SelectedItem as Program;
                aaeP = new Add_and_Edit_program(currentProgram, null);
                aaeP.ShowDialog();
            }
        }

        private void DataGrid3_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Title == "Учет компьютерной техники - Гость")
            {
                MessageBox.Show("У вас недостаточно прав", "Ошибка");
            }
            else
            {
                var currentRaM = DataGrid3.SelectedItem as RaM;
                aaeR = new Add_and_Edit_repair(currentRaM, null);
                aaeR.ShowDialog();
            }
        }

    }
}
