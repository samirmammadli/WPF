using NVVM_InternetMarket.Model;
using NVVM_InternetMarket.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVVM_InternetMarket.ViewModel
{
    class ItemsListVM : ObservableObject
    {
        private ObservableCollection<Product> products;

        public ObservableCollection<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChanged();
            }
        }

        public void LoadProducts(CategoryItem category)
        {
            Products = new ObservableCollection<Product>(MockDataService.Instance.GetProducts(category));
        }
    }
}
