using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barhatnie_Brovki.Models;

namespace Barhatnie_Brovki.ViewModel
{
    public class ProductViewModel
    {
        private Product product ;
        public string Name
        {
            get { return product.Name; }
            set { product.Name = value; }
        }

     

        public double Price
        {
            get { return product.Price; }
            set { product.Price = value; }
        }

       

        public Product Model()
        {
            return product;
        }

        public ProductViewModel()
        {
            product = new Product();
        }

        public ProductViewModel(Product p)
        {
            product = p;
        }
    }
}
