using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NVVM_InternetMarket.Model;
using NVVM_InternetMarket.View;

namespace NVVM_InternetMarket.ViewModel
{
    class MainWindowVM : ObservableObject
    {
        public Dictionary<string, object> ViewModels { get; set; }
        private ProductTreeVM productsTree;

        static public MainWindowVM Instance { get; set; } = new MainWindowVM();

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

        public object LeftViewModel { get; set; }


        private MainWindowVM()
        {
            ViewModels = new Dictionary<string, object>();
            productsTree = new ProductTreeVM();
            ViewModels.Add("ProductsTree", productsTree);
            LeftViewModel = ViewModels["ProductsTree"];
        }
    }
}
