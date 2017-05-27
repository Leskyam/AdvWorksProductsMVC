using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using LINQ101MVC.Models;
using LINQ101MVC.ViewModels;

namespace LINQ101MVC.Controllers
{
    public class ProductController : Controller
    {

        private readonly ApplicationDbContext _db = ApplicationDbContext.Create();

        // GET: Product
        public ActionResult Index(int? categoryId, int? subCategoryId)
        {
            return View(new ProductMasterDetailViewModel(categoryId, subCategoryId));
        }

        public ActionResult AddOrEdit(int? id)
        {
            var product = id.HasValue ?
                _db.Products.SingleOrDefault(p => p.ProductID == id) :
                new Product();

            if (product == null) return HttpNotFound();

            return View(new ProductViewModel(product));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Product product)
        {
            return RedirectToAction("Index", new RouteValueDictionary(){{"subCategoryId", product.ProductSubcategoryID}} );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            // Todo: remember to redirect to the Index according to the subcategory value of the product.
            return Content("Delete option coming soon!");
        }

        [HttpGet]
        public ActionResult Delete()
        {
            return Content("Not implemented yet.");
        }

        protected override void Dispose(bool disposing)
        {
            _db?.Dispose();
        }

    }
}