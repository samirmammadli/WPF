using NVVM_InternetMarket.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NVVM_InternetMarket.ViewModel
{
    enum Currency
    {
        AZN,
        USD,
        EUR
    }

    class test
    {
        public string Name { get; set; }
        //public override string ToString()
        //{
        //    return cur;
        //}
    }

    class MenuVM
    {
        public ObservableCollection<test> curr { get; set; }

        public MenuVM()
        {
            curr = new ObservableCollection<test> { new test { Name = "AZN" }, new test { Name = "USD" }, new test { Name = "EUR" } };
        }

       

        private RelayCommand exitProgram;
        public RelayCommand ExitProgram
        {
            get
            {
                return exitProgram ?? (exitProgram = new RelayCommand(
                    param =>
                    {
                        System.Windows.Application.Current.Shutdown();
                    }
                ));
            }
        }
    }
}
