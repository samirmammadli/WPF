using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NVVM_InternetMarket.Model;
using NVVM_InternetMarket.Services;

namespace NVVM_InternetMarket.ViewModel
{
    class CategoriesVM : ObservableObject
    {

        public CategoriesVM()
        {
            Categories = new ObservableCollection<CategoryItem>(MockDataService.Instance.GetCategories());
        }

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

        private CategoryItem currentCategory;

        public CategoryItem CurrentCategory
        {
            get { return currentCategory; }
            set { currentCategory = value; }
        }

        public event SelectedItemEventHandler CategorySelected;
        private void OnCategorySelected()
        {
            CategorySelected?.Invoke(this, new SelectedItemEventArgs { Category = CurrentCategory });
        }

        //Commands
        private RelayCommand selectItemCommand;
        public RelayCommand SelectItemCommand
        {
            get
            {
                return selectItemCommand ?? (selectItemCommand = new RelayCommand(
                    param =>
                    {
                        CurrentCategory = param as CategoryItem;
                        //AppViewModel.Instance.Navigate("ItemsList");
                        OnCategorySelected();
                    }
                ));
            }
        }
    }
}
