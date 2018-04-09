using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NVVM_InternetMarket.Model;
using NVVM_InternetMarket.Services;
using NVVM_InternetMarket.View;

namespace NVVM_InternetMarket.ViewModel
{
    class MainWindowVM : ObservableObject
    {
        public Dictionary<string, object> ViewModels { get; set; }

        private CategoriesVM productsTree;
        private ItemsListVM itemList;
        private MenuVM appMenu;

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

        public object CurrentViewModel { get; set; }

        public object UpperViewModel { get; set; }


        private MainWindowVM()
        {
            productsTree = new CategoriesVM();
            itemList = new ItemsListVM();
            appMenu = new MenuVM();
            ViewModels = new Dictionary<string, object>
            {
                {"ProductsTree", productsTree },
                {"ItemsList", itemList },
                {"AppMenu", appMenu }
            };
            

            LeftViewModel = ViewModels["ProductsTree"];
            CurrentViewModel = ViewModels["ItemsList"];
            UpperViewModel = ViewModels["AppMenu"];

            productsTree.CategorySelected += CategoriesViewModel_CategorySelected;
        }


        private void CategoriesViewModel_CategorySelected(object sender, SelectedItemEventArgs item)
        {
            itemList.LoadProducts(item.Category);
        }
    }
}
