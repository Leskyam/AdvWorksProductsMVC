using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using LINQ101MVC.Models;
using LINQ101MVC.ViewModels;
using System.Data.Entity;

namespace LINQ101MVC.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly ApplicationDbContext _db = ApplicationDbContext.Create();
        // GET: ProductCategory
        public ActionResult Index()
        {
            var categories = _db.ProductCategories.OrderBy(c => c.Name);
            return View(categories);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int? id)
        {
            var productCategory = new ProductCategory();
           
            if(id.HasValue) productCategory = _db.ProductCategories.FirstOrDefault(c => c.ProductCategoryID == id);

            if (productCategory == null) return HttpNotFound();
            
            return View(productCategory);
        }

        //TODO: Check for to avoid "overposting" here.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(ProductCategory category)
        {
            if (!ModelState.IsValid) return View("AddOrEdit", category);

            if (category.ProductCategoryID != 0) // Editing existing Category.
            {
                var categoryInDb =
                    _db.ProductCategories.FirstOrDefault(c => c.ProductCategoryID == category.ProductCategoryID);

                if (categoryInDb == null) return HttpNotFound();
                ModelMapper.Map<IProductCategory>(category, categoryInDb);
            }
            else // New Category
            {
                var newCategory = new ProductCategory();
                ModelMapper.Map<IProductCategory>(category, newCategory);
                _db.ProductCategories.Add(category);
            }

            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int? id)
        {
            var productCategory = _db.ProductCategories.Include(c => c.ProductSubcategories).FirstOrDefault(c => c.ProductCategoryID == id);

            if (productCategory == null) return HttpNotFound();

            if(productCategory.ProductSubcategories.Count>0) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            _db.ProductCategories.Remove(productCategory);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _db?.Dispose();
        }
    }
}