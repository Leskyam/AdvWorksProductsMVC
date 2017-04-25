using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LINQ101MVC.Models;

namespace LINQ101MVC.ViewModels
{
    public class ProductViewModel : IDisposable
    {
        private readonly ApplicationDbContext _db = ApplicationDbContext.Create();

        public IEnumerable<ProductCategory> ProductCategories { get; }

        public IEnumerable<ProductSubcategory> ProductSubcategories { get; }

        public Product Product { get; set; }
        
        public ProductViewModel(Product product)
        {
            ProductCategories = _db.ProductCategories;
            ProductSubcategories = _db.ProductSubcategories;
            Product = product;
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}