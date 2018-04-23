using NVVM_InternetMarket.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVVM_InternetMarket.Services
{
    class MockDataService : IDataService
    {
        private List<CategoryItem> categories;
        private List<Product> products;
        public static MockDataService Instance { get; set; } = new MockDataService();
        private MockDataService()
        {
            categories = new List<CategoryItem>();
            products = new List<Product>();

            #region Categories
            //Base Categories
            categories.Add(new Category("Electronics"));
            categories.Add(new Category("Motors"));
            categories.Add(new Category("Musical Instruments"));

            
            //Electronics Categories
            categories.Add(new Category("Computers and Tablets", categories[0]));
            categories.Add(new Category("Cameras and Photo", categories[0]));
            categories.Add(new Category("Tv and Audio", categories[0]));
            categories.Add(new Category("Cell Phones", categories[0]));

            //Cell Phones Categories
            categories.Add(new FinalCategory("Samsung", categories[6]));
            categories.Add(new FinalCategory("Apple", categories[6]));
            categories.Add(new FinalCategory("LG", categories[6]));
            categories.Add(new FinalCategory("Xiaomi", categories[6]));



            //Motors Categories
            categories.Add(new FinalCategory("Parts and accessories", categories[1]));
            categories.Add(new FinalCategory("Cars and Trucks", categories[1]));
            categories.Add(new FinalCategory("Motorcycles", categories[1]));

            //Musical Instruments
            categories.Add(new FinalCategory("Guitar", categories[2]));
            categories.Add(new FinalCategory("Pro audio equipment", categories[2]));
            categories.Add(new FinalCategory("String", categories[2]));
            #endregion

            #region Products
            //Samsung
            products.Add(new Product("Galaxy S8", "Samsung") {Price = 2000, Category = categories[7], ImagePath = "samsung_galaxy_s8.png" });
            products.Add(new Product("Galaxy Note 9", "Samsung") { Price = 2200, Category = categories[7], ImagePath = "samsung_galaxy_note9.png" });
            //Apple
            products.Add(new Product("Iphone 8", "Apple") { Price = 1800, Category = categories[8] });
            products.Add(new Product("Iphone X", "Apple") { Price = 2100, Category = categories[8] });
            #endregion
        }

        public IEnumerable<Product> GetProducts(CategoryItem category)
        {
            return products.Where(x => x.Category == category);
        }

        public IEnumerable<CategoryItem> GetCategories()
        {
            var composite = categories.Where(x => x.Parent == null);
            foreach (var item in composite)
            {
                FindChildren(item);
            }
            return composite;
        }

        public void FindChildren(CategoryItem category)
        {
            var subcategories = categories.Where(x => x.Parent == category);
            foreach (var item in subcategories)
            {
                category.AddItem(item);
                FindChildren(item);
            }
        }
    }
}
