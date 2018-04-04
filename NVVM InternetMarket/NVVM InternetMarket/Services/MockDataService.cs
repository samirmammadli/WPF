using NVVM_InternetMarket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVVM_InternetMarket.Services
{
    class MockDataService
    {
        private List<CategoryItem> categories;
        public MockDataService()
        {
            categories = new List<CategoryItem>();

            //Base Categories
            categories.Add(new Category("Electronics"));
            categories.Add(new Category("Motors"));
            categories.Add(new Category("Musical Instruments"));

            //Electronics Categories
            categories.Add(new FinalCategory("Computers and Tablets", categories[0]));
            categories.Add(new FinalCategory("Cameras and Photo", categories[0]));
            categories.Add(new FinalCategory("Tv and Audio", categories[0]));
            categories.Add(new FinalCategory("Cell Phones", categories[0]));

            //Motors Categories
            categories.Add(new FinalCategory("Parts and accessories", categories[1]));
            categories.Add(new FinalCategory("Cars and Trucks", categories[1]));
            categories.Add(new FinalCategory("Motorcycles", categories[1]));

            //Musical Instruments
            categories.Add(new FinalCategory("Guitar", categories[2]));
            categories.Add(new FinalCategory("Pro audio equipment", categories[2]));
            categories.Add(new FinalCategory("String", categories[2]));
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
