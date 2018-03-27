using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NVVM_InternetMarket.Model;

namespace NVVM_InternetMarket.ViewModel
{
    class ViewModel : ObservableObject
    {
        public ViewModel()
        {
            var category = new Electronics();
            Categories = new ObservableDictionary<string, ICategory> {{category.CategoryName, category}};
            Categories[category.CategoryName].Products.Add(new MobilePhone {Name = "Iphone 6", BrandName = "Apple"});
            Categories[category.CategoryName].Products.Add(new MobilePhone { Name = "Galaxy S8", BrandName = "Samsung" });
        }


        private ObservableDictionary<string, ICategory> _categories;

        public ObservableDictionary<string, ICategory> Categories
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
