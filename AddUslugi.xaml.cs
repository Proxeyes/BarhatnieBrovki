
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
using System.Collections;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using Barhatnie_Brovki.Models;

namespace Barhatnie_Brovki
{
    /// <summary>
    /// Логика взаимодействия для AddUslugi.xaml
    /// </summary>
    public partial class AddUslugi : Window
    {
        static String connectionString = "server=307-01\\SQLEXPRESS01; Initial Catalog=brovki;Integrated Security=SSPI";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataSet ds;
        public AddUslugi()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
         Product pr = new Product();
            pr.Name = Convert.ToString(TitleText.Text.ToString());
            pr.Price = Convert.ToDouble(Cost.Text.ToString());
            pr.DurationInSeconds = Convert.ToInt32(DurText.Text.ToString());
            pr.Description = Convert.ToString(DescText.Text.ToString());
            pr.Discount = Convert.ToDouble(discountText.Text.ToString());
            pr.MainImagePath = Convert.ToString(ImgText.Text.ToString());
            con = new SqlConnection(connectionString);
            con.Open();
            cmd = new SqlCommand("INSERT INTO Service (Title, Cost, DurationInSeconds, Description, Discount, MainImagePath) VALUES ('" + pr.Name + "', " + pr.Price + " , " + pr.DurationInSeconds + ", '" + pr.Description + "', " + pr.Discount + ", '" + pr.MainImagePath + "') ", con);
            //MessageBox.Show(pr.Name + pr.Price + pr.DurationInSeconds + pr.Description + pr.Discount + pr.MainImagePath);
            adapter = new SqlDataAdapter(cmd);
           ds = new DataSet();
            adapter.Fill(ds, "Service");
            ds = null;
            adapter.Dispose();
            con.Close();
            con.Dispose();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
