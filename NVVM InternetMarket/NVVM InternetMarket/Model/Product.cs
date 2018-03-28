using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace NVVM_InternetMarket.Model
{

    abstract class Element : ObservableObject
    {
        protected string _name;
        protected ObservableCollection<Element> _subElements;

        public Element()
        {
            SubElements = new ObservableCollection<Element>();
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Element> SubElements
        {
            get { return _subElements; }
            set
            {
                _subElements = value;
                OnPropertyChanged();
            }
        }
    }

    class AllProducts : Element
    {
        public AllProducts()
        {
            Name = "All Products";
        }
    }

    class MobilePhones : Element
    {
        public MobilePhones()
        {
            Name = "Mobile Phones";
        }
    }

    class Electronics : Element
    {
        public Electronics()
        {
            Name = "Electronics";
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


    class Product : Element
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
