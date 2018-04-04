using NVVM_InternetMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVVM_InternetMarket.Services
{
    interface IDataService
    {
        IEnumerable<CategoryItem> GetCategories();
        IEnumerable<Product> GetProducts(CategoryItem category);

        //void AddCategory(BaseCategory category);
        //void AddProduct(Product product);
    }
}
