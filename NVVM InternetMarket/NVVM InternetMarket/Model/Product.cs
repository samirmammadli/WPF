using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace NVVM_InternetMarket.Model
{
    interface ICategory
    {
        string CategoryName { get; set; }
        ObservableDictionary<string, ObservableCollection<Product>> Products { get; set; }
        void AddProduct(Product product);
    }

    class Electronics : ICategory
    {
        public string CategoryName { get; set; }
        public ObservableDictionary<string, ObservableCollection<Product>> Products { get; set; }

        public void AddProduct(Product product)
        {
            if (Products.ContainsKey(product.ToString()))
            {
                Products[product.ToString()].Add(product);
            }
            else
            {
                Products.Add(product.ToString(), new ObservableCollection<Product>());
                Products[product.ToString()].Add(product);
            }
                
        }

        public Electronics()
        {
            CategoryName = "Electronics";
            Products = new ObservableDictionary<string, ObservableCollection<Product>>();
        }

        public override string ToString()
        {
            return CategoryName;
        }
    }

    #region Test
    //abstract class ProductDescription
    //{
    //    public Dictionary<string, string> Descriptions { get; set; }
    //    public ProductDescription()
    //    {
    //        Descriptions = new Dictionary<string, string>();
    //    }
    //}

    //class ElectronicDescription : ProductDescription
    //{
    //    public ElectronicDescription()
    //    {
    //        Descriptions.Add("", "");
    //        Descriptions.Add("", "");
    //        Descriptions.Add("", "");
    //        Descriptions.Add("", "");
    //        Descriptions.Add("", "");
    //        Descriptions.Add("", "");
    //    }
    //}
    #endregion


    abstract class Product : ObservableObject
    {
        protected string _name;
        protected string _brandName;
        protected double _price;
        protected string _imagePath;

        public string ImagePath
        {
            get { return _imagePath; }
            set
            {
                _imagePath = value;
                OnPropertyChanged();
            }
        }

        public virtual Dictionary<string, string> Description { get; set; }


        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string BrandName
        {
            get { return _brandName; }
            set
            {
                _brandName = value;
                OnPropertyChanged();
            }
        }

        public double Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged();
            }
        }
    }

    class MobilePhone : Product
    {
        public override string ToString()
        {
            return "Mobile Phone";
        }
    }

}
