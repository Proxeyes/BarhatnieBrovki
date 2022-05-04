﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data;
using Barhatnie_Brovki.Models;

namespace Barhatnie_Brovki
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static String connectionString = "server=307-01\\SQLEXPRESS01; Initial Catalog=brovki;Integrated Security=SSPI";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataSet ds;
        public MainWindow()
        {
            InitializeComponent();
            FillList();
            
        }
        
        public void FillList()
        {
            try
            {
                con = new SqlConnection(connectionString);
                con.Open();
                cmd = new SqlCommand("SELECT * FROM Service", con);
                adapter = new SqlDataAdapter(cmd);
                ds = new DataSet();
                adapter.Fill(ds, "Service");
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
                
                }
                lstBox.ItemsSource = co1;
                con = new SqlConnection(connectionString);
                con.Open();
                cmd = new SqlCommand("SELECT Count (*) FROM Service ", con);
                adapter = new SqlDataAdapter(cmd);
                string fg = cmd.ExecuteScalar().ToString();
                Count1.Text = fg;
                ds = new DataSet();
                adapter.Fill(ds, "Service");
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                ds = null;
                adapter.Dispose();
                con.Close();
                con.Dispose();
                Count.IsEnabled = false;
                Count1.IsEnabled = false;
            }
        }


        public void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string intext = text.Text.ToString();
            try
            {
                
                con = new SqlConnection(connectionString);
                con.Open();
                cmd = new SqlCommand("SELECT * FROM Service WHERE Title LIKE '" + intext.ToString() + "%' OR Cost LIKE '" + intext.ToString() + "%'  ", con);
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

                }
                lstBox.ItemsSource = co1;
                con = new SqlConnection(connectionString);
                con.Open();
                cmd = new SqlCommand("SELECT Count (*) FROM Service WHERE Title LIKE '" + intext.ToString() + "%' OR Cost LIKE '" + intext.ToString() + "%'  ", con);
                adapter = new SqlDataAdapter(cmd);
                string fg = cmd.ExecuteScalar().ToString();
                Count.Text = fg;
                ds = new DataSet();
                adapter.Fill(ds, "Service");
                



            }
            catch (Exception ex)
            {

            }
            finally
            {
                ds = null;
                adapter.Dispose();
                con.Close();
                con.Dispose();
            }

        }
        
        
        
        public void Button_Click(object sender, RoutedEventArgs e)
        { 
            try
            {

            
            int a = Convert.ToInt32((sender as Button).Uid);
            con = new SqlConnection(connectionString);
            con.Open();
            cmd = new SqlCommand("DELETE FROM Service WHERE ID = " + a + "", con);
            adapter = new SqlDataAdapter(cmd);
            ds = new DataSet();
            adapter.Fill(ds,"Service");
            ds = null;
            adapter.Dispose();
            con.Close();
            con.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        
        

       

        private void dobavl_Uslugi(object sender, RoutedEventArgs e)
        {
            AddUslugi add = new AddUslugi();
            add.Show();
            this.Close();
        }

        private void Rename(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32((sender as Button).Uid);
            Redact redact = new Redact(a);
            redact.Show();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)cmBox.SelectedItem;
            string intext = selectedItem.Content.ToString();


            try
            {
                if (intext == "Без фильтров")
                {
                    intext = "0";
                }
                else if (intext == "до 5%")
                    intext = "0.05";
                else if (intext == "от 10% до 15%")
                    intext = "0.1";
                else if (intext == "от 20% до 25%")
                    intext = "0.2";
                else if (intext == "до 30%")
                    intext = "0.3";


                con = new SqlConnection(connectionString);
                con.Open();
                cmd = new SqlCommand("SELECT * FROM Service WHERE Discount LIKE '" + intext.ToString() + "%'", con);
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

                }
                lstBox.ItemsSource = co1;
                con = new SqlConnection(connectionString);
                con.Open();
                cmd = new SqlCommand("SELECT Count (*) FROM Service WHERE Discount LIKE '" + intext.ToString() + "%'", con);
                adapter = new SqlDataAdapter(cmd);
                string fg = cmd.ExecuteScalar().ToString();
                Count.Text = fg;
                ds = new DataSet();
                adapter.Fill(ds, "Service");
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ds = null;
                adapter.Dispose();
                con.Close();
                con.Dispose();
            }
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            string intext = text.Text.ToString();
            try
            {

                con = new SqlConnection(connectionString);
                con.Open();
                cmd = new SqlCommand("SELECT * FROM Service WHERE Title LIKE '" + intext.ToString() + "%' OR Cost LIKE '" + intext.ToString() + "%' ", con);
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

                }
                lstBox.ItemsSource = co1;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ds = null;
                adapter.Dispose();
                con.Close();
                con.Dispose();
            }
        }

        private void update(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        
        

        private void Client_Click(object sender, RoutedEventArgs e)
        {
            Client client = new Client();
            client.Show();
            this.Close();
        }
    } 
}
    

