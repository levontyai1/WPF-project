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
    /// Логика взаимодействия для Add_and_Edit_program.xaml
    /// </summary>
    public partial class Add_and_Edit_program : Window
    {
        Program program;
        Computer computer = new Computer();
        bool red;
        Program_Computer PC = new Program_Computer();
        public Add_and_Edit_program(Program currentProgram, Computer currentComputer)
        {
            InitializeComponent();

            program = currentProgram;
            computer = currentComputer;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (program != null)
            {
                txbProgram_name.Text = program.Program_name;
                txbDescription.Text = program.Description;
                txbPrice.Text = program.Price.ToString();
                txbInstallation_date.Text = program.Installation_date.ToString();
                red = true;
            }
            else program = new Program();
        }

        private void OK(object sender, RoutedEventArgs e)
        {
            try
            {
                program.Program_name = txbProgram_name.Text;
                program.Description = txbDescription.Text;
                program.Price = Convert.ToDecimal(txbPrice.Text);
                program.Installation_date = Convert.ToDateTime(txbInstallation_date.Text);

                if (program.Program_name == "" || program.Price <= 0)
                {
                    MessageBox.Show("Вы не доконца заполнили запись", "Ошибка");
                }
                else
                {
                    if (!red)
                    {
                        PC.IDProgram = program.IDProgram;
                        PC.IDComputer = computer.IDComputer;
                        AppConnect.db.Program_Computer.Add(PC);
                        AppConnect.db.Program.Add(program);
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
