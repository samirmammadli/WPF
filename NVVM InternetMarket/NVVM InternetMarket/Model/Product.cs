﻿using System;
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
        ObservableCollection<Product> Products { get; set; }
    }

    abstract class ProductDescription
    {
        public Dictionary<string, string> Descriptions { get; set; }
        public ProductDescription()
        {
            Descriptions = new Dictionary<string, string>();
        }
    }

    class ElectronicDescription : ProductDescription
    {
        public ElectronicDescription()
        {
            Descriptions.Add("", "");
            Descriptions.Add("", "");
            Descriptions.Add("", "");
            Descriptions.Add("", "");
            Descriptions.Add("", "");
            Descriptions.Add("", "");
        }
    }

    abstract class Product : ObservableObject
    {
        protected string _name;
        protected string _brandName;
        protected double _price;

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

    }

}
