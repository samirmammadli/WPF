using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NVVM_InternetMarket.Model;
using NVVM_InternetMarket.Services;

namespace NVVM_InternetMarket.ViewModel
{
    class ViewModel : ObservableObject
    {
        static private ViewModel _instance;

        static public ViewModel Instance
        {
            get
            {
                return _instance ?? (_instance = new ViewModel());
            }
        }

        public ViewModel()
        {
            Categories = new ObservableCollection<CategoryItem>(MockDataService.Instance.GetCategories());
        }
        private Product _currentProduct;

        public Product CurrentProduct
        {
            get { return _currentProduct; }
            set { _currentProduct = value; }
        }


        private ObservableCollection<CategoryItem> _categories;

        public ObservableCollection<CategoryItem> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                OnPropertyChanged();
            }
        }


    }
}
