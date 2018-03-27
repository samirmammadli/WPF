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
            Categories = new ObservableCollection<ICategory> { new Electronics() };
            Categories.FirstOrDefault().AddProduct(new MobilePhone());
        }


        private ObservableCollection<ICategory> _categories;

        public ObservableCollection<ICategory> Categories
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
