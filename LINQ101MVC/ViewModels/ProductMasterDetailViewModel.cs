using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using LINQ101MVC.Models;
using System.Data.Entity;

namespace LINQ101MVC.ViewModels
{
    public class ProductMasterDetailViewModel : IDisposable
    {
        private readonly ApplicationDbContext _db = ApplicationDbContext.Create();

        public SelectList ProductCategories { get; }

        public SelectList ProductSubCategories { get; }

        public IEnumerable<Product> Products { get; set; }

        public ProductMasterDetailViewModel(int? categoryId, int? subCategoryId)
        {
            var subCategories = categoryId.HasValue ?
                _db.ProductSubcategories.Where(s => s.ProductCategoryID == categoryId) :
                _db.ProductSubcategories;

            if (subCategoryId.HasValue)
            {
                Products = _db.Products.Where(p => p.ProductSubcategoryID == subCategoryId).Include(p => p.SalesOrderDetails);
            } else {
                if (subCategories.Any() && categoryId.HasValue)
                {
                    Products = (from p in _db.Products
                               from s in subCategories
                               where p.ProductSubcategoryID == s.ProductSubcategoryID
                               select p); // Too heavy .Include(p => p.SalesOrderDetails);
                }
                else {
                    Products = _db.Products;
                }
            }

            ProductCategories = new SelectList(_db.ProductCategories, "ProductCategoryID", "Name", categoryId);

            ProductSubCategories = new SelectList(subCategories, "ProductSubcategoryID", "Name", subCategoryId);
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }

}