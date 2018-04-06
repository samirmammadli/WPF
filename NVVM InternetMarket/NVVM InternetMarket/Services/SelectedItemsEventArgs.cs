using NVVM_InternetMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVVM_InternetMarket.Services
{
    internal delegate void SelectedItemEventHandler(object sender, SelectedItemEventArgs Item);

    internal class SelectedItemEventArgs
    {
        public CategoryItem Category { get; set; }
        public Product Product { get; set; }
    }

}
