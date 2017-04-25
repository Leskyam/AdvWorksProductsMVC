using System.Linq;
using System.Web.Mvc;
using LINQ101MVC.Models;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using LINQ101MVC.ViewModels;

namespace LINQ101MVC.Controllers
{
    public class ProductSubCategoryController : Controller
    {
        private readonly ApplicationDbContext _db = ApplicationDbContext.Create();

        // GET: ProductSubCategoryViewModel
        public ActionResult Index()
        {
            var subCategories = _db.ProductSubcategories
                .Include(s => s.ProductCategory)
                .Include(s => s.Products)
                .OrderBy(s => s.ProductCategory.Name)
                .ThenBy(s => s.Name);
            return View(subCategories);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int? id)
        {
            var subCategory = new ProductSubcategory();

            if(id.HasValue) subCategory = _db.ProductSubcategories.FirstOrDefault(s => s.ProductSubcategoryID == id);

            if (subCategory == null) return HttpNotFound();

            return View(new ProductSubCategoryViewModel(subCategory));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save([Bind(Prefix = "ProductSubcategory")]ProductSubcategory subCategory)
        {
            if (!ModelState.IsValid) return View("AddOrEdit", new ProductSubCategoryViewModel(subCategory));

            if (subCategory.ProductSubcategoryID != 0)
            {
                var subCategoryInDb =
                    _db.ProductSubcategories.FirstOrDefault(
                        s => s.ProductSubcategoryID == subCategory.ProductSubcategoryID);
                if (subCategoryInDb == null) return HttpNotFound();
                ModelMapper.Map<IProductSubCategory>(subCategory, subCategoryInDb);
            }
            else
            {
                var newSubCategory = new ProductSubcategory();
                ModelMapper.Map<IProductSubCategory>(subCategory, newSubCategory);
                _db.ProductSubcategories.Add(newSubCategory);
            }

            await _db.SaveChangesAsync();

            return RedirectToAction("Index");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int? id)
        {
            var subCategory = _db.ProductSubcategories.Include(s => s.Products).FirstOrDefault(s => s.ProductSubcategoryID == id);

            if (subCategory == null) return HttpNotFound();

            if (subCategory.Products.Count > 0) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            _db.ProductSubcategories.Remove(subCategory);

            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _db?.Dispose();
        }

    }
}