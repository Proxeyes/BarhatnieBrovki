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

namespace Barhatnie_Brovki
{
    /// <summary>
    /// Логика взаимодействия для Vhod.xaml
    /// </summary>
    public partial class Vhod : Window
    {

        public Vhod()
        {
            InitializeComponent();
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }
        private void Login(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password == "1234")
            {
                Guest gs = new Guest();
                gs.Show();
                this.Close();
            }
            else if (passwordBox.Password == "0000")
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка ввода пароля");
            }
        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            Vhod vhod = new Vhod();
            vhod.Close();
            this.Close();
        }
    }
}
