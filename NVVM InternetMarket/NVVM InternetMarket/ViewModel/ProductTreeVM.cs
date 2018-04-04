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
    class ProductTreeVM : ObservableObject
    {

        public ProductTreeVM()
        {
            Categories = new ObservableCollection<CategoryItem>(MockDataService.Instance.GetCategories());
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
