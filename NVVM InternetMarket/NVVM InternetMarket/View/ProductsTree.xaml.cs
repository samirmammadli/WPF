﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NVVM_InternetMarket;

namespace NVVM_InternetMarket.View
{
    /// <summary>
    /// Interaction logic for ProductsTree.xaml
    /// </summary>
    public partial class ProductsTree : UserControl
    {
        public ProductsTree()
        {
            InitializeComponent();

            var model = new ViewModel.ViewModel();

            viewsTreeView.ItemsSource = model.Categories;
        }
    }
}
