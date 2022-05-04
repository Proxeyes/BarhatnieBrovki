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
using System.Data.SqlClient;
using System.Data;
using System.IO;
using Barhatnie_Brovki.Models;
using Microsoft.Win32;

namespace Barhatnie_Brovki
{
    
    
    public partial class Redact : Window
    {
        static String connectionString = "server=307-01\\SQLEXPRESS01; Initial Catalog=brovki;Integrated Security=SSPI";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataSet ds;
        Product srv;
        public int id { get; set; }
        public Redact(int id=0)
        {
            
            InitializeComponent();
             this.id = id;
            FillList();
            
            TitleText.Text = srv.Name;
            CostTetxt.Text = Convert.ToString(srv.Price);
            DurText.Text = Convert.ToString(srv.DurationInSeconds);
            ImgText.Text = srv.MainImagePath;
        }
        public void FillList()
        {
            try
            {
                con = new SqlConnection(connectionString);
                con.Open();
                cmd = new SqlCommand("SELECT * FROM Service WHERE ID = " + id + "", con);
                adapter = new SqlDataAdapter(cmd);
                ds = new DataSet();
                adapter.Fill(ds, "Service");
                Product co = new Product();
                IList<Product> co1 = new List<Product>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    co1.Add(new Product
                    {
                        ID = Convert.ToInt32(dr[0].ToString()),
                        Name = dr[1].ToString(),
                        Price = Convert.ToDouble(dr[2].ToString()),
                        DurationInSeconds = Convert.ToInt32(dr[3].ToString()),
                        Description = dr[4].ToString(),
                        Discount = Convert.ToDouble(dr[5].ToString()),
                        MainImagePath = Convert.ToString(dr[6].ToString())
                    });
                    srv = new Product
                    {
                        ID = Convert.ToInt32(dr[0].ToString()),
                        Name = dr[1].ToString(),
                        Price = Convert.ToDouble(dr[2].ToString()),
                        DurationInSeconds = Convert.ToInt32(dr[3].ToString()),
                        Description = dr[4].ToString(),
                        Discount = Convert.ToDouble(dr[5].ToString()),
                        MainImagePath = Convert.ToString(dr[6].ToString())
                    };
                }
                //lstBox.ItemsSource = co1;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                ds = null;
                adapter.Dispose();
                con.Close();
                con.Dispose();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Product cr = new Product();
                cr.Name = Convert.ToString(TitleText.Text.ToString());
                cr.Price = Convert.ToDouble(CostTetxt.Text.ToString());
                cr.DurationInSeconds = Convert.ToInt32(DurText.Text.ToString());
                cr.MainImagePath = Convert.ToString(ImgText.Text.ToString());
                con = new SqlConnection(connectionString);
                con.Open();

                cmd = new SqlCommand("UPDATE Service SET Title = '" + cr.Name + "', Cost = '" + cr.Price + "', DurationInSeconds = " + cr.DurationInSeconds + ", MainImagePath = '" + cr.MainImagePath + "' WHERE ID= " + id + " ", con);
                adapter = new SqlDataAdapter(cmd);
                ds = new DataSet();
                adapter.Fill(ds, "Service");
                ds = null;
                adapter.Dispose();
                con.Close();
                con.Dispose();


                System.Windows.MessageBox.Show("Услуга успешно обновлена!", "Уведомление");
                MainWindow zap = new MainWindow();
                zap.Show();
                this.Close();
            }
            catch
            {
                System.Windows.MessageBox.Show("Проверьте правильность ввода", "Ошибка");

            }

        }
        private string imgName;
        private void add_img(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*jpg|All Files (*.*)|*.*";
            ofd.ShowDialog();
            string imgPath = ofd.FileName;

            string[] splitter = imgPath.Split('\\');

            imgName = @"C:\Users\307-01\Desktop\Barhatnie_Brovki\Image\" + splitter[splitter.Length - 1];

            var di = new DirectoryInfo(@"C:\Users\307-01\Desktop\Barhatnie_Brovki\Image\");


            System.IO.File.Copy(imgPath, imgName, true);
            ImgText.Text = imgPath;

            System.Windows.MessageBox.Show("ok!");
        }

        private void Button_ClickNazad(object sender, RoutedEventArgs e)
        {

        }
    }
}
