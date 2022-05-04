using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barhatnie_Brovki.ViewModel
{
    public class ProductFilterViewModel
    {
        public bool ByText { get; set; }
        public bool ByPrice { get; set; }
       

        public string Text { get; set; }
        public string PriceFrom { get; set; } = 0.ToString();
        public string PriceTo { get; set; } = 100000.ToString();
       

    }
}