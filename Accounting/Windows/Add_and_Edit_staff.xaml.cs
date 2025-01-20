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
    /// Логика взаимодействия для Add_and_Edit_staff.xaml
    /// </summary>
    public partial class Add_and_Edit_staff : Window
    {
        User user;
        bool red;
        public Add_and_Edit_staff(User currentUser)
        {
            InitializeComponent();

            user = currentUser;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (user != null)
            {
                txbFIO.Text = user.FIO;
                txbAccount_name.Text = user.Account_name;
                txbPassword.Text = user.Password;
                txbTelephone.Text = user.Telephone;
                txbEmail.Text = user.Email;
                txbCreation_date.Text = user.Creation_date.ToString();
                red = true;
            }
            else user = new User();
        }

        private void OK(object sender, RoutedEventArgs e)
        {
            try
            {
                user.FIO = txbFIO.Text;
                user.Account_name = txbAccount_name.Text;
                user.Password = txbPassword.Text;
                user.Telephone = txbTelephone.Text;
                user.Email = txbEmail.Text;
                user.Creation_date = Convert.ToDateTime(txbCreation_date.Text);

                if (user.FIO == "" || user.Account_name == "" || user.Password == "" || user.Telephone == "" || user.Email == "")
                {
                    MessageBox.Show("Вы не доконца заполнили запись", "Ошибка");
                }
                else
                {
                    if (!red)
                    {
                        AppConnect.db.User.Add(user);
                    }
                    AppConnect.db.SaveChanges();
                    MainWindow main = new MainWindow();
                    main.DataGrid.ItemsSource = AppConnect.db.User.ToList();
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
