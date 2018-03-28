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
            var category = new Category { Name = "All products" };
            category.SubElements.Add(new Category { Name = "Electronics" });
            category.SubElements.FirstOrDefault().SubElements.Add(new Category { Name = "Mobile Phones" });
            category.SubElements.FirstOrDefault().SubElements.FirstOrDefault().SubElements.Add(new Product { Name = "Galaxy S8", BrandName = "Samsung"});
            category.SubElements.FirstOrDefault().SubElements.FirstOrDefault().SubElements.Add(new Product { Name = "Galaxy S7", BrandName = "Samsung" });
            category.SubElements.FirstOrDefault().SubElements.FirstOrDefault().SubElements.Add(new Product { Name = "Galaxy A5 2017", BrandName = "Samsung" });
            category.SubElements.FirstOrDefault().SubElements.FirstOrDefault().SubElements.Add(new Product { Name = "Galaxy A8 2015", BrandName = "Samsung" });
            category.SubElements.FirstOrDefault().SubElements.FirstOrDefault().SubElements.Add(new Product { Name = "Galaxy Note 9", BrandName = "Samsung" });

            Categories = new ObservableCollection<Element>();
            Categories.Add(category);

        }

        private ObservableCollection<Element> _categories;

        public ObservableCollection<Element> Categories
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
