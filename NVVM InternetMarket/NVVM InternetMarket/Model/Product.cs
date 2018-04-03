using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace NVVM_InternetMarket.Model
{

    abstract class CategoryItems : ObservableObject
    {
        protected string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public CategoryItems(string name)
        {
            Name = name;
        }

        public virtual void AddItem(string key, CategoryItems item) { throw new NotImplementedException(); }
        public virtual void Delete(string key, CategoryItems item) { throw new NotImplementedException(); }
    }


    class Category : CategoryItems
    {

        private Dictionary<string, CategoryItems> _subCategories;

        public Category(string name) : base (name)
        {
            SubCategories = new Dictionary<string, CategoryItems>();
        }

        public Dictionary<string, CategoryItems> SubCategories
        {
            get { return _subCategories; }
            set
            {
                _subCategories = value;
                OnPropertyChanged();
            }
        }

        public override void AddItem(string key, CategoryItems item)
        {
            
        }
    }

    class FinalCategory : CategoryItems
    {

        private ObservableCollection<Product> _products;

        public FinalCategory()
        {
            Products = new ObservableCollection<Product>();
        }

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged();
            }
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


    class Product : ObservableObject
    {
        
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
}
