using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml.Serialization;
using Microsoft.Win32;
using Barhatnie_Brovki.ViewModel.Common;
using Barhatnie_Brovki.Models;


namespace Barhatnie_Brovki.ViewModel
{
    internal class ProductRepositoryViewModel
    {
        
        private ICommand _clearProducts;
        private ICommand _saveProducts;
        private ICommand _loadProducts;
        private ICommand _showAll;
        private ICommand _showFiltered;

        public ProductFilterViewModel ProductFilter { get; set; }
        public ObservableCollection<ProductViewModel> Products { get; set; }
        public ObservableCollection<ProductViewModel> FilteredProducts { get; set; }

        public ICommand ShowAll
        {
            get
            {
                if (_showAll == null)
                {
                    _showAll = new RelayCommand(x =>
                    {
                        FilteredProducts.Clear();
                        foreach (var productViewModel in Products)
                        {
                            FilteredProducts.Add(productViewModel);
                        }
                    });
                }

                return _showAll;
            }
        }
        public ICommand ShowFiltered
        {
            get
            {
                if (_showFiltered == null)
                {
                    _showFiltered = new RelayCommand(x =>
                    {
                        int priceFrom = 0;
                        int priceTo = 0;

                        if (ProductFilter.ByPrice)
                        {
                            bool r1 = Int32.TryParse(ProductFilter.PriceFrom, out priceFrom);
                            bool r2 = Int32.TryParse(ProductFilter.PriceTo, out priceTo);

                            if (!(r1 && r2))
                            {
                                MessageBox.Show("Не корректная цена", "Ошибка", MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                                return;
                            }
                        }

                        var filteredObj = from obj in Products
                                          where (!ProductFilter.ByText ||
                                                 Regex.IsMatch(obj.Name, $"^{ProductFilter.Text}", RegexOptions.IgnoreCase))
                                                &&
                                                (!ProductFilter.ByPrice ||
                                                 (obj.Price > priceFrom && obj.Price < priceTo))
                                          select obj;

                        FilteredProducts.Clear();

                        foreach (var productViewModel in filteredObj)
                        {
                            FilteredProducts.Add(productViewModel);
                        }

                    }, x => ProductFilter.ByPrice || ProductFilter.ByText);
                }
                return _showFiltered;
            }
        }
    }
}
