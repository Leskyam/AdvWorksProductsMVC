using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LINQ101MVC.Models;

namespace LINQ101MVC.ViewModels
{
    public class ProductSubCategoryViewModel : IDisposable
    {
        private readonly ApplicationDbContext _db = ApplicationDbContext.Create();

        public ProductSubcategory ProductSubcategory { get;}
        public IEnumerable<ProductCategory> ProductCategories { get;}

        public ProductSubCategoryViewModel(ProductSubcategory subCategory)
        {
            ProductSubcategory = subCategory;
            ProductCategories = _db.ProductCategories;
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}