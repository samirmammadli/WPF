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

            //Categories
            category.SubCategories.Add(new Category { Name = "Computer and Office" });
            category.SubCategories.Add(new Category { Name = "Sports" });
            category.SubCategories.Add(new Category { Name = "Consumer electronics"});


            ////Computer and Office
            //category.SubCategories.FirstOrDefault().SubCategories.Add(new Category { Name = "Mobile Phones" });
            //category.SubCategories.FirstOrDefault().SubCategories.FirstOrDefault().SubCategories.Add(new Product { Name = "Galaxy S8", BrandName = "Samsung" });
            //category.SubCategories.FirstOrDefault().SubCategories.FirstOrDefault().SubCategories.Add(new Product { Name = "Galaxy S7", BrandName = "Samsung" });
            //category.SubCategories.FirstOrDefault().SubCategories.FirstOrDefault().SubCategories.Add(new Product { Name = "Galaxy A5 2017", BrandName = "Samsung" });
            //category.SubCategories.FirstOrDefault().SubCategories.FirstOrDefault().SubCategories.Add(new Product { Name = "Galaxy A8 2015", BrandName = "Samsung" });
            //category.SubCategories.FirstOrDefault().SubCategories.FirstOrDefault().SubCategories.Add(new Product { Name = "Galaxy Note 9", BrandName = "Samsung" });

            ////Sports
            //category.SubCategories[1].SubCategories.Add(new Category { Name = "Boots" });
            //category.SubCategories[1].SubCategories.FirstOrDefault().SubCategories.Add(new Product { Name = "Shoes", BrandName = "Nike" });

            //Consumer electronics
            //category.SubCategories[2].SubCategories.Add(new Category { Name = "Home Audio and Video" });
            //category.SubCategories[2].SubCategories.Add(new Category { Name = "Portable Audio and Video" });
            //category.SubCategories[2].SubCategories.Add(new Category { Name = "Video Games" });
            //Television
            //category.SubCategories[2].SubCategories[0].SubCategories.Add(new Category { Name = "Television" });
            //category.SubCategories[2].SubCategories[0].SubCategories[0].SubCategories.Add(new Product { Name = "SM9013", BrandName = "Samsung" });
            //category.SubCategories[2].SubCategories[0].SubCategories[0].SubCategories.Add(new Product { Name = "G551080", BrandName = "LG" });
            ////Portable Audio and Video
            //category.SubCategories[2].SubCategories[0].SubCategories.Add(new Category { Name = "Console" });
            //category.SubCategories[2].SubCategories[0].SubCategories[1].SubCategories.Add(new Product { Name = "Play Station 2", BrandName = "Sony" });
            //category.SubCategories[2].SubCategories[0].SubCategories[1].SubCategories.Add(new Product { Name = "Play Station 3", BrandName = "Sony" });
            //category.SubCategories[2].SubCategories[0].SubCategories[1].SubCategories.Add(new Product { Name = "Play Station 4", BrandName = "Sony" });
            //category.SubCategories[2].SubCategories[0].SubCategories[1].SubCategories.Add(new Product { Name = "X-BOX ONE", BrandName = "Microsoft" });

            //Categories = new ObservableCollection<Category>();
            //Categories.Add(category);
        }
        private Product _currentProduct;

        public Product CurrentProduct
        {
            get { return _currentProduct; }
            set { _currentProduct = value; }
        }


        private ObservableCollection<Category> _categories;

        public ObservableCollection<Category> Categories
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
