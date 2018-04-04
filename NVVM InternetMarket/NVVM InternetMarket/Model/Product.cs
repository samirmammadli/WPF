using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace NVVM_InternetMarket.Model
{

    public abstract class CategoryItem : ObservableObject
    {
        
        protected CategoryItem _parent;
        public CategoryItem Parent
        {
            get { return _parent; }
            set
            {
                _parent = value;
                OnPropertyChanged();
            }
        }
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

        public CategoryItem(string name, CategoryItem parent = null)
        {
            Name = name;
            Parent = parent;
        }

        public virtual void AddItem(CategoryItem item) { throw new NotImplementedException(); }
        public virtual void Delete(CategoryItem item) { throw new NotImplementedException(); }
    }


    class Category : CategoryItem
    {

        private ObservableCollection<CategoryItem> _subCategories;

        public Category(string name, CategoryItem parent = null) : base (name, parent)
        {
            SubCategories = new ObservableCollection<CategoryItem>();
        }

        public ObservableCollection<CategoryItem> SubCategories
        {
            get { return _subCategories; }
            set
            {
                _subCategories = value;
                OnPropertyChanged();
            }
        }

        public override void AddItem(CategoryItem item)
        {
            SubCategories.Add(item);
        }

        public override void Delete(CategoryItem item)
        {
            SubCategories.Remove(item);
        }
    }

    class FinalCategory : CategoryItem
    {
        private ObservableCollection<Product> _products;
        public FinalCategory(string name, CategoryItem parent = null) : base(name, parent)
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
        public Dictionary<string, string> Description { get; set; }
        private CategoryItem category;
        public CategoryItem Category
        {
            get { return category; }
            set { category = value; OnPropertyChanged(); }
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
}
