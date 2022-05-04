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

namespace Barhatnie_Brovki.Models
{
    public class Product
    {
        
     
    
            public int ID { get; set; }
            public string Name { get; set; }
            public string Text { get; set; }
            public double Price { get; set; }
            public int DurationInSeconds { get; set; }
            public string Description { get; set; }
            public double Discount { get; set; }
            public string MainImagePath { get; set; }

        
    }
}
