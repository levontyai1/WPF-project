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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Accounting.Windows
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void Entry(object sender, RoutedEventArgs e)
        {
            if (Login.Text.ToString() == "Админ" && Password.Password == "admin" || Login.Text.ToString() == "Гость")
            {
                MainWindow main = new MainWindow();
                main.Title += " - " + Login.Text.ToString();
                main.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Вы ввели неправильный пароль", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
