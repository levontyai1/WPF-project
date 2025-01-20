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
    /// Логика взаимодействия для Add_and_Edit_repair.xaml
    /// </summary>
    public partial class Add_and_Edit_repair : Window
    {
        RaM ram;
        Computer computer = new Computer();
        bool red;
        Program_Computer PC = new Program_Computer();
        public Add_and_Edit_repair(RaM currentRaM, Computer currentComputer)
        {
            InitializeComponent();

            ram = currentRaM;
            computer = currentComputer;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (ram != null)
            {
                txbRepair_date.Text = ram.Repair_date.ToString();
                txbDescription.Text = ram.Description;
                txbType_of_repair.Text = ram.Type_of_repair;
                txbPrice.Text = ram.Price.ToString();
                red = true;
            }
            else ram = new RaM();
        }

        private void OK(object sender, RoutedEventArgs e)
        {
            try
            {
                ram.Repair_date = Convert.ToDateTime(txbRepair_date.Text);
                ram.Description = txbDescription.Text;
                ram.Type_of_repair = txbType_of_repair.Text;
                ram.Price = Convert.ToDecimal(txbPrice.Text);

                if (ram.Type_of_repair == "" || ram.Price <= 0)
                {
                    MessageBox.Show("Вы не доконца заполнили запись", "Ошибка");
                }
                else
                {
                    if (!red)
                    {
                        PC.IDProgram = ram.IDRaM;
                        PC.IDComputer = computer.IDComputer;
                        AppConnect.db.Program_Computer.Add(PC);
                        AppConnect.db.RaM.Add(ram);
                    }
                    AppConnect.db.SaveChanges();
                    MainWindow main = new MainWindow();
                    main.DataGrid.ItemsSource = AppConnect.db.User.ToList();
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
    }
}
